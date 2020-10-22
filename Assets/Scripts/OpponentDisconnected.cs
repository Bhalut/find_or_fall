using UnityEngine;
using UnityEngine.SceneManagement;

public class OpponentDisconnected : MonoBehaviour
{
    [SerializeField] private GameObject screenOpponentDisconnected;
    [SerializeField] private EndGame endGame;

    private void Start()
    {
        Connection.opponentDisconnected = this;
    }

    public void ShowScreenOpponentDisconnected()
    {
        if (!endGame.IsEndGame())
            screenOpponentDisconnected.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
    }
}
