using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerPongCollider : MonoBehaviour
{




    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PingPong"))
        {
            Debug.Log("BEER");

            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            Destroy(gameObject.transform.parent.gameObject,8);
            
            Destroy(collider.gameObject);


        }
    }
}
