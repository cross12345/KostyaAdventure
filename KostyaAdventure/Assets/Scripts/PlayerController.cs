using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] float speed;
    [Header("Animations")]
    [SerializeField] Animator anim;
    [Header("Attack")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce;
    [SerializeField] float AttackRate;
    private float nextAttack;
    [Header("Stats")]
    public bool Dead = false;
    public int Health;
    public int Max_Health;
    [SerializeField] Image HealthBar;
    [SerializeField] float DestroyTime;
    [Header("Other")]
    public Rigidbody2D rb;
    [SerializeField] Joystick joystickMove;
    [SerializeField] Joystick joystickAttack;
    [HideInInspector] public Vector2 Axis;
    [SerializeField] int damage;

    private void FixedUpdate()
    {
        Axis = new Vector2(joystickMove.Horizontal, joystickMove.Vertical);
        Attack();
        Move();
        Animation();
        Rotate();
    }
    void Animation()
    {
        if (Axis != Vector2.zero)
        {
            anim.SetInteger("State", 1);
        }
        if (Axis == Vector2.zero)
        {
            anim.SetInteger("State", 0);
        }
    }
    void Attack()
    {
        if (joystickAttack.Horizontal != 0 && joystickAttack.Vertical != 0 && Time.time > nextAttack)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().Damage = damage;
            bullet.transform.Rotate(0, 0, Random.Range(0, 1000));
            bullet.GetComponent<Rigidbody2D>().AddForce(joystickAttack.Direction * bulletForce, ForceMode2D.Impulse);
            nextAttack = Time.time + 1f / AttackRate;
        }
    }
    void Rotate()
    {
        if(Axis.x > 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else  if (Axis.x < 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        
        if (joystickAttack.Horizontal != 0 && joystickAttack.Vertical != 0)
        {
            if (joystickAttack.Horizontal > 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else if (joystickAttack.Horizontal < 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
        }
    }
    void Move()
    {
        rb.velocity = new Vector2(Axis.x * speed, Axis.y * speed);
    }

    public void ChangeHealth(int count, bool hurt)
    {
        Health += count;
        float fH = Health;
        float fHM = Max_Health;
        HealthBar.fillAmount = fH / fHM;
        if (hurt)
        {
            anim.Play("PlayerHurt");
        }
        if (Health > Max_Health) { Health = Max_Health; }
        if (Health <= 0)
        {
            Health = 0;
            Death();
        }
    }
    protected void Death()
    {
        Dead = true;
        GetComponentInChildren<BoxCollider2D>().enabled = false;
        anim.SetTrigger("Dead");
        anim.Play("HeavyHurt");
        Invoke("Destroy", DestroyTime);
    }
    protected void Destroy()
    {
        
    }
}
