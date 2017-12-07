using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;
using System.Reflection;

public class JsonDataHandle {
    
    public static string SerializeData(AIBaseBehavior behavior, RootNode root)
    {
        Dictionary<string, object> rootDic = new Dictionary<string, object>();
        rootDic.Add("Name", "root");
        rootDic.Add("Root", JsonDataHandle.SerializeNodeData(behavior.aiSource.rootNode, true));
        string jsonStr = MiniJSON.Json.Serialize(rootDic);
        return jsonStr;
    }

    public static Dictionary<string,object> SerializeNodeData(BNode node, bool isSerializeChild)
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();
        Debug.Log("ser " + node.Name);
        dic.Add("ID", node.ID);
        dic.Add("Name", node.Name);
        if (node.Disabled)
            dic.Add("Disabled", node.Disabled);
        if(isSerializeChild && node is BParentNode)
        {
            BParentNode parentNode = node as BParentNode;
            if(parentNode.CBNodes != null && parentNode.ChildCount > 0)
            {
                Dictionary<string, object>[] arr = new Dictionary<string, object>[parentNode.ChildCount];
                for(int i = 0; i < parentNode.ChildCount; i ++)
                {
                    arr[i] = JsonDataHandle.SerializeNodeData(parentNode.CBNodes[i], isSerializeChild);
                }
                dic.Add("Child", arr);
            }
        }
        return dic;
    }

    public static void LoadSerializeData(AIBaseBehavior behavior, string json)
    {
        Debug.Log("Json : " + json);
        Dictionary<string, object> dic = MiniJSON.Json.Deserialize(json) as Dictionary<string, object>;
        Dictionary<string, object> dic2 = dic["Root"] as Dictionary<string, object>;
        RootNode root = new RootNode();
        root.ID = int.Parse(dic2["ID"].ToString());
        root.Name = dic2["Name"].ToString();

        List<object> list = dic2["Child"] as List<object>;
        if(list == null)
        {
            Debug.Log("arr is null");
        }
        if(list.Count > 0)
        {
            root.SetStartNode(LoadSerializeNodeData(list[0] as Dictionary<string, object>));
            behavior.aiSource.rootNode = root;
        }
        else
        {
            Debug.Log("The Root haven't child");
        }

    }

    public static BNode LoadSerializeNodeData(Dictionary<string, object> nodeDic)
    {
        string name = nodeDic["Name"].ToString();
        int id = int.Parse(nodeDic["ID"].ToString());
        Assembly assembly = Assembly.GetExecutingAssembly();
        BNode bNode = assembly.CreateInstance(Constant.Name_SPACE + name) as BNode;
        bNode.ID = id;
        bNode.Name = name;
        if(bNode is BParentNode)
        {
            BParentNode parentNode = bNode as BParentNode;
            
            List<object> list = nodeDic["Child"] as List<object>;
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    parentNode.AddChildNode(LoadSerializeNodeData(list[i] as Dictionary<string, object>));
                }
            }
        }
        return bNode;
    }

}
