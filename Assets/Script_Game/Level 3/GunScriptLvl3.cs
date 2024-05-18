using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScriptLvl3 : MonoBehaviour
{
    public GameObject player;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 1.0f; // Jeda waktu antar tembakan dalam detik

    private float nextFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<pMoveLvl3>().scorePoint == 400 || player.GetComponent<pMoveLvl3>().kill == 20)
        {
            fireRate = 0.5f;
        }

        if (player.GetComponent<pMoveLvl3>().scorePoint == 700 || player.GetComponent<pMoveLvl3>().kill == 50)
        {
            fireRate = 0.1f;
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
