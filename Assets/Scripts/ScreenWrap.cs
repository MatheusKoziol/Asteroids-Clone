using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{

    public bool asteroid;
    public bool active;
    void Awake()
    {
        if(asteroid)
        {
            active = false;
            StartCoroutine(ActivateWrap());
        }
        else
        {
            active = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision);
    }


    public void CheckCollision(Collider2D collision)
    {
        if(active)
        {
            if (collision.gameObject.tag == "BorderUp")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 9.5f, transform.position.z);
            }

            if (collision.gameObject.tag == "BorderDown")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 9.5f, transform.position.z);
            }

            if (collision.gameObject.tag == "BorderRight")
            {
                transform.position = new Vector3(transform.position.x - 17, transform.position.y, transform.position.z);
            }

            if (collision.gameObject.tag == "BorderLeft")
            {
                transform.position = new Vector3(transform.position.x + 17, transform.position.y, transform.position.z);
            }
        }
        
    }

    public IEnumerator ActivateWrap()
    {
        yield return new WaitForSeconds(6);
        active = true;

    }

}
