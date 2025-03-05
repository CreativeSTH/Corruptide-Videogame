using UnityEngine;
using TMPro; // Importar TextMeshPro

public class PlayerController3D : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Shooting Settings")]
    [SerializeField] private GameObject leftProjectilePrefab;
    [SerializeField] private GameObject rightProjectilePrefab;
    [SerializeField] private Transform firePoint;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI missileText; // 🔹 Referencia al texto de misiles

    private float projectileSpeed = 100f;
    private float missileSpeed = 60f;
    private Camera mainCamera;
    private Quaternion initialRotation;

    private int maxMissiles = 20;
    public int missileCount = 0;

    void Start()
    {
        mainCamera = Camera.main;
        initialRotation = transform.rotation;
        missileCount = maxMissiles; // 🔹 El jugador comienza con 20 misiles
        UpdateMissileUI(); // 🔹 Actualizar la UI al iniciar
    }

    void Update()
    {
        Move();
        RotateTowardsMouse();
        HandleShooting();
    }

    private void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += Vector3.up * verticalInput * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -35, 35), transform.position.z);
    }

    private void RotateTowardsMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane xyPlane = new Plane(Vector3.forward, Vector3.zero);

        if (xyPlane.Raycast(ray, out float distance))
        {
            Vector3 mousePosition = ray.GetPoint(distance);
            Vector3 direction = mousePosition - transform.position;
            direction.z = 0;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle = Mathf.Clamp(angle, -70f, 70f);

            transform.rotation = Quaternion.Euler(-angle, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z);
        }
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0)) // Click Izquierdo (Proyectiles ilimitados)
        {
            ShootProjectile(leftProjectilePrefab, projectileSpeed);
        }
        if (Input.GetMouseButtonDown(1)) // Click Derecho (Misiles limitados)
        {
            ShootMissile(rightProjectilePrefab);
        }
    }

    private void ShootProjectile(GameObject projectilePrefab, float speed)
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = transform.forward * speed;
            }
        }
    }

    private void ShootMissile(GameObject missilePrefab)
    {
        if (missileCount <= 0) return; // No dispara si no hay misiles

        if (missilePrefab != null && firePoint != null)
        {
            GameObject missile = Instantiate(missilePrefab, firePoint.position, transform.rotation);
            Rigidbody rb = missile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = transform.forward * missileSpeed;
            }

            missileCount--; // 🔹 Restar un misil al disparar
            UpdateMissileUI(); // 🔹 Actualizar la UI
            Debug.Log("Misil disparado. Restantes: " + missileCount);
        }
    }

    public void AddMissiles(int amount)
    {
        missileCount = Mathf.Clamp(missileCount + amount, 0, maxMissiles);
        UpdateMissileUI(); // 🔹 Actualizar la UI
        Debug.Log("Misiles añadidos: " + amount + " | Total: " + missileCount);
    }

    private void UpdateMissileUI()
    {
        if (missileText != null)
        {
            missileText.text = "Misiles: " + missileCount; // 🔹 Mostrar la cantidad de misiles
        }
    }
}
