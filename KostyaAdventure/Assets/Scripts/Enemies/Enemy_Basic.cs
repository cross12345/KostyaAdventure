using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic : MonoBehaviour
{
    [SerializeField] protected string Type;
    [SerializeField] protected float speed;
    [SerializeField] protected int Health;
    [SerializeField] protected int Max_Health;
    [SerializeField] protected GameObject player;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator anim;
    [SerializeField] protected float FOV;
    [SerializeField] protected bool DrawFOV;
    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] protected float DestroyTime;
    public  bool Dead = false;
    protected Collider2D PlayerInFov;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update()
    {
        PlayerInFov = Physics2D.OverlapCircle(transform.position, FOV, playerLayer);
        if (PlayerInFov != null && !Dead)
        {
            Move();
            anim.SetInteger("State", 1);
        }
        else
        {
            anim.SetInteger("State", 0);
        }

    }

    protected void Move()
    {
        transform.right = player.transform.position - transform.position;
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (player.transform.position.x < transform.position.x)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        if (player.transform.position.x > transform.position.x)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (DrawFOV)
        {
            Gizmos.DrawWireSphere(transform.position, FOV);
        }
    }
    public void ChangeHealth(int count, bool hurt)
    {
        Health += count;
        if (hurt)
        {
            anim.Play("Hurt");
        }
        if (Health > Max_Health) { Health = Max_Health; }
        if (Health<=0) 
        {
            Health = 0;
            Death();
        }
    }
    protected void Death()
    {
        Dead = true;
        anim.SetTrigger("Dead");
        anim.Play("HeavyHurt");
        Invoke("Destroy", DestroyTime);
    }
    protected void Destroy()
    {
        Destroy(gameObject);
    }
}
