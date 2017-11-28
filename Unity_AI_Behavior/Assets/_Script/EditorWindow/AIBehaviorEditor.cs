using UnityEditor;
using UnityEngine;

public class AIBehaviorEditor : EditorWindow {

    public static AIBehaviorEditor Instance;
    public static int GUI_WIDTH = 240;


    public static Texture button;

    private Vector2 mScrollPos = new Vector2(0, 0);

    int windowCount = 2;


    //Composite
    string Paralle_Node = "ParallelNode";
    string Selector_Node = "SelectorNode";
    string Sequence_Node = "SequenceNode";


    bool s1 = false;
    bool s2 = false;
    bool s3 = false;

    [@MenuItem("AI/AIEditor")]
    static void InitEditor()
    {
        InitBinding();
        LoadConfigData();
        AIBehaviorEditor editor = (AIBehaviorEditor)AIBehaviorEditor.GetWindow(typeof(AIBehaviorEditor));

        Instance = editor;
    }


    static void InitBinding()
    {
        button = Resources.Load<Texture>(Constant.TEXTURE_PATH + "Button");
    }

    static void LoadConfigData()
    {
        BaseConfig.LoadData("Config/BaseConfig");
    }

    public Rect windowRect0 = new Rect(20, 20, 120, 50);
    public Rect windowRect = new Rect(100, 100, 200, 200);
    public Rect windowRect2 = new Rect(100, 100, 200, 200);
    public Rect windowRect3 = new Rect(100, 100, 200, 200);
    void OnGUI()
    {
        //----------------------------- MainView -----------------------
        mScrollPos = GUI.BeginScrollView(new Rect(0, 0, position.width - 240, position.height), this.mScrollPos, new Rect(0, 0, this.maxSize.x, this.maxSize.y));
        BeginWindows();

        //GUI.Window(1, new Rect(0, 100, 100, 100), DoMyWindow, "mywindow");
        UpdateNodeGUI();

        EndWindows();
        //GUI.Box(new Rect(0, 0, 100, 100), button);
        //GUI.Box(new Rect(100, 0, 100, 100), "test");
        GUI.EndScrollView();
        //-----------------------------End MainView --------------------
        //-----------------------------Editor Button -------------------
        GUI.BeginGroup(new Rect(position.width - GUI_WIDTH, 0, 300, 1000));
        int x = 0;
        int y = 0;



        if (GUI.Button(new Rect(x, y, 240, 20), Paralle_Node))
        {
            s1 = true;
        }
        y += 20;
        if (GUI.Button(new Rect(x, y, 240, 20), Selector_Node))
        {
            s2 = true;
        }
        y += 20;
        if (GUI.Button(new Rect(x, y, 240, 20), Sequence_Node))
        {
            s3 = true;
        }
        y += 20;

        GUI.EndGroup();
        //windowRect0 = GUI.Window(0, new Rect(0, 1200, 120, 50), DoMyWindow, "My Window");
    }

    void DoMyWindow1(int windowID)
    {
        GUILayout.Button("Hi");
        GUI.DragWindow();
    }

    void DoMyWindow2(int windowID)
    {
        GUILayout.Button("Hi");
        GUI.DragWindow();
    }

    void DoMyWindow3(int windowID)
    {
        GUILayout.Button("Hi");
        GUI.DragWindow();
    }

    void UpdateNodeGUI()
    {   for(int i = 0; i < 3; i++)
        {
            if (i == 0 && s1)
                windowRect = GUI.Window(i, windowRect, DoMyWindow1, Paralle_Node);
            if (i == 1 && s2)
                windowRect2 = GUI.Window(i, windowRect2, DoMyWindow2, Selector_Node);
            if (i == 2 && s3)
                windowRect3 = GUI.Window(i, windowRect3, DoMyWindow3, Sequence_Node);
        }
    }
 
}
