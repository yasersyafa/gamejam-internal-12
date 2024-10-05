using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int health;
    
    // constructor
    public HealthSystem(int initialHealth) {
        health = initialHealth;
    }

    // use this function to get health Data
    public int GetHealth() {
        return health;
    } 

    // function to decrease the player's health
    public void DecreaseHealth(int damage) {
        health -= damage;
        if(health < 0) {
            health = 0;
        }
    }

    // check if player dead or not
    public bool IsDead() {
        return health <= 0;
    }
    
}
