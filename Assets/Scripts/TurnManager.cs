using UnityEngine;

#pragma warning disable 618
#pragma warning disable 649

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameObject backgroundText;
    [SerializeField] private GameObject boardCover;
    [SerializeField] private GameObject yourTurnText;
    [SerializeField] private GameObject notYourTurnText;

    private Connection connection;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();

        if (connection.socket.sid == connection.player1ID)
            ShowMyTurnText();
        else ShowNotMyTurnText();

        Connection.TurnManager = this;
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
}