using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OneShotYahaladim : MonoBehaviour
{
    private static OneShotYahaladim _instance;

    [SerializeField] private AudioClip[] _clips;
    private AudioSource _source;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _source = GetComponent<AudioSource>();
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (!_source.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
    public void PlayMe()
    {
        _source.clip = _clips[Random.Range(0, _clips.Length)];
        _source.Play();
    }
}