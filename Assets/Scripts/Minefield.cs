using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minefield : MonoBehaviour
{
    [SerializeField]private bool isActivated, isPlaced;
    private Rigidbody2D player1Rb, player2Rb;
    private GameObject[] mines;
    private Rigidbody2D[] minesRb;
    [SerializeField] private float explosionPower, explosionRadius, uplift;
    [SerializeField] private int Lives;


    // Start is called before the first frame update
    void Start()
    {
        isPlaced = false;
        player1Rb = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>();
        //player2Rb = GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody2D>();
        mines = GameObject.FindGameObjectsWithTag("minebody");
        minesRb = new Rigidbody2D[mines.Length];
        for (int i = 0; i < mines.Length; i++)
        {
            minesRb[i] = mines[i].GetComponent<Rigidbody2D>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player1") || c.CompareTag("Player2"))
        {
            if (isActivated)
            {
                Debug.Log("explosion");
                explode();
            }
        }

    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (isPlaced == false)
        {
            isActivated = true;
            isPlaced = true;
        }

    }

    void explode()
    {
        Vector3 explosionCore = new Vector3(transform.position.x, transform.position.y - 0.5f);
        Rigidbody2DExtension.AddExplosionForce(player1Rb, explosionPower, explosionCore, explosionRadius, uplift);
        //Rigidbody2DExtension.AddExplosionForce(player2Rb, explosionPower, explosionCore, explosionRadius, uplift);
        foreach (Rigidbody2D r in minesRb)
        {
            Rigidbody2DExtension.AddExplosionForce(r, explosionPower, explosionCore, explosionRadius, uplift);
        }
        checkLives();
    }

    void checkLives()
    {
        Lives -= Lives;
        if (Lives == 0)
        {
            killMine();
        }
    }

    void killMine()
    {
        transform.GetComponentInParent<PolygonCollider2D>().enabled = false;
        this.gameObject.SetActive(false);
    }
}
