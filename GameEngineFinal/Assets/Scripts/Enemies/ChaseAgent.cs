using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    private Vector3 spawnLoc;
    // Start is called before the first frame update
    void Start()
    {
        spawnLoc = this.transform.position;
    }
    public void Respawn()
    {
        this.transform.position = spawnLoc;
    }
    // Update is called once per frame
    void Update()
    {
       agent.SetDestination(player.transform.position);
    }
}
