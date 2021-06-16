using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimations : MonoBehaviour
{
    public NavMeshAgent agent;
    public float wait;
    float hits = 3;
    private Animator animator;
    bool couroutineStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update() {
        
    }

    void LateUpdate()
    {
        if (agent.velocity == new Vector3(0, 0, 0))
        {
            animator.SetBool("isWalking", false);
            //if is in front of player
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!couroutineStarted)
                {
                    couroutineStarted = true;
                    Invoke("Atack", wait);
                    couroutineStarted = false;
                    animator.SetBool("isAtacking", false);
                }
            }
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }

    void Atack()
    {
        animator.SetBool("isAtacking", true);
    }


    public void hit(){
        hits--;
        if(hits <= 0){
            animator.SetBool("isWalking", false);
            animator.SetBool("isAtacking", false);
            animator.SetBool("isHit", false);
            animator.SetBool("isDeath", true);
            Destroy(gameObject, 3);
        }else{
            animator.SetBool("isHit", true);
            Invoke("Damage", 1);
        }
    }

    void Damage()
    {
        animator.SetBool("isHit", false);
    }

}

