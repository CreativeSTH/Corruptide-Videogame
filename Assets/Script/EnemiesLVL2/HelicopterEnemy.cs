using UnityEngine;

public class HelicopterEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float trackingSpeed = 1.5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;
    private float projectileSpeed = 10f;
    private Transform player;
    private float nextFireTime;
    private bool reachedStartPosition = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(CameraController.xPosition + 5.5f, transform.position.y, -2f);

        if (!reachedStartPosition)
        {
            Vector3 reachedTarget = CameraController.finish == false ?
                new Vector3(CameraController.xPosition + 5f, player.position.y, -2f) :
                new Vector3(transform.position.x, player.position.y, -2f);
            transform.position = Vector3.MoveTowards(transform.position, reachedTarget, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                reachedStartPosition = true;
            }
        }
        else if (player)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, player.position.y, transform.position.z), trackingSpeed * Time.deltaTime);
        }
        if (Time.time >= nextFireTime)
        {
            GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.left * projectileSpeed;
            nextFireTime = Time.time + fireRate;
        }
    }
}