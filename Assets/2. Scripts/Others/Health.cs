using UnityEngine;

public class Health : MonoBehaviour
{
    #region Variables to use: 

    public float value = 100f;

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

    public void TakeDamage(float damage)
    {
        value -= damage;

        if (value <= 0f)
        {
            value = 0f;
        }
    }

    #endregion
}
