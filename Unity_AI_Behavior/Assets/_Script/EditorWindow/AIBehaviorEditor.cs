using UnityEditor;
using UnityEngine;

public class AIBehaviorEditor : EditorWindow {

    public static AIBehaviorEditor Instance;
    public static int GUI_WIDTH = 240;

    private Vector2 mScrollPos = new Vector2(0, 0);

    [@MenuItem("AI/AIEditor")]
    static void InitEditor()
    {
        AIBehaviorEditor editor = (AIBehaviorEditor)AIBehaviorEditor.GetWindow(typeof(AIBehaviorEditor));
        
        Instance = editor;
        
    }

    void OnGUI()
    {
        //----------------------------- MainView -----------------------
        mScrollPos = GUI.BeginScrollView(new Rect(0, 0, position.width - 240, position.height), this.mScrollPos, new Rect(0, 0, this.maxSize.x, this.maxSize.y));

        GUI.EndScrollView();
        //-----------------------------End MainView --------------------
        //-----------------------------Editor Button -------------------
        GUI.BeginGroup(new Rect(position.width - GUI_WIDTH, 0, 300, 1000));
        int x = 0;
        int y = 0;

        for(int i = 0; i < 5; i ++)
        {
            if (GUI.Button(new Rect(x, y, 240, 20), "Load"))
            {
            }
            y += 20;
        }

       
        GUI.EndGroup();
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
