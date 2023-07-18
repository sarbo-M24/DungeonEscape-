using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private LayerMask JumpableGround;
    [SerializeField] private float JumpSpeed;
    [SerializeField] private float JumpCooldown = 1f;
    [SerializeField] private float AttkCooldown = 0f;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private float NextJump = .1f;
    private float NextAttk = .1f;
    private PlayerAnimation PlayerAnim;
    private Animator an;

    float horizontalInput;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll= GetComponent<BoxCollider2D>();
        PlayerAnim = GetComponent<PlayerAnimation>();
        an = GetComponentInChildren<Animator>();
    }

   
    void Update()
    {
        Movement();

        Jump();

        attack();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * MoveSpeed, rb.velocity.y);

        PlayerAnim.move(horizontalInput);
    }

    

    private void Jump()
    {
        if (IsGrounded())
        {
            an.SetBool("jump", false);
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded() && Time.time > NextJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
            NextJump = Time.time + JumpCooldown;
            an.SetBool("jump", true);
        }
    }

    private void attack() 
    {
        if (Input.GetButtonDown("Fire1"))//&& Time.time > NextAttk)
        {
            PlayerAnim.attack();
            
            NextAttk = Time.time + AttkCooldown;
        }
        
    }




    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }

}
