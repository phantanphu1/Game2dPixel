using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;
    //xác định vai trò trong mặt đất
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    private Animator animator;
    private Rigidbody2D rb;
    GameManager gameManager;

    private bool isGrounded;
    public bool isPressedButtonRight = false;
    public bool isPressedButtonLeft = false;
    public bool isPressedButtonJump = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver()) return;
        HandleMove();
        HandleJump();
        HandleAnimation();
        TouchController();
    }
    //handle button
    void TouchController()
    {
        if (isPressedButtonRight == true || Input.GetKey(KeyCode.A))
        {
            HandleMoveRight();
        }
        else if (isPressedButtonLeft == true || Input.GetKey(KeyCode.D))
        {
            HandleMoveLeft();
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    float moveInput = 0f;
    private void HandleMove()
    {

        moveInput = 0f;
        if (isPressedButtonRight)
        {
            moveInput = 1f;
        }
        else if (isPressedButtonLeft)
        {
            moveInput = -1f;
        }
        else
        {
            moveInput = Input.GetAxisRaw("Horizontal");

        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);


        if (moveInput > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (moveInput < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void HandleJump()
    {
        if (gameManager.IsGameOver()) return;
        else if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.instance.HandleJumpAudio();
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void HandleMoveJump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.instance.HandleJumpAudio();

        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    public void HandleMoveLeft()
    {
        HandleMove();
    }

    public void HandleMoveRight()
    {
        HandleMove();
    }
    private void HandleAnimation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }
}