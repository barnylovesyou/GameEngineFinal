using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private RespawnWorld respawnWorld;
    public float speed = 2.0f;
    public float rotationSpeed = 90f;
    public GameObject myCam;
    public float speedCap = 3.0f;
    public float jumpForce = 2.0f;
    public Vector3 spawnPoint;
    public KeyCode jump = KeyCode.Space;
    private float horizontal;
    private float vertical;
    private Rigidbody rb;
    private float yRotation;
    private float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(jump))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotationSpeed;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rotationSpeed;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        myCam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        //if (rb.velocity.x < speedCap && rb.velocity.x > -speedCap && rb.velocity.z < speedCap && rb.velocity.z > -speedCap)
        if (new Vector3 (rb.velocity.x,0, rb.velocity.z).magnitude>speedCap)
        {
             Vector3 cappedVel =new Vector3(rb.velocity.x, 0, rb.velocity.z);
            cappedVel.Normalize();
            cappedVel = cappedVel * speedCap;
            cappedVel += new Vector3(0,rb.velocity.y,0);
            rb.velocity = cappedVel;
        }
        else
        {
            Vector3 force = new Vector3(horizontal, 0, vertical);
            force.Normalize();
            force = force * speed;
            rb.AddRelativeForce(force, ForceMode.Force);
        }
    }

    public void Respawn()
    {
        respawnWorld.Respawn();
        transform.position = spawnPoint;
    }
    
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f, 3|~0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Agent"))
        {
            Respawn();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Agent"))
        {
            Respawn();
        }
    }

}
