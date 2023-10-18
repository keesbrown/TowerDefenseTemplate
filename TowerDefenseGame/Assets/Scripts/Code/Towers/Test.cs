using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour // BuildManager
{
    public static  Test main;

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;

    private int selectedTower = 0;

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    } 
    
    public int currency;
    private void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
    }
}
