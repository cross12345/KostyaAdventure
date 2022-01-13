using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;
    [SerializeField] ParticleSystem destroyParticle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            if (!collision.transform.GetComponent<Enemy_Basic>().Dead)
            {
                collision.transform.GetComponent<Enemy_Basic>().ChangeHealth(-Damage, true);
            }
        }
        DestroyBullet();
    }
    public void DestroyBullet()
    {
        Instantiate(destroyParticle, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}
