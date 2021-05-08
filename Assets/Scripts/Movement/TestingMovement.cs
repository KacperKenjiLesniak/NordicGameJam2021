using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMovement : MonoBehaviour
{

    [SerializeField] private string upKey, leftKey, rightKey, weaponKey, interactKey, boostKey;
    [SerializeField] private float speed, jumpingSpeed,boostSpeed;
    [SerializeField] private int mines, boosts;
    [SerializeField] GameObject mine;
    private Rigidbody2D playerRB;
    private float movementTimer, lastMovementTime, timeLeftBoost;
    private bool isMoving, left;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            Jump();
        }

        if (Input.GetKeyDown(leftKey))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(rightKey))
        {
            MoveRight();
        }

        if (Input.GetKeyUp(leftKey))
        {
            StopMovement();
        }

        if (Input.GetKeyUp(rightKey))
        {
            StopMovement();
        }

        if (Input.GetKeyDown(weaponKey))
        {
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

        if (isMoving)
        {
            if (Mathf.Abs(playerRB.velocity.x) > speed)
            {
                Move(Mathf.Abs(playerRB.velocity.x));
            }
            else
            {
                Move(speed);
            }
            movementTimer += Time.deltaTime;
            
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
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpingSpeed);
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
