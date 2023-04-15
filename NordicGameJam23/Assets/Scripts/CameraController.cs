using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    private List<IClickable> heldItems = new();

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
        return hit.collider != null ? hit.collider.gameObject.GetComponent<IClickable>() : null;
    }

    private void Update()
    {
        if (InputDown())
        {
            var click = GetClickable();
            heldItems.Add(click);
            click.OnClick();
        }

        if (InputUp())
        {
            foreach (var item in heldItems) 
                item.OnClickUp();
            heldItems.Clear();
        }
    }
}
