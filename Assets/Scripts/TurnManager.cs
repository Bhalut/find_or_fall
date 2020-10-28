using UnityEngine;
using TMPro;
using System.Collections;

#pragma warning disable 618
#pragma warning disable 649

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameObject backgroundText;
    [SerializeField] private GameObject boardCover;
    [SerializeField] private GameObject yourTurnText;
    [SerializeField] private GameObject notYourTurnText;
    [SerializeField] private TextMeshProUGUI namePlayer1;
    [SerializeField] private TextMeshProUGUI namePlayer2;

    private Connection connection;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();

        if(connection.socket.sid == connection.player1ID)
            ShowMyTurnText();
        else ShowNotMyTurnText();

        Connection.TurnManager = this;

        StartCoroutine(WaitOpponentName());
    }

    public void ShowMyTurnText()
    {
        notYourTurnText.SetActive(false);
        yourTurnText.SetActive(true);
        boardCover.SetActive(false);
    }

    public void ShowNotMyTurnText()
    {
        notYourTurnText.SetActive(true);
        yourTurnText.SetActive(false);
        boardCover.SetActive(true);
    }

    public void HideFeedbackTrun()
    {
        notYourTurnText.SetActive(false);
        yourTurnText.SetActive(false);
        boardCover.SetActive(false);
        backgroundText.SetActive(false);
    }

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