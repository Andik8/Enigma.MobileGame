using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Motion3 : MonoBehaviour
{
	[SerializeField] private Animator activateAnimation1;//Add prefab with animation 1
	[SerializeField] private Animator activateAnimation2;//Add prefab with animation 2
	public GameObject messagePanelLever;//Add message panel when player is in the collider area
	public GameObject PrefabFromMotion4;//Object from next animation. Hide it before animation 1 ends
	public GameObject PrefabKey;//Object used to finish level

	private int count = 0;//Counter to activate animation only once
	private bool playerInTrigger;

	private void Awake()
    {
		PrefabKey.SetActive(false);
		messagePanelLever.SetActive(false);
		PrefabFromMotion4.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)//Activates message in the collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			playerInTrigger = true;
			messagePanelLever.SetActive(true);
		}


	}

	private void OnTriggerExit(Collider other)//Hide message when player is out of collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			playerInTrigger = false;
			messagePanelLever.SetActive(false);
		}
	}

	public void ActivateButton()
	{
		if (playerInTrigger)
		{
			PrefabFromMotion4.SetActive(true);
			PrefabKey.SetActive(true);
			activateAnimation1.SetBool("LeverActivatesPanelNearKey", true);
			activateAnimation2.SetBool("ActionThenIndicator2", true);
			Debug.Log("THE KEY ITEM NOW APPEARED!");
			messagePanelLever.SetActive(false);
			count++;
		}
	}
}
