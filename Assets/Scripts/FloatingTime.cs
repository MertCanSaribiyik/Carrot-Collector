using UnityEngine;

public class FloatingTime : MonoBehaviour
{
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] Vector3 offset = new Vector3(0f, .2f, 0f);

    private void Start() {
        transform.position += offset;
        Destroy(gameObject, destroyTime);
    }

}
