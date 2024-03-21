using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer _audioMixer;
    public Slider _SFXSound;
    //public Slider MusicSound;
    //public void SetVolumeMusic(float volume)
    //{
    //    audioMixer.SetFloat("Music", volume);
    //}

    private void Start()
    {
        if (PlayerPrefs.GetInt("SaveSFX") == 1)
        {
            _SFXSound.value = PlayerPrefs.GetFloat("SFX");
        }
        _audioMixer.SetFloat("SFX", _SFXSound.value);
    }
    public void SetVolumeSound(float volume)
    {
        _audioMixer.SetFloat("SFX", volume);
    }
}