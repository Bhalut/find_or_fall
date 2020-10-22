using UnityEngine;

/// <summary>
///     Class inherited by each class that restricts the instantiation of a it to one object.
/// </summary>
/// <typeparam name="T">Specific class that will implement the singleton</typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance) return _instance;
            var singleton = new GameObject();
            _instance = singleton.AddComponent<T>();
            singleton.name = typeof(T).ToString();

            return _instance;
        }
        set
        {
            if (_instance == null)
            {
                DontDestroyOnLoad(value.gameObject);
                _instance = value;
            }
            else
            {
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        Instance = this as T;
        Init();
    }

    /// <summary>
    ///     Allows each class inheriting from Singleton class to use the Awake function
    /// </summary>
    private void Init()
    {
    }
}