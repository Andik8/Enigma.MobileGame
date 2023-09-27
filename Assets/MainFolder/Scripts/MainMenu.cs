/*		Script contains
		           ***
	                  Main screen
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour
{
    private readonly string LevelKey = "LevelKey";

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    //public GameObject item4;
    bool isClicked = false;
    private void Start()
    {
        item1.SetActive(false);
        item2.SetActive(false);
        item3.SetActive(false);
        //item4.SetActive(false);
    }

    public static bool GameIsPaused = true;
    public void PlayGame ()
    {
        int levelIndex = PlayerPrefs.GetInt(LevelKey, 0);
        string levelName = StartUp.Instance.LevelSetting.LevelName[levelIndex];
        SceneManager.LoadScene(levelName);
      
         isClicked = !isClicked;
       // item4.SetActive(isClicked);
    }

    public void ViewMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void TestLevel()
    {
        SceneManager.LoadScene("TestRoom");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();

    }


    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    
    }

    public void ToggleMenu()
    {
        isClicked = !isClicked;
            item1.SetActive(isClicked);
            item2.SetActive(isClicked);
            item3.SetActive(isClicked);
        
    }

}


[CreateAssetMenu(fileName = "LevelSetting", menuName = "LevelSetting")]
public class LevelSetting : ScriptableObject
{
    [field: SerializeField]
    public string[] LevelName
    {
        get;
        private set;
    }
}   

public class StartUp : MonoBehaviour
{
    public static StartUp Instance;//точка входа в игру(

    [field: SerializeField]
    public LevelSetting LevelSetting
    {
        get;
        private set;
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }
    }
}
