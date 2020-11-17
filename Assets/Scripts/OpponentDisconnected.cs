using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable 618
#pragma warning disable 649

/// <summary>
/// Contains methods to manage the events when opponenet is disconnected
/// </summary>
public class OpponentDisconnected : MonoBehaviour
{
    [SerializeField] private GameObject screenOpponentDisconnected;

    [SerializeField] private EndGame endGame;

    private Connection connection;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();
        Connection.OpponentDisconnected = this;
    }

    /// <summary>
    /// Displays the pop-up message
    /// </summary>
    public void ShowScreenOpponentDisconnected()
    {
        if(!endGame.IsEndGame())
        {
            screenOpponentDisconnected.SetActive(true);
            FindObjectOfType<DisplayCountdown>().StopCountdown();
        }
    }

    /// <summary>
    /// Returns to the main menu
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        Destroy(connection.gameObject);
    }
}