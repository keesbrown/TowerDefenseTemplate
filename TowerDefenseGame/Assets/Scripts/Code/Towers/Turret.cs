using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Atribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float bps = 1f;

    private Transform target;
    private float timeUntilFire;

    private void Update()
    {
        if (target == null) 
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

       if (!CheckTargetIsInRange())
        {
       }
       else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject buleltobj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = buleltobj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2) transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void RotateTowardsTarget() 
    {
        //float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x)
        //* Mathf.Rad2Deg + -90f;

        //Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        //turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, 
        //rotationSpeed * Time.deltaTime);

        Vector2 direction = target.position - turretRotationPoint.position;
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, direction);

        turretRotationPoint.rotation = Quaternion.Lerp(turretRotationPoint.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnDrawGizmoSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

}
