using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public GameObject Player;
    public PlayerScript playerScript;
    public float enemyHealth;
    //Change between 1-100 for percent chance of dropping. (Drop could be heal or score or whatever you want.)
    public float enemyDropRate;

    //Change these variables for each enemy to give them the desired movement type. To make it still give it none of the below.
    public string enemyMovementType; //Changes the base movement. Choose: "Slide","Crawl", or "fly"
    public string Temper; //Changes how it reacts toward player. Choose: "Scared","neutral","Mean", or "BloodThirsty"
    public string Scale; //Changes how far it goes from the start position. Choose: "Tiny","Small","Medium","Big", or "Uncontained"
    public float Speed;

    //You don't need to change these. Just drag it to the center of where you want it.
    public float startX;
    public float startY;

    //Don't try to change these variables please! If you want to change specifications beyond the types above, maybe make chagnes to the serperate functions for movement below.

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public bool moveRight;
    public float Attack;
    public float moveBiasX;
    public float moveBiasY;

    // Use this for initialization
    void Start () {
        Attack = 1f;
        moveRight = false;
        startX = transform.position.x;
        startY = transform.position.y;
        playerScript = Player.GetComponent<PlayerScript>();

    }
	
	// Update is called once per frame
	void Update () {

        if (enemyMovementType == "Slide")
        {
            if (Scale == "Tiny")
            {
                Slide(startX - 1f, startX + 1f, Speed, Temper);
            }
            if (Scale == "Small")
            {
                Slide(startX - 2.5f, startX + 2.5f, Speed, Temper);
            }
            if (Scale == "Medium")
            {
                Slide(startX - 4f, startX + 4f, Speed, Temper);
            }
            if (Scale == "Big")
            {
                Slide(startX - 10f, startX + 10f, Speed, Temper);
            }
            if (Scale == "Uncontained")
            {
                Slide(-1000000000000f, 1000000000000f, Speed, Temper);
            }
        }
        if (enemyMovementType == "Crawl")
        {
            if (Scale == "Tiny")
            {
                Crawl(startX - 1f, startX + 1f, Speed, Temper);
            }
            if (Scale == "Small")
            {
                Crawl(startX - 2.5f, startX + 2.5f, Speed, Temper);
            }
            if (Scale == "Medium")
            {
                Crawl(startX - 4f, startX + 4f, Speed, Temper);
            }
            if (Scale == "Big")
            {
                Crawl(startX - 10f, startX + 10f, Speed, Temper);
            }
            if (Scale == "Uncontained")
            {
                Crawl(-1000000000000f, 1000000000000f, Speed, Temper);
            }
        }
        if (enemyMovementType == "Fly")
        {
            if (Scale == "Tiny")
            {
                Fly(startX - 1f, startX + 1f, startY - 0.5f, startY + 0.5f, Speed, Temper);
            }
            if (Scale == "Small")
            {
                Fly(startX - 2.5f, startX + 2.5f, startY - 1.25f, startY + 1.25f, Speed, Temper);
            }
            if (Scale == "Medium")
            {
                Fly(startX - 4f, startX + 4f, startY - 2f, startY + 2f, Speed, Temper);
            }
            if (Scale == "Big")
            {
                Fly(startX - 10f, startX + 10f, startY - 5f, startY + 5f, Speed, Temper);
            }
            if (Scale == "Uncontained")
            {
                Fly(-1000000000f, 10000000f, -1000000000f, 10000000f, Speed, Temper);
            }
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


    //function that makes it slide back and forth
    void Slide (float xMin, float xMax, float Speed, string Temper)
    {

        if (Temper == "Scared")
        {
            //I am using the distance formula to find distance from player to enemy to see if its close.
            if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 4)
            {
                Attack = 0f;
            }
            else
            {
                Attack = 1f;
            }
        }
            if (Temper == "neutral")
            {
                Attack = 1f;
            }
            if (Temper == "Mean")
            {
                //I am using the distance formula to find distance from player to enemy to see if its close.
                if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 5)
                {
                    Attack = 1.5f;
                }
                else
                {
                    Attack = 1f;
                }
            }
            if (Temper == "BloodThirsty")
            {
                //I am using the distance formula to find distance from player to enemy to see if its close.
                if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 7)
                {
                    Attack = 1.5f;
                }
                //I am using the distance formula to find distance from player to enemy to see if its close.
                else if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 3)
                {
                    Attack = 2f;
                }
                else
                {
                    Attack = 1f;
                }
            }
            if (moveRight)
            {
                if (transform.position.x > xMax - Speed * Attack)
                {
                     moveRight = false;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x + Speed * Attack, transform.position.y, 0.0f);
                }
            }
            else
            {
                if (transform.position.x < xMin + Speed * Attack)
                {
                    moveRight = true;
                }
                else
                {
                     transform.position = new Vector3(transform.position.x - Speed * Attack, transform.position.y, 0.0f);
                }
            }
    }




    //function that makes it move somewhat randomly back and forth
    void Crawl(float xMin, float xMax, float Speed, string Temper)
    {
        
        moveBiasX = (transform.position.x - startX) / xMax;
        if (Temper == "Scared")
        {
            //I am using the distance formula to find distance from player to enemy to see if its close.
            if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 4)
            {
                Attack = -1f;
            }
            else
            {
                Attack = 0f;
            }
        }
        if (Temper == "neutral")
        {
            Attack = 0f;
        }
        if (Temper == "Mean")
        {
            //I am using the distance formula to find distance from player to enemy to see if its close.
            if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 5)
            {
                Attack = 1.5f;
            }
            else
            {
                Attack = 0f;
            }
        }
        if (Temper == "BloodThirsty")
        {
            //I am using the distance formula to find distance from player to enemy to see if its close.
            if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 7)
            {
                Attack = 1.5f;
            }
            else
            {
                Attack = 0f;
            }
            //I am using the distance formula to find distance from player to enemy to see if its close.
            if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 3)
            {
                Attack = 2f;
            }

        }
        if (transform.position.x < xMin + Speed)
        {
            transform.position = new Vector3(transform.position.x + Speed, transform.position.y, 0.0f);
        }
        else if (transform.position.x > xMax - Speed)
        {
            transform.position = new Vector3(transform.position.x - Speed, transform.position.y, 0.0f);
        }
        else if (Attack != 0f && Random.Range(0f, 3f) > 2f)
        {
            if (transform.position.x > playerScript.playerX)
            {
                transform.position = new Vector3(transform.position.x - Speed * (Attack * 1.5f), transform.position.y, 0.0f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + Speed * (Attack * 1.5f), transform.position.y, 0.0f);
            }
        }
        else if (Random.Range(0 + moveBiasX, 4f) > 2f)
        {
            transform.position = new Vector3(transform.position.x - Speed, transform.position.y, 0.0f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + Speed, transform.position.y, 0.0f);
        }

    }
   
    
    
    
    //function that makes it fly somewhat randomly around
    void Fly(float xMin, float xMax, float yMin, float yMax, float Speed, string Temper)
    {
        moveBiasX = (transform.position.x - startX) / xMax;
        moveBiasY = (transform.position.y - startY) / yMax;
        if (Temper == "Scared")
        {
            //I am using the distance formula to find distance from player to enemy to see if its close.
            if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 4)
            {
                Attack = -1f;
            }
            else
            {
                Attack = 0f;
            }
        }
        if (Temper == "neutral")
        {
            Attack = 0f;
        }
        if (Temper == "Mean")
        {
            //I am using the distance formula to find distance from player to enemy to see if its close.
            if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 5)
            {
                Attack = 1.5f;
            }
            else
            {
                Attack = 0f;
            }
        }
        if (Temper == "BloodThirsty")
        {
            //I am using the distance formula to find distance from player to enemy to see if its close.
            if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 7)
            {
                Attack = 1.5f;
            }
            else
            {
                Attack = 0f;
            }
            //I am using the distance formula to find distance from player to enemy to see if its close.
            if (Mathf.Sqrt((playerScript.playerX - startX) * (playerScript.playerX - startX) + (playerScript.playerY - startY) * (playerScript.playerY - startY)) < 3)
            {
                Attack = 2f;
            }
        }
        if (transform.position.x < xMin + Speed)
        {
            transform.position = new Vector3(transform.position.x + Speed, transform.position.y, 0.0f);
        }
        else if (transform.position.x > xMax - Speed)
        {
            transform.position = new Vector3(transform.position.x - Speed, transform.position.y, 0.0f);
        }
        else if (transform.position.y < yMin + Speed)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Speed, 0.0f);
        }
        else if (transform.position.y > yMax - Speed)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Speed, 0.0f);
        }
        else if (Attack != 0f && Random.Range(0f, 3f) > 2f)
            
        {
            if (transform.position.x > playerScript.playerX)
            {
                transform.position = new Vector3(transform.position.x - Speed * (Attack * 1.5f), transform.position.y, 0.0f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + Speed * (Attack * 1.5f), transform.position.y, 0.0f);
            }
            if (transform.position.y > playerScript.playerY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - Speed * (Attack * 1.5f), 0.0f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + Speed * (Attack * 1.5f), 0.0f);
            }
        }
        else if (Random.Range(0 + moveBiasX, 4f) > 2f)
        {
            transform.position = new Vector3(transform.position.x - Speed, transform.position.y, 0.0f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + Speed, transform.position.y, 0.0f);
        }
        if (Random.Range(0 + moveBiasY, 4f) > 2f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Speed, 0.0f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Speed, 0.0f);
        }

    }
}

