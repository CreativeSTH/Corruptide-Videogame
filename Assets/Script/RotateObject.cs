using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotateLife;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateLife);
    }
}
