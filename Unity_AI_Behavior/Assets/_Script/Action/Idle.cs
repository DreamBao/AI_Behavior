using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AIBehavior.BaseNode;
namespace AIBehavior.BaseNode
{
    public class Idle : Action
    {
        public override void OnStart()
        {
            base.OnStart();
            Debug.Log("Idle Start");
        }

        public override BNodeStatus OnExecute()
        {
            Debug.Log("OnExecute Idle");
            return BNodeStatus.Active;
        }
    }
}
