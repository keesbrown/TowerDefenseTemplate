using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float movespeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private PathFinder pathFinder;

    private void Start() { 
        target = pathFinder.path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == pathFinder.path.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke(); 
                Destroy(gameObject);
                return;
            }
            else
            {
                target = pathFinder.path[pathIndex]; 
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * movespeed;
    }

    public void SetPathFinderInstance(PathFinder pathFinder) {
        this.pathFinder = pathFinder;
    }
}
