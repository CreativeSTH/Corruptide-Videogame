using UnityEngine;

public class GameManagerHelper : MonoBehaviour
{
    public GameManager gameManager;

    void Awake()
    {
        AudioManager.Instance.StopMusic();
    }

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        AudioManager.Instance.PlayMusic("intro");
    }

    public void RestartLevel()
    {
        gameManager.RestartLevel();
    }

    public void WinLevel()
    {
        gameManager.WinLevel();
    }
}
