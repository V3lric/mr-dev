using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LookAt : MonoBehaviour
{
    public Transform target;
    [SerializeField] TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(target);
        if (GameManager.instance.gameWin)
            text.SetText("You Win!");
        else
            text.SetText("You Lose!");
    }
}
