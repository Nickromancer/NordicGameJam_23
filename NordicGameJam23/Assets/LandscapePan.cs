using UnityEngine;
using UnityEngine.EventSystems;

public class LandscapePan : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Camera cam;
    [SerializeField] float panSpeed = 5f;

    private bool isMouseOver = false;

    private void Update()
    {
        if (isMouseOver)
        {
            Debug.Log("Hovering");
            PanCam();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

    private void PanCam()
    {
        if (gameObject.name == "RightColum")
        {
            Debug.Log("Hello right");
            cam.transform.position += new Vector3(panSpeed * Time.deltaTime, 0, 0);
        }
        if (gameObject.name == "LeftColum")
        {
            Debug.Log("Hello left");
            cam.transform.position -= new Vector3(panSpeed * Time.deltaTime, 0, 0);
        }
    }
}
