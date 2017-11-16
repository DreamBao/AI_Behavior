using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior.BaseNode
{
    public class RootNode : MonoBehaviour
    {
        protected BNode startNode;

        protected RootNode()
        {

        }

        public void SetStartNode(BNode sNode)
        {
            startNode = sNode;
        }

        public BNodeStatus ExecuteBTree()
        {
            return startNode.OnExecute();
        }
    }
}
