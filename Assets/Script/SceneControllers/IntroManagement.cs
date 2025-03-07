using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    
    public GameObject panelGameOver; 
    public GameObject panelPause;
    public GameObject panelGameWin;
    public Slider sliderMusic;   // Asigna el Slider de música desde el Inspector
    public Slider sliderFx;      // Asigna el Slider de FX desde el Inspector
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.PlayMusic("spaceAmbient");
    }

    // Método para manejar la entrada del usuario (Enter o clic)
    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter o clic izquierdo
        {
            AudioManager.Instance.PlayFX("start");
            GameManager.Instance.PressStart();
        }
    }
    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    public void FxClick()
    {
        AudioManager.Instance.PlayFX("start");
    }

    public void SetMusicVolume(float volume)
    {
        if (AudioManager.Instance.audioMixer != null)
        {
            // Convierte el valor lineal del slider a logarítmico para el AudioMixer
            AudioManager.Instance.audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("MusicVolume", volume); // Guarda el valor
        }
    }

    public void SetFxVolume(float volume)
    {
        if (AudioManager.Instance.audioMixer != null)
        {
            // Convierte el valor lineal del slider a logarítmico para el AudioMixer
            AudioManager.Instance.audioMixer.SetFloat("Fx", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("FxVolume", volume); // Guarda el valor
        }
    }

    public void OpenMenu()
    {
        GameManager.Instance.OpenOptionsMenu();
    }

    //panels
    public void GameOver(){
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("¡Has perdido!");
    }
}
