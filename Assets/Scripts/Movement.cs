
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    public GameObject jumpDustPrefab;
    public GameObject landingDustPrefab;
    private bool wasGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        wasGrounded = IsGrounded();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );

            GameObject dust = Instantiate(jumpDustPrefab, groundCheck.position + Vector3.up * 0.3f, Quaternion.identity);
            Destroy(dust, 0.7f);
        }
    }

    void Update()
    {
        bool grounded = IsGrounded();

        if (grounded && !wasGrounded)
        {
            GameObject dust = Instantiate(landingDustPrefab, groundCheck.position + Vector3.up * 0.3f, Quaternion.identity);
            Destroy(dust, 0.7f);
        }

        wasGrounded = grounded;

        // Update running animation
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));

        // Update grounded state
        anim.SetBool("IsGrounded", IsGrounded());

        // Update falling state
        anim.SetFloat("YVelocity", rb.linearVelocity.y);

        // Flip sprite based on movement direction
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            moveInput.x * speed,
            rb.linearVelocity.y
        );
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }
}
