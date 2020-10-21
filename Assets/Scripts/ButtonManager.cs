using UnityEngine;
using UnityEngine.UI;


#pragma warning disable 618
#pragma warning disable 649

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
 
    [SerializeField] private GameObject gateOne;
    
    [SerializeField] private GameObject gateTwo;

    [SerializeField] private EndGame endGame;

    private Connection connection;

    private void Start()
	{
        connection = FindObjectOfType<Connection>();
        Connection.buttons = this;
	}

    private static void OpenGate(Behaviour collider2D)
    {
        collider2D.enabled = false;
    }

    public void ButtonPressed(int buttonPressed)
    {
        if(buttonPressed == Connection.Button1)
        {
            OpenGate(gateOne.GetComponent<Collider2D>());
        }
        else if (buttonPressed == Connection.Button2)
        {
            OpenGate(gateTwo.GetComponent<Collider2D>());
        }
    }

    public void CheckConditionToWin(int buttonPressed)
    {
        if(buttonPressed == Connection.Button1)
        {
            if(connection.socket.sid == connection.player1_id)
            {
                //lose
                endGame.GetEndGame(false);
                Debug.Log("lose");
            }
            else
            {
                // win
                endGame.GetEndGame(true);
                Debug.Log("win");
            }
        }
        else if(buttonPressed == Connection.Button2)
        {
            if(connection.socket.sid == connection.player1_id)
            {
                //win
                endGame.GetEndGame(true);
                Debug.Log("win");
            }
            else
            {
                // lose
                endGame.GetEndGame(false);
                Debug.Log("lose");
            }
        }
    }

    public void DisableButton(int button)
    {
        buttons[button].interactable = false;
    }
}
