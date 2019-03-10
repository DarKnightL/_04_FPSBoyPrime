using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 40f;
    [SerializeField]
    private float rotateSpeed = 10f;
    [SerializeField]
    private float jumpSpeed = 2.0f;
    [SerializeField]
    private float groundCheckDistance = 0.2f;

    private bool isGrounded;


    private Animator animator;
    private Rigidbody rigidbody;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        MoveHAndV(h, v);
    }


    private void MoveHAndV(float h, float v)
    {
        if (v > 0)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (v < 0)
        {
            transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
        }
        if (v != 0)
        {
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }


        transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);

    }


    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, groundCheckDistance);
        Jump(isGrounded);
    }


    private void Jump(bool isGrounded)
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            animator.SetBool("isJump", true);
        }
        else if (isGrounded)
        {
            animator.SetBool("isJump", false);
        }

    }

}