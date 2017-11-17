using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior.BaseNode
{
    public class SequenceNode : Composite
    {
        private int curChildIndex = 0;
        private BNodeStatus nodeStatus = BNodeStatus.Inactive;

        public override void OnStart()
        {
            base.OnStart();
            Debug.Log("sequence node start");
            curChildIndex = 0;
        }

        public override BNodeStatus OnExecute()
        {
            for (int i = 0; i < cBNodes.Count; i++)
            {
                if (CanExecute())
                {
                    if (DoChildExecute() == BNodeStatus.Failure)
                        return BNodeStatus.Failure;
                }
            }
            return BNodeStatus.Success;
        }

        protected override BNodeStatus DoChildExecute()
        {
            BNodeStatus status = cBNodes[curChildIndex].ProcessLiftCycle();
            curChildIndex++;
            return status;
        }
    }
}
