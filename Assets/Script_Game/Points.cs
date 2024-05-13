using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            other.GetComponent<pMove>().score++;
            //Debug.Log("point " + other.GetComponent<pMove>().score);
            other.GetComponent<pMove>().checkScore();
            Destroy(gameObject);
        }
    }
}
