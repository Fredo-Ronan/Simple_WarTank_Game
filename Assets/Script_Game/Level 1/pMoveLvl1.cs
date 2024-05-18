using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pMoveLvl1 : MonoBehaviour
{
    public TMP_Text uiPoint;
    public Button tryAgainBtn;
    public Button nextLevelBtn;
    public Timer timer;

    private float xDir, yDir;

    public float speed;
    public float rotateSpeed;
    private Rigidbody rig;

    public int score = 0;
    public int scoreReq = 1000;
    public bool isWin = false;
    private bool isOver = false;

    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        tryAgainBtn.gameObject.SetActive(false);
        nextLevelBtn.gameObject.SetActive(false);
        rig = GetComponent<Rigidbody>();
        uiPoint.text = "Health : " + HP + "\nScore : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        xDir = Input.GetAxis("Horizontal");
        yDir = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(xDir, 0.0f, yDir);

        // cek kalau timernya udh selesai tapi HP nya masih di atas 0 dan score nya masih belum sama dengan target, brarti WAKTU HABIS/GAME OVER
        if (timer.IsTimerFinished && HP > 0 && score < scoreReq)
        {
            this.isOver = true;
            uiPoint.text = "Health : " + HP + "\nScore : " + score + "\nGAME OVER";
            tryAgainBtn.gameObject.SetActive(true);
            Debug.Log("Selesai");
            speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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
        if(score == scoreReq)
        {
            timer.StopTimer();
            uiPoint.text = "Health : " + HP + "\nScore : " + score + "\nLEVEL COMPLETED";
            nextLevelBtn.gameObject.SetActive(true);
            this.isWin=true;
        }
    }

    public void addHP()
    {
        HP += 10;
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
            tryAgainBtn.gameObject.SetActive(true);
            Debug.Log("Game over");
            speed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!this.isWin && !this.isOver)
            {
                HP--;
            }

            if (this.isWin)
            {
                nextLevelBtn.gameObject.SetActive(true);
                uiPoint.text = "Health : " + HP + "\nScore : " + score + "\nLEVEL COMPLETED";
            }
            else
            {
                uiPoint.text = "Health : " + HP + "\nScore : " + score;
            }

            if (HP <= 0)
            {
                timer.StopTimer(); // stop timer pas playernya HP nya habis
                uiPoint.text = "Health : 0" + "\nScore : " + score + "\nGAME OVER";
                tryAgainBtn.gameObject.SetActive(true);
                Debug.Log("Game over");
                speed = 0;
            }

        }
    }
}
