using UnityEngine;
using UnityEngine.EventSystems;

public class LandscapePan : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Camera cam;
    [SerializeField] float panSpeed = 5f;
    // [SerializeField] float maxPan = 10f;
    [SerializeField] GameObject landscape;
    float minX;
    float maxX;

    private void Awake()
    {
        CalculateBounds();
    }

    private void CalculateBounds()
    {
        Renderer landscapeRenderer = landscape.GetComponent<Renderer>();
        float landscapeHalfWidth = landscapeRenderer.bounds.size.x / 2;
        float cameraHalfWidth = cam.orthographicSize * cam.aspect;

        minX = -landscapeHalfWidth + cameraHalfWidth;
        maxX = landscapeHalfWidth - cameraHalfWidth;
    }



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
        Vector3 targetPosition = cam.transform.position;

        if (gameObject.name == "RightColum")
        {
            targetPosition.x += panSpeed * Time.deltaTime;
        }
        if (gameObject.name == "LeftColum")
        {
            targetPosition.x -= panSpeed * Time.deltaTime;
        }

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        cam.transform.position = targetPosition;
    }

}
