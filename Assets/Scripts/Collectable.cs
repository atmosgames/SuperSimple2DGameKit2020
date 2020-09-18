using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum ItemType { Coin, Health, Ammo, InventoryItem } //Creates an ItemType enum (drop down)
    [SerializeField] private ItemType itemType;
    [SerializeField] private string inventoryStringName;
    [SerializeField] private Sprite inventorySprite;
    [SerializeField] private AudioClip collectionSound;
    [SerializeField] private float collectionSoundVolume = 1;

    [SerializeField] private ParticleSystem particlesCollectableGlitter;

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
        //If the player is touching me, print "Collect" in the console
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            if(collectionSound) NewPlayer.Instance.sfxAudioSource.PlayOneShot(collectionSound, collectionSoundVolume*Random.Range(.8f, 1.4f));

            if (particlesCollectableGlitter)
            {
                particlesCollectableGlitter.transform.parent = null;
                particlesCollectableGlitter.gameObject.SetActive(true);
                Destroy(particlesCollectableGlitter.gameObject, particlesCollectableGlitter.main.duration);
            }

            if (itemType == ItemType.Coin)
            {
                NewPlayer.Instance.coinsCollected += 1;
            }
            else if (itemType == ItemType.Health)
            {
                if (NewPlayer.Instance.health < 100)
                {
                    NewPlayer.Instance.health += 1;
                }
            }
            else if (itemType == ItemType.Ammo)
            {

            }
            else if (itemType == ItemType.InventoryItem)
            {
                NewPlayer.Instance.AddInventoryItem(inventoryStringName, inventorySprite);
            }
            else
            {

            }



            NewPlayer.Instance.UpdateUI();
            Destroy(gameObject);
        }
    }
}
