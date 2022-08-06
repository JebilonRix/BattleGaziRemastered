using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class StateMachine : MonoBehaviour
{
    private BaseState _currentState;
    public IdleState idleState = new IdleState();
    public WalkState walkState = new WalkState();
    public HideState hideState = new HideState();

    [Range(1f, 10f)][SerializeField] private float _walkingSpeed = 5f;
    [SerializeField] private AudioClip _hideSfx;
    [SerializeField] private AudioClip _showSfx;
    [SerializeField] private AudioClip _walkSfx;
    [SerializeField] private BoxCollider2D _detectionCollider;
    [SerializeField] private Audios audios;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;
    private AudioSource _audioSource;
    private CapsuleCollider2D _capsuleCollider;

    public AudioSource AudioSource { get => _audioSource; private set => _audioSource = value; }
    public Animator Animator { get => _animator; private set => _animator = value; }
    public SpriteRenderer Sr { get => _sr; private set => _sr = value; }
    public Rigidbody2D Rb { get => _rb; private set => _rb = value; }
    public AudioClip HideSfx { get => _hideSfx; }
    public AudioClip ShowSfx { get => _showSfx; }
    public AudioClip WalkSfx { get => _walkSfx; }
    public float WalkingSpeed { get => _walkingSpeed; }
    public BoxCollider2D DetectionCollider { get => _detectionCollider; }
    public Audios Audios { get => audios; }
    public CapsuleCollider2D CapsuleCollider { get => _capsuleCollider; set => _capsuleCollider = value; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
        AudioSource = GetComponent<AudioSource>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    private void Start()
    {
        SwitchState(idleState);
    }
    private void Update()
    {
        _currentState.UpdateState(this);
    }
    private void FixedUpdate()
    {
        walkState.FixedUpdate(this);
    }
    public void SwitchState(BaseState state)
    {
        if (_currentState != null)
        {
            _currentState.OnExit(this);
        }

        _currentState = state;

        state.OnEnter(this);
    }
    public BaseState GetCurrentState()
    {
        return _currentState;
    }
}