using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletLvl1 : MonoBehaviour
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
            collision.gameObject.GetComponent<eMove>().targetPlayer.GetComponent<pMoveLvl1>().addScore();
            collision.gameObject.GetComponent<eMove>().targetPlayer.GetComponent<pMoveLvl1>().checkScore();
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);

    }
}
