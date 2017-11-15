using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AIBehavior.BaseNode
{
    public class Composite : BParentNode {
        protected AbortType abortType;

        protected Composite()
        {

        }

        public AbortType AbortType { get { return abortType; } }
        
    }

}
