﻿using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthManager : MonoBehaviour
{

    [SerializeField]
    int startingHealth = 100;

    double currentHealth;

    Animator anim;

    NavMeshAgent navMeshAgent;

    AudioSource deadSound;

    public static bool zombieDead = false;

    public static int numZombiesDead = 0;

    private void Start()
    {
        deadSound = GetComponent<AudioSource>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage, int isHead)
    {
        if (isHead == 1)
        {
            currentHealth -= damage * 2.5;
            Debug.Log("Zombie Health: " + currentHealth);
        }
        else
        {
            currentHealth -= damage;
            Debug.Log("Zombie Health: " + currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            HitZombie();
        }
    }

    private void HitZombie()
    {
        //navMeshAgent.isStopped = true;
        anim.SetTrigger("zombieHit");
        //Debug.Log("HitZombie: " + navMeshAgent.isStopped);
    }

    public void Die()
    {
        numZombiesDead += 1;
        gameObject.tag = "IsDead";
        anim.SetTrigger("isDead");
        navMeshAgent.isStopped = true;
        deadSound.Play();
        anim.SetBool("playerFound", false);
        anim.SetBool("zombieAttack", false);
        Destroy(gameObject, 10f);
    }

}
