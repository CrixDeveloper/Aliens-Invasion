using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap_Controller : MonoBehaviour
{
    #region Variables to use: 

    public Transform player;
    
    #endregion

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
