/*		Script contains
		           ***
	                 Level switch
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    //int levelsUnlocked;
    //public Button[] buttons;
    // Start is called before the first frame update
    private void Start()
    {
        //levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        //for (int i = 0; i < buttons.Length; i++)
        //{
        //    buttons[i].interactable = false;
        //}
        //for (int i = 0; i < levelsUnlocked; i++)
        //{
         //   buttons[i].interactable = true;
        //}
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
            //LoadNextLevel();
        //}
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //place for animation
        transition.SetTrigger("Start");
        //wait for animation
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
