using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int health = 9;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision detected with {other.gameObject.name}");

        if (other.CompareTag("Missile"))
        {
            TakeDamage(5);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }

        Debug.Log($"Player Health after collision: {health}");
        
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Taking damage: {damage}, Remaining Player Health: {health}");

        if (health <= 0)
        {
            Debug.Log("Player Health reached 0. Reloading scene...");
            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
