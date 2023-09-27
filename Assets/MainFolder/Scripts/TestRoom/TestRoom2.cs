using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoom2 : MonoBehaviour
{
	public GameObject tile2;
	public GameObject tile3;
	public GameObject collider2;
	public GameObject collider3;
	public GameObject light2;
	public GameObject light3;

	private int count = 0;//Counter to activate animation only once
	private bool playerInTrigger;


	private void Start()
	{
		tile3.SetActive(false);
		collider3.SetActive(false);
		light3.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)//Activates message in the collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			tile3.SetActive(true);
			collider3.SetActive(true);
			light3.SetActive(true);
		}


	}

	private void OnTriggerExit(Collider other)//Hide message when player is out of collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			tile2.SetActive(false);
			collider2.SetActive(false);
			light2.SetActive(false);
		}
	}
}
