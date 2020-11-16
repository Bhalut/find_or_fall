using UnityEngine;
using TMPro;
using System.Collections;

#pragma warning disable 618
#pragma warning disable 649

/// <summary>
/// Contains the methods to manage the player's turn
/// </summary>
public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameObject backgroundText;
    [SerializeField] private GameObject boardCover;
    [SerializeField] private GameObject yourTurnText;
    [SerializeField] private GameObject notYourTurnText;
    [SerializeField] private TextMeshProUGUI namePlayer1;
    [SerializeField] private TextMeshProUGUI namePlayer2;
    [SerializeField] private DisplayCountdown displayCountdown;

    private Connection connection;

    private void Start()
    {
        displayCountdown = FindObjectOfType<DisplayCountdown>();

        connection = FindObjectOfType<Connection>();

        if(connection.socket.sid == connection.player1ID)
            ShowMyTurnText();
        else ShowNotMyTurnText();

        Connection.TurnManager = this;

        StartCoroutine(WaitOpponentName());
    }

    /// <summary>
    /// Displays text when turn
    /// </summary>
    public void ShowMyTurnText()
    {
        notYourTurnText.SetActive(false);
        yourTurnText.SetActive(true);
        boardCover.SetActive(false);
        displayCountdown.StartCountdown();
    }

    /// <summary>
    /// Displays text when opponent's turn
    /// </summary>
    public void ShowNotMyTurnText()
    {
        notYourTurnText.SetActive(true);
        yourTurnText.SetActive(false);
        boardCover.SetActive(true);
        displayCountdown.StopCountdown();
    }

    /// <summary>
    /// Hides all the texts
    /// </summary>
    public void HideFeedbackTrun()
    {
        notYourTurnText.SetActive(false);
        yourTurnText.SetActive(false);
        boardCover.SetActive(false);
        backgroundText.SetActive(false);
    }

    /// <summary>
    /// Waits for name verification
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitOpponentName()
    {
        while(PlayerPrefs.GetString("opponent username") == "")
        {
            yield return new WaitForSeconds(.3f);
        }
        if(connection.socket.sid == connection.player1ID)
            namePlayer2.text = PlayerPrefs.GetString("opponent username");
        else
            namePlayer1.text = PlayerPrefs.GetString("opponent username");
        yield return null;
    }
}