using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable 618
#pragma warning disable 649

public class OpponentDisconnected : MonoBehaviour
{
    [SerializeField] private GameObject screenOpponentDisconnected;

    [SerializeField] private EndGame endGame;

    private void Start()
    {
        Connection.OpponentDisconnected = this;
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