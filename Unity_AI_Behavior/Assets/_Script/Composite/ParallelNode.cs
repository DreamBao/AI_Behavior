﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AIBehavior.BaseNode
{
    public class ParallelNode : Composite
    {
        private int curChildIndex = 0;
        private BNodeStatus nodeStatus = BNodeStatus.Inactive;

        public override void OnStart()
        {
            base.OnStart();
            curChildIndex = 0;
        }

        public override int GetCurrentChildIndex()
        {
            return curChildIndex;
        }

        public override bool CanExecute()
        {
            return curChildIndex < cBNodes.Count && nodeStatus != BNodeStatus.Failure;
        }

        //ParallelNode execute logic
        public override BNodeStatus OnExecute()
        {
            BNodeStatus executeStatus = BNodeStatus.Success;
            for (int i = 0; i < cBNodes.Count; i++)
            {
                if (CanExecute())
                {
                    if (DoChildExecute() == BNodeStatus.Failure)
                        executeStatus = BNodeStatus.Failure;
                }
            }
            return executeStatus;
        }

        protected override BNodeStatus DoChildExecute()
        {
            BNodeStatus status = cBNodes[curChildIndex].OnExecute();
            curChildIndex++;
            return status;
        }




        //public override 
    }
}
