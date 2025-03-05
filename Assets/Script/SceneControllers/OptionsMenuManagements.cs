using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuManagement : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider musicSlider;

    // Inicialización
    void Awake()
    {
        // Cargar los valores guardados o usar valores predeterminados si no existen
        float sfxVolume = PlayerPrefs.GetFloat("FxVolume", 0f); // Valor predeterminado en 0 dB
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f); // Valor predeterminado en 0 dB

        // Asignar los valores a los sliders
        sfxSlider.value = sfxVolume;
        musicSlider.value = musicVolume;

        // Aplicar los valores al AudioMixer
        SetFxVolume(sfxVolume);
        SetMusicVolume(musicVolume);
    }

    void Start()
    {
        // Asignar los métodos a los eventos de cambio de valor de los sliders
        sfxSlider.onValueChanged.AddListener(SetFxVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    // Método para ajustar el volumen de los efectos de sonido
    public void SetFxVolume(float volume)
    {
        Debug.Log($"Setting FX Volume: {volume}");
        if (AudioManager.Instance.audioMixer != null)
        {
            // Asigna directamente el valor en dB al AudioMixer
            AudioManager.Instance.audioMixer.SetFloat("Fx", volume);
            PlayerPrefs.SetFloat("FxVolume", volume); // Guarda el valor
        }
    }

    // Método para ajustar el volumen de la música
    public void SetMusicVolume(float volume)
    {
        Debug.Log($"Setting Music Volume: {volume}");
        if (AudioManager.Instance.audioMixer != null)
        {
            // Asigna directamente el valor en dB al AudioMixer
            AudioManager.Instance.audioMixer.SetFloat("Music", volume);
            PlayerPrefs.SetFloat("MusicVolume", volume); // Guarda el valor
        }
    }

    // Método para cerrar el menú de opciones
    public void CloseMenu()
    {
        PlayerPrefs.Save(); // Guarda los valores en disco
        SceneManager.UnloadSceneAsync("Options");
    }

    // Método para reproducir un efecto de sonido al hacer clic
    public void FxClick()
    {
        AudioManager.Instance.PlayFX("start");
    }
}