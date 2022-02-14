using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager_Game : MonoBehaviour
{
    #region Variables to use: 

    public Health playerLife;
    public int restartDelay = 10;

    [Header("References:")]

    public GameObject airPlanePrefab;
    public GameObject popUpText;

    #endregion

    #region Methods to use: 

    // Start is called before the first frame update
    void Start()
    {
        playerLife.GetComponent<Health>().value = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
        checkLoseCondition();
        checkEnergy();
    }

    private void checkLoseCondition()
    {
        if (Manager_Energy.energyCount == -15)
        {
            GameOver();
        }
    }

    private void checkEnergy()
    {
        if (Manager_Energy.energyCount == 30)
        {
            airPlanePrefab.gameObject.SetActive(true);
            popUpText.gameObject.SetActive(true);
            Destroy(popUpText, 30f);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void GameWin()
    {
        SceneManager.LoadScene("WinGame");
    } 

    #endregion
}
