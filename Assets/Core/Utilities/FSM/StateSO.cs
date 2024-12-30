using UnityEngine;

public abstract class StateSO : ScriptableObject
{
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public virtual void OnStateUpdate() { }
}