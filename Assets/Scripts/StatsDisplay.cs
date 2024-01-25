using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
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

        messageText.SetText("STATS\nHunger: " + dog.GetComponent<DogControls>().hunger + "\nCoins: " + dog.GetComponent<DogControls>().coins + "\nTotal Coins: " + dog.GetComponent<DogControls>().totalCoins + "\nGiven Food: " + dog.GetComponent<DogControls>().timesFed + "\nPlayed Fetch: " + dog.GetComponent<DogControls>().timesFetch + "\nTotal Headpats: " + dog.GetComponent<DogControls>().timesPet);

        
    }
}
