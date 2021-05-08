using System.Collections;
using System.Collections.Generic;
using Recorder;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float radius, speed;
    [SerializeField] private bool isMoving, isHorizontal, isCenterrd;
    public Countdown countdown;
    private bool firstTime;
    private Vector3 startPos, endPos, resetPos;
    // Start is called before the first frame update
    void Start()
    {
        countdown = FindObjectOfType<Countdown>();
        resetPos = transform.position;
        firstTime = true;
        startPos = new Vector3(transform.position.x, transform.position.y);
        if (isCenterrd == false)
        {
            if (isHorizontal)
            {
                setMovement(radius, 0);
            }

            else
            {
                setMovement(0, radius);
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

        resetPosition();
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


    void resetPosition()
    {
        if (countdown.recordingState == RecordingState.BREAK)
        {
            transform.position = resetPos;
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    void setMovement(float x, float y)
    {
        endPos = new Vector3(transform.position.x + x, transform.position.y + y);
    }
}
