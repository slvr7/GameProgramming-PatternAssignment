using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRandomMove : MonoBehaviour
{
    public float wanderScope = 15.0f;
    private Transform ballTransform;
    private UnityEngine.AI.NavMeshAgent agent;
    public float currentSpeed = 0.0f;
    public float wanderSpeed = 5f;

    protected bool AgentDone()
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = true;
       // agent.ResetPath();
        ballTransform = transform;
    }

    private void setMaxAgentSpeed(float maxSpeed)
    {
        Vector3 targetVelocity = Vector3.zero;
        if (agent.desiredVelocity.magnitude > maxSpeed)
        {
            targetVelocity = agent.desiredVelocity.normalized * maxSpeed;
        }
        else
        {
            targetVelocity = agent.desiredVelocity;
        }
        agent.velocity = targetVelocity;
        currentSpeed = agent.velocity.magnitude;

    }

    void FixedUpdate()
    {
        if (AgentDone())
        {
            Vector3 randomRange = new Vector3((Random.value - 0.5f) * 2 * wanderScope,
                0, (Random.value - 0.5f) * 2 * wanderScope);
            Vector3 nextDestination = ballTransform.position + randomRange;
            agent.destination = nextDestination;
        }
        //setMaxAgentSpeed(wanderSpeed);

    }

}
