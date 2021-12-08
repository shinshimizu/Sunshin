using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSript : MonoBehaviour
{
    //public Transform pfButtons;
    public Button[] skills;

    private void Start()
    {
        //SpawnButtons();

        // Set button attacks
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Skill");
        int i = 0;
        skills = new Button[buttons.Length];
        foreach (GameObject button in buttons)
        {            
            skills[i] = button.GetComponent<Button>();
            i++;
        }

        Initiate();
    }
    /*
    private void SpawnButtons()
    {
        Transform buttons = Instantiate(pfButtons, transform.position, Quaternion.identity, gameObject.transform);

        Text text = buttons.Find("Text").GetComponent<Text>();
        text.text = "attack";
    }*/
    
    private void Initiate()
    {
        Text text = skills[0].transform.Find("Text").GetComponent<Text>();
        text.text = "attack";
        skills[0].interactable = true;
        skills[1].interactable = false;
        skills[2].interactable = false;
        skills[3].interactable = false;
    }
}
