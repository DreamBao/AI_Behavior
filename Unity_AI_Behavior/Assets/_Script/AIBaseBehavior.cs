using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;
public class AIBaseBehavior : MonoBehaviour {

    public string BehaviorName = "";

    public string BehaviorDescription = "";

    public RootNode root;


	// Use this for initialization
	public void Start () {
		
	}

    public BNodeStatus OnAIStart()
    {
        return root.ExecuteBTree();
    }
}
