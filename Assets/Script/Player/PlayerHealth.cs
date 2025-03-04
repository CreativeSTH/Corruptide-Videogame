using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int health = 9;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision detected with {other.gameObject.name}");

        if (other.CompareTag("Missile"))
        {
            TakeDamage(5);
        }
        else if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }

        Debug.Log($"Player Health after collision: {health}");
        Destroy(other.gameObject);
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
