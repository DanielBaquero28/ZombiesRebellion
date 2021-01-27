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

    //[SerializeField]
    //GameObject gunPrefab;

    GameObject zombieRoot;

    //WeaponManager weaponManager;

    public static bool playerDead = false;


    private void OnTriggerEnter(Collider other)
    {
        zombieRoot = gameObject.transform.root.gameObject;
        anim = zombieRoot.GetComponent<Animator>();
        navMeshAgent = zombieRoot.GetComponent<NavMeshAgent>();
        //weaponManager = gunPrefab.GetComponent<WeaponManager>();
        //Debug.Log("Weapon Manager: " + weaponManager);
        var player = other.GetComponent<PlayerVoid>();
        Debug.Log("TriggerEnter()");

        if (player != null)
        {
            var tmp = player.gameObject.transform.GetChild(0).gameObject;
            //Debug.Log("Tmp Name: " + tmp.name);
            tmp.SetActive(true);
            TakeDamage(20);
            Debug.Log(tmp.name);
            Debug.Log(tmp.transform.GetChild(0).gameObject.GetComponent<Image>());
            StartCoroutine(FadeImage(tmp.transform.GetChild(0).gameObject));
        }
    }

    IEnumerator FadeImage(GameObject image)
    {
        Image img = image.GetComponent<Image>();
        for (float i = 0.6f; i >= 0; i -= Time.deltaTime)
        {
            img.color = new Color(1, 1, 1, i);
            yield return null;
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
            //img.enabled = true;
            //Debug.Log("Tiene " + playerHealth + " de vida");
            //Parte de UI de Sangre
        }
    }

    private void Die()
    {
        playerDead = true;
        Debug.Log("Player Murio");
        navMeshAgent.isStopped = true;
        //weaponManager.enabled = false;
        anim.SetBool("idle", true);
        anim.SetBool("playerFound", false);
        anim.SetBool("zombieAttack", false);
    }


    //private void OnTriggerExit(Collider other)
    //{
        //var player = other.GetComponent<PlayerVoid>();

        //if (player != null)
        //{
            //var tmp = player.gameObject.transform.GetChild(0).gameObject;
            //tmp.SetActive(false);
        //}
    //}
}
