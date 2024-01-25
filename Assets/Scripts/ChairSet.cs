using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChairSet : MonoBehaviour
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
        if(control.GetComponent<ButtonControls>().armchairPurchase) {
            messageText.SetText("Chair Set");
        } else {
            messageText.SetText("Chair Set (20)");
        }
    }
}
