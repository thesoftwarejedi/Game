using UnityEngine;
using System.Collections;
using System;

public class EnemyAttack : MonoBehaviour {

    public Transform target;
    public float timeBetweenAttacks = 2f;

    Animator anim;
    NavMeshAgent nav;
    bool targetInRange;
    float timeSinceAttack;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        if (target == null)
            target = GameObject.Find("/Player").transform;
    }

    void OnAnimatorMove()
    {
        nav.speed = anim.deltaPosition.magnitude / Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetInRange)
        {
            //handle the attack?
            timeSinceAttack += Time.deltaTime;
            if (timeSinceAttack >= timeBetweenAttacks)
            {
                Attack();
            }
        }
        else
        {
            //handle the movement
            nav.SetDestination(target.position);
        }
	}

    private void Attack()
    {
        timeSinceAttack = 0;
        anim.SetTrigger("Use");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            targetInRange = true;
            //anim.SetBool("NonCombat", false);
            anim.SetBool("Idling", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            targetInRange = false;
            //anim.SetBool("NonCombat", true);
            anim.SetBool("Idling", false);
        }
    }
}
