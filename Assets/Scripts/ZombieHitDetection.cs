using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieHitDetection : MonoBehaviour
{
    int playerHealth = 100;

    double currentHealth;

    Animator anim;

    NavMeshAgent navMeshAgent;

    //[SerializeField]
    //GameObject gunPrefab;

    GameObject zombieRoot;

    //WeaponManager weaponManager;

    public static bool playerDead = false;

    GameObject bloodSpatter;

    GameObject canvas;

    GameObject healthText;

    //GameObject playersPrefab;

    private void OnTriggerEnter(Collider other)
    {
        zombieRoot = gameObject.transform.root.gameObject;
        anim = zombieRoot.GetComponent<Animator>();
        navMeshAgent = zombieRoot.GetComponent<NavMeshAgent>();
        //weaponManager = gunPrefab.GetComponent<WeaponManager>();
        //Debug.Log("Weapon Manager: " + weaponManager);
        var player = other.GetComponent<PlayerVoid>();
        //playersPrefab = player.gameObject;
        //Debug.Log("TriggerEnter()");

        if (player != null)
        {
            canvas = player.gameObject.transform.GetChild(0).gameObject;
            //Debug.Log("Tmp Name: " + tmp.name);
            bloodSpatter = canvas.transform.GetChild(0).gameObject;
            bloodSpatter.SetActive(true);
            var tmp = player.transform.parent.gameObject;
            TakeDamage(20, tmp.transform.parent.gameObject);
            //Debug.Log(bloodSplatter.name);
            //Debug.Log(bloodSplatter.GetComponent<Image>());
            StartCoroutine(FadeImage(bloodSpatter));
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

    private void TakeDamage(int damage, GameObject playerPrefab)
    {
        var tmp = playerPrefab.transform.GetChild(0).gameObject;
        tmp = tmp.transform.parent.gameObject;
        tmp = tmp.transform.parent.gameObject;
        var tmp2 = tmp.transform.GetChild(1).gameObject;
        tmp2 = tmp2.transform.GetChild(4).gameObject;
        tmp2 = tmp2.transform.GetChild(0).gameObject;
        healthText = tmp2.transform.GetChild(2).gameObject;
        tmp = tmp.transform.GetChild(2).gameObject;
        tmp = tmp.transform.GetChild(4).gameObject;
        //tmp = tmp.transform.GetChild(2).gameObject;
        //tmp = tmp.transform.GetChild(4).gameObject;
        playerHealth -= damage;
        //Debug.Log("TakeDamage() CurrentHealth: " + playerHealth);
        if (playerHealth <= 0)
        {
            healthText.GetComponent<Text>().text = "0";
            tmp.SetActive(false);
            Die();
        }
        else
        {
            string healthStr = playerHealth.ToString("F0");
            healthText.GetComponent<Text>().text = "" + healthStr;
            //Debug.Log("Tiene " + currentHealth + " de vida");
        }
    }

    private void Die()
    {
        //AudioSource audio = playersPrefab.GetComponent<AudioSource>();
        //audio.Stop();
        playerDead = true;
        //Debug.Log("Player Murió");
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
