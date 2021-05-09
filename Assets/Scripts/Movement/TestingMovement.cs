using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMovement : MonoBehaviour
{

    [SerializeField] private string upKey, leftKey, rightKey, weaponKey, interactKey, boostKey;
    [SerializeField] private float speed, jumpingSpeed,boostSpeed, distToGround;
    [SerializeField] private int mines, boosts;
    [SerializeField] GameObject mine;
    private InputFeedback inputFeedback;
    private Rigidbody2D playerRB;
    private Animator animator;
    private float movementTimer, lastMovementTime, timeLeftBoost;
    [SerializeField] private bool isMoving, left,isJumping;
    // Start is called before the first frame update
    void Start()
    {
        inputFeedback = GetComponent<InputFeedback>();
        playerRB = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            inputFeedback.ShowFeedback("Jump");
            Jump();
        }

        if (Input.GetKeyDown(leftKey))
        {
            inputFeedback.ShowFeedback("Left");
            MoveLeft();
        }

        if (Input.GetKeyDown(rightKey))
        {
            inputFeedback.ShowFeedback("Right");
            MoveRight();
        }

        if (Input.GetKeyUp(leftKey))
        {
            inputFeedback.ShowFeedback("Stop left");
            StopMovement();
        }

        if (Input.GetKeyUp(rightKey))
        {
            inputFeedback.ShowFeedback("Stop right");
            StopMovement();
        }

        if (Input.GetKeyDown(weaponKey))
        {
            inputFeedback.ShowFeedback("Dropped mine");
            ImplementWeapon();
        }

        if (Input.GetKeyDown(interactKey))
        {
            Interact();
        }

        if (Input.GetKeyDown(boostKey))
        {
            BoostSpeed();
        }

        float v = Mathf.Abs(playerRB.velocity.x);
        animator.SetFloat("Speed", v);
        if (isMoving)
        {
            if (v > speed)
            {
                Move(v);
            }
            else
            {
                Move(speed);
            }

        }
        
    }

    public void StopMovement()
    {
        isMoving = false;
        lastMovementTime = movementTimer;
        movementTimer = 0.0f;
    }

    public void MoveRight()
    {
        left = false;
        isMoving = true;
    }

    public void MoveLeft()
    {
        left = true;
        isMoving = true;
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpingSpeed);
            animator.SetTrigger("Jump");
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Killer")) return false;
        return hit;
    }


    public void Move(float currentSpeed)
    {
        float x = 0.0f;
        if (left)
        {
            x = -1.0f;
        }
        else
        {
            x = 1.0f;
        }
        playerRB.velocity = new Vector2(x * currentSpeed, playerRB.velocity.y);
    }

    public void ImplementWeapon()
    {
        if (mines > 0)
        {
            Instantiate(mine, this.transform.position, Quaternion.identity);
            mines -= 1;
        }
        
        else
        {
            //add empty feedback
        }
    }

    public void Interact()
    {

    }

    public void BoostSpeed()
    {
        if (boosts > 0)
        {
            if (playerRB.velocity.x > 0.0f)
            {
                playerRB.AddForce(Vector2.right * boostSpeed, ForceMode2D.Impulse);
            }
            else if (playerRB.velocity.x < 0.0f)
            {
                playerRB.AddForce(Vector2.left * boostSpeed, ForceMode2D.Impulse); ;
            }
            
            boosts -= 1;
        }

        else
        {
            //add empty feedback
        }
    }
}
