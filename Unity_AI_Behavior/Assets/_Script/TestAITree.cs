using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;
using AIBehavior.BaseNode.ActionNode;
public class TestAITree : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        AIBaseBehavior behavior = this.GetComponent<AIBaseBehavior>();
        behavior.root = new RootNode();
        SequenceNode sequence = new SequenceNode();
        SequenceNode sequence2 = new SequenceNode();
        sequence.AddChildNode(sequence2);

        for (int i = 0; i < 5; i++)
        {
            Idle idle = new Idle();
            sequence2.AddChildNode(idle);
        }
        for (int i = 0; i < 5; i++)
        {
            Idle idle = new Idle();
            sequence.AddChildNode(idle);
        }

        behavior.root.SetStartNode(sequence);
        Debug.Log(behavior.OnAIStart());
    }
}
