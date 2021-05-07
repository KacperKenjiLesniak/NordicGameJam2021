using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed, jumpingSpeed, distToGround = 2f;
    private Rigidbody2D playerRB;
    private float movementTimer,lastMovementTime;
    private bool isMoving,left;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            movementTimer += Time.deltaTime;
            Move();
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
        Debug.Log("Jumping!");
        if (IsGrounded())
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x,jumpingSpeed);
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit =  Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        return hit;
    }
    
    public void Move()
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
        playerRB.velocity = new Vector2(x * speed, playerRB.velocity.y);
    }

    public void ImplementWeapon()
    {

    }

    public void Interact()
    {

    }

    public void BoostSpeed()
    {

    }
}
