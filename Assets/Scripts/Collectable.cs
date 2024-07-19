using TMPro;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Transform carrot;
    [SerializeField] private Transform top, bottom, left, right;

    [SerializeField] private TextMeshProUGUI scoreTxt;
    public int Score { get; private set; }

    [SerializeField] private AudioClip eatClip;

    private void Awake() {
        SetRandomPos(carrot);

        Score = 0;
        scoreTxt.text = Score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Collectable")) {
            AudioManager.Instance.PlaySoundEffect(eatClip);
            SetRandomPos(collision.transform);
            scoreTxt.text = (++Score).ToString();
        }
    }

    private void SetRandomPos(Transform obj) {
        float yPos = Random.Range(bottom.position.y + 1f, top.position.y - 1f);
        float xPos = Random.Range(left.position.x + 1f, right.position.x - 1f);

        obj.position = new Vector3(xPos, yPos, 0f);
    }
}
