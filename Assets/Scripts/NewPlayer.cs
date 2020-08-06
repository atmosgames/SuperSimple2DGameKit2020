using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10;

    public int coinsCollected;
    private int maxHealth = 100;
    public int health = 100;
    public int ammo;

    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();
    public Image inventoryItemImage;
    public Sprite keySprite;
    public Sprite keyGemSprite;
    public Sprite inventoryItemBlank;

    public Text coinsText;
    public Image healthBar;
    [SerializeField] private Vector2 healthBarOrigSize;

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

    // Start is called before the first frame update
    void Start()
    {
        healthBarOrigSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal")*maxSpeed, 0);
        //If the player presses "Jump" and we're grounded, set the velocity to a jump power value
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpPower;
        }
    }

    //Update UI elements
    public void UpdateUI()
    {
        coinsText.text = coinsCollected.ToString();
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health / (float)maxHealth), healthBar.rectTransform.sizeDelta.y);
    }

    public void AddInventoryItem(string inventoryName, Sprite image = null)
    {
        inventory.Add(inventoryName, image);
        //The blank sprite should now swap with key sprite
        inventoryItemImage.sprite = inventory[inventoryName];
    }

    public void RemoveInventoryItem(string inventoryName)
    {
        inventory.Remove(inventoryName);
        //The blank sprite should now swap with key sprite
        inventoryItemImage.sprite = inventoryItemBlank;
    }
}
