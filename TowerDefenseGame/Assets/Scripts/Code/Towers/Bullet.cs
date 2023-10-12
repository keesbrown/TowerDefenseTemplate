using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb; 

    [Header("Atributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;
  
    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (!target) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        Destroy(this.gameObject);

        
    }


    // if enemy dies, set bool to false, if bool is false dont do check for health component with a if statement ^^^ 
    // if new enemy spawns, set bool to true so the health component gets checked.
}
