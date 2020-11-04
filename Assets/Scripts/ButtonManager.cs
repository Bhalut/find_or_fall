using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

#pragma warning disable 618
#pragma warning disable 649

/// <summary>
/// Contains all the methods for buttons management
/// </summary>
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    [SerializeField] private GameObject gateOne;

    [SerializeField] private GameObject gateTwo;

    [SerializeField] private EndGame endGame;

    [SerializeField] private Animator playeronefall;

    [SerializeField] private Animator playertwofall;

    [SerializeField] private Animator opengates;

    [SerializeField] private AudioManager audioManager;

    private Connection connection;

    private void Start()
    {
        connection = FindObjectOfType<Connection>();

        Connection.Buttons = this;
    }

    /// <summary>
    /// Deactivates the collider2d object to make the gates open
    /// </summary>
    /// <param name="collider2D"></param>
    private static void OpenGate(Behaviour collider2D)
    {
        collider2D.enabled = false;
    }

    /// <summary>
    /// Checks if the button pressed open the gates
    /// </summary>
    /// <param name="buttonPressed"></param>
    public void ButtonPressed(int buttonPressed)
    {
        if (buttonPressed == Connection.Button1)
        {
            this.Invoke(() => OpenGate(gateOne.GetComponent<Collider2D>()), 1.5f);
            //OpenGate(gateOne.GetComponent<Collider2D>());
        }
        else if (buttonPressed == Connection.Button2)
        {
            this.Invoke(() => OpenGate(gateTwo.GetComponent<Collider2D>()), 1.5f);
            //OpenGate(gateTwo.GetComponent<Collider2D>());
        }

    }

    /// <summary>
    /// Checks the winner and trigger the events to display
    /// </summary>
    /// <param name="buttonPressed"></param>
    /// <param name="me"></param>
    public void CheckConditionToWin(int buttonPressed, bool me)
    {
        if (buttonPressed == Connection.Button1)
        {
            audioManager.StopMusic();

            if (connection.socket.sid == connection.player1ID)
            {
                //lose
                playeronefall.SetBool("IsFalling", true);
                opengates.SetBool("LosePlayerOne", true);
                endGame.GetEndGame(false);

                // sound: fall
                audioManager.ShotAudio(7);

                if (me) audioManager.ShotAudio(4); // sound: lose-self
                else audioManager.ShotAudio(5); // sound: lose

#if UNITY_EDITOR
                Debug.Log("lose");
#endif
            }
            else
            {
                // win
                playeronefall.SetBool("IsFalling", true);
                opengates.SetBool("LosePlayerOne", true);
                audioManager.ShotAudio(6);
                endGame.GetEndGame(true);

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
                playertwofall.SetBool("TwoIsFalling", true);
                opengates.SetBool("LosePlayerTwo", true);
                audioManager.ShotAudio(6);
                endGame.GetEndGame(true);

#if UNITY_EDITOR
                Debug.Log("win");
#endif

            }
            else
            {
                // lose
                playertwofall.SetBool("TwoIsFalling", true);
                opengates.SetBool("LosePlayerTwo", true);
                endGame.GetEndGame(false);

                // sound: fall
                audioManager.ShotAudio(7);

                if (me) audioManager.ShotAudio(4); // sound: lose-self
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

/// <summary>
/// Contains methods for utilities
/// </summary>
public static class Utility
{
    public static void Invoke(this MonoBehaviour mb, Action f, float delay)
    {
        mb.StartCoroutine(InvokeRoutine(f, delay));
    }

    private static IEnumerator InvokeRoutine(System.Action f, float delay)
    {
        yield return new WaitForSeconds(delay);
        f();
    }
}