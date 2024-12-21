using System;
using UnityEngine;

namespace Assets.Core.Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}