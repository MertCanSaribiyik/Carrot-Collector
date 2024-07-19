using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private FixedJoystick joystick;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate() {
        float moveHorizontal = joystick.Horizontal * speed;
        float moveVertical = joystick.Vertical * speed;

        rb.velocity = new Vector2 (moveHorizontal, moveVertical);
    }
}
