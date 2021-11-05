using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_MaiMenu : MonoBehaviour
{
    #region: Variables to use:
    
    // No variables in this script. 

    #endregion

    #region: Methods to use: 

    public void NewGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    #endregion
}
