using UnityEditor;
using UnityEngine;

public class AIBehaviorEditor : EditorWindow {

    public static AIBehaviorEditor Instance;
    public static int GUI_WIDTH = 240;


    public static Texture button;

    private Vector2 mScrollPos = new Vector2(0, 0);

    [@MenuItem("AI/AIEditor")]
    static void InitEditor()
    {
        InitBinding();
        AIBehaviorEditor editor = (AIBehaviorEditor)AIBehaviorEditor.GetWindow(typeof(AIBehaviorEditor));
        
        Instance = editor;
        
    }


    static void InitBinding()
    {
        button = Resources.Load<Texture>(Constant.TEXTURE_PATH + "Button");
    }

    public Rect windowRect0 = new Rect(20, 20, 120, 50);

    void OnGUI()
    {
        //----------------------------- MainView -----------------------
        mScrollPos = GUI.BeginScrollView(new Rect(0, 0, position.width - 240, position.height), this.mScrollPos, new Rect(0, 0, this.maxSize.x, this.maxSize.y));
        //GUI.Box(new Rect(0, 0, 100, 100), button);
        //GUI.Box(new Rect(100, 0, 100, 100), "test");
        //GUI.Window(0, new Rect(0, 100, 100, 100), MyWindow, "mywindow");
        
        GUI.EndScrollView();
        //-----------------------------End MainView --------------------
        //-----------------------------Editor Button -------------------
        GUI.BeginGroup(new Rect(position.width - GUI_WIDTH, 0, 300, 1000));
        int x = 0;
        int y = 0;
        
        for (int i = 0; i < 5; i ++)
        {
            if (GUI.Button(new Rect(x, y, 240, 20), "Load"))
            {
            }
            y += 20;
        }
        

        GUI.EndGroup();
        //windowRect0 = GUI.Window(0, new Rect(0, 1200, 120, 50), DoMyWindow, "My Window");
    }
    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
            Debug.Log("Got a click in window " + windowID);

        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }

    void Update()
    {
        //Instance = this;
        //if (select != null)
        //{
        //    Repaint();
        //}
    }
}
