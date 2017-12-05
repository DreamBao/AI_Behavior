using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;

[System.Serializable]
public class AISource {
    [SerializeField]
    public List<BNode> SourceNodes = new List<BNode>();
    [SerializeField]
    public RootNode rootNode;

    public string JsonData;
}
