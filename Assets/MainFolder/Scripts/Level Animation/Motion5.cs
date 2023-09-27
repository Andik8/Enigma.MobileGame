using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion5 : MonoBehaviour
{
    [SerializeField] private Animator activateAnimation1;//Add prefab with animation 1
    [SerializeField] private Animator activateAnimation2;//Add prefab with animation 2
    [SerializeField] private Animator activateAnimation3;//Add prefab with animation 3
    [SerializeField] private Animator activateAnimation4;//Add prefab with animation 4
    public GameObject PrefabFromMotion6;//Object from next animation. Hide it before animation 1 ends
    public GameObject Prefab2FromMotion6;//Object from next animation. Hide it before animation 1 ends
    public GameObject messagePanelBoard;//Add message panel when player is in the collider area

    private int count = 0;//Counter to activate animation only once
    private bool playerInTrigger;

    void Start()
    {
        Prefab2FromMotion6.SetActive(true);
        PrefabFromMotion6.SetActive(false);
        messagePanelBoard.SetActive(false);
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
            Prefab2FromMotion6.SetActive(false);
            PrefabFromMotion6.SetActive(true);
            activateAnimation1.SetBool("BoardRotation180", true);
            activateAnimation2.SetBool("MainPartAndUpPartFW", true);
            activateAnimation3.SetBool("BoardRotateThenFW", true);
            activateAnimation4.SetBool("ActionThenIndicator3", true);
            Debug.Log("ROTATION SUCCESSFUL!");
            messagePanelBoard.SetActive(false);
            count++;
        }
    }
}
