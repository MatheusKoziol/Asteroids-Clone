using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveAsteroid : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D rb2d;
    public float speed;
    public float lifeTime;
    public GameObject Particles;
    Player player;

    PlaySounds soundPlayer;
    public CircleCollider2D circleCollider;
    public GameObject explosionCollider;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        explosionCollider.SetActive(false);
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
            Instantiate(Particles, transform.position, transform.rotation);
            circleCollider.enabled = false;
            _spriteRenderer.enabled = false;
            explosionCollider.SetActive(true);
            if (soundPlayer != null) soundPlayer.PlaySound("Explosion");
            player.points += 100;
            StartCoroutine(DisableCollider());
        }
    }

    public IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
