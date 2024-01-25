using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawerSet : MonoBehaviour
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
        if(control.GetComponent<ButtonControls>().drawerPurchase) {
            messageText.SetText("Drawer Set");
        } else {
            messageText.SetText("Drawer Set (20)");
        }
    }
}
