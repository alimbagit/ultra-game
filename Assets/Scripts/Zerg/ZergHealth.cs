using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZergHealth : MonoBehaviour
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
    }

    private void Kill()
    {
        Destroy(this.gameObject);
    }
}
