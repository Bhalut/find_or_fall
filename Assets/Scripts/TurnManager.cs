using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject yourTurnText;
    [SerializeField] private GameObject notYourTurnText;

    private Connection connection;
    
    void Start()
    {
        connection = FindObjectOfType<Connection>();

        if(connection.socket.sid == connection.player1_id)
        {
            ShowMyTurnText();
        }
        else ShowNotMyTurnText();
        
        Connection.turnManager = this;
    }
    public void ShowMyTurnText()
    {
        notYourTurnText.SetActive(false);
        yourTurnText.SetActive(true);
        image.SetActive(false);
    }

    public void ShowNotMyTurnText()
    {
        notYourTurnText.SetActive(true);
        yourTurnText.SetActive(false);
        image.SetActive(true);
    }
}
