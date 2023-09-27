using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoom4 : MonoBehaviour
{
	public GameObject tile4;
	public GameObject tile1;
	public GameObject collider4;
	public GameObject collider1;
	public GameObject light4;
	public GameObject light1;

	private int count = 0;//Counter to activate animation only once
	private bool playerInTrigger;


	private void OnTriggerEnter(Collider other)//Activates message in the collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			tile1.SetActive(true);
			collider1.SetActive(true);
			light1.SetActive(true);
		}


	}

	private void OnTriggerExit(Collider other)//Hide message when player is out of collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			tile4.SetActive(false);
			collider4.SetActive(false);
			light4.SetActive(false);
		}
	}
}
