// Final Boss AI Controller
// - Moves randomly in X and Y axis
// - Shoots single bullets and auto-fire
// - Executes actions in cycles (move, attack, repeat)

using System.Collections;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float actionInterval = 2f;
    [SerializeField] private float projectileSpeed = 20;
    [SerializeField] private float missileSpeed = 12;

    [Header("Shooting Settings")]
    [SerializeField] private GameObject singleShotPrefab;
    [SerializeField] private GameObject autoShotPrefab;
    [SerializeField] private Transform firePoint;

    private Transform player;
    private Animator animator;
    private bool isAttacking = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        StartCoroutine(BossBehaviorLoop());
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private IEnumerator BossBehaviorLoop()
    {
        while (true)
        {
            if (!isAttacking)
            {
                ChooseRandomAction();
                yield return new WaitForSeconds(actionInterval);
            }
        }
    }

    private void ChooseRandomAction()
    {
        int action = Random.Range(0, 4);

        switch (action)
        {
            case 0:
                MoveLeft();
                break;
            case 1:
                MoveRight();
                break;
            case 2:
                Jump();
                break;
            case 3:
                if (Random.Range(0, 2) == 0)
                    StartCoroutine(ShootAuto());
                else
                    ShootSingle();
                break;
        }
    }

    private void MoveLeft()
    {
        animator.SetBool("WalkLeft", true);
        StartCoroutine(Move(Vector3.left));
    }

    private void MoveRight()
    {
        animator.SetBool("WalkRight", true);
        StartCoroutine(Move(Vector3.right));
    }

    private IEnumerator Move(Vector3 direction)
    {
        float moveTime = actionInterval;
        while (moveTime > 0)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.3f, 7.3f), transform.position.y, transform.position.z);
            moveTime -= Time.deltaTime;
            yield return null;
        }

        animator.SetBool("WalkLeft", false);
        animator.SetBool("WalkRight", false);
    }

    private void Jump()
    {
        animator.SetBool("Jump", true);
        StartCoroutine(ExecuteJump());
    }

    private IEnumerator ExecuteJump()
    {
        float jumpProgress = 0f;
        while (jumpProgress < 1f)
        {
            transform.position += Vector3.up * jumpHeight * Time.deltaTime;
            jumpProgress += Time.deltaTime;
            yield return null;
        }
        animator.SetBool("Jump", false);
    }

    private void ShootSingle()
    {
        animator.SetBool("ShootSing", true);
        GameObject projectile = Instantiate(singleShotPrefab, firePoint.position, Quaternion.Euler(0, 90, 90));
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.back * missileSpeed; // Moves right in a horizontal shooter
        }
        StartCoroutine(ResetShooting("ShootSing"));
    }

    private IEnumerator ShootAuto()
    {
        animator.SetBool("ShootAuto", true);
        isAttacking = true;

        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject projectile = Instantiate(autoShotPrefab, firePoint.position, Quaternion.Euler(0, 90, 90));
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.back * projectileSpeed; // Moves right in a horizontal shooter
            }
        }

        isAttacking = false;
        StartCoroutine(ResetShooting("ShootAuto"));
    }

    private IEnumerator ResetShooting(string animationBool)
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool(animationBool, false);
    }

    public void Die()
    {
        animator.SetBool("Die", true);
        // End the game, trigger explosion, disable boss
    }
}
