using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleOverWindow : MonoBehaviour
{    
    private static BattleOverWindow instance;
    private Image image;
    private bool isVictory;
    public SceneChanger sceneChanger;

    private void Awake()
    {
        image = gameObject.transform.Find("Image").GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0.9f;
        image.color = tempColor;
        instance = this;
        Hide();
    }

    public void ChangeScene()
    {
        if (isVictory && PlayerPrefs.GetInt("Floor") < 10)
        {
            sceneChanger.ChangeScene("ExplorationScene");
        }
        else
        {
            sceneChanger.ChangeScene("HomeScene");
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show(string winnerString, bool isVictory)
    {
        this.isVictory = isVictory;
        gameObject.transform.SetAsLastSibling();
        gameObject.SetActive(true);

        transform.Find("WinnerText").GetComponent<Text>().text = winnerString;
    }

    public static void Show_Static(string winnerString, bool isVictory)
    {
        instance.Show(winnerString, isVictory);
    }
}
