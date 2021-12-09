using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSript : MonoBehaviour
{
    //public Transform pfButtons;
    private GameObject[] buttons;
    public Button[] skills;

    private void Awake()
    {
        // Get buttons GameObjects
        buttons = GameObject.FindGameObjectsWithTag("Skill");
    }
    private void Start()
    {
        //SpawnButtons();        

        AssignButtons(() =>
        {
            // Initiate();
        });
    }
    /*
    private void SpawnButtons()
    {
        Transform buttons = Instantiate(pfButtons, transform.position, Quaternion.identity, gameObject.transform);

        Text text = buttons.Find("Text").GetComponent<Text>();
        text.text = "attack";
    }*/

    private void AssignButtons(System.Action OnButtonAssigned)
    {
        int i = 0;
        skills = new Button[4];
        foreach (GameObject button in buttons)
        {
            skills[i] = button.GetComponent<Button>();
            i++;
        }

        OnButtonAssigned();
    }
    
    private void Initiate()
    {
        Text text = skills[1].transform.Find("Text").GetComponent<Text>();
        text.text = "attack";/*
        skills[1].interactable = true;
        skills[0].interactable = false;
        skills[2].interactable = false;
        skills[3].interactable = false;*/
    }
}
