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

    [SerializeField] private Animator playeronefall;

    [SerializeField] private Animator playertwofall;

    private Connection connection;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();
        
        Connection.Buttons = this;
    }

    private static void OpenGate(Behaviour collider2D)
    {
        collider2D.enabled = false;
    }

    public void ButtonPressed(int buttonPressed)
    {
        if (buttonPressed == Connection.Button1)
            OpenGate(gateOne.GetComponent<Collider2D>());
        else if (buttonPressed == Connection.Button2) OpenGate(gateTwo.GetComponent<Collider2D>());
    }

    public void CheckConditionToWin(int buttonPressed)
    {
        if (buttonPressed == Connection.Button1)
        {
            if (connection.socket.sid == connection.player1ID)
            {
                //lose
                endGame.GetEndGame(false);
                playeronefall.SetBool("IsFalling", true);


#if UNITY_EDITOR
                Debug.Log("lose");
#endif

            }
            else
            {
                // win
                endGame.GetEndGame(true);
                playeronefall.SetBool("IsFalling", true);

#if UNITY_EDITOR
                Debug.Log("win"); 
#endif

            }
        }
        else if (buttonPressed == Connection.Button2)
        {
            if (connection.socket.sid == connection.player1ID)
            {
                //win
                endGame.GetEndGame(true);
                playertwofall.SetBool("TwoIsFalling", true);

#if UNITY_EDITOR
                Debug.Log("win");
#endif

            }
            else
            {
                // lose
                endGame.GetEndGame(false);
                playertwofall.SetBool("TwoIsFalling", true);


#if UNITY_EDITOR
                Debug.Log("lose");
#endif

            }
        }
    }

    public void DisableButton(int button)
    {
        buttons[button].interactable = false;
    }
}