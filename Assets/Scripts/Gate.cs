using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string requiredInventoryItemString;
    [SerializeField] private Animator animator;

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
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            //Check to see if the player's inventory contains the required inventory item!
            if (NewPlayer.Instance.inventory.ContainsKey(requiredInventoryItemString))
            {
                NewPlayer.Instance.RemoveInventoryItem(requiredInventoryItemString);
                animator.SetBool("opened", true);
            }
        }
    }

}
