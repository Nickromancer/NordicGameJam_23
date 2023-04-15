using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public int totalClicks = 0;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject("GameManager");
                obj.AddComponent<GameManager>();
                DontDestroyOnLoad(obj);
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
