using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class munculMusuhLvl3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject musuh;
    public int xPos;
    public int zPos;
    private int enemyCount = 0;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (enemyCount < 100)
        {
            xPos = Random.Range(1, 50);
            zPos = Random.Range(1, 100);
            Instantiate(musuh, new Vector3(xPos, 2, zPos), Quaternion.identity);
            yield return null;
            enemyCount++;
        }
    }
}
