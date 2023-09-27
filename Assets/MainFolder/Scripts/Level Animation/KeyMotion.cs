using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KeyMotion : MonoBehaviour
{
	[SerializeField] private Animator finalDoorAnimation;//Add prefab to open final door
	public GameObject messagePanelKey;//Add message panel when player is in the collider area

	//Mission objects
	public GameObject keyIsNotFound;
	public GameObject keyIsFound;
	public GameObject keyObjectPicture;
	public GameObject silhouette;

	private int count = 0;//Counter to activate animation only once
	private bool playerInTrigger;

	private void Awake()
    {
        keyIsNotFound.SetActive(true);//Cross
		silhouette.SetActive(true);   //Black silhouette
		keyIsFound.SetActive(false);
		keyObjectPicture.SetActive(false);
		messagePanelKey.SetActive(false);
    }

	private void OnTriggerEnter(Collider other)//Activates message in the collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			playerInTrigger = true;
			messagePanelKey.SetActive(true);
		}


	}

	private void OnTriggerExit(Collider other)//Hide message when player is out of collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			playerInTrigger = false;
			messagePanelKey.SetActive(false);
		}
	}

	public void ActivateButton()
	{
		if (playerInTrigger)
		{
			Destroy(gameObject);
			finalDoorAnimation.SetBool("ElecLeverThenDoor", true);
			keyIsFound.SetActive(true);      //Tick
			keyObjectPicture.SetActive(true);//Object picture
			keyIsNotFound.SetActive(false);
			silhouette.SetActive(false);
			Debug.Log("VICTORY");
			messagePanelKey.SetActive(false);
			count++;
		}
	}
}
