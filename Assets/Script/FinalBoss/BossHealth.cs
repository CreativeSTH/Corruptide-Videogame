using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private int health = 90;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPlayer")) // Ensure bullets have the "Bullet" tag
        {
            TakeDamage(1);
            Destroy(other.gameObject); // Destroy the bullet upon impact
        }
        else if (other.CompareTag("MissilePlayer"))
        {
            TakeDamage(5);
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining health: {health}");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
