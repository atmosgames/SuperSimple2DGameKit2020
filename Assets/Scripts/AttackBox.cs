using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       //If I touch an enemy, hurt the enemy! 
       if(col.gameObject.GetComponent<Enemy>())
        {
            col.gameObject.GetComponent<Enemy>().health -= NewPlayer.Instance.attackPower;
        }
    }
}
