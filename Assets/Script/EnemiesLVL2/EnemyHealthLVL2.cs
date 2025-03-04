using UnityEngine;

public class EnemyHealthLVL2 : MonoBehaviour
{
    private int health;

    private void Start()
    {
        if (CompareTag("AH64"))
            health = 6;
        else if (CompareTag("A10"))
            health = 1;
        else if (CompareTag("Su57"))
            health = 3;
    }

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
