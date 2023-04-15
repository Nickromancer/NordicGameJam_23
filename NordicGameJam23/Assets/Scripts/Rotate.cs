using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 1f;
    void Update()
    {
        transform.Rotate(0, 0, 360 * rotateSpeed * Time.deltaTime);
    }
}
