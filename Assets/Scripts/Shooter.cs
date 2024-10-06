using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.Netcode;
using TMPro.Examples;

public class Shooter : NetworkBehaviour 
{

    public GameObject bullet;
    public Transform spawnPos;

    //private float bulletSpeed = 10f;
    private void Start()
    {
        if (NetworkManager.Singleton == null) Debug.LogError("No network manager yet...");
        NetworkManager.Singleton.AddNetworkPrefab(bullet);
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        XRGrabInteractable theGunGrab = GetComponent<XRGrabInteractable>();
        theGunGrab.activated.AddListener(gunShot);

    }

    public void gunShot(ActivateEventArgs arg)
    {
        spawnBullet_ServerRpc();

    }

    [ServerRpc(RequireOwnership = false)] //Client calls the server on the phone and asks them to do this and therefore it works
    public void spawnBullet_ServerRpc()
    {

        GameObject newBullet = Instantiate(bullet, spawnPos.position, spawnPos.rotation);
        NetworkObject netBullet = newBullet.GetComponent<NetworkObject>();
        netBullet.Spawn();

    }

}
