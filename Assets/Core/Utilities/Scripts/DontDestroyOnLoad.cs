using System;
using UnityEngine;


public class DontDestroyOnLoad : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}