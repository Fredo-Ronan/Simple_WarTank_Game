using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class munculMusuh : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject musuh;
    void Start()
    {
        Instantiate(musuh, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
