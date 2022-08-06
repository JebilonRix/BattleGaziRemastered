using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MusicHandler : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private AudioClip _clip1;
    [SerializeField] private AudioClip _clip2;

    private AudioSource _source;
    private bool _playMain = false;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        _source.outputAudioMixerGroup = _mixer;
        _playMain = false;
        _source.PlayOneShot(_clip1);
    }

    private void Update()
    {
        if (_playMain)
            return;
        if (_source.isPlaying)
            return;

        PlayMainTheme();
    }
    private void PlayMainTheme()
    {
        _source.clip = _clip2;
        _source.loop = true;
        _source.Play();

        _playMain = true;
    }
}