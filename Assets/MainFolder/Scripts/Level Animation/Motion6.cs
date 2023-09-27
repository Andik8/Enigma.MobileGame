using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion6 : MonoBehaviour
{
    [SerializeField] private Animator activateAnimation1;//Add prefab with animation 1
    [SerializeField] private Animator activateAnimation2;//Add prefab with animation 2
    public GameObject messagePanelBoard;//Add message panel when player is in the collider area
    public GameObject elecLever;
    public GameObject previousBoard180;
    public GameObject nextRotate;

    private int count = 0;//Counter to activate animation only once
    private bool playerInTrigger;

    void Start()
    {
        elecLever.SetActive(false);
        messagePanelBoard.SetActive(false);
        nextRotate.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)//Activates message in the collider area
    {
        if (count == 0 && other.CompareTag("Player"))
        {
            playerInTrigger = true;
            messagePanelBoard.SetActive(true);
        }


    }

    private void OnTriggerExit(Collider other)//Hide message when player is out of collider area
    {
        if (count == 0 && other.CompareTag("Player"))
        {
            playerInTrigger = false;
            messagePanelBoard.SetActive(false);
        }
    }

    public void ActivateButton()
    {
        if (playerInTrigger)
        {
            elecLever.SetActive(true);
            previousBoard180.SetActive(false);
            nextRotate.SetActive(true);
            activateAnimation1.SetBool("BoardRotation270", true);
            activateAnimation2.SetBool("BoardRotateThenDrawerOpen", true);
            Debug.Log("MM, WHAT A SECRET!");
            messagePanelBoard.SetActive(false);
            count++;
        }
    }
}
