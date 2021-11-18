using UnityEngine;
using UnityEngine.UI;

public class FuelPickUp : MonoBehaviour
{
    #region Variables to use:

    protected AudioSource audioSource;
    private int barrels = 0;

    #endregion

    #region Methods to use: 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        barrels = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            barrels += 1;
            FindObjectOfType<Manager_Barrels>().barrelsCountdown.GetComponent<Text>().text = "= 50 / 0" + barrels;
            gameObject.SetActive(false);
            Destroy(gameObject, 30f);
        }
    }

    #endregion
}
