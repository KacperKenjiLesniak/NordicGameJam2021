using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private float delay = 1f;
    private bool isMoving;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(ExecuteAfterTime(delay));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        isMoving = true;
    }

    public void ResetObstacle()
    {
        
    }
}
