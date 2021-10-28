using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Rigidbody2D rb2d;
    bool thrust;
    bool turnLeft;
    bool turnRight;
    [SerializeField]
    float speed = 5;
    [SerializeField]
    float turningSpeed = 30;

    public bool testOnEditor;

    public Bullet bulletPrefab;

    public int points;

    public Text txt;
    public GameObject gameOverUI;
    public GameObject[] inactiveObjects;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        txt.text = points.ToString();

        if (testOnEditor)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                thrust = true;
            }
            else
            {
                thrust = false;
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                turnRight = true;
            }
            else
            {
                turnRight = false;
            }


            if (Input.GetAxis("Horizontal") < 0)
            {
                turnLeft = true;
            }
            else
            {
                turnLeft = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }

    }

    private void FixedUpdate()
    {
        if (thrust)
        {
            rb2d.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (turnRight)
        {
            rb2d.AddTorque(-1 * turningSpeed * Time.deltaTime);
        }

        if (turnLeft)
        {
            rb2d.AddTorque(1 * turningSpeed * Time.deltaTime);
        }
    }


    public void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Move(transform.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
            for (int i = 0; i < inactiveObjects.Length; i++)
            {
                inactiveObjects[i].SetActive(false);
            }

        }
    }

    #region When playing Mobile


    public void onPressTurnRight()
    {
        turnRight = true;
    }

    public void onReleaseTurnRight()
    {
        turnRight = false;
    }

    public void onPressTurnLeft()
    {
        turnLeft = true;
    }

    public void onReleaseTurnLeft()
    {
        turnLeft = false;
    }

    public void onPressThrust()
    {
        thrust = true;
    }

    public void onReleaseThrust()
    {
        thrust = false;
    }
    #endregion



}
