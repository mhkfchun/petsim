using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : MonoBehaviour
{

    [SerializeField] GameObject TV1;
    [SerializeField] GameObject TV2;
    [SerializeField] GameObject Armchair1;
    [SerializeField] GameObject Armchair2;
    [SerializeField] GameObject Armchair3;
    [SerializeField] GameObject Plant1;
    [SerializeField] GameObject Plant2;
    [SerializeField] GameObject Plant3;
    [SerializeField] GameObject Plant4;
    [SerializeField] GameObject Plant5;
    [SerializeField] GameObject Drawer1;
    [SerializeField] GameObject Drawer2;
    [SerializeField] GameObject Stand1;
    [SerializeField] GameObject Stand2;
    [SerializeField] GameObject Stand3;
    [SerializeField] GameObject Stand4;
    [SerializeField] GameObject Stand5;
    [SerializeField] GameObject Stand6;
    [SerializeField] GameObject Shelf1;
    [SerializeField] GameObject Shelf2;
    [SerializeField] GameObject Shelf3;
    [SerializeField] GameObject Shelf4;
    [SerializeField] GameObject Shelf5;
    [SerializeField] GameObject Shelf6;
    [SerializeField] GameObject Shelf7;
    [SerializeField] GameObject Shelf8;
    [SerializeField] GameObject Shelf9;
    [SerializeField] GameObject Shelf10;
    [SerializeField] GameObject Shelf11;
    [SerializeField] GameObject Shelf12;
    [SerializeField] GameObject Shelf13;
    [SerializeField] GameObject Shelf14;
    [SerializeField] public bool isTV;
    [SerializeField] public bool isArmchair;
    [SerializeField] public bool isPlant;
    [SerializeField] public bool isDrawer;
    [SerializeField] public bool isStand;
    [SerializeField] public bool isShelf;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isTV) {
            TV1.SetActive(true);
            TV2.SetActive(true);
        } else{
            TV1.SetActive(false);
            TV2.SetActive(false);
        }

        if(isArmchair) {
            Armchair1.SetActive(true);
            Armchair2.SetActive(true);
            Armchair3.SetActive(true);
        } else{
            Armchair1.SetActive(false);
            Armchair2.SetActive(false);
            Armchair3.SetActive(false);
        }

        if(isPlant) {
            Plant1.SetActive(true);
            Plant2.SetActive(true);
            Plant3.SetActive(true);
            Plant4.SetActive(true);
            Plant5.SetActive(true);
        } else{
            Plant1.SetActive(false);
            Plant2.SetActive(false);
            Plant3.SetActive(false);
            Plant4.SetActive(false);
            Plant5.SetActive(false);
        }

        if(isDrawer) {
            Drawer1.SetActive(true);
            Drawer2.SetActive(true);
        } else{
            Drawer1.SetActive(false);
            Drawer2.SetActive(false);
        }

        if(isStand) {
            Stand1.SetActive(true);
            Stand2.SetActive(true);
            Stand3.SetActive(true);
            Stand4.SetActive(true);
            Stand5.SetActive(true);
            Stand6.SetActive(true);
        } else{
            Stand1.SetActive(false);
            Stand2.SetActive(false);
            Stand3.SetActive(false);
            Stand4.SetActive(false);
            Stand5.SetActive(false);
            Stand6.SetActive(false);
        }

        if(isShelf) {
            Shelf1.SetActive(true);
            Shelf2.SetActive(true);
            Shelf3.SetActive(true);
            Shelf4.SetActive(true);
            Shelf5.SetActive(true);
            Shelf6.SetActive(true);
            Shelf7.SetActive(true);
            Shelf8.SetActive(true);
            Shelf9.SetActive(true);
            Shelf10.SetActive(true);
            Shelf11.SetActive(true);
            Shelf12.SetActive(true);
            Shelf13.SetActive(true);
            Shelf14.SetActive(true);
        } else{
            Shelf1.SetActive(false);
            Shelf2.SetActive(false);
            Shelf3.SetActive(false);
            Shelf4.SetActive(false);
            Shelf5.SetActive(false);
            Shelf6.SetActive(false);
            Shelf7.SetActive(false);
            Shelf8.SetActive(false);
            Shelf9.SetActive(false);
            Shelf10.SetActive(false);
            Shelf11.SetActive(false);
            Shelf12.SetActive(false);
            Shelf13.SetActive(false);
            Shelf14.SetActive(false);
        }


    }
   
   
    public void setTV() {
        if(isTV) {
            isTV = false;
        } else {
            isTV = true;
        }
    }

    public void setArmchair() {
        if(isArmchair) {
            isArmchair = false;
        } else {
            isArmchair = true;
        }
    }

    public void setPlant() {
        if(isPlant) {
            isPlant = false;
        } else {
            isPlant = true;
        }
    }

    public void setDrawer() {
        if(isDrawer) {
            isDrawer = false;
        } else {
            isDrawer = true;
        }
    }

    public void setStand() {
        if(isStand) {
            isStand = false;
        } else {
            isStand = true;
        }
    }

    public void setShelf() {
        if(isShelf) {
            isShelf = false;
        } else {
            isShelf = true;
        }
    }
}
