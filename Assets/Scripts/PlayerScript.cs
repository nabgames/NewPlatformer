using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Rigidbody2D rb;

    public float playerHealth;
    public float jumpSpeed;
    public Transform GetTransform;

    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public GameObject Projectile;
    public GameObject ProjectileLeft;
    public float bulletCoolDown = 0f;
    public bool bulletOnCoolDown = false;

    public float hiddenTimer;
    public float secondTimer;

    public float playerX;
    public float playerY;

    public bool rightFace;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rightFace = true;
  
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
        if (Input.GetKeyDown(KeyCode.D)||Input.GetKey(KeyCode.D))
        {
            rightFace = true;
        }
        else if (Input.GetKeyDown(KeyCode.A)|| Input.GetKey(KeyCode.A))
        {
            rightFace = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && bulletOnCoolDown == false && rightFace)
        {
            Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
            bulletOnCoolDown = true;
            bulletCoolDown = 10f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && bulletOnCoolDown == false && rightFace==false)
        {
            Instantiate(ProjectileLeft, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
            bulletOnCoolDown = true;
            bulletCoolDown = 10f;
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
