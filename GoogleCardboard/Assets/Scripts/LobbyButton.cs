using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LobbyButton : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void OnPointerClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
