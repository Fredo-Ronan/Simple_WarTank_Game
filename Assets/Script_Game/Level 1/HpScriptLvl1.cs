using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpScriptLvl1 : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<pMoveLvl1>().addHP();
            Destroy(gameObject);
        }
    }
}
