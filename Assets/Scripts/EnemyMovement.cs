﻿using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    AggroDetection aggroDetection;

    //WeaponManager weaponManager;

    Animator anim;
    NavMeshAgent navMeshAgent;
    bool playerFound = false;

    Transform target;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
        //weaponManager = GetComponent<WeaponManager>();
        //weaponManager.HitEnemy += WeaponManager_HitEnemy;
        //aggroDetection.OnExitAggro += AggroDetection_OnExitAggro;
    }

    private void AggroDetection_OnAggro(Transform targetPlayer)
    {
        target = targetPlayer;
        playerFound = true;
    }

    //private void AggroDetection_OnExitAggro()
    //{
        //playerFound = false;
    //}

    //private void WeaponManager_HitEnemy()
    //{
        //zombieHit = true;
    //}
    
    private void Update()
    {
        if (target != null)
        {
            if (PlayerHealthManager.playerDead == false)
            {
                anim.SetBool("idle", false);
                anim.SetBool("playerFound", true);
                navMeshAgent.SetDestination(target.position);
            }
            //navMeshAgent.enabled = true;
            
            //Debug.Log("playerFound Parameter State: " + anim.GetBool("playerFound"));
            //if (zombieHit)
            //{
                //anim.SetBool("zombieHit", zombieHit);
            //}

            //Debug.Log("Enemy Health Manager: " + enemyHealthManager.zombieDead);
            

            //Debug.Log("Remaining Distance = " + navMeshAgent.remainingDistance);
            //float speed = navMeshAgent.velocity.magnitude;
            
        }

        if (PlayerHealthManager.playerDead == false)
        {
            if (navMeshAgent.remainingDistance <= 1.3f)
            {
                anim.SetBool("zombieAttack", true);
                anim.SetBool("playerFound", false);
            }
            else
            {
                //navMeshAgent.isStopped = false;
                anim.SetBool("playerFound", true);
                anim.SetBool("zombieAttack", false);
                //Debug.Log("Reanudó: " + navMeshAgent.isStopped);
            }
        }
    }
}
