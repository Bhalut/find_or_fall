using UnityEngine;
using UnityEngine.SceneManagement;

public class OpponentDisconnected : MonoBehaviour
{
    [SerializeField] private GameObject screenOpponentDisconnected;

    private void Start()
    {
        Connection.opponentDisconnected = this;
    }

    public void ShowScreenOpponentDisconnected()
    {
        screenOpponentDisconnected.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
    }
}
