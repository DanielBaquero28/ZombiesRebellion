using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieHitDetection : MonoBehaviour
{
    int playerHealth = 100;

    Animator anim;

    NavMeshAgent navMeshAgent;

    [SerializeField]
    GameObject gunPrefab;

    GameObject zombieRoot;

    WeaponManager weaponManager;

    public static bool playerDead = false;

    [SerializeField]
    public Image img;


    private void OnTriggerEnter(Collider other)
    {
        img.enabled = true;
        StartCoroutine(FadeImage(true));
        zombieRoot = gameObject.transform.root.gameObject;
        anim = zombieRoot.GetComponent<Animator>();
        navMeshAgent = zombieRoot.GetComponent<NavMeshAgent>();
        weaponManager = gunPrefab.GetComponent<WeaponManager>();
        //Debug.Log("Weapon Manager: " + weaponManager);
        var player = other.GetComponent<PlayerVoid>();

        if (player != null)
        {
            TakeDamage(20);
        }
    }

    private void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log("Tiene " + playerHealth + " de vida");
            //Parte de UI de Sangre
        }
    }

    private void Die()
    {
        playerDead = true;
        Debug.Log("Player Murio");
        navMeshAgent.isStopped = true;
        weaponManager.enabled = false;
        anim.SetBool("idle", true);
        anim.SetBool("playerFound", false);
        anim.SetBool("zombieAttack", false);
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //TESTING;
    }
}
