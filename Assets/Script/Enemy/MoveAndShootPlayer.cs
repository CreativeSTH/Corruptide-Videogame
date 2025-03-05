using UnityEngine;

public class MoveAndShootAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 2f;
    private float moveSpeed = 5f;
    private Transform player;
    private float nextFireTime;
    private Transform motherShip;
    

    void Start()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target) player = target.transform;

        GameObject target2 = GameObject.FindGameObjectWithTag("MotherShip");
        if (target2) motherShip = target2.transform;
    }

    void Update()
    {
        if (PlayerHealth.health < 1) this.enabled = false;

        if (player)
        {
            if (transform.position.x < -35)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                Vector3 direction = (motherShip.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(-angle, 90, -90);
            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                Vector3 direction = (player.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(-angle, 90, -90);
            }
        }

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        if (projectilePrefab && firePoint && transform.position.x < 65)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = transform.forward * 80;
            }
        }
    }
}