using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    private float timerGame;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highscore;
    private bool isTimerRunning = true;
    public HealthManager playerHealth;
    public Animator playerAnimator; // Drag Animator player ke sini
    public float deathAnimationDuration = 1f;
    public GameObject scoringPanel; // Drag GameObject scoring panel ke sini
    public Animator scoringPanelAnimator;

    // Start is called before the first frame update
    void Start()
    {
        float highscoreTime = PlayerPrefs.GetFloat("Highscore", 0f);
        UpdateHighscoreText(highscoreTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            timerGame += Time.deltaTime;
            UpdateTimerText();

            // Periksa kondisi kematian player
            if (playerHealth.IsPlayerDead())
            {
                isTimerRunning = false; // Hentikan timer


                float currentHighscore = PlayerPrefs.GetFloat("Highscore", 0f);
                if (timerGame > currentHighscore)
                {
                    PlayerPrefs.SetFloat("Highscore", timerGame);
                    UpdateHighscoreText(timerGame);
                }
                StartCoroutine(ShowGameOverPanelAfterDelay(deathAnimationDuration));
                GetComponent<PlayerController>().canMove = false;

            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timerGame / 60F);
        int seconds = Mathf.FloorToInt(timerGame % 60F);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    IEnumerator SlowDownTime()
    {
        float duration = 2f; // Durasi slowdown dalam detik
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            yield return null;
        }

        Time.timeScale = 0f; // Pastikan game benar-benar berhenti
    }
    void UpdateHighscoreText(float highscoreTime)
    {
        int minutes = Mathf.FloorToInt(highscoreTime / 60F);
        int seconds = Mathf.FloorToInt(highscoreTime % 60F);
        highscore.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    IEnumerator ShowGameOverPanelAfterDelay(float delay)
    {
        // Trigger animasi kematian player
        playerAnimator.SetTrigger("isDead");

        StartCoroutine(SlowDownTime()); // Panggil coroutine untuk slow down time

        yield return new WaitForSeconds(delay); // Tunggu selama delay

        if (scoringPanel != null && scoringPanelAnimator != null)
        {
            scoringPanel.SetActive(true);
            scoringPanelAnimator.SetTrigger("Scoring");

            // Pastikan kecepatan animasi scoring panel tetap normal
            scoringPanelAnimator.speed = 1f;

            // Pindahkan scoring panel ke depan black image
            scoringPanel.transform.SetAsLastSibling();
            highscore.gameObject.SetActive(true);

        }
        //if (blackImage != null)
        //{
        //    blackImage.gameObject.SetActive(true);

        //    // Atur opacity black image
        //    Color imageColor = blackImage.color;
        //    imageColor.a = 0.7f; // Contoh: 70% opacity (atur sesuai keinginan)
        //    blackImage.color = imageColor;

        //    // Pastikan layer black image di atas player
            

            
        //}
    }

}
