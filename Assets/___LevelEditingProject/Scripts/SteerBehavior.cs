using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class SteerBehavior : MonoBehaviour
{
    [SerializeField]
    bool behaviorEnabled = true;

    protected NavMeshAgent agent;
    protected Animator anim;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        anim.SetFloat("Speed", (float)agent.velocity.magnitude);
        if (behaviorEnabled)
        {
            SetDestination();
        }
    }

    protected abstract void SetDestination();
}
