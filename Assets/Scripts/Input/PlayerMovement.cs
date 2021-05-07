using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private string upKey, leftKey, rightKey, weaponKey, interactKey, boostKey;
    [SerializeField] private float speed, jumpingSpeed;
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
        if (Input.GetKeyDown(upKey))
        {
            Jump();
        }

        if (Input.GetKeyDown(leftKey))
        {
            left = true;
            isMoving = true;         
        }

        if (Input.GetKeyDown(rightKey))
        {
            left = false;
            isMoving = true;
        }

        if(Input.GetKeyUp(leftKey)|| Input.GetKeyUp(rightKey))
        {
            isMoving = false;
            lastMovementTime = movementTimer;
            movementTimer = 0.0f;
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

    void Jump()
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x,jumpingSpeed);
    }

    void Move()
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

    void ImplementWeapon()
    {

    }

    void Interact()
    {

    }

    void BoostSpeed()
    {

    }
}
