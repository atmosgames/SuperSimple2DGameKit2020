using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10;

    public int coinsCollected;
    public int health = 100;
    public int ammo;

    public Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
