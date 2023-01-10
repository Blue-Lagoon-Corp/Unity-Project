using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
	public float jumpForce;
	public float runSpeed = 15f;
	private Rigidbody2D rb;

	public Transform groundPos;
	bool isGrounded = false;
	public float checkRadius;
	public LayerMask whatIsGround;

	private float jumpTimeCounter;
	public float jumpTime;
	private bool isJumping;
	private bool doubleJump;
	
	private Animator animator;

	float horizontalMove = 0f;
	bool jump = false;


	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update()
	{
		isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

		if (isGrounded == true && Input.GetKeyDown(KeyCode.Z))
		{
			animator.SetTrigger("isJumping");
			doubleJump = true;
			isJumping = true;
			jumpTimeCounter = jumpTime;
			rb.velocity = Vector2.up * jumpForce;
		}
		if (isGrounded == true)
		{
			animator.SetBool("isJumping", false);
		}
		else
		{
			animator.SetBool("isJumping", true);
		}

		if(Input.GetKey(KeyCode.Z)&& isJumping == true)
        {
			if(jumpTimeCounter > 0)
            {
				rb.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;

            }
			else
            {
				isJumping = false;
            }
        }

		if(Input.GetKeyUp(KeyCode.Z))
        {
			isJumping = false;
        }

		if(isGrounded == false && doubleJump == false && Input.GetKeyDown(KeyCode.Z))
        {
			isJumping = true;
			doubleJump = true;
			isJumping = true;
			jumpTimeCounter = jumpTime;
			rb.velocity = Vector2.up * jumpForce;
		}

		float moveInput = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);

		if(moveInput == 0)
        {
			animator.SetBool("isRunning", false);
        }
        else
        {
			animator.SetBool("isRunning", true);
		}

		if (moveInput < 0)
        {
			transform.eulerAngles = new Vector3(0, 180, 0);
        }

		else if (moveInput > 0)
        {
			transform.eulerAngles = new Vector3(0, 0, 0);
        }
		//if (Input.GetKey(KeyCode.Q))
		//{
		//    horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		//    controller.transform.Translate(horizontalMove * Time.deltaTime, 0, 0);
		//}

		//if (Input.GetKey(KeyCode.D))
		//{
		//    horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		//    controller.transform.Translate(horizontalMove * Time.deltaTime, 0, 0);
		//}

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		transform.Translate(horizontalMove * Time.deltaTime, 0, 0);
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}


	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}



	void FixedUpdate()
	{
		// Move our character

	}

}