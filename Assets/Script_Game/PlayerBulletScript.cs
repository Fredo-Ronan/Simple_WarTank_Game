using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    public float life = 3;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<eMove>().targetPlayer.GetComponent<pMove>().addScore();
            collision.gameObject.GetComponent<eMove>().targetPlayer.GetComponent<pMove>().checkScore();
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);

    }
}
