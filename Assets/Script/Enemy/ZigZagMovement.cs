using UnityEngine;

public class ZigZagMovement : MonoBehaviour
{
    [SerializeField] private float xStep = 30f;
    [SerializeField] private float yRange = 35f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    private Transform player;
    private Transform motherShip;
    private Vector3 targetPosition;
    private float moveSpeed = 12f;
    private bool movingToMotherShip = false;
    private float nextFireTime;
    private float fireRate = 4.0f;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj) player = playerObj.transform;

        GameObject shipObj = GameObject.FindGameObjectWithTag("MotherShip");
        if (shipObj) motherShip = shipObj.transform;

        targetPosition = new Vector3(transform.position.x - xStep, yRange, transform.position.z);
    }

    void Update()
    {
        if (PlayerHealth.health < 1) this.enabled = false;

        if (!movingToMotherShip)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
            {
                targetPosition = new Vector3(transform.position.x - xStep, -targetPosition.y, transform.position.z);
            }
        }

        if (transform.position.x < -35 && motherShip)
        {
            movingToMotherShip = true;
            targetPosition = motherShip.position;
        }

        if (movingToMotherShip)
        {
            transform.position = Vector3.MoveTowards(transform.position, motherShip.position, moveSpeed * Time.deltaTime);
        }

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        if (projectilePrefab && firePoint)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, projectilePrefab.transform.rotation);
        }
    }
}
