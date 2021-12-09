using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{
    private static BattleHandler instance;

    public static BattleHandler GetInstance()
    {
        return instance;
    }

    // private CameraShake cameraShake;
    [SerializeField] private Transform pfEnemyCharacter;
    public Sprite enemySprites;
    private string enemy;
    public int enemyNum;
    public int EnemyNum { get; set; }

    private CharacterBattle playerCharacterBattle;
    private CharacterBattle[] enemyCharacterBattle;
    private CharacterBattle activeCharacterBattle;
    private ButtonSript button;
    private State state;

    private enum State
    {
        WaitingForPlayer,
        Busy,
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetEnemyNumber(() => { // Set up enemy(ies)
            enemyCharacterBattle = new CharacterBattle[enemyNum]; 
            int j = enemyNum - 1;
            for (int i = 0; i < enemyNum; i++)
            {
                GetEnemy(() => {
                    GetEnemySprites(() => {
                        enemyCharacterBattle[i] = SpawnCharacter(j);
                        j -= 2;
                    });
                });
            }
        });

        playerCharacterBattle = GameObject.Find("PlayerUI").GetComponent<CharacterBattle>(); // Get player character
        button = playerCharacterBattle.transform.Find("Buttons").GetComponent<ButtonSript>(); // Get player attack buttons

        // SetActiveCharacterBattle(playerCharacterBattle);
        state = State.WaitingForPlayer;

        // Get Main Camera
        // cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2d, Vector2.zero);
            if (hit.collider != null)
            {
                // print(hit.collider.gameObject.name + "is clicked.");
                SetActiveCharacterBattle(hit.collider.gameObject.GetComponent<CharacterBattle>());
            }
        }

        if (state == State.Busy)
        {
            foreach (Button skill in button.skills)
            {
                skill.interactable = false;
            }
        }
        else
        {
            foreach (Button skill in button.skills)
            {
                skill.interactable = true;
            }
        }
        /*
        if (state == State.WaitingForPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = State.Busy;
                playerCharacterBattle.Attack(enemyCharacterBattle, () => {
                    ChooseNextActiveCharacter();
                });
            }
        }*/
    }

    public void Skill1()
    {
        // print("Button is clicked");
        if (activeCharacterBattle != null)
        {
            state = State.Busy;
            playerCharacterBattle.Attack(activeCharacterBattle, -5, () => {
                StartCoroutine(EnemyTurn());
            });
        }        
    }

    private void GetEnemySprites(Action OnEnemySpriteFound)
    {
        switch (enemy)
        {
            case "BasicSlime" :
                enemySprites = Resources.Load<Sprite>("Sprites/Basic_Slime");
                break;
            case "Bear" :
                enemySprites = Resources.Load<Sprite>("Sprites/Bear");
                break;
        }
        OnEnemySpriteFound();
    }

    private void GetEnemy(Action OnEnemyFound)
    {
        switch (UnityEngine.Random.Range(0, 1))
        {
            case 0:
                enemy = "BasicSlime";
                break;
            case 1:
                enemy = "Bear";
                break;
        }
        OnEnemyFound();
    }

    private void GetEnemyNumber(Action OnNumberGenerated)
    {
        enemyNum = UnityEngine.Random.Range(1, 3);
        OnNumberGenerated();
    }

    private CharacterBattle SpawnCharacter(int j)
    {
        Vector3 position;
        position = new Vector3(j, 0);

        Transform characterTransform = Instantiate(pfEnemyCharacter, position, Quaternion.identity);
        CharacterBattle characterBattle = characterTransform.GetComponent<CharacterBattle>();
        characterBattle.Setup(enemy);

        return characterBattle;
    }
    
    private void SetActiveCharacterBattle(CharacterBattle characterBattle)
    {
        if (activeCharacterBattle != null)
        {
            activeCharacterBattle.HideSelectionCircle();
        }

        activeCharacterBattle = characterBattle;
        activeCharacterBattle.ShowSelectionCircle();
    }

    private IEnumerator EnemyTurn()
    {
        if (TestBattleOver())
            yield break;

        foreach (CharacterBattle enemy in enemyCharacterBattle)
        {
            if (!enemy.IsDead())
            {
                yield return new WaitForSeconds(1f);
                enemy.RecoverEnergyOnTurn();
                enemy.Attack(playerCharacterBattle, -5, () => {
                    // StartCoroutine(cameraShake.Shake(0.5f, 0.1f));
                });
                if (TestBattleOver())
                    yield break;
            }
        }

        yield return new WaitForSeconds(1f);

        // Player turn
        state = State.WaitingForPlayer;
        playerCharacterBattle.RecoverEnergyOnTurn();
    }
    /*
    private void ChooseNextActiveCharacter()
    {
        if (TestBattleOver())
        {
            return;
        }

        if (activeCharacterBattle == playerCharacterBattle)
        {
            SetActiveCharacterBattle(enemyCharacterBattle);
            state = State.Busy;

            enemyCharacterBattle.Attack(playerCharacterBattle, () => {
                ChooseNextActiveCharacter();
            });
        }
        else
        {
            SetActiveCharacterBattle(playerCharacterBattle);
            state = State.WaitingForPlayer;
        }
    }*/

    private bool TestBattleOver()
    {
        if (playerCharacterBattle.IsDead())
        {
            // Player dead, enemy wins
            BattleOverWindow.Show_Static("DEFEAT!", false);
            // print("DEFEAT!");
            return true;
        }
        int i = 0;
        foreach (CharacterBattle enemy in enemyCharacterBattle)
        {
            if (enemy.IsDead())
                i++;
        }
        if (i == enemyNum)
        {
            // Enemy dead, player wins
            BattleOverWindow.Show_Static("VICTORY!", true);
            // print("VICTORY!");
            return true;
        }

        return false;
    }
}
