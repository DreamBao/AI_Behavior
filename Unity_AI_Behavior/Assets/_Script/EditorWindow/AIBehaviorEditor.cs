using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public enum MenuType
{
    Delete,
    Line
}




public class AIBehaviorEditor : EditorWindow {

    public static int GUI_WIDTH = 240;

    public static Texture button;

    private Vector2 mScrollPos = new Vector2(0, 0);

    private Vector2 mousePos;

    static Dictionary<uint, BaseConfig> baseConfigDic;

    //Editor Node Index
    List<EditorNodeInfo> editorNode = new List<EditorNodeInfo>();
    EditorNodeInfo CurSelectNode;
    EditorNodeInfo PreDrawNode;

    private AIBaseBehavior Owner;

    //on-off
    bool DrawLineMode = false;
    bool IsClickedOnNode = false;

    [@MenuItem("AI/AIEditor")]
    public  AIBehaviorEditor InitEditor(AIBaseBehavior behavior = null)
    {
        
        InitBinding();
        LoadConfigData();
        Owner = behavior;
        ExternAISource source = null;
        if (behavior != null)
            source = behavior.source;
            //AssetDatabase.LoadAssetAtPath<ExternAISource>("Assets/ExternAIStruct/AI.asset");
        if (source != null)
        {
            Debug.Log("Count : " + source.editorNode.Count);
            LoadNodeData(source.editorNode);
        }
            
        AIBehaviorEditor editor = (AIBehaviorEditor)AIBehaviorEditor.GetWindow(typeof(AIBehaviorEditor));
        return editor;
    }

    public AIBehaviorEditor OpenEditor(List<EditorNodeInfo> sourceNode = null)
    {

        //ExternAISource source = AssetDatabase.LoadAssetAtPath("Assets/ExternAIStruct/AI.asset", typeof(ExternAISource)) as ExternAISource;
        //sourceNode = source.editorNode;
        
        AIBehaviorEditor editor = (AIBehaviorEditor)AIBehaviorEditor.GetWindow(typeof(AIBehaviorEditor));
        //if (sourceNode != null)
        //    LoadNodeData(sourceNode);
        return editor;
    }

    void InitBinding()
    {
        //button = Resources.Load<Texture>(Constant.TEXTURE_PATH + "Button");
    }

    static void LoadConfigData()
    {
        baseConfigDic = BaseConfig.LoadData("Config/BaseConfig");
    }

    void LoadNodeData(List<EditorNodeInfo> externNode)
    {
        editorNode.AddRange(externNode);
    }

