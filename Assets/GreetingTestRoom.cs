using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreetingTestRoom : MonoBehaviour
{
    
    public GameObject Greeting;
     void Awake()
    {
        Greeting.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Input.GetTouch(1);
            Greeting.SetActive(false);
        }
    }

    public void Click()
    {
            Greeting.SetActive(false);
    }
}
