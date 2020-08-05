using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum ItemType { Coin, Health, Ammo} //Creates an ItemType enum (drop down)
    [SerializeField] private ItemType itemType;
    NewPlayer newPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //If I'm a coin, print to the console "I'm a coin"
        
        if (itemType == ItemType.Coin)
        {
            Debug.Log("I'm a coin!");
        }
        else if(itemType == ItemType.Health)
        {
            Debug.Log("I'm health!");
        }
        else if (itemType == ItemType.Ammo)
        {
            Debug.Log("I'm ammo!");
        }
        else
        {
            Debug.Log("I'm an inventory item!");
        }

        newPlayer = GameObject.Find("NewPlayer").GetComponent<NewPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player is touching me, print "Collect" in the console
        if (collision.gameObject.name == "Player")
        {
            newPlayer.coinsCollected += 1;
            newPlayer.UpdateUI();
            Destroy(gameObject);
        }
    }
}
