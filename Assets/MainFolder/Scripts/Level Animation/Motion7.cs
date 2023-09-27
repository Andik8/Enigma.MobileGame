using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion7 : MonoBehaviour
{
	[SerializeField] private Animator activateAnimation1;//Add prefab with animation 1
	public GameObject messagePanelElecLever;//Add message panel when player is in the collider area
	public GameObject PrefabFromMotion7;//Object from next animation. Hide it before animation 1 ends
	public GameObject Prefab2FromMotion7;//Object from next animation. Hide it before animation 1 ends

	private int count = 0;//Counter to activate animation only once
	private bool playerInTrigger;


	private void Start()
	{
		messagePanelElecLever.SetActive(false);
		PrefabFromMotion7.SetActive(false);
		Prefab2FromMotion7.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)//Activates message in the collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			playerInTrigger = true;
			messagePanelElecLever.SetActive(true);
		}


	}

	private void OnTriggerExit(Collider other)//Hide message when player is out of collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			playerInTrigger = false;
			messagePanelElecLever.SetActive(false);
		}
	}

	public void ActivateButton()
	{
		if (playerInTrigger)
		{
			PrefabFromMotion7.SetActive(true);
			Prefab2FromMotion7.SetActive(true);
			activateAnimation1.SetBool("DrawerOpenThenElecLever", true);
			Debug.Log("NOW DOOR WORKS!");
			messagePanelElecLever.SetActive(false);
			count++;
		}
	}
}
