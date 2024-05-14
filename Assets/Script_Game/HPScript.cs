using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<pMove>().addHP();
            Destroy(gameObject);
        }
    }
}
