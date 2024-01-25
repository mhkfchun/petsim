using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerBallThrown() {
        GameObject dog = GameObject.Find("Dog");
        Debug.Log("Triggered");
        Debug.Log(dog);
        dog.GetComponent<DogControls>().setBallThrown();
    }
}
