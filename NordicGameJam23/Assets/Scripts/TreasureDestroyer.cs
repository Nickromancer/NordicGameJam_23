using UnityEngine;

public class TreasureDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy(other.gameObject);    
    }
}
