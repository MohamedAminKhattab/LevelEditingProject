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
        anim.SetFloat("Speed", agent.velocity.magnitude);
        NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 0, -1);

        if (behaviorEnabled)
        {
            SetDestination();
        }
    }

    protected abstract void SetDestination();
}
