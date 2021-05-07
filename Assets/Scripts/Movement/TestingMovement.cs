using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMovement : MonoBehaviour
{

    [SerializeField] private string upKey, leftKey, rightKey, weaponKey, interactKey, boostKey;
    [SerializeField] private float speed, jumpingSpeed;
    private Rigidbody2D playerRB;
    private float movementTimer, lastMovementTime;
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
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpingSpeed);
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
