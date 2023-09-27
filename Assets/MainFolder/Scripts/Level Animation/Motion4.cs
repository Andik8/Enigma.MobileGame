using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion4 : MonoBehaviour
{
	[SerializeField] private Animator activateAnimation1;//Add prefab with animation 1
	[SerializeField] private Animator activateAnimation2;//Add prefab with animation 2
	public GameObject PrefabFromMotion5;//Object from next animation. Hide it before animation 1 ends
	public GameObject Prefab3FromMotion5;//Object from next animation. Hide it before animation 1 ends

	private int count = 0;//Counter to activate animation only once


	private void Start()
	{
		PrefabFromMotion5.SetActive(false);
		Prefab3FromMotion5.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)//Press F in the colider area to activate animations(2), show prefab from next motion and delete message
	{
		if (count == 0 && other.CompareTag("Player"))
		{
			PrefabFromMotion5.SetActive(true);
			Prefab3FromMotion5.SetActive(true);
			activateAnimation1.SetBool("LeverThenPushPanel", true);
			activateAnimation2.SetBool("PanelMovesRight", true);
			Debug.Log("PRESS PANEL WORKS!");
			count++;
		}
	}

}
