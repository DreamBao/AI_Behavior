using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;
using System.Reflection;

public class AIBaseBehavior : MonoBehaviour {

    public string BehaviorName = "";

    public string BehaviorDescription = "";

    public RootNode root;

    public AIBehaviorEditor AIEditor;

    [SerializeField]
    public ExternAISource source;

    [SerializeField]
    public AISource aiSource;

    // Use this for initialization
    public void Start () {
        root = aiSource.rootNode;
        if (root != null)
        {
            Debug.Log("Root Start");
            OnAIStart();
        }
        else
        {
            Debug.Log("Root is null");
        }
	}

    public BNodeStatus OnAIStart()
    {
        return root.ExecuteBTree();
    }

    [ContextMenu("Open Editor")]
    void OpenAIEditor()
    {
        Debug.Log("Open Editor");
        if (source == null)
        {
            Debug.Log("source is null");
            source = new ExternAISource();
        }
        else
            Debug.Log("source is not null");

        AIEditor = new AIBehaviorEditor();
        AIEditor = AIEditor.InitEditor(this);

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
