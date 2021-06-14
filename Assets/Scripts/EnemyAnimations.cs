using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimations : MonoBehaviour
{
    public NavMeshAgent agent;

    private Animator animator;
    bool couroutineStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Is Stoped
        /*if (agent.velocity == new Vector3(0, 0, 0))
        {
            //Debug.Log("Stoped!");
            animator.SetBool("isWalking", false);
            //if is in front of player
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                //Debug.Log("Ready to hit the player");
                if(!couroutineStarted)
                {
                    StartCoroutine(UsingYield(5));
                }
            }

        }
        else
        {
            animator.SetBool("isWalking", true);
            //Debug.Log("Walking!");
        }*/
    }

    void LateUpdate() {
        if (agent.velocity == new Vector3(0, 0, 0))
        {
            //Debug.Log("Stoped!");
            animator.SetBool("isWalking", false);
            //if is in front of player
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                //Debug.Log("Ready to hit the player");
                if(!couroutineStarted)
                {
                    StartCoroutine(UsingYield(5));
                }
            }

        }
        else
        {
            animator.SetBool("isWalking", true);
            //Debug.Log("Walking!");
        }
    }

    IEnumerator UsingYield(int seconds)
    {
        Debug.Log("Coroutine Start!");
        animator.SetBool("isAtacking", true);
        couroutineStarted = true;
        yield return new WaitForSeconds(seconds);
        couroutineStarted = false;
        animator.SetBool("isAtacking", false);
        Debug.Log("Coroutine End!");
    }

}

