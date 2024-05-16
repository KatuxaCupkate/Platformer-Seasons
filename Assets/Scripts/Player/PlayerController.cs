
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Transform _groundCheck;
   [SerializeField] private float _groundCheckRadius = 0.2f;
   
    private SpriteRenderer rbSprite;
    private Animator animator;
    
    private float _timeToApex=0.5f;
    private float horizontalInput;
    private Vector2 move;
    private Rigidbody2D rb;
    private bool isGround;
    private bool canThrow;
    public bool CanMove { get; private set; }
    public GameObject itemPrefab; 
    private enum MovementState { Idle, Run, Jump, Falling };

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
        UpdateAnimationState();
       
    }
    private void FixedUpdate() 
    {
       MoveInternal();
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
    public void Move(float horizontalInput)
    {
       this.horizontalInput = horizontalInput;
    }
    public void Jump()
    {  
        if(GroundCheck())
        {
         jumpSoundEffect.Play();
         ApplyJumpForce();   
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
        else if ((rb.velocity.y < -.1f) && (!GroundCheck()))
        {
            state = MovementState.Falling;
        }
        animator.SetInteger("State", ((int)state));
    }
   private bool GroundCheck()
   {
       var groundOverlap = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayerMask);
       return groundOverlap;
   }
   
    private void PlayerCantMove()
    {
        CanMove = false; 
    }

    private void ApplyJumpForce()
    {
        float jumpVelocityY = CalculateJumpVelocityY(_jumpForce, _timeToApex);
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocityY);
    }

    private static float CalculateJumpVelocityY(float jumpHeight, float jumpTime)
    {
        return Mathf.Sqrt(2 * jumpHeight / jumpTime);
    }

    private void CanThrowTheItem(GameObject item ,bool CanThrow)
    {
        itemPrefab = item;
        canThrow = CanThrow; 
    }
    public void ThrowItem()
    {
        const int throwForce = 3;
        if (canThrow && itemPrefab != null)
        {
            var itemInstance = Instantiate(itemPrefab, transform.position + Vector3.up, Quaternion.identity);
            itemInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,1) * throwForce, ForceMode2D.Impulse);
            this.canThrow = false;
            EventBus.OnItemThrown();
        }
    }

public void MoveInternal()
{
    if(CanMove)
    {
      move = transform.position;
       move.x += _speed * horizontalInput * Time.fixedDeltaTime;
      transform.position = move;
    }
}

    
}
