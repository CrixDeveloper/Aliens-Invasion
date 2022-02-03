using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharlesHelp : MonoBehaviour
{
    public float timeLastDamage;
    public float damagePeriod;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerStay()
    {
        if(Time.time > timeLastDamage + damagePeriod)
        {
            timeLastDamage = Time.time;
            Manager_Energy.energyCount -= 1;
        }
    }
}
