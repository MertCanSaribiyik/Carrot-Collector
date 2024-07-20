using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private Configuration config;
    public int Time { get; set; }
    private float counter;

    [SerializeField] private Collectable playerCollectable;
    [SerializeField] private GameObject carrot, arrow;

    [SerializeField] private GameObject pauseMenu;
    private bool gameFinished;

    private void Awake() {
        SetGame();
    }

    private void Update() {
        if(UnityEngine.Time.time >= counter && !gameFinished) {
            SetTimeTxt(--Time);
            counter = UnityEngine.Time.time + 1;

            if(Time == 0) {
                GameOver();
                Invoke("PreviousScene", 3f);
            }
        }
    }

    private void SetGame() {
        Time = config.time;
        counter = UnityEngine.Time.time + 1;
        SetTimeTxt(Time);

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

    public void SetTimeTxt(int time) {
        timeTxt.text = $"Time : {time}s";
    }

    public void PauseButton() {
        UnityEngine.Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeButton() {
        UnityEngine.Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void BackButton() {
        UnityEngine.Time.timeScale = 1f;
        PreviousScene();
    }


}
