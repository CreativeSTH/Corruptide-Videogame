using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public static int health = 10;
    [SerializeField] private Slider healthBar;
    [SerializeField] IntroController introController;


    void Start()
    {
        introController = FindAnyObjectByType<IntroController>();
        health = 10;
        
        //healthBar.value = health;
    }

    void Update()
    {
        healthBar.value = health;
    }


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
            // open Panel gameOver script IntroController
            introController.GameOver();

        }
    }

}