using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineShooter : MonoBehaviour
{
    [SerializeField] GameObject mine;

    public void ShootMine()
    {
        Debug.Log(this.transform.position);
        Instantiate(mine, this.transform.position, Quaternion.identity);
    }
}
