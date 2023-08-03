using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{


    private Animator anim;
    private Animator swordAnim;
    private SpriteRenderer sr;
    private SpriteRenderer swordsr;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
        swordAnim = transform.GetChild(1).GetComponent<Animator>();
        swordsr= transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

  
    public void move(float horizontalInput)
    {
        anim.SetFloat("Move", Mathf.Abs(horizontalInput));

        if (horizontalInput > 0) 
        {
           sr.flipX = false;
        }

        if (horizontalInput < 0)
        {
            sr.flipX = true;
        }

        if (horizontalInput > 0)
        {
            
            swordsr.flipY = false;
        }

        if (horizontalInput < 0)
        {
            swordsr.flipY = true;
           
        }
    }

    public void attack() 
    {
        anim.SetTrigger("Attack");
        swordsr.enabled = true;

        swordAnim.SetTrigger("Sword");
    }

    public void hit() 
    {
        anim.SetTrigger("Hit");
    }

}
