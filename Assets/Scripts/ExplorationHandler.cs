using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplorationHandler : MonoBehaviour
{
    private GameObject[] options;
    private GameObject activeOption;
    private Outline outline;
    private Button continueBtn;
    private Text floorTxt;
    private int floorCount;

    private void Awake()
    {
        options = GameObject.FindGameObjectsWithTag("Option");
        continueBtn = GameObject.Find("Canvas").transform.Find("Button").GetComponent<Button>();
        floorTxt = GameObject.Find("Canvas").transform.Find("Text").GetComponent<Text>();
        floorCount = PlayerPrefs.GetInt("Floor");
    }

    // Start is called before the first frame update
    private void Start()
    {
        CountFloor(() => {
            PlayerPrefs.SetInt("Floor", floorCount);
        });

        foreach (GameObject option in options)
        {
            HideOptionOutline(option);
        }
        continueBtn.interactable = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2d, Vector2.zero);
            if (hit.collider != null)
            {
                // print(hit.collider.gameObject.name + "is clicked.");
                SetActiveOption(hit.collider.gameObject);
            }
        }
    }

    private void CountFloor(System.Action OnCountFloor)
    {
        floorCount++;
        floorTxt.text = "Floor : " + floorCount;
        OnCountFloor();
    }    

    private void SetActiveOption(GameObject op)
    {
        if (activeOption != null)
        {
            HideOptionOutline(activeOption);
        }

        activeOption = op;
        ShowOptionOutline(activeOption);
        continueBtn.interactable = true;
    }

    private void HideOptionOutline(GameObject activeOp)
    {
        outline = activeOp.transform.Find("Background").GetComponent<Outline>();
        outline.enabled = false;
    }

    private void ShowOptionOutline(GameObject activeOp)
    {
        outline = activeOp.transform.Find("Background").GetComponent<Outline>();
        outline.enabled = true;
    }
}