    void OnGUI()
    {
        Event e = Event.current;
        mousePos = e.mousePosition;
        
        if(e.button == 1 && e.isMouse && !DrawLineMode)
        {
            RefreshSelectedWindow();
            CreateWindowMenu(e);
        }
        else if(e.button == 0 && e.isMouse && DrawLineMode)
        {
            RefreshSelectedWindow();

            if(IsClickedOnNode && PreDrawNode != null)
            {
                PreDrawNode.next = CurSelectNode;
            }

            DrawLineMode = false;
            CurSelectNode = null;
            PreDrawNode = null;
        }
        

        //----------------------------- MainView -----------------------
        mScrollPos = GUI.BeginScrollView(new Rect(0, 0, position.width - 240, position.height), this.mScrollPos, new Rect(0, 0, this.maxSize.x, this.maxSize.y));
        BeginWindows();

        UpdateNodeGUI();
 
        if(DrawLineMode && CurSelectNode != null)
        {
            //画线模式画出临时线
            Rect endRect = new Rect(mousePos, new Vector2(10, 10));
            DrawBezier(CurSelectNode.windowRect, endRect);
            Repaint();
        }

        EndWindows();

        GUI.EndScrollView();
        //-----------------------------End MainView --------------------
        //-----------------------------Editor Button -------------------
        GUI.BeginGroup(new Rect(position.width - GUI_WIDTH, 0, 300, 1000));
        int x = 0;
        int y = 0;

        if(baseConfigDic != null)
            foreach(var config in baseConfigDic)
            {
                if(GUI.Button(new Rect(x, y, 240, 20), config.Value.nodeName))
                {
                    EditorNodeInfo eni = new EditorNodeInfo();
                    eni.ID = config.Value.ID;
                    eni.NodeName = config.Value.nodeName;
                    eni.Descript = config.Value.nodeName;
                    editorNode.Add(eni);
                    Owner.source.editorNode = new List<EditorNodeInfo>(editorNode);
                }
                y += 20;
            }


        if (GUI.Button(new Rect(x, y, 240, 20), "Export Extern AI"))
        {
            string selectPath = "ExternAIStruct/";
            string path = EditorUtility.SaveFilePanel("Save Test", selectPath, "Test", "asset");
            if (string.IsNullOrEmpty(path))
            {
                Debug.Log("Save Cancel");
                return;
            }

            //path = path.Substring(Application.dataPath.Length - 6);
            //Debug.Log("CreateAinationPath=" + path);
            //ExternAISource source = ScriptableObject.CreateInstance<ExternAISource>();
            //source.editorNode.AddRange(editorNode);
            //Debug.Log("source Node=" + source.editorNode.Count);
            //AssetDatabase.CreateAsset(source, path);
            //AssetDatabase.ImportAsset(path);
        }
        y += 20;

        GUI.EndGroup();
    }

    void DoMyWindow(int windowID)
    {
        GUILayout.Button("Hi");
        GUI.DragWindow();
    }

    void UpdateNodeGUI()
    {
        for (int i = 0; i < editorNode.Count; i++)
        {
            editorNode[i].windowRect = GUI.Window(i, editorNode[i].windowRect, DoMyWindow, editorNode[i].NodeName);
            if(editorNode[i].next != null)
            {
                DrawBezier(editorNode[i].windowRect, editorNode[i].next.windowRect);
            }
        }
    }

    private void DrawBezier(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x + start.width / 2, start.y + start.height / 2, 0);

        Vector3 endPos = new Vector3(end.x + end.width / 2, end.y + end.height / 2, 0);
        //Debug.Log("startPos : " + startPos + " end : " + endPos);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadow = new Color(0, 0, 0, 0.7f);

        for (int i = 0; i < 5; i++)
        {
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadow, null, 1 + (i * 2));
        }

        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
    }


    private void CreateWindowMenu(Event e)
    {
        GenericMenu menu = new GenericMenu();
        if (IsClickedOnNode)
        {
            menu.AddItem(new GUIContent("Delete Node"), false, MenuCallback, MenuType.Delete);
            menu.AddItem(new GUIContent("Draw Line"), false, MenuCallback, MenuType.Line);
            IsClickedOnNode = false;
        }
        else
        {
            menu.AddItem(new GUIContent("Add Node"), false, MenuCallback, "Test");
            //menu.AddItem(new GUIContent("Add Output"), false, MenuCallback, MenuType.Output);
            //menu.AddItem(new GUIContent("Add Cale"), false, MenuCallback, MenuType.Cale);
            //menu.AddItem(new GUIContent("Add Comp"), false, MenuCallback, MenuType.Comp);
        }

        e.Use();
        menu.ShowAsContext();
    }

    private void MenuCallback(object type)
    {
        switch((MenuType)type)
        {
            case MenuType.Delete:
                break;
            case MenuType.Line:
                DrawLineMode = true;
                PreDrawNode = CurSelectNode;
                break;
        }
    }

    private void RefreshSelectedWindow()
    {
        for(int i = 0; i < editorNode.Count; i ++)
        {
            if(editorNode[i].windowRect.Contains(mousePos))
            {
                IsClickedOnNode = true;
                CurSelectNode = editorNode[i];
                break;
            }
            else
            {
                IsClickedOnNode = false;
            }
        }
    }
}
