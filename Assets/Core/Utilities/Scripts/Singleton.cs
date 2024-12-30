using UnityEngine;

/// <summary>
/// A base class for creating singleton instances of MonoBehaviour-derived classes.
/// </summary>
/// <typeparam name="T">The type of the singleton instance.</typeparam>
public abstract class StaticInstace<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;

    /// <summary>
    /// Gets the singleton instance of the specified type.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Sets the singleton instance to this instance.
    /// </summary>
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
    }
}

public abstract class Singleton<T> : StaticInstace<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

public abstract class PersistentSingleton<T> : StaticInstace<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}