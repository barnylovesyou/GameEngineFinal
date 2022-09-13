using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.transform.GetComponent<PlayerMovement>().Respawn();
        }
    }
    //private void OnCollisionrEnter(Collision other)
    //{
    //    if (other.collider.tag == "Player")
    //    {
    //        Player.Respawn();
    //    }
    //    else if(other.collider.tag.Contains("Agent"))
    //    {

    //    }
    //}
}
