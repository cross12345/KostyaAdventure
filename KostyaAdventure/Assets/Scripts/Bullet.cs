using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyParticle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBullet();
    }
    public void DestroyBullet()
    {
        Instantiate(destroyParticle, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}
