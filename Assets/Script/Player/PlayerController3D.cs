using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("The movement at which the space ship moves")]
    [SerializeField] private float moveSpeed = 5f; // Speed for vertical movement

    [Header("Shooting Settings")]
    [SerializeField] private GameObject leftProjectilePrefab; // Prefab for left click
    [SerializeField] private GameObject rightProjectilePrefab; // Prefab for right click
    [SerializeField] private Transform firePoint; // Position where projectiles are instantiated

    private float projectileSpeed = 100f;
    private float missileSpeed = 60f;
    private Camera mainCamera;
    private Quaternion initialRotation;

    void Start()
    {
        mainCamera = Camera.main;
        initialRotation = transform.rotation; // Store the rotation set in the Scene
    }

    void Update()
    {
        Move();
        RotateTowardsMouse();
        HandleShooting();
    }

    /// <summary>
    /// A method that runs every frame and controlls the movement of the player in the Y axis
    /// </summary>
    private void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += Vector3.up * verticalInput * moveSpeed * Time.deltaTime;
        if (transform.position.y < -35)
        {
            transform.position = new Vector3(transform.position.x, -35, transform.position.z);
        } else if (transform.position.y > 35)
        {
            transform.position = new Vector3(transform.position.x, 35, transform.position.z);
        }
    }

    private void RotateTowardsMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane xyPlane = new Plane(Vector3.forward, Vector3.zero);

        if (xyPlane.Raycast(ray, out float distance))
        {
            Vector3 mousePosition = ray.GetPoint(distance);
            Vector3 direction = mousePosition - transform.position;
            direction.z = 0; // Keep rotation in the X-Y plane

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle = Mathf.Clamp(angle, -70f, 70f); // Ensure rotation stays within -90 to 90 degrees

            transform.rotation = Quaternion.Euler(-angle, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z);
        }
    }


    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            ShootProjectile(leftProjectilePrefab, true);
        }
        if (Input.GetMouseButtonDown(1)) // Right Click
        {
            ShootProjectile(rightProjectilePrefab, false);
        }
    }

    private void ShootProjectile(GameObject projectilePrefab, bool type)
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (type)
                {
                rb.linearVelocity = transform.forward * projectileSpeed;
                } else rb.linearVelocity = transform.forward * missileSpeed;
            }
        }
    }
}
