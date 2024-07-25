using ButchersGames;
using PathCreation.Examples;
using UnityEngine;

[RequireComponent(typeof(Wealth), typeof(PathFollower), typeof(PlayerModelChanger))]
[RequireComponent(typeof(Wallet), typeof(PlayerMover), typeof(PlayerAudio))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private LevelLauncher _launcher;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private InputReader _input;
    [SerializeField] private float _startingSpeed;

    private Wealth _wealth;
    private PlayerModelChanger _modelChanger;
    private PathFollower _pathFollower;
    private PlayerMover _mover;
    private PlayerAudio _audio;
    private Level _currentLevel;
    private bool _canMove = true;

    private void Awake()
    {
        _wealth = GetComponent<Wealth>();
        _modelChanger = GetComponent<PlayerModelChanger>();
        _mover = GetComponent<PlayerMover>();
        _pathFollower = GetComponent<PathFollower>();
        _audio = GetComponent<PlayerAudio>();
    }

    private void OnEnable()
    {
        _wealth.WealthLevelChanged += ChangeModel;
        _wealth.Lost += Lose;
        _wealth.WealthChanged += OnWealthChanged;
        _launcher.Started += StartMoving;
        _input.Clicked += MoveHorizontal;
        _levelManager.OnLevelStarted += OnLevelStart;
    }

    private void Start()
    {
        StopMoving();
    }

    private void OnDisable()
    {
        _wealth.WealthLevelChanged -= ChangeModel;
        _wealth.Lost -= Lose;
        _wealth.WealthChanged += OnWealthChanged;
        _launcher.Started -= StartMoving;
        _input.Clicked -= MoveHorizontal;
        _levelManager.OnLevelStarted += OnLevelStart;
    }

    public void OnLevelStart(Level level)
    {
        _currentLevel = level;
        Reset();
    }

    public void StopMoving()
    {
        _pathFollower.speed = 0;
        _canMove = false;
        _audio.StopPlayingSteps();
    }

    public void Win()
    {
        _playerAnimator.OnWin();
    }

    private void ChangeModel(WealthLevel level)
    {
        _modelChanger.ChangeModel(level);
        _playerAnimator.OnModelChanged();
    }

    private void MoveHorizontal(float percentOffsetX)
    {
        if (_canMove)
        {
            _mover.MovePlayer(percentOffsetX);
        }
    }

    private void StartMoving()
    {
        _pathFollower.speed = _startingSpeed;
        _playerAnimator.OnMove();
        _canMove = true;
        _audio.StartPlayingSteps();
    }

    private void Lose()
    {
        _playerAnimator.OnLose();
    }

    private void OnWealthChanged(WealthLevel level, float currentWealth, float maxWealth)
    {
        _playerAnimator.OnWealthChange(currentWealth, maxWealth);
    }

    private void Reset()
    {
        transform.position = Vector3.zero;
        _playerAnimator.Reset();
        _wealth.Reset();
        _pathFollower.pathCreator = _currentLevel.Path;
    }
}
