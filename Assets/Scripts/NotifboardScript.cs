using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotifboardScript : MonoBehaviour
{
    public CharacterScript player;
    public CharacterScript enemy;
    public GameObject notifBoard;
    public Text text;
    
    private void Start()
    {
        notifBoard.SetActive(false);
    }

    public void CheckBattle()
    {
        if(enemy.currentHealth <= 0)
        {
            text.text = "Victory!";
        }
        else if(player.currentHealth <= 0)
        {
            text.text = "Defeat!";
        }
        notifBoard.SetActive(true);
    }
}
