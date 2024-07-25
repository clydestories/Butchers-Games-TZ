using PathCreation.Examples;
using System;
using UnityEngine;

[RequireComponent(typeof(Wealth), typeof(PathFollower), typeof(PlayerModelChanger))]
[RequireComponent(typeof(Wallet), typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private LevelLauncher _launcher;
    [SerializeField] private InputReader _input;
    [SerializeField] private float _startingSpeed;

    private Wealth _wealth;
    private PlayerModelChanger _modelChanger;
    private PathFollower _pathFollower;
    private PlayerMover _mover;

    public event Action SkinChanged;

    private void Awake()
    {
        _wealth = GetComponent<Wealth>();
        _modelChanger = GetComponent<PlayerModelChanger>();
        _mover = GetComponent<PlayerMover>();
        _pathFollower = GetComponent<PathFollower>();
    }

    private void OnEnable()
    {
        _wealth.WealthLevelChanged += ChangeModel;
        _wealth.Lost += Lose;
        _wealth.WealthChanged += OnWealthChanged;
        _launcher.Started += StartMoving;
        _input.Clicked += MoveHorizontal;
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
    }

    public void StopMoving()
    {
        _pathFollower.speed = 0;
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
        _mover.MovePlayer(percentOffsetX);
    }

    private void StartMoving()
    {
        _pathFollower.speed = _startingSpeed;
        _playerAnimator.OnMove();
    }

    private void Lose()
    {
        _playerAnimator.OnLose();
    }

    private void OnWealthChanged(WealthLevel level, float currentWealth, float maxWealth)
    {
        _playerAnimator.OnWealthChange(currentWealth, maxWealth);
    }
}
