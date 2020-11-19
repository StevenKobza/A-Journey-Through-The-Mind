using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Onboarding : MonoBehaviour
{
    public Button _button;
    private Scene _thisScene;
    public AudioSource _bgAudio;
    public AudioClip _bgClip;

    // Start is called before the first frame update
    void Start()
    {
        
        _button.onClick.AddListener(ContinueTour);
        _thisScene = this.gameObject.scene;
        if (_thisScene.name == "Starting")
        {
            Settings.volume = 1.0f;
            Settings.musicSet = true;
        }
        PlaySound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ContinueTour()
    {
        Debug.Log(_thisScene.name);
        switch (_thisScene.name)
        {
            case "Starting":
                SceneManager.LoadSceneAsync("Onboarding1", LoadSceneMode.Single);
                break;
            case "Onboarding1":
                SceneManager.LoadSceneAsync("Onboarding2", LoadSceneMode.Single);
                break;
            case "Onboarding2":
                SceneManager.LoadSceneAsync("Onboarding3", LoadSceneMode.Single);
                break;
            case "Onboarding3":
                SceneManager.LoadSceneAsync("Onboarding4", LoadSceneMode.Single);
                break;
            case "Onboarding4":
                SceneManager.LoadSceneAsync("Onboarding5", LoadSceneMode.Single);
                break;
            case "Onboarding5":
                SceneManager.LoadSceneAsync("HubRoom", LoadSceneMode.Single);
                break;
        }
    }

    void PlaySound()
    {
        _bgAudio.clip = _bgClip;
        _bgAudio.volume = Settings.volume;
    }
}
