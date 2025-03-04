using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private Slider healthBar;

    private void Start()
    {
        if (healthBar)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KamiKaze"))
        {
            TakeDamage(2);
            Destroy(other.gameObject);
        } else if (other.CompareTag("Fighter"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        } else if (other.CompareTag("Fighter2"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0)
        {
            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

