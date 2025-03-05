using UnityEngine;

public class DeleteProjectile : MonoBehaviour
{
    float limitY = 60f;
    float limitXMax = 103f;
    float limitXMin = -88f;

    void Update()
    {
        if (transform.position.y > limitY)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -limitY){
            Destroy(gameObject);
        }

        if (transform.position.x > limitXMax)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < limitXMin){
            Destroy(gameObject);
        }

    }
}