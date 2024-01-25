// Based on https://youtu.be/0xt6dACM_1I?t=559
/*
This simple demo script can be attached to an Interactable object.
It listens for an Activate event and when it gets the event, the function DropIt will
be called.
The DropIt function simply instantiates a copy of an object.
The object that it instantiates is defined in thingToDrop.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Need to declare this to use XR Interaction Toolkit API
using UnityEngine.XR.Interaction.Toolkit;

public class ShootSomething : MonoBehaviour
{
    public GameObject thingToDrop;
    public Transform spawnPoint;
    public float moveSpeed=10;

    // Start is called before the first frame update
    void Start()
    {

        // The code below is not necessary because in the Grab Interactable
        // I have bound the ShootIt function to the Activate event.
        // Look at the Grab Interactable object and look at Interactable Events
        // Scroll down to Activate and you can see when the Activate
        // event occurs, it will use the Grab Interactableʻs DropIt function
    
        // The code below is just an example of what it would be like
        // if you didnt do the binding above but instead wanted to
        // set up the event listener manually.

        // Get the Grab Interactable component
        //  XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();

        // Listen for the Activate event
        //  grabbable.activated.AddListener(DropIt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function gets called when an Activate event happens
    public void ShootIt(ActivateEventArgs arg){

        // Spawn the object
        GameObject spawnedObject = Instantiate(thingToDrop);

        // and place it at the designated spawn point
        spawnedObject.transform.position = spawnPoint.position;

        spawnedObject.GetComponent<Rigidbody>().velocity = spawnPoint.forward * moveSpeed;
        Destroy(spawnedObject,5);

    }
}