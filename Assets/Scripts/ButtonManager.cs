using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

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

    [SerializeField] private Animator opengates;

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