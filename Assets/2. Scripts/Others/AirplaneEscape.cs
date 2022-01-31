using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneEscape : MonoBehaviour
{
    #region Variables to use: 

    protected AudioSource audioSource;
    public GameObject popUpText;
    public AudioClip pickUpSound;

    #endregion

    #region Methods to use: 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.CompareTag("Collidable"))
        {
            Debug.Log("Airplane Hit");

            popUpText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interlude.InterludeManager.KeyFound();
                FindObjectOfType<Manager_Game>().GameWin();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            audioSource.PlayOneShot(pickUpSound);
        }
    }

    #endregion
}
