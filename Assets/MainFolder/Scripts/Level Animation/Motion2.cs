using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Motion2 : MonoBehaviour
{
	[SerializeField] private Animator activateAnimation1;//Add prefab with animation 1
	[SerializeField] private Animator activateAnimation2;//Add prefab with animation 2
	public GameObject messagePanelRedButton;//Add message panel when player is in the collider area
	public GameObject PrefabFromMotion3;//Object from next animation. Hide it before animation 1 ends
	public GameObject Prefab2FromMotion3;//Object from next animation. Hide it before animation 1 ends
	public GameObject PrefabKey;//Object used to finish level

	private int count = 0;//Counter to activate animation only once
	private bool playerInTrigger;

	private void Awake()
    {
		PrefabKey.SetActive(false);
		messagePanelRedButton.SetActive(false);
		PrefabFromMotion3.SetActive(false);
		Prefab2FromMotion3.SetActive(false);
	}
	private void OnTriggerEnter(Collider other)//Activates message in the collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			playerInTrigger = true;
			messagePanelRedButton.SetActive(true);
		}


	}

	private void OnTriggerExit(Collider other)//Hide message when player is out of collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			playerInTrigger = false;
			messagePanelRedButton.SetActive(false);
		}
	}

	public void ActivateButton()
    {
		if (playerInTrigger)
		{
			PrefabFromMotion3.SetActive(true);
			Prefab2FromMotion3.SetActive(true);
			activateAnimation1.SetBool("PressButtonThenPanelMove", true);
			activateAnimation2.SetBool("ActionThenIndicator", true);
			Debug.Log("YOU PRESSED THE BUTTON!");
			messagePanelRedButton.SetActive(false);
			count++;
		}
	}
}
