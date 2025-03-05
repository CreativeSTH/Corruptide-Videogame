using UnityEngine;
using UnityEngine.UI;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private Slider healthBar;
    [SerializeField] private IntroController introController;

    private void Start()
    {
        introController = FindAnyObjectByType<IntroController>();

        if (healthBar)
        {
            healthBar.maxValue = health;
            healthBar.value = health; // Inicializamos la barra de vida
        }
    }

    private void Update()
    {
        if (healthBar)
        {
            healthBar.value = health; // Actualiza el slider directamente
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KamiKaze"))
        {
            TakeDamage(2);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Fighter") || other.CompareTag("Fighter2"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0); // Evita que la vida sea negativa

        if (health <= 0)
        {
            introController.GameOver();
        }
    }
}
