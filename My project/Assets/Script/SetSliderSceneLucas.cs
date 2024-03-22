using UnityEngine;
using UnityEngine.Audio;

public class SetSliderSceneLucas : MonoBehaviour
{
    public AudioMixer _audioMixer;
    public void SetVolumeSound(float volume)
    {
        _audioMixer.SetFloat("SFX", volume);
    }
}
