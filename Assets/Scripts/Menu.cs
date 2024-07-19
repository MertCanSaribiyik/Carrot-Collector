using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel, configPanel, highscorePanel;

    [SerializeField] private Configuration config;
    [SerializeField] private Button[] timeButtons;

    [SerializeField] private TextMeshProUGUI[] highscoreTxts;

    private void Awake() {
        Application.targetFrameRate = 60;
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        BackButton();

        config.time = (config.time == 0) ? 20 : config.time;
        SelectedButton(config.time);
    }

    public void PlayButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton() {
        Application.Quit();
    }

    public void ConfigButton() {
        menuPanel.SetActive(false);
        configPanel.SetActive(true);
    }

    public void HighscoreButton() {
        foreach (TextMeshProUGUI text in highscoreTxts) {
            string score = text.name[0].ToString() + text.name[1];
            text.text = $"{score} second : {PlayerPrefs.GetInt($"highscore{score}", 0)}";
        }

        menuPanel.SetActive(false);
        highscorePanel.SetActive(true);
    }

    public void BackButton() {
        menuPanel.SetActive(true);
        configPanel.SetActive(false);
        highscorePanel.SetActive(false);
    }

    public void TimeButton(int time) {
        SelectedButton(time);
        config.time = time;
    }

    private void SelectedButton(int time) {
        foreach (Button button in timeButtons) {
            if (button.GetComponentInChildren<TextMeshProUGUI>().text == $"{time}s") {
                button.interactable = false;
            }

            else {
                button.interactable = true;
            }
        }
    }
}
