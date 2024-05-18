using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            other.GetComponent<pMoveLvl3>().addScore();
            //Debug.Log("point " + other.GetComponent<pMove>().score);
            other.GetComponent<pMoveLvl3>().checkScorePoint();
            Destroy(gameObject);
        }
    }
}
