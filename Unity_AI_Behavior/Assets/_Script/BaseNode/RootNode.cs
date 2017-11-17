using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior.BaseNode
{
    public class RootNode
    {
        protected BNode startNode;

        public RootNode()
        {

        }

        public void SetStartNode(BNode sNode)
        {
            startNode = sNode;
        }

        public BNodeStatus ExecuteBTree()
        {
            return startNode.ProcessLiftCycle();
        }
    }
}
