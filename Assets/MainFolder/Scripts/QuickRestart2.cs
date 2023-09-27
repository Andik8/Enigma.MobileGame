using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickRestart2 : MonoBehaviour
{
    public GameObject startMessage;
    void Start()
    {
        startMessage.SetActive(true);
    }

    private void OnTriggerEnter(Collider collision)
    {
        SceneManager.LoadScene("TestRoom");
        startMessage.SetActive(false);
    }
    //void DestroyObjectDelayed()
    //{
    //    // Kills the game object in 5 seconds after loading the object
    //    Destroy(gameObject, 2);
    //}

    public void Restart()
    {
        SceneManager.LoadScene("TestRoom");
    }
}
