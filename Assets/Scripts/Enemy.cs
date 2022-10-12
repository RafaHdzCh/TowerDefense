using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    private float enemyStartHeatlh = 10f;
    private float enemyHealt;
    private const float initialSpeed = 10f;
    [HideInInspector] public float enemySpeed;
    private const int drop = 20;

    [Header("Enemy Components")]
    [SerializeField] GameObject deathEffect;
    [SerializeField] Image healthBar;

    private void Start()
    {
        enemySpeed = initialSpeed;
        enemyHealt = enemyStartHeatlh;
    }

    public void TakeDamage(int amount)
    {
        enemyHealt -= amount;
        Debug.Log(enemyHealt / 10);
        healthBar.fillAmount = (enemyHealt / enemyStartHeatlh);
        if (enemyHealt <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        healthBar.fillAmount = (enemyHealt / enemyStartHeatlh);
    }

    void Die()
    {
        PlayerStats.Money += drop;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}
