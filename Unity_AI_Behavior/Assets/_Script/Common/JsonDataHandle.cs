using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;
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

}
