using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    private enum AttacksWhat { Enemy, Player };
    [SerializeField] private AttacksWhat attacksWhat;
    [SerializeField] private int attackPower = 10;
    [SerializeField] private int targetSide;

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
        //If I'm at an x position that is smaller than what I'm attacking (col), then I'm on the left side (-1)
        //Otherwise, I'm on the right side (1).

        if(transform.parent.transform.position.x < col.transform.position.x)
        {
            targetSide = -1;
        }
        else
        {
            targetSide = 1;
        }

        if (attacksWhat == AttacksWhat.Enemy)
        {
            //If I touch an enemy, hurt the enemy! 
            if (col.gameObject.GetComponent<Enemy>())
            {
                //col.gameObject.GetComponent<Enemy>().health -= NewPlayer.Instance.attackPower;
                col.gameObject.GetComponent<Enemy>().Hurt(attackPower);

            }
        }
        else if (attacksWhat == AttacksWhat.Player)
        {
            if (col.gameObject == NewPlayer.Instance.gameObject)
            {
                //Hurt the player, then update the UI!
                NewPlayer.Instance.Hurt(attackPower, targetSide);
            }
        }
    }
}

