using UnityEngine;

public class MissileBox : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento hacia el jugador
    private Transform player; // Referencia al jugador

    void Start()
    {
        // Buscar al jugador por el Tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró un objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Mover la caja hacia el jugador
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Intentamos encontrar el script del jugador y sumarle los misiles
            PlayerController3D playerScript = other.GetComponent<PlayerController3D>();
            AudioManager.Instance.PlayFX("powerUp");

            if (playerScript != null)
            {
                playerScript.AddMissiles(20); // Agrega 20 misiles
            }

            Destroy(gameObject); // Destruye la caja una vez recogida
        }
    }
}
