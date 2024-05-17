using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptLvl1 : MonoBehaviour
{
    public float life = 3;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<pMoveLvl1>().isWin)
            {
                collision.gameObject.GetComponent<pMoveLvl1>().HP--;
            }
            collision.gameObject.GetComponent<pMoveLvl1>().checkScore();
            collision.gameObject.GetComponent<pMoveLvl1>().checkHP();
        }

        Destroy(gameObject);

    }
}
