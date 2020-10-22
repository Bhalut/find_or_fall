using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable 618
#pragma warning disable 649

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject finishImage;
    [SerializeField] private GameObject winImage;
    [SerializeField] private GameObject loseImage;

    public void GetEndGame(bool win)
    {
        finishImage.SetActive(true);
        if (win)
            winImage.SetActive(true);
        else
            loseImage.SetActive(true);
    }

    public bool IsEndGame()
    {
        if(finishImage.activeSelf) return true;
        else return false;
    }
}
