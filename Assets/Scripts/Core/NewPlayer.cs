using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [Header("Attributes")]
    [SerializeField] private float attackDuration; //How long is the attackBox active when attacking?
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float fallForgiveness = 1; //This is the amount of seconds the player has after falling from a ledge to be able to jump
    [SerializeField] private float fallForgivenessCounter; //This is the simple counter that will begin the moment the player falls from a ledge
    [SerializeField] private AudioClip deathSound;
    private bool frozen;

    [Header("Inventory")]
    public int ammo;
    public int coinsCollected;
    private int maxHealth = 100;
    public int health = 100;

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorFunctions animatorFunctions;
    [SerializeField] private GameObject attackBox;
    public CameraEffects cameraEffects;
    private Vector2 healthBarOrigSize;
    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>(); //Dictionary storing all inventory item strings and values
    public Sprite inventoryItemBlank; //The default inventory item slot sprite
    public Sprite keySprite; //The key inventory item
    public Sprite keyGemSprite; //The gem key inventory item

    public AudioSource sfxAudioSource;
    public AudioSource musicAudioSource;
    public AudioSource ambienceAudioSource;

    //Singleton instantation
    private static NewPlayer instance;
    public static NewPlayer Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<NewPlayer>();
            return instance;
        }
    }

    private void Awake()
    {
        if (GameObject.Find("New Player")) Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.name = "New Player";
        UpdateUI();
        SetSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);

            //If the player is no longer grounded, begin counting the fallForgivenessCounter
            if (!grounded)
            {
                fallForgivenessCounter += Time.deltaTime;
            }
            else
            {
                fallForgivenessCounter = 0;
            }

            //If the player presses "Jump" and we're grounded, set the velocity to a jump power value
            if (Input.GetButtonDown("Jump") && fallForgivenessCounter < fallForgiveness)
            {
                animatorFunctions.EmitParticles1();
                velocity.y = jumpPower;
                grounded = false;
                fallForgivenessCounter = fallForgiveness;
            }


            //Flip the player's localScale.x if the move speed is greater than .01 or less than -.01
            if (targetVelocity.x < -.01)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else if (targetVelocity.x > .01)
            {
                transform.localScale = new Vector2(1, 1);
            }

            //If we press "Fire1", then set the attackBox to active. Otherwise, set active to false
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("attack");
                //StartCoroutine(ActivateAttack());
            }

            //Check if player health is smaller than or equal to 0.
            if (health <= 0)
            {
                StartCoroutine(Die());
            }
        }

        //Set each animator float, bool, and trigger so it knows which animation to fire
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetFloat("velocityY", velocity.y);
        animator.SetBool("grounded", grounded);
        animator.SetFloat("attackDirectionY", Input.GetAxis("Vertical"));

    }

    //Update UI elements
    public void UpdateUI()
    {
        //If the healthBarOrigSize has not been set yet, match it to the healthBar rectTransform size!
        if (healthBarOrigSize == Vector2.zero) healthBarOrigSize = GameManager.Instance.healthBar.rectTransform.sizeDelta;
        GameManager.Instance.coinsText.text = coinsCollected.ToString();
        GameManager.Instance.healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health / (float)maxHealth), GameManager.Instance.healthBar.rectTransform.sizeDelta.y);
    }

    public void SetSpawnPosition()
    {
        transform.position = GameObject.Find("Spawn Location").transform.position;
    }

    public IEnumerator Die()
    {
        frozen = true;
        sfxAudioSource.PlayOneShot(deathSound);
        animator.SetBool("dead", true);
        animatorFunctions.EmitParticles5();
        //pause (yield) this function for 2 seconds
        yield return new WaitForSeconds(2);
        LoadLevel("Level1");
    }

    public IEnumerator FreezeEffect(float length, float timeScale)
    {
        Time.timeScale = timeScale;
        yield return new WaitForSeconds(length);
        Time.timeScale = 1;

    }

    public void LoadLevel(string loadSceneString)
    {
        animator.SetBool("dead", false);
        health = 100;
        coinsCollected = 0;
        RemoveInventoryItem("none", true);
        frozen = false;
        SceneManager.LoadScene(loadSceneString);
        SetSpawnPosition();
        UpdateUI();
    }

    public void AddInventoryItem(string inventoryName, Sprite image = null)
    {
        inventory.Add(inventoryName, image);
        //The blank sprite should now swap with key sprite
        GameManager.Instance.inventoryItemImage.sprite = inventory[inventoryName];
    }

    public void RemoveInventoryItem(string inventoryName, bool removeAll = false)
    {
        if(!removeAll)
        {
            inventory.Remove(inventoryName);
        }
        else
        {
            inventory.Clear();
        }

        inventory.Remove(inventoryName);
        //The blank sprite should now swap with key sprite
        GameManager.Instance.inventoryItemImage.sprite = inventoryItemBlank;
    }

    public void Hurt(int attackPower)
    {
        StartCoroutine(FreezeEffect(.5f, .6f));
        animator.SetTrigger("hurt");
        cameraEffects.Shake(5, .5f);
        NewPlayer.Instance.health -= attackPower;
        NewPlayer.Instance.UpdateUI();
    }
}
