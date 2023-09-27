using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoom3 : MonoBehaviour
{
	public GameObject tile3;
	public GameObject tile4;
	public GameObject collider3;
	public GameObject collider4;
	public GameObject light3;
	public GameObject light4;

	private int count = 0;//Counter to activate animation only once
	private bool playerInTrigger;


	private void Start()
	{
		tile4.SetActive(false);
		collider4.SetActive(false);
		light4.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)//Activates message in the collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			tile4.SetActive(true);
			collider4.SetActive(true);
			light4.SetActive(true);
		}


	}

	private void OnTriggerExit(Collider other)//Hide message when player is out of collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			tile3.SetActive(false);
			collider3.SetActive(false);
			light3.SetActive(false);
		}
	}
}
