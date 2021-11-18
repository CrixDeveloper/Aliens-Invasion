using UnityEngine;
using UnityEngine.UI;

public class Manager_Barrels : MonoBehaviour
{
    #region Variables to use: 

    public GameObject barrelsCountdown;

    #endregion

    #region Methods to use: 

    // Start is called before the first frame update
    void Start()
    {
        barrelsCountdown.GetComponent<Text>().text = "= 50 / 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
