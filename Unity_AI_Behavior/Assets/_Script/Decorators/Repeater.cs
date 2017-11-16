using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior.BaseNode
{
    public class Repeater : Decorator
    {
        public int repeatCount = 1;

        public int interval = 0;    //interval time
        public int curCount = 0;    //current repeat time

        public BNodeStatus nodeStatus = BNodeStatus.Inactive;

        public override void OnStart()
        {
            base.OnStart();
            nodeStatus = BNodeStatus.Active;

            nodeStatus = this.OnExecute();
        }

        public override BNodeStatus OnExecute()
        {

            float time = 0;
            if (repeatCount < 0 && repeatCount != -1)
                return BNodeStatus.Failure;

            while (true)
            {
                time += Time.deltaTime;
                if (time > interval)
                {
                    time = 0;
                    if (repeatCount == -1)
                    {

                    }
                    else
                    {
                        curCount++;
                        if(curCount == repeatCount)
                            break;
                    }
                    DoChildExecute();
                }

            }
            return BNodeStatus.Success;
        }

        

        protected override BNodeStatus DoChildExecute()
        {
            //now repeater only support one child
            return cBNodes[0].OnExecute();
        }


    }
}
