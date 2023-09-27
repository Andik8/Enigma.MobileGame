using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{

    // Update is called once per frame

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
