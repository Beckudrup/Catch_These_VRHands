using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Bullets : NetworkBehaviour
{

    private float bulletSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.velocity= transform.forward * bulletSpeed;
        

        StartCoroutine(Despawn());

    }

    [ServerRpc(RequireOwnership = false)]

    public void despawnServerRPC()
    {
        var netObject = GetComponent<NetworkObject>();
        netObject.Despawn();
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(10);

        despawnServerRPC();

    }
}
