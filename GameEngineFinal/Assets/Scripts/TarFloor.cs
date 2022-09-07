using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarFloor : MonoBehaviour
{
    public PlayerMovement Player;
    public float speedPenalty;
    private float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = Player.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Player.speed *= speedPenalty;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Player.speed = maxSpeed;
        }
    }
}
