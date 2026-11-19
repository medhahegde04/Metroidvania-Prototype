
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 3.0f;
    private Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        // Allow movement only along the X-axis
        Vector3 direction = new Vector3(moveInput.x, 0, 0);

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
