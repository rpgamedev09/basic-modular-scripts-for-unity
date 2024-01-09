using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    [SerializeField] private float speed = 10;
    [SerializeField] private float lifetime = 3;
    
    [SerializeField] private new string tag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag)
        {
            OnProjectileCollided();
        }
    }

    //Implement this function while instantiating a new projectile
    //ex - Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity).Init(transform.left);
    public void Init(Vector2 dir)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();   
        rb.velocity = dir * speed;

        Destroy(this.gameObject,lifetime);
    }

    private void OnProjectileCollided()
    {
        if (particle != null)
            particle.Play();
        
        Destroy(gameObject, .2f);
    }

}
