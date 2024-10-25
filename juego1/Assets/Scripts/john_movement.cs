using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class john_movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D Rigidbody2D;
    public GameObject BulletPrefab;
    private float horizontal;
    private bool grounded;
    private Animator animator;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Grounded: ");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontal>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        animator.SetBool("running", horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.2f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
        {
            grounded = true;
            Debug.Log("Grounded: " + grounded); // Añade esta línea para depurar.
        }
        else
        {
            grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, 3);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direction;
            if (transform.localScale.x == 1)
            {
                direction = Vector3.right;
            }
            else
            {
                direction = Vector3.left;
            }
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direction *0.1f, Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction);
        }
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
    }
}


