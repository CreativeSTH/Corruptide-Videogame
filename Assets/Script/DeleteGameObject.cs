using UnityEngine;

public class DeleteGameObject : MonoBehaviour
{
    float limit = 10.5f;
    void Update()
    {
        if (transform.position.y > limit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -limit){
            Destroy(gameObject);
        }

    }
}
