using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] Players;
    List<GameObject> players = new List<GameObject>();
    public string playerTags;
    [SerializeField] float startTimer, gameTimer;
    public bool gameStart,gameWin,losegame = false;
    public GameObject winPanel;
    [SerializeField] int randInt;
    [SerializeField] int round = 0;
    [SerializeField] TMP_Text person, timer,wintext;
    [SerializeField] string[] playerDesc;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Transform parent = transform;
        LocatePlayers(parent);
        SelectPerson();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart)
        {
            timer.SetText(timer.text);
            startTimer -= 1f * Time.deltaTime;
            if (startTimer < 1)
            {
                timer.SetText("Begin!!");
                gameStart = true;
            }
        }

        if (gameStart && !losegame && !gameWin)
        {
            gameTimer -= 1f * Time.deltaTime % 1f;
             float roundedTimer = UnityEngine.Mathf.Round(gameTimer);
            timer.SetText("Time Left: " + roundedTimer.ToString());
            if (gameTimer < 0)
                losegame = true;
            else if (round > 3)
                gameWin = true;
        }

        if (gameWin)
        {
            winPanel.SetActive(true);
            wintext.SetText("You Win!");
        }
        else if (losegame)
        {
            winPanel.SetActive(true);
            wintext.SetText("You Lose!");
        }
    }

    void LocatePlayers(Transform parent)
    {
        Transform[] allChildren = parent.GetComponentsInChildren<Transform>();
        int id = 0;
        foreach (Transform child in allChildren)
        {  
            if (child.CompareTag(playerTags))
            {
                id++;
                players.Add(child.gameObject);
                CityPeople cityPeople = child.gameObject.GetComponent<CityPeople>();
                cityPeople.PlayerIndex(id);
            }
        }

        // Assign the switches to the public Switch array
        Players = players.ToArray();
    }

    public void PlayerOnHit(int id)
    {
        if (gameStart && !gameWin && !losegame)
        {
            if (id == randInt)
            {
                round++;
                SelectPerson();
            }
            else
                losegame = true;
        }
    }
    void SelectPerson()
    {
        randInt = Random.Range(1,players.Count);
        person.SetText("Target: " + playerDesc[randInt]);
    }
}
