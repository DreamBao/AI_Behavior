using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior.BaseNode
{
    [System.Serializable]
    public class RootNode : BParentNode
    {
        protected BNode startNode;

        public RootNode()
        {

        }

        public void SetStartNode(BNode sNode)
        {
            AddChildNode(sNode);
            startNode = sNode;
        }

        public BNodeStatus ExecuteBTree()
        {
            return startNode.ProcessLiftCycle();
        }
    }
}
