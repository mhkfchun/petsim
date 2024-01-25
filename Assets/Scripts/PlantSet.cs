using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantSet : MonoBehaviour
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
        if(control.GetComponent<ButtonControls>().plantPurchase) {
            messageText.SetText("Plant Set");
        } else {
            messageText.SetText("Plant Set (20)");
        }
    }
}
