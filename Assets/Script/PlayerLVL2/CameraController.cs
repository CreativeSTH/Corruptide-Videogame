using UnityEngine;

// Camera Controller: Moves constantly forward
public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float levelLenght = 400;

    public static bool finish = false;
    public static float xPosition;


    void Update()
    {
        if (transform.position.x < levelLenght)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            xPosition = transform.position.x;
        }
        else if (finish == false)
        {
            finish = true;
            xPosition = transform.position.x;
        }
    }
}
