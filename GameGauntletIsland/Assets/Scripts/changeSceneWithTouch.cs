using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneWithTouch : MonoBehaviour
{
    // Changes scene when touch is detected
    public void MoveToScene (int sceneID) {
        SceneManager.LoadScene(sceneID);
    }
}
