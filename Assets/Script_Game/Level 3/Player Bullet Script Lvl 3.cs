using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScriptLvl3 : MonoBehaviour
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
            collision.gameObject.GetComponent<eMove>().targetPlayer.GetComponent<pMoveLvl3>().addKill();
            collision.gameObject.GetComponent<eMove>().targetPlayer.GetComponent<pMoveLvl3>().checkKill();
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);

    }
}
