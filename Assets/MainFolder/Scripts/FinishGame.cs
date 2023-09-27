/*		Script contains
		           ***
	        Finish panel activation
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject finishPanel;
    public GameObject restartCollider;

    private void Start()
    {
        finishPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        finishPanel.SetActive(true);
        restartCollider.SetActive(false);
    }
}
