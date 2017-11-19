using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;
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

    public Rect windowRect0 = new Rect(20, 20, 120, 50);
    public Rect windowRect1 = new Rect(20, 100, 120, 50);
    void OnGUI()
    {
        windowRect0 = GUI.Window(0, windowRect0, DoMyWindow, "My Window");
        windowRect1 = GUI.Window(1, windowRect1, DoMyWindow, "My Window");
    }
    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
            print("Got a click in window " + windowID);

        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }

}
