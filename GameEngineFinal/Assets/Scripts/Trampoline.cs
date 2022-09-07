using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Collider col;
    public KeyCode stopBouncing = KeyCode.LeftShift;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(stopBouncing))
        {
            col.material.bounciness = 0f;
        }
        else
        {
            col.material.bounciness = 0.95f;
        }
    }
}
