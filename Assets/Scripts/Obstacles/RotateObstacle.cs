using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    public float degreesPerSec = 360f;
    public bool isRotating = true;
    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.localRotation.eulerAngles.z + degreesPerSec * Time.deltaTime));
        }
    }
}

