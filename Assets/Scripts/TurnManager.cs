using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject yourTurnText;
    [SerializeField] private GameObject notYourTurnText;
    void Start()
    {
        Connection.turnManager = this;
    }
    public void ShowMyTurnText()
    {
        notYourTurnText.SetActive(false);
        yourTurnText.SetActive(true);
        image.SetActive(false);
        Debug.Log("Mi turno!");
    }

    public void ShowNotMyTurnText()
    {
        notYourTurnText.SetActive(true);
        yourTurnText.SetActive(false);
        image.SetActive(true);
    }
}
