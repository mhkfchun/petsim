using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headpats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision) {
        if(collision.name.Equals("Collision")) {
            GameObject.Find("Dog").GetComponent<DogControls>().timesPet++;
        }
    }
}
