using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private bool InputDown() => Input.GetButtonDown("Fire1");
    private bool InputUp() => Input.GetButtonUp("Fire1");

    // ReSharper disable Unity.PerformanceAnalysis
    private IClickable GetClickable()
    {
        Vector2 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(pos, Vector2.zero);
        return hit.collider.gameObject.GetComponent<IClickable>();
    }

    private void Update()
    {
        if (InputDown()) 
            GetClickable()?.OnClick();

        if (InputUp()) 
            GetClickable()?.OnClickUp();
    }
}
