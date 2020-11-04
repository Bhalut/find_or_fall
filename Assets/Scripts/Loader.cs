using UnityEngine.SceneManagement;
using UnityEngine;

#pragma warning disable 618
#pragma warning disable 649

/// <summary>
/// Contains method to load scenes
/// </summary>
public class Loader : MonoBehaviour
{
    [SerializeField] private string nameScene;

    /// <summary>
    /// Loads a given scene
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Single);
    }
}
