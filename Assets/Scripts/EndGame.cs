using UnityEngine;

#pragma warning disable 618
#pragma warning disable 649

/// <summary>
/// Cointains the methods to finish the game
/// </summary>
public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject finishImage;

    [SerializeField] private GameObject winImage;

    [SerializeField] private GameObject loseImage;

    [SerializeField] private TurnManager turnManager;

    /// <summary>
    /// Checks if the game is ended
    /// </summary>
    /// <param name="win"></param>
    public void GetEndGame(bool win)
    {
        this.Invoke(() => finishImage.SetActive(true), 4.0f);
        turnManager.HideFeedbackTrun();

        if (win)
            winImage.SetActive(true);
        else
            loseImage.SetActive(true);
    }

    /// <summary>
    /// Enables the finish image
    /// </summary>
    /// <returns></returns>
    public bool IsEndGame()
    {
        return finishImage.activeSelf;
    }
}
