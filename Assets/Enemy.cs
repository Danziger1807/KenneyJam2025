using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 200;


    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
