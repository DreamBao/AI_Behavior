using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIBehavior.BaseNode
{
    /// <summary>
    /// Return status when end
    /// </summary>
    public enum BNodeStatus
    {
        Inactive = 0,
        Success = 1,
        Failure = 2,
        Active = 3,
    }

    /// <summary>
    /// The result as node be aborted
    /// </summary>
    public enum AbortType
    {
        Self,
        Other,
    }

}
