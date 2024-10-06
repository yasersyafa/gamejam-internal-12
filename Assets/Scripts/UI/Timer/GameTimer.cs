using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    private float timerGame;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highscore;
    private bool isTimerRunning = true;
    public HealthManager playerHealth;
    public Image blackImage;
    public Animator playerAnimator; // Drag Animator player ke sini
    public float deathAnimationDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        float highscoreTime = PlayerPrefs.GetFloat("Highscore", 0f);
        UpdateHighscoreText(highscoreTime);
        if (blackImage != null)
        {
            blackImage.gameObject.SetActive(false);
        }
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
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timerGame / 60F);
        int seconds = Mathf.FloorToInt(timerGame % 60F);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    void UpdateHighscoreText(float highscoreTime)
    {
        int minutes = Mathf.FloorToInt(highscoreTime / 60F);
        int seconds = Mathf.FloorToInt(highscoreTime % 60F);
        highscore.text = "Highscore: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    IEnumerator ShowGameOverPanelAfterDelay(float delay)
    {
        // Trigger animasi kematian player
        playerAnimator.SetTrigger("isDead"); // Ganti "isDead" dengan nama trigger di Animator Controller

        yield return new WaitForSeconds(delay); // Tunggu selama delay

        // Aktifkan black image dan pause game
        if (blackImage != null)
        {
            blackImage.gameObject.SetActive(true);

            // Atur opacity black image (0 = transparan, 1 = opaque)
            Color imageColor = blackImage.color;
            imageColor.a = 0.5f; // Contoh: 50% opacity
            blackImage.color = imageColor;
        }

        Time.timeScale = 0f; // Pause game
    }
}
