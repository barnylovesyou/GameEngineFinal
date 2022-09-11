using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotationSpeed = 90f;
    public float speedCap;
    public Transform spawnPoint;
    private float horizontal;
    private float vertical;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (rb.velocity.x < speedCap && rb.velocity.z < speedCap)
        {
            rb.velocity = transform.TransformDirection(horizontal * speed, rb.velocity.y, vertical * speed);
        }
        transform.Rotate((transform.up * Input.GetAxis("Mouse X")) * rotationSpeed * Time.fixedDeltaTime);
        if (Input.GetAxis("Mouse X") == 0)
        {
            rb.angularVelocity = new Vector3(0f, 0f, 0f);
        }
    }

    public void Respawn()
    {
        transform.position = spawnPoint.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ice")
        {
            GetComponent<Collider>().material.dynamicFriction = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ice")
        {
            GetComponent<Collider>().material.dynamicFriction = 1;
        }
    }
}
