using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Motion1 : MonoBehaviour
{
	[SerializeField] private Animator activateAnimation1;//Add prefab with animation 1
	public GameObject messagePanelBunk;//Add message panel when player is in the collider area
	public GameObject PrefabFromMotion2;//Object from next animation. Hide it before animation 1 ends
	public GameObject Prefab2FromMotion2;//Object from next animation. Hide it before animation 1 ends
	public GameObject PrefabKey;//Object used to finish level

	private int count = 0;//Counter to activate animation only once
	private bool playerInTrigger;


    private void Start()
	{
		PrefabKey.SetActive(false);
		messagePanelBunk.SetActive(false);
		PrefabFromMotion2.SetActive(false);
		Prefab2FromMotion2.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)//Activates message in the collider area
	{
		if (count == 0 && other.CompareTag("Player"))
        {
			playerInTrigger = true;
			messagePanelBunk.SetActive(true);
        }
		
		
	}

	private void OnTriggerExit(Collider other)//Hide message when player is out of collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			playerInTrigger = false;
			messagePanelBunk.SetActive(false);
		}
	}

	public void ActivateButton()
    {
		if (playerInTrigger)
		{ 
		PrefabFromMotion2.SetActive(true);
		Prefab2FromMotion2.SetActive(true);
		activateAnimation1.SetBool("BunkMechanismRun", true);
		Debug.Log("YOU OPENED BUNK!");
		messagePanelBunk.SetActive(false);
		count++;
		}
	}
	
}
