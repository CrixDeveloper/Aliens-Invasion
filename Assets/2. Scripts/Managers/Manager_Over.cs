using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Over : MonoBehaviour
{
    #region Variables to use: 

    private int restartSceneDelay = 10;

    #endregion

    #region Methods to use: 

    // Start is called before the first frame update
    void Update()
    {
        Invoke("Restart", restartSceneDelay);
    }

    private void Restart()
    {
        SceneManager.LoadScene("MainLevel");
    }

    #endregion 
}
