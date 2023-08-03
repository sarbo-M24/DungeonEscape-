using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform PointA, PointB;

    private void Start()
    {
        Init();
    }

    protected bool IsHit = false;

    protected Vector3 target;
    protected Animator anim;
    protected SpriteRenderer sr;
    protected Player player;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")&& anim.GetBool("InCombat")==false)
        {
            return;
        }
        Movement();

    }

    

    public virtual void Movement()
    {
        if (transform.position == PointA.position)
        {
            anim.SetTrigger("Idle");
            target = PointB.transform.position;
            sr.flipX = false;
        }
        else if (transform.position == PointB.position)
        {
            anim.SetTrigger("Idle");
            target = PointA.transform.position;
            sr.flipX = true;
        }

        if (IsHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }


       
    }
}
   


