using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Win : MonoBehaviour
{
    #region Variables to use: 

    private int restartSceneDelay = 10;

    #endregion

    #region Methods to use: 

    // Start is called before the first frame update
    void Update()
    {
        Invoke("RestartMainMenu", restartSceneDelay);
    }

    private void RestartMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    #endregion
}
