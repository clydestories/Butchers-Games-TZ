using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int Wealth = Animator.StringToHash(nameof(Wealth));
    private readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
    private readonly int Changed = Animator.StringToHash(nameof(Changed));
    private readonly int Won = Animator.StringToHash(nameof(Won));
    private readonly int Lost = Animator.StringToHash(nameof(Lost));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnModelChanged()
    {
        _animator.SetTrigger(Changed);
    }

    public void OnMove()
    {
        _animator.SetBool(IsWalking, true);
    }

    public void OnWin()
    {
        _animator.SetTrigger(Won);
    }

    public void OnLose()
    {
        _animator.SetTrigger(Lost);
    }

    public void OnWealthChange(float currentWealth, float maxWealth)
    {
        _animator.SetFloat(Wealth, currentWealth / maxWealth);
    }
}
