using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject NavBall;
    private UnityEngine.AI.NavMeshAgent agent;
    public float attackRange = 15f;
    public float currentSpeed = 0.0f;
    public float chaseSpeed = 5.0f;
    public float nearSpeed = 3.0f;
    public Transform tankTransform;
    public GameObject TankBase;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = true;
        agent.ResetPath();
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

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(NavBall.transform.position);

        TankBase.transform.LookAt(NavBall.transform.position);
    }
}
