using System;
using UnityEngine;

public class SpellManual : MonoBehaviour
{
    public static SpellManual Instance { get; private set; }
    
    public bool hasVelocity;
    public bool hasGravity;
    public bool hasForce;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}