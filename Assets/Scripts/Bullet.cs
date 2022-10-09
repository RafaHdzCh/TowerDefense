using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [Header("Bullet Attributes")]
    [SerializeField] GameObject impactEffect;
    public float bulletspeed = 70f;
    public int bulletDamage = 5;
    public float effectDuration = 0.5f;
    public float explosionRadius = 0f;
    
    

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletspeed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, effectDuration);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    private void Damage(Transform enemy)
    {
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript == null) return;

        enemyScript.TakeDamage(bulletDamage);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
