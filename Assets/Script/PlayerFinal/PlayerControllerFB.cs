using System.Collections;
using UnityEngine;

public class PlayerControllerFB : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float boostMultiplier = 1.8f;
    [SerializeField] private float boostMax = 5f;
    private float boostMeter;
    private bool isBoosting;

    [Header("Constraints")]
    [SerializeField] private float xMin = -2f;
    [SerializeField] private float xMax = 2f;
    [SerializeField] private float yMin = -1.3f;
    [SerializeField] private float yMax = 1f;

    [Header("Shooting Settings")]
    [SerializeField] private GameObject leftProjectilePrefab;
    [SerializeField] private GameObject rightProjectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float projectileSpeed = 10f;

    private Transform camTransform;

    void Start()
    {
        camTransform = Camera.main.transform;
        boostMeter = boostMax;
    }

    void Update()
    {
        Move();
        HandleShooting();
        ManageBoost();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float currentSpeed = moveSpeed * (isBoosting ? boostMultiplier : 1f);
        Vector3 movement = new Vector3(horizontal, vertical, 0) * currentSpeed * Time.deltaTime;
        transform.position += movement;

        // Apply movement constraints relative to the camera's position
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, camTransform.position.x + xMin, camTransform.position.x + xMax);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, camTransform.position.y + yMin, camTransform.position.y + yMax);
        transform.position = clampedPosition;
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            Shoot(leftProjectilePrefab);
        }
        if (Input.GetMouseButtonDown(1)) // Right Click
        {
            Shoot(rightProjectilePrefab);
        }
    }

    private void Shoot(GameObject projectilePrefab)
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 90, 90));
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.forward * projectileSpeed; // Moves right in a horizontal shooter
            }
        }
    }

    private void ManageBoost()
    {
        if (Input.GetKey(KeyCode.Space) && boostMeter > 0)
        {
            isBoosting = true;
            boostMeter -= Time.deltaTime;
        }
        else
        {
            if (boostMeter < 0.1f)
            {
                StartCoroutine(BoostCooldDown());
            } else isBoosting = false;
            if (boostMeter < boostMax)
            {
                boostMeter += Time.deltaTime;
            }
        }
    }

    IEnumerator BoostCooldDown()
    {
        yield return new WaitForSeconds(6f);
        isBoosting = false;
    }
}
