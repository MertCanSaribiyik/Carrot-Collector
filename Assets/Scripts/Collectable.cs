using TMPro;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Transform carrot;
    [SerializeField] private Transform top, bottom, left, right;

    [SerializeField] private TextMeshProUGUI scoreTxt;
    public int Score { get; private set; }

    [SerializeField] private GameManager gameManager;
    [SerializeField] private int extraTime = 3;
    [SerializeField] private GameObject floatingTimeText;

    [SerializeField] private AudioClip eatClip;

    private void Awake() {
        SetRandomPos(carrot);

        Score = 0;
        scoreTxt.text = Score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Collectable")) {
            Collect(collision.gameObject);
        }
    }

    private void SetRandomPos(Transform obj) {
        float yPos = Random.Range(bottom.position.y + 1f, top.position.y - 1f);
        float xPos = Random.Range(left.position.x + 1f, right.position.x - 1f);

        obj.position = new Vector3(xPos, yPos, 0f);
    }

    private void Collect(GameObject obj) {
        AudioManager.Instance.PlaySoundEffect(eatClip);

        SetRandomPos(obj.transform);
        scoreTxt.text = (++Score).ToString();

        GameObject floatingText = Instantiate(floatingTimeText, transform.position, Quaternion.identity);
        floatingText.transform.SetParent(transform);
        gameManager.Time += extraTime;

        gameManager.SetTimeTxt(gameManager.Time);
    }
}
