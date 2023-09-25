using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] private int hitPoint = 2;

    public void TakeDamage(int dmg)
    {
        hitPoint -= dmg;

        if (hitPoint <= 0)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}
