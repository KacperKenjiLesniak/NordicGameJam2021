using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float radius, speed;
    [SerializeField] private bool isMoving, isHorizontal, isCenterrd;
    private bool firstTime;
    private Vector3 startPos, endPos;
    // Start is called before the first frame update
    void Start()
    {
        firstTime = true;
        startPos = new Vector3(transform.position.x, transform.position.y);
        if (isCenterrd == false)
        {
            if (isHorizontal)
            {
                setMovement(0, radius);
            }

            else
            {
                setMovement(radius, 0);
            }
        }
        else
        {
            setMovementCenter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (firstTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
                if (transform.position == endPos)
                {
                    firstTime = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
                if (transform.position == startPos)
                {
                    firstTime = true;
                }
            }

        }
    }

    void setMovementCenter()
    {
        if (isHorizontal)
        {
            startPos = new Vector3(transform.position.x + radius, transform.position.y);
            endPos = new Vector3(transform.position.x - radius, transform.position.y);
        }
        else
        {
            startPos = new Vector3(transform.position.x, transform.position.y + radius);
            endPos = new Vector3(transform.position.x, transform.position.y - radius);
        }

    }

    void setMovement(float x, float y)
    {
        endPos = new Vector3(transform.position.x + x, transform.position.y + y);
    }
}
