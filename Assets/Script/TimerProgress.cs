using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class TimerProgress : MonoBehaviour
{
    public float remainingTime = 120f; // 2 minutos
    public TMP_Text timerText; 

    [SerializeField] GameManagerHelper gameManagerHelper;

    void Start()
    {
        gameManagerHelper = FindAnyObjectByType<GameManagerHelper>();
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTex();
        }
        else
        {
            NexrtLevel();
        }
    }

    void UpdateTex()
    {
        int minutos = Mathf.FloorToInt(remainingTime / 60);
        int segundos = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("TIME:{0:00}:{1:00}", minutos, segundos);
    }

    void NexrtLevel()
    {
        gameManagerHelper.WinLevel();
    }
}
