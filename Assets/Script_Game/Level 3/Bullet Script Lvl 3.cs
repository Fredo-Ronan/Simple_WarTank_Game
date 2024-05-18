using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptLvl3 : MonoBehaviour
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
            if (!collision.gameObject.GetComponent<pMoveLvl3>().isWin)
            {
                collision.gameObject.GetComponent<pMoveLvl3>().HP--;
            }
            collision.gameObject.GetComponent<pMoveLvl3>().checkScorePoint();
            collision.gameObject.GetComponent<pMoveLvl3>().checkHP();
        }

        Destroy(gameObject);

    }
}
