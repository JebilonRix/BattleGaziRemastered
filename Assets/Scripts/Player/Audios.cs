using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Audios", menuName = "PlayerAudio")]
public class Audios : ScriptableObject
{
    [SerializeField] private AudioMixerGroup _hideShowMixer;
    [SerializeField] private AudioMixerGroup _walkMixer;

    [SerializeField] private AudioClip _hideSfx;
    [SerializeField] private AudioClip _showSfx;
    [SerializeField] private AudioClip _walkSfx;

    public AudioClip PlayAudio(string tag, AudioSource source)
    {
        if (tag == "Show")
        {
            MixerCheck(source, _hideShowMixer);
            return _showSfx;
        }
        else if (tag == "Hide")
        {
            MixerCheck(source, _hideShowMixer);
            return _hideSfx;
        }
        else
        {
            MixerCheck(source, _walkMixer);
            return _walkSfx;
        }
    }

    private void MixerCheck(AudioSource source, AudioMixerGroup targetGroup)
    {
        if (source.outputAudioMixerGroup == targetGroup)
        {
            return;
        }

        source.outputAudioMixerGroup = targetGroup;
    }
}