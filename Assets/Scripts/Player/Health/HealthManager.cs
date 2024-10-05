using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private HealthSystem playerHealth;

    // Damage yang diterima ketika menyentuh DeathZone
    public int damageOnDeathZone = 5;

    void Start()
    {
        // Set health awal 100
        playerHealth = new HealthSystem(100);
    }

    public void TakeDamage()
    {
        // Kurangi health player
        playerHealth.DecreaseHealth(damageOnDeathZone);
        Debug.Log("Player terkena DeathZone! Health berkurang. Health sekarang: " + playerHealth.GetHealth());
    }

    public bool IsPlayerDead()
    {
        return playerHealth.IsDead();
    }
}
