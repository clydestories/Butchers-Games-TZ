using ButchersGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnder : MonoBehaviour
{
    [SerializeField] private Wealth _wealth;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Player _player;
    [SerializeField] private Canvas _loseUI;
    [SerializeField] private Canvas _ingameUI;
    [SerializeField] private Canvas _ingameStatsUI;
    [SerializeField] private Canvas _winUI;
    [SerializeField] private Canvas _startUI;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private LevelLauncher _levelLauncher;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _loseSound;
    [SerializeField] private AudioClip _winSound;

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
        _ingameStatsUI.enabled = false;
        _ingameUI.enabled = false;
        _winUI.enabled = true;
        _player.Win();
        _player.StopMoving();
        _audio.clip = _winSound;
        _audio.Play();
    }

    public void Lose()
    {
        _player.StopMoving();
        _ingameStatsUI.enabled = false;
        _ingameUI.enabled = false;
        _loseUI.enabled = true;
        _audio.clip = _loseSound;
        _audio.Play();
    }

    public void Restart()
    {
        /*_levelManager.RestartLevel();
        _levelManager.StartLevel();
        _loseUI.enabled = false;
        _startUI.enabled = true;
        _startUI.enabled = true;
        _levelLauncher.enabled = true;*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
