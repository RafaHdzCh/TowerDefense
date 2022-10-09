using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathEffect;
    private int enemyHealt = 10;
    private const float initialSpeed = 10f;
    [HideInInspector] public float enemySpeed;
    private const int drop = 20;

    private void Start()
    {
        enemySpeed = initialSpeed;
    }

    public void TakeDamage(int amount)
    {
        enemyHealt -= amount;
        if(enemyHealt <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += drop;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}
