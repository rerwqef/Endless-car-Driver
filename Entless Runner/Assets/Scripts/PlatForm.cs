using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
         Invoke("FallDown",0.2f);
        }
    }
    
    void FallDown()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 0.5f);
    }
}
