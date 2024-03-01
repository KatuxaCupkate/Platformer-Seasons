using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : Singleton  <PlayerController>
{
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private Animator animator;
    private CinemachineVirtualCamera vCamera;

    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _jumpForce = 5.0f;
   

    private float horizontalInput;
    private Vector2 move;
    private bool isGround;
     public bool CanMove { get; private set; } 
    private enum MovementState { Idle, Run, Jump, Falling };
    private MovementState state;

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        CanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        horizontalInput = Input.GetAxisRaw("Horizontal");
        UpdateAnimationState();
        
    }
    private void OnEnable()
    {
        EventBus.PlayerDeathEvent += IsPlayerDead;
        EventBus.LevelRestartedEvent += ResetPlayerControl;
    }
    private void OnDisable()
    {
        
        EventBus.PlayerDeathEvent -= IsPlayerDead;
        EventBus.LevelRestartedEvent -= ResetPlayerControl;
        
    }
    public void PlayerMove()
    {
        if (CanMove)
        {
            move = transform.position;
            move.x += _speed * horizontalInput * Time.deltaTime;
            transform.position = move;
        }
        

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGround&&CanMove)
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
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

    private void IsPlayerDead()
    {
        CanMove = false; 
    }

    private void ResetPlayerControl()
    {
        PlayerController.Instance.gameObject.AddComponent<PlayerLife>();
        vCamera=FindAnyObjectByType<CinemachineVirtualCamera>();
        vCamera.Follow = gameObject.transform;
        CanMove = true;
    }   
}
