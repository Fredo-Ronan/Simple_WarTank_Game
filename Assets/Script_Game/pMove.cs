using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class pMove : MonoBehaviour
{
    public TMP_Text uiPoint;
    public Timer timer;

    private float xDir, yDir;

    public float speed;
    public float rotateSpeed;
    private Rigidbody rig;

    public int score =0;
    public int scorReq = 1000;
    public bool isWin = false;
    private bool isOver = false;

    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        uiPoint.text = "Health : " + HP + " \nScore : 0";
    }

    // Update is called once per frame
    void Update()
    {
        xDir = Input.GetAxis("Horizontal");
        yDir = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(xDir, 0.0f, yDir);

        // cek kalau timernya udh selesai tapi HP nya masih di atas 0 dan score nya masih belum sama dengan target, brarti WAKTU HABIS/GAME OVER
        if (timer.IsTimerFinished && HP > 0 && score < scorReq)
        {
            this.isOver = true;
            uiPoint.text = "Health : " + HP + "\nScore : " + score + "\nGAME OVER";
            Debug.Log("Game over");
            speed = 0;
        }

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
        uiPoint.text = "Health : " + HP + "\nScore : " + score;
        if ((score >= scorReq)) 
        {
            this.isWin = true;
            timer.StopTimer(); // stop timer biar timernya berhenti pas player berhasil mencapai target score
            uiPoint.text = "Health : " + HP + "\nScore : " + score + "\nLEVEL COMPLETED";
            Debug.Log("Selesai");
        }
    }

    public void addHP()
    {
        HP++;
        uiPoint.text = "Health : " + HP + "\nScore : " + score;
    }

    public void addScore()
    {
        score += 25;
        uiPoint.text = "Health : " + HP + "\nScore : " + score;
    }

    public void checkHP()
    {
        if (HP <= 0)
        {
            timer.StopTimer(); // stop timer pas playernya HP nya habis
            uiPoint.text = "Health : 0" + "\nScore : " + score + "\nGAME OVER";
            Debug.Log("Game over");
            speed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(!this.isWin && !this.isOver)
            {
                HP--;
            }

            if (this.isWin)
            {
                uiPoint.text = "Health : " + HP + "\nScore : " + score + "\nLEVEL COMPLETED";
            } else
            {
                uiPoint.text = "Health : " + HP + "\nScore : " + score;
            }

            if (HP <= 0)
            {
                timer.StopTimer(); // stop timer pas playernya HP nya habis
                uiPoint.text = "Health : 0" + "\nScore : " + score + "\nGAME OVER";
                Debug.Log("Game over");
                speed = 0;
            }
            
        }
    }
}
