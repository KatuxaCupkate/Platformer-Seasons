using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private Animator animator;
    private PlayerLife playerLife;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 5.0f;

    private float horizontalInput;
    private Vector2 move;
    private bool isGround;
    private enum MovementState { Idle, Run, Jump, Falling };
    private MovementState state;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerLife = GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        horizontalInput = Input.GetAxisRaw("Horizontal");
        UpdateAnimationState();

    }

    public void PlayerMove()
    {
        if (!playerLife.isDead)
        {
            move = transform.position;
            move.x += speed * horizontalInput * Time.deltaTime;
            transform.position = move;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGround = false;

        }
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (horizontalInput > .1f)
        {
            rbSprite.flipX = false;
            state = MovementState.Run;
        }
        else if (horizontalInput < -.1f)
        {
            rbSprite.flipX = true;
            state = MovementState.Run;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jump;
        }
        else if ((rb.velocity.y < -.1f) && (!isGround))
        {
            state = MovementState.Falling;
        }
        animator.SetInteger("State", ((int)state));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGround = true;

    }


}
