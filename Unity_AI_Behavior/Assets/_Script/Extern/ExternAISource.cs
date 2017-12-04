using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EditorNodeInfo
{
    [SerializeField]
    public uint ID;
    [SerializeField]
    public string NodeName;
    [SerializeField]
    public string Descript;
    [SerializeField]
    public Rect windowRect = new Rect(100, 100, 200, 200);
    [SerializeField]
    public EditorNodeInfo next;
}


[System.Serializable]
public class ExternAISource
{
    [SerializeField]
    public List<EditorNodeInfo> editorNode = new List<EditorNodeInfo>();

    public void SetSourceNode(List<EditorNodeInfo> sourceNode)
    {

        editorNode = sourceNode;
    }

}
