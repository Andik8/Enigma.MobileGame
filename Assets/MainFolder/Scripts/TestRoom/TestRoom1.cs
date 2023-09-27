using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoom1 : MonoBehaviour
{
	public GameObject tile1;
	public GameObject tile2;
	public GameObject collider1;
	public GameObject collider2;
	public GameObject light1;
	public GameObject light2;

	private int count = 0;//Counter to activate animation only once
	private bool playerInTrigger;


	private void Start()
	{
		tile2.SetActive(false);
		collider2.SetActive(false);
		light2.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)//Activates message in the collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			tile2.SetActive(true);
			collider2.SetActive(true);
			light2.SetActive(true);
		}


	}

	private void OnTriggerExit(Collider other)//Hide message when player is out of collider area
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			tile1.SetActive(false);
			collider1.SetActive(false);
			light1.SetActive(false);
		}
	}
}
