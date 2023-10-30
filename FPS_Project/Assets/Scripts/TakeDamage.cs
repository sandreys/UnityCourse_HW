using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public enum collisionType { Head, Body, Arms }
    public collisionType DamageType;

    public PlayerHealth PlayerHealth;
    public AIHealth AIHealth;

    public int BodyTakeDamageDecrease = 2;
    public int ArmsTakeDamageDecrease = 4;
    public void Start()
    {

    }
    public void Hit(int value)
    {
            AIHealth.TakeDamage(value);      
    }

    public void PlayerHit(int value)
    {    
            PlayerHealth.TakeDamage(value);     
    }
}
