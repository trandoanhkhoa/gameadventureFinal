using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    // Vat the ran
    private Rigidbody2D rb;
    // Hoat anh nhan vat
    private Animator anim;
    private BoxCollider2D coll;
    private float dirX= 0f;
    [SerializeField] private LayerMask jumpableground;
    [SerializeField] private AudioSource soundEffect;
    private SpriteRenderer sprite;

    public  float moveSpeed = 7f;
    public float jumpForce = 7f;

    public bool doubleJump=true;
    private enum MovementState { idle, running, jumping,falling};
    //private MovementState state = MovementState.idle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void Update()
    {
        //Get location in player on horizontal
        dirX = Input.GetAxisRaw("Horizontal");

        //Jump
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) && IsGround()) || (Input.GetKeyDown(KeyCode.Space) && doubleJump ))
        {
            soundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = false;
        }
        if(IsGround()) doubleJump = true;
        UpdateAnimationState();




    }
    private void UpdateAnimationState()
    {
        MovementState state;
        
        //Check running player
        if (dirX > 0f)  // right
        {
            
            // set running in animator is true 
            state = MovementState.running;
            sprite.flipX = false;
            
        }
        else if (dirX < 0f) // left
        {
           
            state = MovementState.running;
            sprite.flipX = true;
            
        }
        else // no action 
        {
            state = MovementState.idle;
            
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }    
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;

        }
        anim.SetInteger("state", (int)state);
    }    
    private bool IsGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, .1f, Vector2.down,.1f, jumpableground);
    }    
}
