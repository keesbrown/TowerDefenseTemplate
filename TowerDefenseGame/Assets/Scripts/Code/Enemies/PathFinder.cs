using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public static PathFinder main;

    public Transform startPoint; 
    public Transform[] path;

    private void Awake() { 
        main = this;
        
    }
}
