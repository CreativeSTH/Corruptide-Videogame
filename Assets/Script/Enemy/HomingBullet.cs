// Bullet Tracking Script: Makes a bullet follow the "Player" and switches to "MotherShip" if x < 40
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Transform player;
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
        if (player && transform.position.x > -42.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (motherShip)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.left * 1000, speed * Time.deltaTime);
            Vector3 direction = (motherShip.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}