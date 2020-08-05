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
    public Image inventorySprite;
    public Sprite keySprite;

    public Text coinsText;
    public Image healthBar;
    [SerializeField] private Vector2 healthBarOrigSize;

    // Start is called before the first frame update
    void Start()
    {
        healthBarOrigSize = healthBar.rectTransform.sizeDelta;
        UpdateUI();

        inventory.Add("key1", keySprite);
        //The blank sprite should now swap with key sprite

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

        //Set the healthBar width to a percentage of its original value. 
        //healthBarOrigSize.x * (health/maxHealth)
        healthBar.rectTransform.sizeDelta = new Vector2(healthBarOrigSize.x * ((float)health / (float)maxHealth), healthBar.rectTransform.sizeDelta.y);
    }
}
