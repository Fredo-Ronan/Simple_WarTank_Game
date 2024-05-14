using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float life = 3;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<pMove>().isWin)
            {
                collision.gameObject.GetComponent<pMove>().HP--;
            }
            collision.gameObject.GetComponent<pMove>().checkScore();
            collision.gameObject.GetComponent<pMove>().checkHP();
        }

        Destroy(gameObject);

    }
}
