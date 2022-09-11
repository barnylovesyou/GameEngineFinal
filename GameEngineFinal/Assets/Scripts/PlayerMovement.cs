using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float rotationSpeed = 90f;
    public float speedCap = 3.0f;
    public float jumpForce = 2.0f;
    public Transform spawnPoint;
    public KeyCode jump = KeyCode.Space;
    private float horizontal;
    private float vertical;
    private Rigidbody rb;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetKeyDown(jump))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (rb.velocity.x < speedCap && rb.velocity.x > -speedCap && rb.velocity.z < speedCap && rb.velocity.z > -speedCap)
        {
            rb.AddRelativeForce(new Vector3(horizontal * speed, 0f, vertical * speed), ForceMode.Impulse);
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
        if (collision.collider.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }
}
