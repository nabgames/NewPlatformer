using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileScript : MonoBehaviour {

    public float projectileSpeed = .25f;
    public float hiddenTimer;
    public float secondTimer;
    //public PlayerScript aScript;
    //public GameObject aGameObject;
    public float bulletRange = 30f;

    // Use this for initialization
    void Start () {

        //aScript = aGameObject.GetComponent<PlayerScript>();
        Vector3 move = new Vector3(1.75f, 0.0f, 0.0f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        hiddenTimer++;
        secondTimer = (int) (hiddenTimer / 20);
        if (hiddenTimer > bulletRange)
        {
            Destroy(gameObject);

        }

        Vector3 move = new Vector3(1.75f, 0.0f, 0.0f);

        transform.position = transform.position + move * projectileSpeed;


        }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyTrigger"))
        {
            Destroy(gameObject);
        }
    }
}

