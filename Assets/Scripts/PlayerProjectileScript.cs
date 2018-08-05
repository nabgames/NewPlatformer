using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileScript : MonoBehaviour {
    public float mouseX;
    public float mouseY;
    public float playerX;
    public float playerY;
    public float projectileSpeed = .25f;
    public float hiddenTimer;
    public float secondTimer;

    public float bulletRange = 10f;

    // Use this for initialization
    void Start () {
        playerX = transform.position.x;
        playerY = transform.position.y;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        hiddenTimer++;
        secondTimer = (int) (hiddenTimer / 30);
        if (hiddenTimer > bulletRange)
        {
            Destroy(gameObject);
        }
        

        mouseX = (Input.mousePosition.x) - (Screen.width / 2f);
        mouseY = (Input.mousePosition.y) - (Screen.height / 2f);
        if (mouseX > 0)
        {
           

            if (mouseY > 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, ((Mathf.Atan(mouseY / mouseX) / 6.28f) * 360f));

                transform.position = new Vector3(transform.position.x + Mathf.Cos(Mathf.Atan(mouseY / mouseX)) * projectileSpeed, transform.position.y + Mathf.Sin(Mathf.Atan(mouseY / mouseX)) * projectileSpeed, 0f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, ((Mathf.Atan(mouseY / mouseX) / 6.28f) * 360f));

                transform.position = new Vector3(transform.position.x + Mathf.Cos(Mathf.Atan(mouseY / mouseX)) * projectileSpeed, transform.position.y + Mathf.Sin(Mathf.Atan(mouseY / mouseX)) * projectileSpeed, 0f);
            }
            }
        else
        {
                if (mouseY > 0)
                {
                transform.eulerAngles = new Vector3(0f, 0f, ((Mathf.Atan(mouseY / mouseX) / 6.28f) * 360f) + 180f);
                transform.position = new Vector3(transform.position.x + Mathf.Cos(Mathf.Atan(mouseY / mouseX) + 3.14f) * projectileSpeed, transform.position.y + Mathf.Sin(Mathf.Atan(mouseY / mouseX) + 3.14f) * projectileSpeed, 0f);
            }
                else
                {
                transform.eulerAngles = new Vector3(0f, 0f, ((Mathf.Atan(mouseY / mouseX) / 6.28f) * 360f) + 180f);
                transform.position = new Vector3(transform.position.x + Mathf.Cos(Mathf.Atan(mouseY / mouseX) + 3.14f) * projectileSpeed, transform.position.y + Mathf.Sin(Mathf.Atan(mouseY / mouseX) + 3.14f) * projectileSpeed, 0f);
            }
         }
 
        }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyTrigger"))
        {
            Destroy(gameObject);
        }
    }
}

