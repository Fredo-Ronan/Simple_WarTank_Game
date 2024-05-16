using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class munculMusuh : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject musuh;
    public int xPos;
    public int zPos;
    public int enemyCount = 0;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (enemyCount < 40)
        {
            xPos = Random.Range(1, 50);
            zPos = Random.Range(1, 31);
            Instantiate(musuh, new Vector3(xPos, 2, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2);
            enemyCount++;
        }
    }
}
