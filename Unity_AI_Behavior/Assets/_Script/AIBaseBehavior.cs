using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;

public class exTest : ScriptableObject
{
    [HideInInspector]
    public string text;
    public int num;
}

public class AIBaseBehavior : MonoBehaviour {

    public string BehaviorName = "";

    public string BehaviorDescription = "";

    public RootNode root;

    public AIBehaviorEditor AIEditor;

    // Use this for initialization
    public void Start () {
		
	}

    public BNodeStatus OnAIStart()
    {
        return root.ExecuteBTree();
    }

    [ContextMenu("Open Editor")]
    void OpenAIEditor()
    {
        Debug.Log("Open Editor");
        
        if(AIEditor == null)
        {
            AIEditor = new AIBehaviorEditor();
            AIEditor = AIEditor.InitEditor();
        }
        else
        {
            AIEditor = AIEditor.OpenEditor();
        }

        Dictionary<string, object> dic = new Dictionary<string, object>();
        Dictionary<string, object> dic2 = new Dictionary<string, object>();
        List<Dictionary<string, object>> child = new List<Dictionary<string, object>>();
        Dictionary<string, object> childDic = new Dictionary<string, object>();
        childDic.Add("type", 1);
        childDic.Add("hp", 50);
        child.Add(childDic);
        dic2.Add("child", child);
        dic.Add("name", "AI");
        dic.Add("root", dic2);
        ParallelNode p = new ParallelNode();
        string txt = MiniJSON.Json.Serialize(dic);
        Debug.Log("json : " + txt);
    }

    //[ContextMenu("Save AI")]
    //void SaveAIStruct()
    //{
       
    //}
}
