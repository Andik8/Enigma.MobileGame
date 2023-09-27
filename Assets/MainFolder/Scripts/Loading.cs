/*		Script contains
		           ***
	                Loading scene
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Loading : MonoBehaviour
{
    float time, second;
    public Image FillImage;
    // Start is called before the first frame update
    void Start()
    {
        second = 11;
        Invoke("LoadGame",11f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 11)
        {
            time += Time.deltaTime;
            FillImage.fillAmount = time / second;
        }
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
