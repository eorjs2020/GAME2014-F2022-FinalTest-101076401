//Singleton
//LastUpdate 22_12_15
//Daekoen_Lee 101076401
//Revision History
//First modified 22_12_15
//Description - Singleton - making scripts as singleton
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }
}