using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    private Vector2 direction;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D.velocity = direction * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
