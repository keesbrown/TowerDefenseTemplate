using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    private Color startColor;

    private bool canSpawnTower;
    private void Start()
    {
        startColor = sr.color;
        canSpawnTower = true;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {

        if (canSpawnTower == true)
        {
            canSpawnTower = false;
            GameObject towerToBuild = Test.main.GetSelectedTower();
            GameObject tower = Instantiate(towerToBuild, transform.position, quaternion.identity);
        }

    }
}
