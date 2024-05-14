using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    private string minutes, seconds;
    private bool isRunning = true;
    public float timerDuration = 240f; // durasi 4 menit

    // untuk script atau komponen lain membaca apakah timer sudah berhenti atau belum
    public bool IsTimerFinished { get; private set; } = false;

    void Start()
    {
        StartTimer(); // Otomatis start timer
    }

    void Update()
    {
        if (isRunning)
        {
            float t = Time.time - startTime; // menghitung dari start time sampe time saat ini trus di assign ke variabel t

            // cek timer sudah lebih dari 4 menit atau belum
            if (t >= timerDuration)
            {
                t = timerDuration; // klo iya brarti ganti variabel t dengan 4 menit
                StopTimer(); // stop timernya
                IsTimerFinished = true; // set variabel IsTimerFinished jadi true biar script lain juga bisa tau
            }

            this.minutes = ((int)t / 60).ToString("00"); // get menit
            this.seconds = (t % 60).ToString("00"); // get detik

            timerText.text = this.minutes + ":" + this.seconds; // rangkai menit:detik
        }
    }

    public void StopTimer()
    {
        isRunning = false;
        Debug.Log("Timer stopped at 4 minutes.");
    }

    public void StartTimer()
    {
        isRunning = true;
        startTime = Time.time;
        IsTimerFinished = false; // reset state IsTimerFinished ke false, soalnya method ini bisa saja di panggil di script lain pas udh selesai timernya
        Debug.Log("Timer started.");
    }
}
