using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior.BaseNode
{
    public abstract class BParentNode : BNode
    {
        protected List<BNode> cBNodes; //children

        protected BParentNode()
        {

        }

        public void AddChildNode(BNode child)
        {
            cBNodes.Add(child);
        }

        public void AddChildNode(BNode child, int index) 
        {
            cBNodes.Insert(index, child);
        }

        public int ChildCount()
        {
            return cBNodes.Count;
        }

        public virtual bool CanExecute() { return true; }

        protected virtual BNodeStatus DoChildExecute()
        {
            return BNodeStatus.Inactive;
        }

        public virtual int GetCurrentChildIndex() { return -1; }

    }
}
