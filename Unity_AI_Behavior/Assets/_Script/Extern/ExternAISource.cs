using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;

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
