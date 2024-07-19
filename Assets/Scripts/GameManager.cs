using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private Configuration config;
    private int time;
    private float counter;

    [SerializeField] private Collectable playerCollectable;
    [SerializeField] private GameObject carrot, arrow;

    [SerializeField] private GameObject pauseMenu;
    private bool gameFinished;

    private void Awake() {
        SetGame();
    }

    private void Update() {
        if(Time.time >= counter && !gameFinished) {
            timeTxt.text = $"Time : {--time}s";
            counter = Time.time + 1;

            if(time == 0) {
                GameOver();
                Invoke("PreviousScene", 3f);
            }
        }
    }

    private void SetGame() {
        time = config.time;
        counter = Time.time + 1;
        timeTxt.text = $"Time : {time}s";

        pauseMenu.SetActive(false);
        gameFinished = false;
    }

    private void GameOver() {
        gameFinished = true;
        carrot.SetActive(false);
        arrow.SetActive(false);

        if(playerCollectable.Score > PlayerPrefs.GetInt($"highscore{config.time}", 0)) {
            PlayerPrefs.SetInt($"highscore{config.time}", playerCollectable.Score);
        }
    }

    private void PreviousScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PauseButton() {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeButton() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void BackButton() {
        Time.timeScale = 1f;
        PreviousScene();
    }


}
