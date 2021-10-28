using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public Sprite[] sprites;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D rb2d;
    public float speed;
    public float lifeTime;
    public bool Big;
    public Asteroid smallAsteroid;
    public GameObject Particles;
    Player player;

    PlaySounds soundPlayer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        soundPlayer = FindObjectOfType<PlaySounds>();
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        transform.eulerAngles = new Vector3(0, 0, Random.value * 360f);

    }


    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
    public void Move(Vector2 direction)
    {
        rb2d.AddForce(direction * this.speed);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            if (Big)
            {
                Instantiate(Particles, transform.position, transform.rotation);
                if (soundPlayer != null) soundPlayer.PlaySound("Explosion");
                SpawnSmallAsteroids();
                player.points += 50;
                Destroy(gameObject);
            }
            else
            {
                Instantiate(Particles, transform.position, transform.rotation);
                if (soundPlayer != null) soundPlayer.PlaySound("Explosion");
                player.points += 100;
                Destroy(gameObject);
            }
        }
    }


    void SpawnSmallAsteroids()
    {
        Asteroid asteroid1 = Instantiate(smallAsteroid, transform.position, transform.rotation);
        asteroid1.Move(new Vector2(1 * speed, 1 * speed));

        Asteroid asteroid2 = Instantiate(smallAsteroid, transform.position, transform.rotation);
        asteroid2.Move(new Vector2(0.2f * speed, -1 * speed));

        Asteroid asteroid3 = Instantiate(smallAsteroid, transform.position, transform.rotation);
        asteroid3.Move(new Vector2(-1 * speed, 0.2f * speed));
    }


}
