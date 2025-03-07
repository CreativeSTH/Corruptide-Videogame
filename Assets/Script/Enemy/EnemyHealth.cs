using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health;

    private void Start()
    {
        if (CompareTag("KamiKaze"))
            health = 8;
        else if (CompareTag("Fighter"))
            health = 2;
        else if (CompareTag("Fighter2"))
            health = 4;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPlayer")) // Ensure bullets have the "Bullet" tag
        {
            TakeDamage(1);
            Destroy(other.gameObject); // Destroy the bullet upon impact
            AudioManager.Instance.PlayFX("enemieDie");

        } else if (other.CompareTag("MissilePlayer"))
        {
            TakeDamage(5);
            Destroy(other.gameObject);
            AudioManager.Instance.PlayFX("enemieDie");
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
