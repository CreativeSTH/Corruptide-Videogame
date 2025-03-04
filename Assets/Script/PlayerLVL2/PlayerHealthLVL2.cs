using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthLVL2 : MonoBehaviour
{
    public static int health = 22;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        } else if (other.CompareTag("Su57"))
        {
            TakeDamage(7);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("AH64"))
        {
            TakeDamage(4);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("A10"))
        {
            TakeDamage(2);
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
