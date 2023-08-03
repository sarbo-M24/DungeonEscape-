using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy,IDamageable
{

    public int health { get; set; }
    public void damage() 
    {
        Debug.Log("Damage()");
        anim.SetTrigger("Hit");
        health--;
        IsHit = true;
        anim.SetBool("InCombat", true);

        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public override void Movement()
    {
        base.Movement();

        float dist = Vector3.Distance(player.transform.position, transform.localPosition);
        
        if (dist > 2.0f)
        {
            IsHit = false;
            anim.SetBool("InCombat", false);
        }

        Vector3 direction = player.transform.position - transform.localPosition;
        Vector3 Movement_Direction = transform.localPosition;

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
            sr.flipX = false;

        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
            sr.flipX = true;
        
        
        if (anim.GetBool("InCombat") == false && Movement_Direction.x < 0)
            sr.flipX = false;

        else if (anim.GetBool("InCombat") == false && Movement_Direction.x > 0)
            sr.flipX = true;
    }

    public override void Init()
    {
        base.Init();
        health =base.health;
    }
}







