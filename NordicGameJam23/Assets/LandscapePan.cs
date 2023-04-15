using UnityEngine;
using UnityEngine.EventSystems;
public class LandscapePan : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float panSpeed = 1f;
    private void Update() 
    {
        if (IsMouseOverUI())
        {
            Debug.Log("Hovering");
            PanCam();
        } 
    }

    private bool IsMouseOverUI() 
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void PanCam()
    {
        if (gameObject.name == "RightColum")
        {
            Debug.Log("Hello");
            cam.transform.position += new Vector3(panSpeed * Time.deltaTime, 0, 0);
        }
        if (gameObject.name == "LeftColum")
        {
            cam.transform.position += new Vector3(-panSpeed * Time.deltaTime, 0, 0);
        }
    }
}
