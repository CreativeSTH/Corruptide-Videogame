using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthFB : MonoBehaviour
{
    public static int health = 9;


    private void OnTriggerEnter(Collider other)
    {

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

        
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1.5f);
        health = 9;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
