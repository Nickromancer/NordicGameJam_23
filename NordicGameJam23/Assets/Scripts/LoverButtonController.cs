using UnityEngine;

public class LoverButtonController : MonoBehaviour
{
    [SerializeField] bool isYes = true;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject targetRight;
    [SerializeField] GameObject targetLeft;
    [SerializeField] float velocity = 10f;
    private bool isClicked;

    private void Update() 
    {
        if(isClicked)
        {
            if(isYes)
            {
                parent.transform.position = Vector3.Lerp(parent.transform.position, targetRight.transform.position, velocity);
            }
            else
            {
                parent.transform.position = Vector3.Lerp(parent.transform.position, targetLeft.transform.position, velocity);
            }
        }
    }
    public void OnClick()
    {
        isClicked = true;
    }
}    
