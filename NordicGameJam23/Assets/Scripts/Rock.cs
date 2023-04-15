using UnityEngine;

public class Rock : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        Debug.Log("Pressing rock");
    }

    public void OnClickUp()
    {
        Debug.Log("No longer pressing rock");
    }
}
