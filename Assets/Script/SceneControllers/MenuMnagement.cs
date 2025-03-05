using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMnagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        GameManager.Instance.LoadNextScene();
    }

    public void FxClick()
    {
        AudioManager.Instance.PlayFX("start");
    }

    public void OpenMenu()
    {
        GameManager.Instance.OpenOptionsMenu();
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("CreditsScene", LoadSceneMode.Additive);
    }

     public void CloseCreditsMenu()
    {
        GameManager.Instance.CloseCredits();
    }


}
