using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ItemCollecter : MonoBehaviour
{
    [SerializeField] Text scoreCounter;
    [SerializeField] Text lifeCounter;
    int points = 0;
    int lives = 3;

    [SerializeField] int point_goal = 30;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip treasureSound;
    [SerializeField] AudioClip skullSound;
    [SerializeField] AudioClip swordSound;


    private void addPoints(int p)
    {
        points += p;
        Debug.Log("Points: " + points);
        scoreCounter.text = "" + points;

        if (points >= point_goal)
        {
            // TODO: Show win screen
            Debug.Log("You win!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void subtractLives(int l)
    {
        lives -= l;
        Debug.Log("Lives: " + lives);
        if (lives > 0)
        {
            lifeCounter.text = "" + lives;
        }
        else
        {
            lifeCounter.text = "0";
            GameOver();
        }
    }

    private void GameOver()
    {
        // Show game over screen
        SceneManager.LoadScene("EndMenu");
    }

    private void PlayCollectSound(AudioClip clip)
    {
        if (audioSource && clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Treasure":
                Destroy(other.gameObject);
                addPoints(1);
                PlayCollectSound(treasureSound); // Update this line
                break;
            case "Skull":
                Destroy(other.gameObject);
                subtractLives(1);
                PlayCollectSound(skullSound); // Update this line
                break;
            case "Sword":
                Destroy(other.gameObject);
                subtractLives(1);
                PlayCollectSound(swordSound); // Update this line
                break;
        }
    }
}
