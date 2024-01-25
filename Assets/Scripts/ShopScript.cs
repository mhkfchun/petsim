using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{

    [SerializeField] private TMP_Text messageText;
    [SerializeField] private GameObject dog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(dog == null) {
            dog = GameObject.Find("Dog");
        }

        messageText.SetText("STORE\nCurrent Coins: " + dog.GetComponent<DogControls>().coins);

        
    }
}
