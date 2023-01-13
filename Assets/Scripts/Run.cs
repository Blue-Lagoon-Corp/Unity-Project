using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
	public float jumpForce;
	public float runSpeed = 100f;
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



	Vector2 moveInput;
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update()
	{
		moveInput.x = Input.GetAxisRaw("Horizontal");
		rb.MovePosition(rb.position + moveInput * runSpeed * Time.fixedDeltaTime);
		animator.SetFloat("Horizontal", moveInput.x);

		animator.SetFloat("Speed", moveInput.sqrMagnitude);

		isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

		if (isGrounded == true && Input.GetKeyDown(KeyCode.Z))
		{
			animator.SetBool("isJumping",true);
			isJumping = true;
			rb.AddForce(new Vector2(0f, jumpForce));
		}
		if (isGrounded == true)
		{
			animator.SetBool("isJumping", false);
		}
		else
		{
			animator.SetBool("isJumping", true);
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



	}


	void FixedUpdate()
	{
		if (isJumping == true)
        {
			rb.AddForce(new Vector2(0f, jumpForce));
			isJumping = false;
		}
		
	}

}