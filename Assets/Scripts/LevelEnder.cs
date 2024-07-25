using UnityEngine;

public class LevelEnder : MonoBehaviour
{
    [SerializeField] private Wealth _wealth;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _wealth.Lost += Lose;
    }

    private void OnDisable()
    {
        _wealth.Lost -= Lose;
    }

    public void Win(int multiplier)
    {
        _wallet.AddMoney((int)_wealth.Value * multiplier);
        _player.Win();
        _player.StopMoving();
    }

    public void Lose()
    {
        _player.StopMoving();
    }
}
