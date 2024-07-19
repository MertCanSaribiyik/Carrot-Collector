using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Transform player, carrot;

    [SerializeField] private float t = 4f;

    private void Update() {
        Vector2 direction = carrot.position - player.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(Vector3.forward * (angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t * Time.deltaTime);
    }
}
