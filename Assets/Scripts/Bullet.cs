using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

    }

    public void Move(Vector2 direction)
    {
        rb2d.AddForce(direction * this.speed * 100);

        Destroy(gameObject, lifeTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
