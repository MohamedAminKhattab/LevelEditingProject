using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFollowing : SteerBehavior
{
    [SerializeField]
    PathPoints path;
    [SerializeField]
    float inRange = 2;
    int index = -1;

    Vector3 target;

    protected override void SetDestination()
    {
        target = getpath();
        agent.SetDestination(target);
    }

    Vector3 getpath()
    {
        if (target == null)
        {
            (index, target) = path.GetNearestChild(transform.position);
        }
        else if (Vector3.Distance(transform.position, target) < inRange)
        {
            (index, target) = path.GetNextChild(index);
        }
        return target;
    }
}
