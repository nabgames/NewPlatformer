using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Rigidbody2D rb;

    public float playerHealth;
    public float jumpSpeed;

    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    public GameObject Projectile;
    public float bulletCoolDown = 0f;
    public float bulletMaxCoolDown;
    public bool bulletOnCoolDown = false;

    public float hiddenTimer;
    public float secondTimer;

    public float playerX;
    public float playerY;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        bulletMaxCoolDown = 25f;
       

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        playerX = transform.position.x;
        playerY = transform.position.y;

        if (playerHealth < 1)
        {
            Destroy(gameObject);
        }

        if (bulletCoolDown < 1f)
        {
            bulletOnCoolDown = false;
        }
        else
        {
            bulletCoolDown--;
        }


        float below_distance = 1.2f;  // radius of player plus a little         Vector3 down = new Vector3(transform.position.x, transform.position.y - below_distance, 0.0f);
        onGround = Physics2D.OverlapCircle(down, groundCheckRadius, whatIsGround);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + move * .13f;
        if (Input.GetKeyDown(KeyCode.W)&& onGround||Input.GetKeyDown(KeyCode.W)&& onGround){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && bulletOnCoolDown == false)
        {
            Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
            bulletOnCoolDown = true;
            bulletCoolDown = bulletMaxCoolDown;


        }
        if (Input.GetKey(KeyCode.S)&& onGround==false){
            rb.velocity = new Vector2(rb.velocity.x, -jumpSpeed);
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyTrigger"))
        {
            playerHealth = playerHealth - 1;
        }
    }
}
