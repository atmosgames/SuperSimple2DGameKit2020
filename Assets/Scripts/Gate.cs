using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string requiredInventoryItemString;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == NewPlayer.Instance.gameObject)
        {
            Debug.Log("I'm triggered by the Player");
            //inventory.ContainsKey("key1");
            //If the player inventory has "key1", then destroy me!
            if (NewPlayer.Instance.inventory.ContainsKey(requiredInventoryItemString))
            {
                NewPlayer.Instance.RemoveInventoryItem(requiredInventoryItemString);
                Destroy(gameObject);
            }
        }

    }

}
