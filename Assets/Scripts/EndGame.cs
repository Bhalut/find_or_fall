﻿using UnityEngine;

#pragma warning disable 618
#pragma warning disable 649

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject finishImage;
    
    [SerializeField] private GameObject winImage;
    
    [SerializeField] private GameObject loseImage;

    [SerializeField] private TurnManager turnManager;

    public void GetEndGame(bool win)
    {
        finishImage.SetActive(true);
        turnManager.HideFeedbackTrun();

        if (win)
            winImage.SetActive(true);
        else
            loseImage.SetActive(true);
    }

    public bool IsEndGame()
    {
        return finishImage.activeSelf;
    }
}