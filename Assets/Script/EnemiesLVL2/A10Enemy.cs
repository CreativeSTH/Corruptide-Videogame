using UnityEngine;

public class A10Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float zigzagAmplitude = 1.5f;
    [SerializeField] private float zigzagFrequency = 2f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;
    private float projectileSpeed = 10f;
    private float nextFireTime;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        transform.position += Vector3.up * Mathf.Sin(Time.time * zigzagFrequency) * zigzagAmplitude * Time.deltaTime;

        if (Time.time >= nextFireTime)
        {
            GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.left * projectileSpeed;
            nextFireTime = Time.time + fireRate;
        }
    }
}

