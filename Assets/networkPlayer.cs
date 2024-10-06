using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class networkPlayer : NetworkBehaviour
{

    [SerializeField] private Transform root;
    [SerializeField] private Transform head;
    [SerializeField] private Transform lHand;
    [SerializeField] private Transform rHand;

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOwner) {
            root.position = VRrigReferences.singleTon.root.position;
            root.rotation = VRrigReferences.singleTon.root.rotation;

            head.position = VRrigReferences.singleTon.head.position;
            head.rotation = VRrigReferences.singleTon.head.rotation;

            lHand.position = VRrigReferences.singleTon.lHand.position;
            lHand.rotation = VRrigReferences.singleTon.lHand.rotation;

            rHand.position = VRrigReferences.singleTon.rHAnd.position;
            rHand.rotation = VRrigReferences.singleTon.rHAnd.rotation;


        }
    }
}
