using UnityEngine;

public class TimelineManagement : MonoBehaviour
{
    public void FxClick()
    {
        AudioManager.Instance.PlayFX("start");
    }

    public void StartLevelOne()
    {
        GameManager.Instance.LoadSceneByName("Scene1");
    }
}
