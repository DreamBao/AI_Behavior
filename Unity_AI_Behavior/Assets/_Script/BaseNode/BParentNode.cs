using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior.BaseNode
{
    public abstract class BParentNode : BNode
    {
        public List<BNode> CBNodes
        {
            get
            {
                return this.cBNodes;
            }
            private set
            {
                this.cBNodes = value;
            }
        }

        public int ChildCount
        {
            get
            {
                return cBNodes.Count;
            }
        }

        protected List<BNode> cBNodes; //children

        protected BParentNode()
        {
            cBNodes = new List<BNode>();
        }

        public void AddChildNode(BNode child)
        {
            cBNodes.Add(child);
        }

        public void AddChildNode(BNode child, int index) 
        {
            cBNodes.Insert(index, child);
        }



        public virtual bool CanExecute() { return true; }

        protected virtual BNodeStatus DoChildExecute()
        {
            return BNodeStatus.Inactive;
        }

        public virtual int GetCurrentChildIndex() { return -1; }
    }
}
