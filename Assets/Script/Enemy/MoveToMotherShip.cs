using UnityEngine;

public class MoveToMotherShip : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Transform motherShip;

    void Start()
    {
        GameObject target = GameObject.FindGameObjectWithTag("MotherShip");
        if (target) motherShip = target.transform;
    }

    void Update()
    {
        if (PlayerHealth.health < 1) this.enabled = false;

        if (motherShip)
        {
            transform.position = Vector3.MoveTowards(transform.position, motherShip.position, moveSpeed * Time.deltaTime);
        }
    }
}
