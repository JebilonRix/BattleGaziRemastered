using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class EnemyStateMechine : MonoBehaviour
{
    private BaseEnemyState _currentState;
    public PatrolState patrolState = new PatrolState();
    public ChaseState chaseState = new ChaseState();

    [SerializeField] private EnemyAudio _audio;
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _chaseSpeed = 4f;
    [SerializeField] private float _catchDistance = 2f;

    private GameObject _target;
    private Rigidbody2D _rb;
    private AudioSource _audioSource;
    private bool _movingRight = true;
    private int _direction = 0;
    private List<AudioClip> _clips = new List<AudioClip>();

    public AudioSource AudioSource { get => _audioSource; private set => _audioSource = value; }
    public Rigidbody2D Rb { get => _rb; private set => _rb = value; }
    public bool MovingRight { get => _movingRight; private set => _movingRight = value; }
    public int Direction { get => _direction; set => _direction = value; }
    public GameObject Target { get => _target; set => _target = value; }
    public EnemyAudio Audio { get => _audio; }
    public float WalkSpeed { get => _walkSpeed; }
    public float ChaseSpeed { get => _chaseSpeed; }
    public float CatchDistance { get => _catchDistance; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        AudioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        SwitchState(patrolState);
    }
    private void Update()
    {
        _currentState.OnUpdate(this);

        if (!AudioSource.isPlaying && _clips.Count > 0)
        {
            AudioSource.clip = _clips[0];
            AudioSource.Play();

            _clips.RemoveAt(0);
        }
    }
    private void FixedUpdate()
    {
        _currentState.OnFixedUpdate(this);
    }
    public void SwitchState(BaseEnemyState state)
    {
        if (_currentState != null)
        {
            _currentState.OnExit(this);
        }

        _currentState = state;
        _currentState.OnStart(this);
    }
    public void Turn()
    {
        MovingRight = !MovingRight;

        Direction = MovingRight ? 1 : -1;

        transform.rotation = MovingRight ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180f, 0);
    }
    public void AudioLine(AudioClip clip)
    {
        _clips.Add(clip);
    }
    public void Catched()
    {
        SceneManager.LoadScene(2);
    }
    public BaseEnemyState GetCurrentState()
    {
        return _currentState;
    }
    public void PlayOne()
    {
        OneShotYahaladim oneShot = FindObjectOfType<OneShotYahaladim>(true);

        if (oneShot.gameObject.activeSelf == false)
        {
            oneShot.gameObject.SetActive(true);
        }
        oneShot.PlayMe();
    }
}