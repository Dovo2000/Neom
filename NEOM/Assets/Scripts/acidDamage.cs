using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class acidDamage : MonoBehaviour
{
    public Player player;

    public Color colorToTurnTo = Color.red;
    public Color colorByDefault = Color.white;


    void OnTriggerStay2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            player.gameOver();
        }
       
    }

}
