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

    [SerializeField] private AudioManager audioManager;

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

    public void CheckConditionToWin(int buttonPressed, bool me)
    {
        if (buttonPressed == Connection.Button1)
        {
            audioManager.StopMusic();

            if (connection.socket.sid == connection.player1ID)
            {
                //lose
                endGame.GetEndGame(false);
                playeronefall.SetBool("IsFalling", true);

                // sound: fall
                audioManager.ShotAudio(7);

                if(me) audioManager.ShotAudio(4); // sound: lose-self
                else audioManager.ShotAudio(5); // sound: lose

#if UNITY_EDITOR
                Debug.Log("lose");
#endif
            }
            else
            {
                // win
                endGame.GetEndGame(true);
                playeronefall.SetBool("IsFalling", true);
                audioManager.ShotAudio(6);

#if UNITY_EDITOR
                Debug.Log("win"); 
#endif
            }
        }
        else if (buttonPressed == Connection.Button2)
        {
            audioManager.StopMusic();

            if (connection.socket.sid == connection.player1ID)
            {
                //win
                endGame.GetEndGame(true);
                playertwofall.SetBool("TwoIsFalling", true);
                audioManager.ShotAudio(6);

#if UNITY_EDITOR
                Debug.Log("win");
#endif

            }
            else
            {
                // lose
                endGame.GetEndGame(false);
                playertwofall.SetBool("TwoIsFalling", true);

                // sound: fall
                audioManager.ShotAudio(7);

                if(me) audioManager.ShotAudio(4); // sound: lose-self
                else audioManager.ShotAudio(5); // sound: lose

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