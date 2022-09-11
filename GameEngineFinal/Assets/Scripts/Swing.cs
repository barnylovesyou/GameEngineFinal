using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float swingVelocity = 15.0f;
    public float swingTimer = 3.0f;
    private float originalTimer;
    // Start is called before the first frame update
    void Start()
    {
        originalTimer = swingTimer;
        swingTimer /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        swingTimer -= Time.deltaTime;
        if (swingTimer <= 0)
        {
            swingVelocity = -swingVelocity;
            swingTimer = originalTimer;
        }
        transform.Rotate(0, 0, swingVelocity * Time.deltaTime);
    }
}
