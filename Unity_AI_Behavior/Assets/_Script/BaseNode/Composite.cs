using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AIBehavior.BaseNode
{
    public abstract class Composite : BParentNode {

        protected BNode currentBNode;
        protected AbortType abortType;
        protected Composite()
        {

        }

        public AbortType AbortType { get { return abortType; } } 
    }
}
