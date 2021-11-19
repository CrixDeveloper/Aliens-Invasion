using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Countdown : MonoBehaviour
{
    #region Variables to use:
    
    public GameObject textDisplay;
    public static int secondsLeft = 600;
    public bool takingAway = false;

    #endregion

    #region Methods to use:
   
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "Time Left: " + secondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
        else
        {
            if (secondsLeft == 0)
            {
                Time.timeScale = 0;
            }
        }
    }
    private IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.GetComponent<Text>().text = "Time Left: " + secondsLeft;
        takingAway = false;
    }
   
    #endregion
}
