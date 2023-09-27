using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoredBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private float timeUntilBored;

    [SerializeField]
    private int numOfBoredAnimations;

    private bool isBored;
    private float idleTime;
    private int boredAnimation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(isBored == false)
        {
            idleTime += Time.deltaTime;

            if (idleTime > timeUntilBored && stateInfo.normalizedTime % 1 < 0.02f)
            {
                isBored = true;
                boredAnimation = Random.Range(1, numOfBoredAnimations + 1);
            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetIdle();
        }
        animator.SetFloat("BoredAnimation", boredAnimation, 0.2f, Time.deltaTime);
    }
    private void ResetIdle()
    {
        isBored = false;
        idleTime = 0;
        boredAnimation = 0;
    }
}
