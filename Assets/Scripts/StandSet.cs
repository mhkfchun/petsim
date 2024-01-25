using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StandSet : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private GameObject control;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(control.GetComponent<ButtonControls>().standPurchase) {
            messageText.SetText("Stand Set");
        } else {
            messageText.SetText("Stand Set (20)");
        }
    }
}
