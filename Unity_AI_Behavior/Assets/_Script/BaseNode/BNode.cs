﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior.BaseNode
{
    /// <summary>
    /// BNode - Basic Class
    /// </summary>
    public abstract class BNode
    {

        public bool Disabled { get; set; }
        public int ID { get; set; }

        protected BNode()
        {

        }

        #region lifecycle
        public virtual void OnStart()
        {

        }


        public virtual void OnUpdate()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {

        }

        public virtual void OnRestart()
        {

        }

        public virtual void OnComplete()
        {

        }

        public virtual void OnEnd()
        {

        }
        #endregion

        public virtual BNodeStatus OnExcecute()
        {
            return BNodeStatus.Inactive;
        }

        public virtual void OnPause()
        {

        }
    }
}

