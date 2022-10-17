using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float enemyStartHeatlh = 10f;
    private float enemyHealt;
    public float initialSpeed = 10f;
    [HideInInspector] public float enemySpeed;
    public int drop = 20;
    private bool isDead = false;

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
        if (enemyHealt <= 0 && isDead == false)
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
        isDead = true;
        PlayerStats.Money += drop;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
