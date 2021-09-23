using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;

    [SerializeField] Transform orientation;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform Respawn;

    float gdrag = 6f;
    float adrag = 1f;

    public float jumpForce = 10f;

    bool isGrounded;


    float playerheight = 2f;
    float grounddistance = 0.4f;

    float horizontalMovement;
    float verticalMovement;

    public float movemenMultiplier = 10f;
    public float airMultiplier = 0.4f;

    Vector3 movementDirection;
    Vector3 slopeMoveDirection;

    Rigidbody rb;

    RaycastHit slopeHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position,Vector3.down,out slopeHit,playerheight/2 + 0.5f))
        {
            if(slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    void ControlDrag()
    {
       if(isGrounded)
        {
            rb.drag = gdrag;
        }
       else
        {
            rb.drag = adrag;
        }
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, grounddistance, groundMask);
        MyInput();
        ControlDrag();
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }

        slopeMoveDirection = Vector3.ProjectOnPlane(movementDirection, slopeHit.normal); 
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    void MyInput()
    {
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        movementDirection = orientation.transform.forward * verticalMovement + orientation.transform.right * horizontalMovement;
    }

    private void FixedUpdate()
    {
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(movementDirection.normalized * moveSpeed * movemenMultiplier, ForceMode.Acceleration);
        }
        else if(isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movemenMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(movementDirection.normalized * moveSpeed * movemenMultiplier*airMultiplier, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Platform"))
        {
            gameObject.transform.parent = other.transform;
        }
        if(other.CompareTag("Water"))
        {
            gameObject.transform.position = Respawn.position;
        }
        if(other.CompareTag("Finish"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("YouWin");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            gameObject.transform.parent = null;
        }
    }
}
