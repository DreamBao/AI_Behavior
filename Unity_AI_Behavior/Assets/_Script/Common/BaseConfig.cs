using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConfig {
    public int ID;
    public string nodeName;


    public static bool LoadData(string Path)
    {
        TextAsset txtAsset = Resources.Load<TextAsset>(Path);
        Debug.Log("txt : " + txtAsset.text);

        return true;
    }
}


