using UnityEngine;

#pragma warning disable 618
#pragma warning disable 649

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameObject backgroundText;
    [SerializeField] private GameObject boardCover;
    [SerializeField] private GameObject yourTurnText;
    [SerializeField] private GameObject notYourTurnText;
    [SerializeField] private GameObject youPlayer1;
    [SerializeField] private GameObject youPlayer2;

    private Connection connection;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();

        if (connection.socket.sid == connection.player1ID)
            ShowMyTurnText();
        else ShowNotMyTurnText();

        Connection.TurnManager = this;

        if(connection.socket.sid == connection.player1ID)
            youPlayer1.SetActive(true);
        else
            youPlayer2.SetActive(true);
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