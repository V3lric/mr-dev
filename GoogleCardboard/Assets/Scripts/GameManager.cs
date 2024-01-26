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
    bool gameStart,gameWin,losegame = false;
    public GameObject winPanel;
    [SerializeField] int randInt;
    [SerializeField] TMP_Text person, timer;
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
            startTimer -= 1f * Time.deltaTime;
            if (startTimer < 0)
                gameStart = true;
        }

        if (gameStart && !losegame && !gameWin)
        {
            timer.SetText("Time Left: " + gameTimer.ToString());
            gameTimer -= 1f * Time.deltaTime;
            if (gameTimer < 0)
                gameWin = true;
        }

        if (gameWin)
        {
            winPanel.SetActive(true);
        }
        else if (losegame)
        {
            winPanel.SetActive(true);
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
        if (id == randInt)
            gameWin = true;
        else
            losegame = true;
    }
    void SelectPerson()
    {
        randInt = Random.Range(1,players.Count);
        person.SetText("Target: " +randInt.ToString());
    }
}
