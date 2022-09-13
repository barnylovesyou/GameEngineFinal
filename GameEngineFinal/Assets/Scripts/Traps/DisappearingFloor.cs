using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingFloor :Trap
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Active()
    {
        gameObject.SetActive(false);
    }
    public override void Respawn()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Active();
        }
    }
}
