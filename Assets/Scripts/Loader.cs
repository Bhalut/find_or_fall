using UnityEngine.SceneManagement;
using UnityEngine;

#pragma warning disable 618
#pragma warning disable 649

public class Loader : MonoBehaviour
{
    [SerializeField] private string nameScene;
    
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Single);
    }
}
