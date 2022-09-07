using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotationSpeed = 90f;
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

        Vector3 velocity = (transform.forward * vertical) + (transform.right * horizontal) * speed;// * Time.fixedDeltaTime;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
        transform.Rotate((transform.up * Input.GetAxis("Mouse X")) * rotationSpeed * Time.fixedDeltaTime);
        if (horizontal == 0)
        {
            rb.angularVelocity = new Vector3(0f, 0f, 0f);
        }
    }

    public void Respawn()
    {
        transform.position = spawnPoint.position;
    }
}
