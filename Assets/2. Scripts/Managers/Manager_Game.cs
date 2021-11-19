using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager_Game : MonoBehaviour
{
    #region Variables to use: 

    public Health playerLife;

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
        checkLoseConditionOne();
        checkLoseConditionTwo();
        checkEnergy();
    }

    private void checkLoseConditionOne()
    {
        if (Manager_Countdown.secondsLeft == 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void checkLoseConditionTwo()
    {
        if (playerLife.value == 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void checkEnergy()
    {
        if (Manager_Energy.energyCount == 50)
        {
            airPlanePrefab.gameObject.SetActive(true);
            popUpText.gameObject.SetActive(true);
            Destroy(popUpText, 10f);
        }
    }
    #endregion
}
