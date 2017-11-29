using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConfig {
    public uint ID;
    public string nodeName;

    public static Dictionary<uint, BaseConfig> BaseConfigDic = new Dictionary<uint, BaseConfig>();
    public static Dictionary<uint, BaseConfig> LoadData(string Path)
    {
        BaseConfigDic.Clear();
        TextAsset txtAsset = Resources.Load<TextAsset>(Path);
        List<object> obj = MiniJSON.Json.Deserialize(txtAsset.text) as List<object>;
        for(int i = 0;i < obj.Count; i++)
        {
            BaseConfig bc = new BaseConfig();
            Dictionary<string, object> dic = obj[i] as Dictionary<string, object>;
            bc.ID = uint.Parse(dic["id"].ToString());
            bc.nodeName = dic["NodeName"].ToString();

            if (!BaseConfigDic.ContainsKey(bc.ID))
                BaseConfigDic.Add(bc.ID, bc);
            else
                BaseConfigDic[bc.ID] = bc;
        }
        Debug.Log(txtAsset.text);
        return BaseConfigDic;
    }
}


