using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float speedMultiplier;

    public float speedIncreaseMilestone;

    private float speedMilestoneCount;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private Rigidbody2D playerRigidBody;

    public bool grounded;

    public LayerMask whatIsGround;

    public Transform groundCheck;

    public float groundCheckRadius;

    private Collider2D playerCollider;

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(playerCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            }
          
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(jumpTimeCounter > 0)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpTimeCounter = 0;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        playerAnimator.SetFloat("Speed", playerRigidBody.velocity.x);
        playerAnimator.SetBool("Grounded", grounded);
    }
}
