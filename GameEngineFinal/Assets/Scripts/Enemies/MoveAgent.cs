using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{
    [SerializeField]private NavMeshAgent agent;
    [SerializeField] private List<Transform>waypoints;
    private Vector3 enemyLoc;
    private Transform enemyTrans;
    private int curWaypoint=0;
    private bool increasing = true;
    private bool patrolling =true;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(waypoints[0].position,waypoints[0].rotation);
    }
    public void Respawn()
    {
        transform.SetPositionAndRotation(waypoints[0].position, waypoints[0].rotation);
        curWaypoint = 0;
        increasing = true;
        patrolling = true;
        enemyTrans = null;
        Debug.Log("MoveRespawn");
    }

    // Update is called once per frame
    void Update()
    {
            if (patrolling)
            {
                Patrol();
            }
            else
            {
                agent.SetDestination(enemyLoc);
                if (Vector3.Distance(transform.position, enemyTrans.position) > 10)
                {
                    HostileLost();
                }
            }
    }
    void Patrol()
    {
        if (agent.remainingDistance <= .2f)
        {
            NextWaypoint();
        }
        agent.SetDestination(waypoints[curWaypoint].position);
    }
    void NextWaypoint()
    {
        if (increasing)
        {
            curWaypoint++;
            if (curWaypoint >waypoints.Count)
            {
                increasing = false;
                curWaypoint--;
                curWaypoint--;
            }
        }
        else
        {
            curWaypoint--;
            if (curWaypoint < 0)
            {
                increasing = true;
                curWaypoint++;
                curWaypoint++;
            }
        }
    }
    public void HostileFound(Transform newEnemyLoc)
    {
        enemyLoc = newEnemyLoc.position;
        enemyTrans = newEnemyLoc;
        patrolling = false;
    }
    public void HostileLost()
    {
        patrolling = true;
    }
}
