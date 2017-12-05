using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;
public class JsonDataHandle {
    
    public static string SerializeData(AIBaseBehavior behavior, RootNode root)
    {

        Dictionary<string, object> main = new Dictionary<string, object>();
        Dictionary<string, object> rootDic = new Dictionary<string, object>();
        rootDic.Add("name", "root");
        rootDic.Add("start", root);
        main.Add("root", rootDic);

        return "";
    }

}
