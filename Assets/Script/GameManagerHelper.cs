using UnityEngine;

public class GameManagerHelper : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
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
