using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_Controller : MonoBehaviour
{
    #region Variables to use:

    public GameObject energyPrefab;

    #endregion

    #region Methods to use: 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Energy Picked Up");

            energyPrefab.gameObject.SetActive(false);
            FindObjectOfType<Manager_Energy>().IncreaseEnergyNumber();
        }
    }

    #endregion
}
