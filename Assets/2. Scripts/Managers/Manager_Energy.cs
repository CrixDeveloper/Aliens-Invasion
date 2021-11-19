using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Energy : MonoBehaviour
{
    #region Variables to use: 

    public static int energyCount;
    public Text energyText;
    
    #endregion

    #region Methods to use: 

    // Start is called before the first frame update
    void Start()
    {
        energyCount = 0;
        energyText.GetComponent<Text>().text = " " + energyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseEnergyNumber()
    {
        energyCount ++;
        energyText.text = energyCount.ToString() + "";
    }

    #endregion
}
