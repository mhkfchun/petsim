using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogControls : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject ball;
    [SerializeField] private float idleTime = 5f;
    [SerializeField] private float playerTime = 10f;
    [SerializeField] private GameObject player;
    private GameObject moveMarker;
    private List<Transform> moveMarkers = new List<Transform>();
    private bool isIdle = true;
    private bool isIdleWalk = false;
    [SerializeField] private bool isPlayerCall = false;
    private bool isPlayerWait = false;
    private GameObject target;
    [SerializeField] public float hunger = 10f;
    private float hungerTimer = 30f;
    private bool isStarving = false;
    [SerializeField] private bool isStartFetch = false;
    [SerializeField] private bool isFetch = false;
    private bool isFetchWait = false;
    private bool isFetchFind = false;
    private bool isFetchReturn = false;
    [SerializeField] private bool isFetchEnd = false;
    private GameObject inGameBall;
    [SerializeField] private bool ballThrown = false;
    [SerializeField] private GameObject mouth;
    [SerializeField] private GameObject food;
    [SerializeField] bool isEating = false;
    private bool isEatingFood = false;
    private GameObject inGameFood;
    private float foodTimer = 3f;

    [SerializeField] bool triggerFeed = false;

    [SerializeField] public float coins = 0;
    [SerializeField] public float timesPet = 0;
    [SerializeField] public float timesFetch = 0;
    [SerializeField] public float totalCoins = 0;
    [SerializeField] public float timesFed = 0;

    [SerializeField] public AudioClip bark1;
    [SerializeField] public AudioClip bark2;
    [SerializeField] public AudioClip bark3;
    [SerializeField] public AudioClip bark4;
    [SerializeField] public AudioClip bark5;
    [SerializeField] public AudioSource aud;
    // Start is called before the first frame update
    public void Start()
    {
        isStarving = false;
        isIdle = true;
        isIdleWalk = false;
        isPlayerCall = false;
        isPlayerWait = false;
        isStartFetch = false;
        isFetch = false;
        isFetchWait = false;
        isFetchFind = false;
        ballThrown = false;
        isFetchEnd = false;
        isEating = false;
        isEatingFood = false;
        animator = GetComponent<Animator>();
        animator.SetBool("Sitting", true);
        moveMarker = GameObject.Find("Walk Markers");
        foreach(Transform marker in moveMarker.transform) {
            moveMarkers.Add(marker);
        }
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if(triggerFeed) {
            triggerFeed = false;
            SpawnFood();
        }

        if(isEatingFood) {
            if(foodTimer > 0) {
                if(!animator.GetBool("Eating")) {
                    animator.SetBool("Eating", true);
                }
                foodTimer -= Time.deltaTime;
            } else {
                animator.SetBool("Eating", false);
                Object.Destroy(inGameFood);
                timesFed += 1;
                if(!isStarving) {
                    coins += 5;
                    totalCoins += 5;
                }
                hunger = 10;
                isEatingFood = false;
                isIdle = true;
                foodTimer = 3f;
                playBark();
            }

        }

        if(isEating) {
            WalkToFood();
        }

        if(isFetchEnd) {
            isStartFetch = false;
            isFetch = false;
            isFetchWait = false;
            isFetchFind = false;
            ballThrown = false;
            isFetchEnd = false;
            Object.Destroy(inGameBall);
            isIdle = true;
            waitAnimOff();
        }

        if(ballThrown) {
            isStartFetch = false;
            isFetch = false;
            isFetchWait = false;
            isFetchFind = true;
            ballThrown = false;
            animator.SetBool("Sitting", false);
            playBark();
        }

        if(isFetchReturn) {
            GrabBall();
            WalkToPlayer();
        }

        if(isFetchFind) {
            WalkToBall();
        }

        if(isStartFetch) {
            playBark();
            isEating = false;
            isEatingFood = false;
            Object.Destroy(inGameFood);
            isIdle = false;
            isIdleWalk = false;
            isPlayerCall = false;
            isPlayerWait = false;
            SpawnBall();
            isStartFetch = false;
            isFetch = true;
            waitAnimOff();
        }

        if(isFetch) {
            WalkToPlayer();
        }

        if(isFetchWait) {
            LookAtBall();
        }

        if (isPlayerCall) {
            waitAnimOff();
            WalkToPlayer();
        } else if (isPlayerWait) {
            if(playerTime > 0f) {
                LookAtPlayer();
                playerTime -= Time.deltaTime;
            } else {
                isPlayerWait = false;
                isIdle = true;
                playerTime = 10f;
                animator.SetBool("Sitting", false);
            }
        } else {
            if(isIdle) {
                if(idleTime > 0f) {
                    LookAtPlayer();
                    idleTime -= Time.deltaTime;
                } else {
                    isIdle = false;
                    changePosition();
                }
            }
            
            if (isIdleWalk) {
                if(transform.position != target.transform.position) {
                    WalkToTarget();
                } else {
                    animator.SetBool("Walking", false);
                    waitAnimOn(Random.Range(1, 4));
                    isIdleWalk = false;
                    isIdle = true;
                    idleTime = 5f;
                    playBark();
                }
            }
        }

        if(hungerTimer > 0f) {
            hungerTimer -= Time.deltaTime;
        } else {
            hungerTimer = 30f;
            if(hunger > 0f) {
                hunger--;
            } else {
                if(!isStarving) {
                    isStarving = true;
                } 
            }
        }


        
    }

    public void OnTriggerEnter(Collider other) {
        if(other.name.Equals("PlayerCharacter")) {
            if(isPlayerCall) {
                playBark();
                animator.SetBool("Walking", false);
                isPlayerCall = false;
                isPlayerWait = true;
                animator.SetBool("Sitting", true);
            }

            if(isFetch) {
                animator.SetBool("Walking", false);
                isFetch = false;
                isFetchWait = true;
                animator.SetBool("Sitting", true);
                playBark();
            }

            if(isFetchReturn) {
                animator.SetBool("Walking", false);
                isFetchReturn = false;
                inGameBall.GetComponent<Rigidbody>().isKinematic = false;
                isFetchWait = true;
                timesFetch += 1;
                coins += 3;
                totalCoins += 3;
                animator.SetBool("Sitting", true);
                playBark();
            }
        }

        if(other.name.Equals("Ball")) {
            if(isFetchFind) {
                isFetchFind = false;
                isFetchReturn = true;
                inGameBall.GetComponent<Rigidbody>().isKinematic = true;
                playBark();
            }
        }

        if(other.name.Equals("Steak")) {
            if(isEating) {
                isEating = false;
                isEatingFood = true;
                animator.SetBool("Walking", false);
            }
        }
    }

    public void changePosition() {
        waitAnimOff();
        int position = Random.Range(0,moveMarkers.Count);
        target = moveMarkers[position].gameObject;
        isIdleWalk = true;
        
    }

    public void LookAtBall() {
        inGameBall = GameObject.Find("Ball");
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, inGameBall.transform.position - transform.position, 2f * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void GrabBall() {
        Vector3 mouthPosition = mouth.transform.position;
        inGameBall.transform.position = mouthPosition;
    }

    public void WalkToBall() {
        LookAtBall();
        animator.SetBool("Walking", true);
        Vector3 pos = Vector3.MoveTowards(transform.position, inGameBall.transform.position,  1f * Time.deltaTime);
        pos.y = 0.174f;
        transform.position = pos;
    }

    public void WalkToPlayer() {
        LookAtPlayer();
        animator.SetBool("Walking", true);
        Vector3 pos = Vector3.MoveTowards(transform.position, player.transform.position,  1f * Time.deltaTime);
        pos.y = 0.174f;
        transform.position = pos;
    }

    public void LookAtPlayer() {
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, player.transform.position - transform.position, 2f * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void WalkToTarget() {
        animator.SetBool("Walking", true);
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, target.transform.position - transform.position, 2f * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        Vector3 pos = Vector3.MoveTowards(transform.position, target.transform.position,  1f * Time.deltaTime);
        //pos.y = 0.174f;
        transform.position = pos;
    }

    public void WalkToFood() {
        animator.SetBool("Walking", true);
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, inGameFood.transform.position - transform.position, 2f * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        Vector3 pos = Vector3.MoveTowards(transform.position, inGameFood.transform.position,  1f * Time.deltaTime);
        pos.y = 0.174f;
        transform.position = pos;
    }

    public void SpawnBall() {
        Vector3 userPos = player.transform.position;
        Vector3 userDir = player.transform.forward;
        Quaternion userRot = player.transform.rotation;
        Vector3 spawnPos = userPos + userDir*2;
        spawnPos.y += 2;
        GameObject ballIn = GameObject.Find("Ball");
        if(ballIn == null) {
            ballIn = Instantiate(ball, spawnPos, userRot);
            ballIn.name = "Ball";
        } else {
            ballIn.transform.position = spawnPos;
        }
    }

    public void waitAnimOff() {
        if(animator.GetBool("Sitting")) {
            animator.SetBool("Sitting", false);
        }

        if(animator.GetBool("Turning")) {
            animator.SetBool("Turning", false);
        }

        if(animator.GetBool("Laying")) {
            animator.SetBool("Laying", false);
        }

        if(animator.GetBool("Eating")) {
            animator.SetBool("Eating", false);
        }

        if(animator.GetBool("Walking")) {
            animator.SetBool("Walking", false);
        }

        if(animator.GetBool("Standing")) {
            animator.SetBool("Standing", false);
        }
    }

    public void waitAnimOn(int num) {
        if(num == 1) {
            animator.SetBool("Sitting", true);
        } else if(num == 2) {
            animator.SetBool("Turning", true);
        } else {
            animator.SetBool("Laying", true);
        }
    }

    public void SpawnFood() {
        isEating = false;
        isEatingFood = false;
        Object.Destroy(inGameFood);
        Vector3 userPos = player.transform.position;
        Vector3 userDir = player.transform.forward;
        Quaternion userRot = player.transform.rotation;
        Vector3 spawnPos = userPos + userDir*2;
        spawnPos.y += 2;
        inGameFood = GameObject.Find("Steak");
        if(inGameFood == null) {
            inGameFood = Instantiate(food, spawnPos, userRot);
            inGameFood.name = "Steak";
        } else {
            inGameFood.transform.position = spawnPos;
        }
        isStartFetch = false;
        isFetch = false;
        isFetchWait = false;
        isFetchFind = false;
        ballThrown = false;
        isFetchEnd = false;
        Object.Destroy(inGameBall);
        isIdle = false;
        isIdle = false;
        isIdleWalk = false;
        isPlayerCall = false;
        isPlayerWait = false;
        isEating = true;
        waitAnimOff();
    }

    public void SaveGame() {
        PlayerPrefs.SetInt("Coins", (int) coins);
        PlayerPrefs.SetInt("Total Coins", (int) totalCoins);
        PlayerPrefs.SetInt("Times Fed", (int) timesFed);
        PlayerPrefs.SetInt("Times Fetched", (int) timesFetch);
        PlayerPrefs.SetInt("Times Pet", (int) timesPet);
        GameObject deco = GameObject.Find("Set");
        if(deco.GetComponent<Decoration>().isTV) {
            PlayerPrefs.SetInt("TV Set", 1);
        } else {
            PlayerPrefs.SetInt("TV Set", 0);
        }
        if(deco.GetComponent<Decoration>().isArmchair) {
            PlayerPrefs.SetInt("Armchair Set", 1);
        } else {
            PlayerPrefs.SetInt("Armchair Set", 0);
        }
        if(deco.GetComponent<Decoration>().isPlant) {
            PlayerPrefs.SetInt("Plant Set", 1);
        } else {
            PlayerPrefs.SetInt("Plant Set", 0);
        }
        if(deco.GetComponent<Decoration>().isDrawer) {
            PlayerPrefs.SetInt("Drawer Set", 1);
        } else {
            PlayerPrefs.SetInt("Drawer Set", 0);
        }
        if(deco.GetComponent<Decoration>().isStand) {
            PlayerPrefs.SetInt("Stand Set", 1);
        } else {
            PlayerPrefs.SetInt("Stand Set", 0);
        }
        if(deco.GetComponent<Decoration>().isShelf) {
            PlayerPrefs.SetInt("Shelf Set", 1);
        } else {
            PlayerPrefs.SetInt("Shelf Set", 0);
        }
        PlayerPrefs.Save();
    }

    public void LoadGame() {
        coins = PlayerPrefs.GetInt("Coins", 0);
        totalCoins = PlayerPrefs.GetInt("Total Coins", 0);
        timesFed = PlayerPrefs.GetInt("Times Fed", 0);
        timesFetch = PlayerPrefs.GetInt("Times Fetched", 0);
        timesPet = PlayerPrefs.GetInt("Times Pet", 0);
        GameObject control = GameObject.Find("Left Controller");
        GameObject deco = GameObject.Find("Set");
        if(PlayerPrefs.GetInt("TV Set", 0) == 1) {
            control.GetComponent<ButtonControls>().tvPurchase = true;
        } else {
            control.GetComponent<ButtonControls>().tvPurchase = false;
            deco.GetComponent<Decoration>().isTV = false;
        }
        if(PlayerPrefs.GetInt("Armchair Set", 0) == 1) {
            control.GetComponent<ButtonControls>().armchairPurchase = true;
        } else {
            control.GetComponent<ButtonControls>().armchairPurchase = false;
            deco.GetComponent<Decoration>().isArmchair = false;
        }
        if(PlayerPrefs.GetInt("Plant Set", 0) == 1) {
            control.GetComponent<ButtonControls>().plantPurchase = true;
        } else {
            control.GetComponent<ButtonControls>().plantPurchase = false;
            deco.GetComponent<Decoration>().isPlant = false;
        }
        if(PlayerPrefs.GetInt("Drawer Set", 0) == 1) {
            control.GetComponent<ButtonControls>().drawerPurchase = true;
        } else {
            control.GetComponent<ButtonControls>().drawerPurchase = false;
            deco.GetComponent<Decoration>().isDrawer = false;
        }
        if(PlayerPrefs.GetInt("Stand Set", 0) == 1) {
            control.GetComponent<ButtonControls>().standPurchase = true;
        } else {
            control.GetComponent<ButtonControls>().standPurchase = false;
            deco.GetComponent<Decoration>().isStand = false;
        }
        if(PlayerPrefs.GetInt("Shelf Set", 0) == 1) {
            control.GetComponent<ButtonControls>().shelfPurchase = true;
        } else {
            control.GetComponent<ButtonControls>().shelfPurchase = false;
            deco.GetComponent<Decoration>().isShelf = false;
        }

    }

    public void ClearGame() {
        PlayerPrefs.SetInt("Coins", (int) 0);
        PlayerPrefs.SetInt("Total Coins", (int) 0);
        PlayerPrefs.SetInt("Times Fed", (int) 0);
        PlayerPrefs.SetInt("Times Fetched", (int) 0);
        PlayerPrefs.SetInt("Times Pet", (int) 0);
        PlayerPrefs.SetInt("TV Set", 0);
        PlayerPrefs.SetInt("Armchair Set", 0);
        PlayerPrefs.SetInt("Plant Set", 0);
        PlayerPrefs.SetInt("Drawer Set", 0);
        PlayerPrefs.SetInt("Stand Set", 0);
        PlayerPrefs.SetInt("Shelf Set", 0);
        PlayerPrefs.Save();
        LoadGame();
    }

    public float getHunger() {
        return hunger;
    }

    public void setIsStartFetch() {
        isFetch = false;
        isFetchWait = false;
        isFetchFind = false;
        ballThrown = false;
        isFetchEnd = false;
        isStartFetch = true;
    }

    public void setEndFetch() {
        isFetch = false;
        isFetchWait = false;
        isFetchFind = false;
        ballThrown = false;
        isStartFetch = false;
        isFetchEnd = true;
    }

    public void setBallThrown() {
        ballThrown = true;
    }

    public void setIsPlayerCall() {
        isPlayerCall = true;
    }

    public void purchase(float amount) {
        coins -= amount;
    }

    public void resetDog() {
        Vector3 position = new Vector3(4.69799995f,0.173999995f,-9.13000011f);
        Vector3 rotation = new Vector3(0f,260f,0f);
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(rotation);
        isStartFetch = false;
        isFetch = false;
        isFetchWait = false;
        isFetchFind = false;
        ballThrown = false;
        isFetchEnd = false;
        Object.Destroy(inGameBall);
        isIdle = false;
        isIdle = false;
        isIdleWalk = false;
        isPlayerCall = false;
        isPlayerWait = false;
        isEating = false;
        isEatingFood = false;
        Object.Destroy(inGameFood);
        isIdleWalk = false;
        isIdle = true;
    }

    public void resetPlayer() {
        if(player == null) {
            GameObject.Find("PlayerCharacter");
        }
        Vector3 position = new Vector3(0.344999999f,0.173999995f,-10.2189999f);
        //Vector3 rotation = new Vector3(0f,69.9999924f,0f);
        player.transform.position = position;
        //player.transform.rotation = Quaternion.LookRotation(rotation);
    }

    public void playBark() {
        int barkNum = Random.Range(1, 6);
        if(barkNum == 1) {
            aud.PlayOneShot(bark1);
        } else if(barkNum == 2) {
            aud.PlayOneShot(bark2);
        } else if(barkNum == 3) {
            aud.PlayOneShot(bark3);
        } else if(barkNum == 4) {
            aud.PlayOneShot(bark4);
        } else {
            aud.PlayOneShot(bark5);
        }
    }
}
