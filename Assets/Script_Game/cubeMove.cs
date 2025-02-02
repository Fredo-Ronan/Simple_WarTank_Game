using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cubeMove : MonoBehaviour
{
    public TMP_Text uiPoint;

    public float speed;

    public int score = 0;
    public int scorReq = 2;

    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        uiPoint.text = "HP : 5 \nPoint : 0";
    }

    // Update is called once per frame
    void Update()
    {
        //float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(0, 0.0f, yDir);

        transform.position += moveDir * speed;
    }

    public void checkScore()
    {
        uiPoint.text = "HP : " + HP + "\nPoint : " + score;
        if ((score >= scorReq))
        {
            uiPoint.text = "HP : " + HP + "\nPoint : " + score + "\nLEVEL COMPLETED";
            Debug.Log("Selesai");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP--;
            uiPoint.text = "HP : " + HP + "\nPoint : " + score;
            if (HP <= 0)
            {
                uiPoint.text = "HP : 0" + "\nPoint : " + score + "\nGAME OVER";
                Debug.Log("Game over");
                speed = 0;

            }

        }
    }
}
