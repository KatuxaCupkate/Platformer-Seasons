using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private Animator animator;
    
    public GameObject itemPrefab;
   

    private Vector2 _initJumpVelocity;
    private float _yVel;
    private float _timeToApex=0.5f;

    private float horizontalInput;
    private Vector2 move;
    private bool isGround;
    private bool canThrow;
    public bool CanMove { get; private set; }
    private enum MovementState { Idle, Run, Jump, Falling };
  

    [SerializeField] private AudioSource jumpSoundEffect;
    public void Initialize(GameObject Player, bool CanMove)
    {
        animator = Player.GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody2D>();
        rbSprite = Player.GetComponent<SpriteRenderer>();
        this.CanMove = CanMove;

    }
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        horizontalInput = Input.GetAxisRaw("Horizontal");
        UpdateAnimationState();
        ThrowItem(canThrow);
    }
    private void OnEnable()
    {
        EventBus.PlayerDeathEvent += PlayerCantMove;
        EventBus.PlayerGetToFinishEvent += CanThrowTheItem;
       
    }
    private void OnDisable()
    {
        
        EventBus.PlayerDeathEvent -= PlayerCantMove;
        EventBus.PlayerGetToFinishEvent -= CanThrowTheItem;
       
        
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
            Jump();
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

    private void PlayerCantMove()
    {
        CanMove = false; 
    }

  private void Jump()
    {
        var gravity = (2 * _jumpForce) / (_timeToApex*_timeToApex);
        _yVel =(float) Math.Sqrt(2 * gravity * _jumpForce);
        _timeToApex = _yVel / gravity;
        _initJumpVelocity = new Vector2(rb.velocity.x, _yVel);
        rb.velocity = _initJumpVelocity;
    }

    private void CanThrowTheItem(GameObject item ,bool CanThrow)
    {
        itemPrefab = item;
        canThrow = CanThrow; 
    }
    private void ThrowItem(bool CanThrow)
    {
        Vector2 direction = new Vector2(1, 1);
        int force = 3;
        if (CanThrow&&Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(itemPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
            canThrow = false;
        }
    }
}
