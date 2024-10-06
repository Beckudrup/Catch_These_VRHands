using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Shooter : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawnPos;

    private float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable theGunGrab = GetComponent<XRGrabInteractable>();
        theGunGrab.activated.AddListener(gunShot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void gunShot(ActivateEventArgs arg)
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position= spawnPos.position;
        newBullet.GetComponent<Rigidbody>().velocity = spawnPos.forward*bulletSpeed;

        Destroy(newBullet, 10);



    }
}
