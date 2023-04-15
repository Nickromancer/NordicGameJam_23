using UnityEngine;
using UnityEngine.UI;
public class ItemCollecter : MonoBehaviour
{
    [SerializeField] Text scoreCounter;
    int points = 0;

    private void OnTriggerEnter2D(Collider2D other)   
    {
        if (other.gameObject.CompareTag("Treasure"))
        {
            Destroy(other.gameObject);
            points++;
            Debug.Log("Points: " + points);
            scoreCounter.text = "Points: " + points;
        }    
    }
}
