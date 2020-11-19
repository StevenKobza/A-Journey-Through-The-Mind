using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsAdjust : MonoBehaviour
{
    public Toggle _musicOnOff;
    public Slider _volume;
    public Button exit;
    public Scene sceneToCall;
    public AudioSource bgAudio;

    // Start is called before the first frame update
    void Start()
    {
        _musicOnOff.isOn = Settings.musicSet;
        _volume.SetValueWithoutNotify(Settings.volume);
        _musicOnOff.onValueChanged.AddListener(delegate { TurnMusic(); });
        _volume.onValueChanged.AddListener(delegate { TurnVolume(); });
        exit.onClick.AddListener(ExitScene);
        if (Settings.musicSet)
        {
            bgAudio.volume = Settings.volume;
            bgAudio.clip = Settings.currentClip;
            bgAudio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Settings.musicSet)
        {
            bgAudio.volume = Settings.volume;
        }
    }

    public void TurnMusic()
    {
        Debug.Log(_musicOnOff.isOn);
        Settings.musicSet = _musicOnOff.isOn;
    }
    public void TurnVolume()
    {
        Debug.Log(_volume.value);
        Settings.volume = _volume.value;
    }

    public void ExitScene()
    {
        SceneManager.LoadSceneAsync(Settings.things, LoadSceneMode.Single);
    }
}
