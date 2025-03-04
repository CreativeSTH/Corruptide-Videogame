using UnityEngine;

public class FastEnemy : MonoBehaviour
{
    private float moveSpeed = 7f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player && transform.position.x > player.transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        } else transform.position = Vector3.MoveTowards(transform.position, Vector3.left * 1000, moveSpeed * Time.deltaTime);
    }
}
