using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpForce = 12f;
    public float gravityScale = 3f;

    [Header("Dash")]
    public float dashForce = 15f;
    public float dashCooldown = 1f;
    private float dashTimer;
    public float iFrameDuration = 0.12f;

    [Header("Jump Buffer")]
    public float coyoteTime = 0.12f;
    public float jumpBufferTime = 0.1f;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    private Rigidbody2D rb;
    private bool isDashing;
    private bool canMove = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        HandleTimers();
        HandleInput();
    }

    void HandleTimers() {
        if (IsGrounded())
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        jumpBufferCounter -= Time.deltaTime;
        dashTimer -= Time.deltaTime;
    }

    void HandleInput() {
        if (canMove && !isDashing) {
            float move = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
            jumpBufferCounter = jumpBufferTime;

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f) {
            Jump();
            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonDown("Fire3") && dashTimer <= 0f)
            StartCoroutine(Dash());
    }

    void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    System.Collections.IEnumerator Dash() {
        isDashing = true;
        dashTimer = dashCooldown;
        Vector2 dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (dashDirection == Vector2.zero) dashDirection = Vector2.right * transform.localScale.x;
        rb.velocity = dashDirection * dashForce;
        yield return new WaitForSeconds(iFrameDuration);
        isDashing = false;
    }

    bool IsGrounded() {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
    }
}
