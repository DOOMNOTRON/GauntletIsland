using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contMusic : MonoBehaviour
{
    public static contMusic instance;
    // On awake this will detect the game object
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
