using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour // LevelManager
{
    public Transform startPoint; 
    public Transform[] path;

    public static PathFinder main;

    public int currency;

    private void Start()
    {
        currency = 100;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else 
        {
            Debug.Log("You dont have enough to purchase this item");
            return false;
        }
    }

}
