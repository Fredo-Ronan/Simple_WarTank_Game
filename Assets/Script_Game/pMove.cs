using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class pMove : MonoBehaviour
{
    public TMP_Text uiPoint;

    private float xDir, yDir;

    public float speed;
    public float rotateSpeed;
    private Rigidbody rig;

    public int score =0;
    public int scorReq = 2;
    public bool isWin = false;

    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        uiPoint.text = "HP : 5 \nPoint : 0";
    }

    // Update is called once per frame
    void Update()
    {
        xDir = Input.GetAxis("Horizontal");
        yDir = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(xDir, 0.0f, yDir);

        //transform.position += moveDir * speed
        //rig.AddForce(moveDir * speed);
    }

    private void LateUpdate()
    {
        transform.Translate(0f, 0f, (yDir * speed * Time.deltaTime));
        transform.Rotate(0f, (xDir * rotateSpeed * Time.deltaTime), 0f);
    }

    public void checkScore()
    {
        uiPoint.text = "HP : " + HP + "\nPoint : " + score;
        if ((score >= scorReq)) 
        {
            isWin = true;
            uiPoint.text = "HP : " + HP + "\nPoint : " + score + "\nLEVEL COMPLETED";
            Debug.Log("Selesai");
        }
    }

    public void checkHP()
    {
        if (HP <= 0)
        {
            uiPoint.text = "HP : 0" + "\nPoint : " + score + "\nGAME OVER";
            Debug.Log("Game over");
            speed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(!isWin)
            {
                HP--;
            }

            if (isWin)
            {
                uiPoint.text = "HP : " + HP + "\nPoint : " + score + "\nLEVEL COMPLETED";
            } else
            {
                uiPoint.text = "HP : " + HP + "\nPoint : " + score;
            }

            if (HP <= 0)
            {
                uiPoint.text = "HP : 0" + "\nPoint : " + score + "\nGAME OVER";
                Debug.Log("Game over");
                speed = 0;

            }
            
        }
    }
}
