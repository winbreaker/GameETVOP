using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : TargetScript
{
    public Animator animator;
    public float health = 100;
    public NavMeshAgent navMeshAgent;

    boold isDead;
    float coolDown = 0.5f;
    Transform target;

    public GameObject deadEffect;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").transform;
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < 1 && !isDead)
        {
            animator.SetTrigger("Attack");
        }
        if (isHit && coolDown <= 0 && !isDead)
        {
            Debug.Log("Hit");

            health -= 10;
            coolDown = 0.5f;

            if (health <= 0)
            {
                animator.SetTrigger("Dead");
                navMeshAgent.isStopped = true;
                isDead = true;
            }
            else{
                animtor.SetTrigger("Hurt");
                navMeshAgent.isStopped = true;
                
            }

        }
        else if (coolDown <= 0)
        {
            if (!isDead)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(target.position);
            }
        }
        if (coolDown > 0)
        {
        coolDown -= Time.deltaTime;
        }

    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject _effect = Instantiate(deadEffect, transform,position, Quaternion.identity);
        Destroy(_effect, 3f);
        Destroy(gameObject);
    }
    
}