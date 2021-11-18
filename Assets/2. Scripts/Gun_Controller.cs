using UnityEngine;

public class Gun_Controller : MonoBehaviour
{
    #region Variables to use:

    public Camera fpsCamera;
    public float damage = 10f;
    public float range = 10f;

    #endregion

    #region Methods to use: 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }

        Health health = hit.transform.GetComponent<Health>();
        
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }

    #endregion
}
