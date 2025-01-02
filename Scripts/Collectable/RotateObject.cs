using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 3;

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }
}
