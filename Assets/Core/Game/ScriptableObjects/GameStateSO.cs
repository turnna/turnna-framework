using UnityEngine;

public class GameStateSO : StateSO
{
    protected GameManager GameManager;
    public void Initialize(GameManager gameManager)
    {
        GameManager = gameManager;
    }

}