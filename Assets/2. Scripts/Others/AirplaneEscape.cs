using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneEscape : MonoBehaviour
{
    #region Variables to use: 

    public GameObject popUpText;
  
    #endregion

    #region Methods to use: 

    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.CompareTag("Collidable"))
        {
            Debug.Log("Airplane Hit");

            popUpText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<Manager_Game>().GameWin();
            }
        }
    }

    #endregion
}
