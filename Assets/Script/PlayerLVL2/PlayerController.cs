using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 18f;
    [SerializeField] private float xLimit = 6f;
    [SerializeField] private float yMinLimit = -2f;
    [SerializeField] private float yMaxLimit = 3.5f;

    [Header("Shooting Settings")]
    [SerializeField] private GameObject leftProjectilePrefab;
    [SerializeField] private GameObject rightProjectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float missileSpeed = 5f;

    private Transform camTransform;

    void Start()
    {
        camTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        Move();
        HandleShooting();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0.1 && CameraController.finish == false)
        {
            horizontal = 1.7f;
        }
        else if (horizontal < 0.1 && horizontal > -0.1 && CameraController.finish == false)
        {
            horizontal = 0.8f;
        }

        Vector3 movement = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
        transform.position += movement;

        // Apply movement constraints relative to the camera's position
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, camTransform.position.x - xLimit, camTransform.position.x + xLimit);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, camTransform.position.y + yMinLimit, camTransform.position.y + yMaxLimit);
        transform.position = clampedPosition;
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            Shoot(leftProjectilePrefab, true);
        }
        if (Input.GetMouseButtonDown(1)) // Right Click
        {
            Shoot(rightProjectilePrefab, false);
        }
    }

    private void Shoot(GameObject projectilePrefab, bool type)
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, 90));
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = type ? Vector3.right * projectileSpeed : Vector3.right * missileSpeed; // Moves right in a horizontal shooter
            }
        }
    }
}
