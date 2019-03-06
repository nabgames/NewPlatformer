using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Player;
    public PlayerScript playerScript;
    public float enemyHealth;
    //Change between 1-100 for percent chance of dropping. (Drop could be heal or score or whatever you want.)


    //You don't need to change these. Just drag it to the center of where you want it.
    public float distanceFromPlayer;
    public float swooping = 0f;
    public float targetX;
    public float targetY;
    public float startX;
    public float startY;

    // Use this for initialization
    void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = (Mathf.Sqrt((playerScript.playerX - transform.position.x) * (playerScript.playerX - transform.position.x) + (playerScript.playerY - transform.position.y) * (playerScript.playerY - transform.position.y)));
        if (transform.position.x > playerScript.playerX && transform.position.x < playerScript.playerX + 10f && swooping < 1f)
        {
            swooping = 10f;
            targetX = playerScript.playerX;
            targetY = playerScript.playerY;
            startX = transform.position.x;
            startY = transform.position.y;

        }
        while (swooping > 0)
        {
            transform.position = new Vector3(transform.position.x + (targetX - startX) / 10f, transform.position.y, transform.position.z);
            swooping = swooping - 1f;
        }


        if (enemyHealth < 1)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerStandardBulletTrigger"))
        {
            enemyHealth = enemyHealth - 1;
        }
    }
}
