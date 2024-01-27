using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 69f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.rotation.y > -0.5f)
                RotateObject(-1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (transform.rotation.y < 0.5f)
            {
                RotateObject(1);
            }
        }
    }

    void RotateObject(float direction)
    {
        float rotationAmount = rotationSpeed * direction * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);
    }
}
