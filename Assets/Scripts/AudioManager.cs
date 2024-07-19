using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {  get; private set; }

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        else {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        MenuSound();
    }

    [SerializeField] private AudioSource menuAudioSource,audioSource;

    private void MenuSound() {
        if (SceneManager.GetActiveScene().buildIndex != 0) {
            menuAudioSource.enabled = false;
        }

        else {
            menuAudioSource.enabled = true;
        }
    }

    public void PlaySoundEffect(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }

}
