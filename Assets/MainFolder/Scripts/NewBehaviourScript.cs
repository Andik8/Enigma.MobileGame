using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockHandler : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    int unlockedLevelsNumber;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            item1.SetActive(false);
            item2.SetActive(true);
        }
    }
    // Update is called once per frame
    private void Update()
    {
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");
        for (int i = 0; i < unlockedLevelsNumber; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
