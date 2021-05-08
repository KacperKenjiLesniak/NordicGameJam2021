using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter2D(Collider2D col)
    {
        obstacle.transform.Translate(0, 4, 0);
        Debug.Log("GameObject1 collided with " + col.name);
    }

}
