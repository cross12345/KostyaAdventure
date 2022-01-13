using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic : MonoBehaviour
{
    [SerializeField] protected string Type;
    [SerializeField] protected float speed;
    [SerializeField] protected int Health;
    [SerializeField] protected GameObject player;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Update()
    {
        Move();
    }

    protected void Move()
    {
        if (player.transform.position.x < transform.position.x)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        if (player.transform.position.x > transform.position.x)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }
}
