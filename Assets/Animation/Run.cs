using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;
	public SpriteRenderer spriteRenderer;

	public float runSpeed = 15f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update()
	{
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
		controller.transform.Translate(horizontalMove * Time.deltaTime, 0, 0);
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		Flip(horizontalMove);

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
	void Flip(float _velocity)
    {
		if(_velocity > 0.1f)
        {
			spriteRenderer.flipX = false;
        }
		else if(_velocity < 0.1f)
        {
			spriteRenderer.flipX = true;
        }
    }
}