using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed, jumpingSpeed, distToGround = 2f,boostSpeed;
    [SerializeField] private int boosts;
    public int mines;
    [SerializeField] GameObject mine;
    private Rigidbody2D playerRB;
    private Animator animator;
    private bool isMoving,left;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (IsGrounded())
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, 1 * Time.deltaTime);
        }
    }

    public void StopMovement()
    {       
        isMoving = false;
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
            Debug.Log("Jumping!");
            playerRB.velocity = new Vector2(playerRB.velocity.x,jumpingSpeed);
            animator.SetTrigger("Jump");
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        if (hit.collider != null && 
            (hit.collider.gameObject.CompareTag("Killer") ||
             hit.collider.gameObject.CompareTag("mine") ||
             hit.collider.gameObject.CompareTag("Player1") ||
             hit.collider.gameObject.CompareTag("Player2"))) return false;
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
