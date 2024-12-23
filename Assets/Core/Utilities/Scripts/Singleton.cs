using UnityEngine;

/// <summary>
/// A base class for creating singleton instances of MonoBehaviour-derived classes.
/// </summary>
/// <typeparam name="T">The type of the singleton instance.</typeparam>
public abstract class StaticInstace<T> : MonoBehaviour where T : MonoBehaviour
{
    /// <summary>
    /// Gets the singleton instance of the specified type.
    /// </summary>
    public static T Instance { get; private set; }

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Sets the singleton instance to this instance.
    /// </summary>
    protected virtual void Awake() => Instance = this as T;

    /// <summary>
    /// Called when the application is quitting.
    /// Resets the singleton instance to null and destroys the game object.
    /// </summary>
    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

public abstract class Singleton<T> : StaticInstace<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        base.Awake();
    }
}

public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}