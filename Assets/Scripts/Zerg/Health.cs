using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int currentHealth;
    public int startHealth=100;
    private Death death;

    void Awake()
    {
        currentHealth = startHealth;
        death = GetComponent<Death>();
    }

    void Update()
    {
        
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public void HealHealth(int size_heal)
    {
        currentHealth += size_heal;
    }
    public void TakeDamage(int size_damage)

    {
        currentHealth -= size_damage;
        if (currentHealth <= 0) Kill();
        Debug.Log("Damage=="+size_damage);
    }

    private void Kill()
    {
        death.Kill();
    }
}
