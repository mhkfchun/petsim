using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonControls : MonoBehaviour
{   
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private GameObject dog;
    private InputAction homeButtonAction;
    [SerializeField] private bool menuOn = false;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject statMenu;
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private GameObject shopMenuRoom;
    [SerializeField] private GameObject shopMenuSnow;
    [SerializeField] private GameObject shopMenuVenue;
    [SerializeField] private GameObject shopMenuDog;
    [SerializeField] private GameObject shopMenuItem;
    [SerializeField] private GameObject saveMenu;
    [SerializeField] private GameObject saveMenu2;
    [SerializeField] private GameObject loadMenu;
    [SerializeField] private GameObject loadMenu2;
    [SerializeField] private GameObject clearMenu;
    [SerializeField] private GameObject clearMenu2;
    [SerializeField] private GameObject foodButton;
    [SerializeField] public AudioSource aud;
    [SerializeField] public AudioClip money;
    [SerializeField] public AudioClip click;
    [SerializeField] public AudioClip error;
    [SerializeField] public AudioClip whistle;

    public bool tvPurchase = false;
    public bool armchairPurchase = false;
    public bool plantPurchase = false;
    public bool drawerPurchase = false;
    public bool standPurchase = false;
    public bool shelfPurchase = false;

    
    
    

    // Start is called before the first frame update
    public void Start()
    {
        menuOn = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if(inventoryMenu.activeSelf) {
            if(dog == null) {
                GameObject dog = GameObject.Find("Dog");
            }

            if(dog.GetComponent<DogControls>().getHunger() <= 6) {
                foodButton.SetActive(true);
            } else {
                foodButton.SetActive(false);
            }

        }
    }

    public void OnEnable() {
        homeButtonAction = actionAsset.FindActionMap("MyActionMap").FindAction("MyActionPress");
        homeButtonAction.performed += OnHomeButtonPressed;
        homeButtonAction.Enable();
    }

    public void OnDisable() {
        homeButtonAction.Disable();
    }

    public void OnHomeButtonPressed(InputAction.CallbackContext context) {
        {   
            PlayClick();
            if(!menuOn) {
                menuOn = true;
                menu.SetActive(true);
            } else {
                menuOn = false;
                menu.SetActive(false);
                inventoryMenu.SetActive(false);
                statMenu.SetActive(false);
                loadMenu.SetActive(false);
                loadMenu2.SetActive(false);
                shopMenu.SetActive(false);
                shopMenuRoom.SetActive(false);
                shopMenuSnow.SetActive(false);
                shopMenuVenue.SetActive(false);
                shopMenuDog.SetActive(false);
                shopMenuItem.SetActive(false);
                saveMenu.SetActive(false);
                saveMenu2.SetActive(false);
                clearMenu.SetActive(false);
                clearMenu2.SetActive(false);
                //Add More Menus as you add them
            }
        }
    }

    public void ShowInventory() {
        PlayClick();
        menu.SetActive(false);
        inventoryMenu.SetActive(true);
    }

    public void ShowStat() {
        PlayClick();
        menu.SetActive(false);
        statMenu.SetActive(true);
    }

    public void ShowLoad() {
        PlayClick();
        menu.SetActive(false);
        loadMenu.SetActive(true);
    }

    public void ShowLoad2() {
        PlayClick();
        loadMenu.SetActive(false);
        loadMenu2.SetActive(true);
    }

    public void ShowShop() {
        PlayClick();
        menu.SetActive(false);
        shopMenu.SetActive(true);
    }

    public void ShowShopRoom() {
        PlayClick();
        shopMenu.SetActive(false);
        shopMenuRoom.SetActive(true);
    }

    public void ShowShopSnow() {
        PlayClick();
        shopMenu.SetActive(false);
        shopMenuSnow.SetActive(true);
    }

    public void ShowShopVenue() {
        PlayClick();
        shopMenu.SetActive(false);
        shopMenuVenue.SetActive(true);
    }

    public void ShowShopDog() {
        PlayClick();
        shopMenu.SetActive(false);
        shopMenuDog.SetActive(true);
    }

    public void ShowShopItem() {
        PlayClick();
        shopMenu.SetActive(false);
        shopMenuItem.SetActive(true);
    }

    public void ShowSave() {
        PlayClick();
        menu.SetActive(false);
        saveMenu.SetActive(true);
    }

    public void ShowSave2() {
        PlayClick();
        saveMenu.SetActive(false);
        saveMenu2.SetActive(true);
    }

    public void ShowClear() {
        PlayClick();
        menu.SetActive(false);
        clearMenu.SetActive(true);
    }

    public void ShowClear2() {
        PlayClick();
        clearMenu.SetActive(false);
        clearMenu2.SetActive(true);
    }

    public void BackToShop() {
        PlayClick();
        shopMenuRoom.SetActive(false);
        shopMenuSnow.SetActive(false);
        shopMenuVenue.SetActive(false);
        shopMenuDog.SetActive(false);
        shopMenuItem.SetActive(false);
        shopMenu.SetActive(true);
    }

    public void BackToMain() {
        PlayClick();
        inventoryMenu.SetActive(false);
        statMenu.SetActive(false);
        loadMenu.SetActive(false);
        loadMenu2.SetActive(false);
        shopMenu.SetActive(false);
        shopMenuRoom.SetActive(false);
        shopMenuSnow.SetActive(false);
        shopMenuVenue.SetActive(false);
        shopMenuDog.SetActive(false);
        shopMenuItem.SetActive(false);
        saveMenu.SetActive(false);
        saveMenu2.SetActive(false);
        clearMenu.SetActive(false);
        clearMenu2.SetActive(false);
        //Add More Menus as you add them
        menu.SetActive(true);
    }

    public void FeedPressed() {
        PlayClick();
        if(dog == null) {
            GameObject dog = GameObject.Find("Dog");
        }
        dog.GetComponent<DogControls>().SpawnFood();
    }

    public void FetchPressed() {
        PlayClick();
        if(dog == null) {
            GameObject dog = GameObject.Find("Dog");
        }
        dog.GetComponent<DogControls>().setIsStartFetch();
    }

    public void EndFetchPressed() {
        PlayClick();
        if(dog == null) {
            GameObject dog = GameObject.Find("Dog");
        }
        dog.GetComponent<DogControls>().setEndFetch();
    }

    public void ResetDogPressed() {
        PlayClick();
        if(dog == null) {
            GameObject dog = GameObject.Find("Dog");
        }
        dog.GetComponent<DogControls>().resetDog();
    }

    public void ResetPlayerPressed() {
        PlayClick();
        if(dog == null) {
            GameObject dog = GameObject.Find("Dog");
        }
        dog.GetComponent<DogControls>().resetPlayer();
    }

    public void CallPressed() {
        aud.PlayOneShot(whistle);
        if(dog == null) {
            GameObject dog = GameObject.Find("Dog");
        }
        dog.GetComponent<DogControls>().setIsPlayerCall();
    }

    public void LoadPressed() {
        PlayClick();
        if(dog == null) {
            GameObject dog = GameObject.Find("Dog");
        }
        dog.GetComponent<DogControls>().LoadGame();
        ShowLoad2();
    }

    public void SavePressed() {
        PlayClick();
        if(dog == null) {
            GameObject dog = GameObject.Find("Dog");
        }
        dog.GetComponent<DogControls>().SaveGame();
        ShowSave2();
    }

    public void ClearPressed() {
        PlayClick();
        if(dog == null) {
            GameObject dog = GameObject.Find("Dog");
        }
        dog.GetComponent<DogControls>().ClearGame();
        ShowClear2();
    }

    public void CheatPressed() {
        PlayAudio();
        if(dog == null) {
            GameObject dog = GameObject.Find("Dog");
        }
        dog.GetComponent<DogControls>().coins += 20;
    }

    public void TVPressed() {
        if(!tvPurchase) {
            if(dog == null) {
                GameObject dog = GameObject.Find("Dog");
            }
            if(dog.GetComponent<DogControls>().coins > 20) {
                dog.GetComponent<DogControls>().purchase(20);
                tvPurchase = true;
                PlayAudio();
                GameObject deco = GameObject.Find("Set");
                deco.GetComponent<Decoration>().setTV();
            } else {
                PlayError();
            }
        } else {
            PlayClick();
            GameObject deco = GameObject.Find("Set");
            deco.GetComponent<Decoration>().setTV();
        }
    }

    public void ArmchairPressed() {
        if(!armchairPurchase) {
            if(dog == null) {
                GameObject dog = GameObject.Find("Dog");
            }
            if(dog.GetComponent<DogControls>().coins > 20) {
                dog.GetComponent<DogControls>().purchase(20);
                armchairPurchase = true;
                PlayAudio();
                GameObject deco = GameObject.Find("Set");
                deco.GetComponent<Decoration>().setArmchair();
            } else {
                PlayError();
            }
        } else {
            PlayClick();
            GameObject deco = GameObject.Find("Set");
            deco.GetComponent<Decoration>().setArmchair();
        }
    }

    public void PlantPressed() {
        if(!plantPurchase) {
            if(dog == null) {
                GameObject dog = GameObject.Find("Dog");
            }
            if(dog.GetComponent<DogControls>().coins > 20) {
                dog.GetComponent<DogControls>().purchase(20);
                plantPurchase = true;
                PlayAudio();
                GameObject deco = GameObject.Find("Set");
                deco.GetComponent<Decoration>().setPlant();
            } else {
                PlayError();
            }
        } else {
            PlayClick();
            GameObject deco = GameObject.Find("Set");
            deco.GetComponent<Decoration>().setPlant();
        }
    }

    public void DrawerPressed() {
        if(!drawerPurchase) {
            if(dog == null) {
                GameObject dog = GameObject.Find("Dog");
            }
            if(dog.GetComponent<DogControls>().coins > 20) {
                dog.GetComponent<DogControls>().purchase(20);
                drawerPurchase = true;
                PlayAudio();
                GameObject deco = GameObject.Find("Set");
                deco.GetComponent<Decoration>().setDrawer();
            } else {
                PlayError();
            }
        } else {
            PlayClick();
            GameObject deco = GameObject.Find("Set");
            deco.GetComponent<Decoration>().setDrawer();
        }
    }

    public void StandPressed() {
        if(!standPurchase) {
            if(dog == null) {
                GameObject dog = GameObject.Find("Dog");
            }
            if(dog.GetComponent<DogControls>().coins > 20) {
                dog.GetComponent<DogControls>().purchase(20);
                standPurchase = true;
                PlayAudio();
                GameObject deco = GameObject.Find("Set");
                deco.GetComponent<Decoration>().setStand();
            } else {
                PlayError();
            }
        } else {
            PlayClick();
            GameObject deco = GameObject.Find("Set");
            deco.GetComponent<Decoration>().setStand();
        }
    }

    public void ShelfPressed() {
        if(!shelfPurchase) {
            if(dog == null) {
                GameObject dog = GameObject.Find("Dog");
            }
            if(dog.GetComponent<DogControls>().coins > 20) {
                dog.GetComponent<DogControls>().purchase(20);
                shelfPurchase = true;
                PlayAudio();
                GameObject deco = GameObject.Find("Set");
                deco.GetComponent<Decoration>().setShelf();
            } else {
                PlayError();
            }
        } else {
            PlayClick();
            GameObject deco = GameObject.Find("Set");
            deco.GetComponent<Decoration>().setShelf();
        }
    }

    public void PlayAudio() {
        aud.PlayOneShot(money);
    }

    public void PlayClick() {
        aud.PlayOneShot(click);
    }
            
    public void PlayError() {
        aud.PlayOneShot(error);
    }

    

}
