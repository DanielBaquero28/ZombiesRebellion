using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    int playerHealth = 100;

    double currentHealth;

    Animator animZombie;

    NavMeshAgent navMeshAgent;

    //[SerializeField]
    //GameObject gunPrefab;

    GameObject zombieRoot;

    //WeaponManager weaponManager;

    public static bool playerDead = false;

    [SerializeField]
    public GameObject bloodSplatter;

    //[SerializeField]
    //public GameObject canvas;

    [SerializeField]
    public GameObject healthText;

    [SerializeField]
    public GameObject gunPrefab;

    //[SerializeField]
    AudioSource audioInGame;

    [SerializeField]
    public GameObject player;

    [SerializeField]
    public GameObject gameOverPanel;

    private void Start()
    {
        audioInGame = player.GetComponent<AudioSource>();
        currentHealth = playerHealth;
    }


    private void OnTriggerEnter(Collider other)
    {
        zombieRoot = other.transform.root.gameObject;
        animZombie = zombieRoot.GetComponent<Animator>();
        navMeshAgent = zombieRoot.GetComponent<NavMeshAgent>();
        //weaponManager = gunPrefab.GetComponent<WeaponManager>();
        //Debug.Log("Weapon Manager: " + weaponManager);
        var zombieHand = other.GetComponent<ZombieHitDetection>();
        //playersPrefab = player.gameObject;
        //Debug.Log("TriggerEnter()");

        if (zombieHand != null && playerDead == false)
        {
            bloodSplatter.SetActive(true);
            TakeDamage(20);
            StartCoroutine(FadeImage(bloodSplatter));
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
        //var tmp = playerPrefab.transform.GetChild(0).gameObject;
        //tmp = tmp.transform.parent.gameObject;
        //tmp = tmp.transform.parent.gameObject;
        //var tmp2 = tmp.transform.GetChild(1).gameObject;
        //tmp2 = tmp2.transform.GetChild(4).gameObject;
        //tmp2 = tmp2.transform.GetChild(0).gameObject;
        //healthText = tmp2.transform.GetChild(2).gameObject;
        //tmp = tmp.transform.GetChild(2).gameObject;
        //tmp = tmp.transform.GetChild(4).gameObject;
        //tmp = tmp.transform.GetChild(2).gameObject;
        //tmp = tmp.transform.GetChild(4).gameObject;

        if (animZombie.GetBool("zombieAttack") == true)
            currentHealth -= damage;
        //Debug.Log("TakeDamage() CurrentHealth: " + playerHealth);
        if (currentHealth <= 0)
        {
            healthText.GetComponent<Text>().text = "0";
            gunPrefab.SetActive(false);
            Die();
        }
        else
        {
            string healthStr = currentHealth.ToString("F0");
            healthText.GetComponent<Text>().text = "" + healthStr;
            Debug.Log("Tiene " + currentHealth + " de vida");
        }
    }

    private void Die()
    {
        gameOverPanel.SetActive(true);
        audioInGame.Stop();
        playerDead = true;
        //Debug.Log("Player Murió");
        navMeshAgent.isStopped = true;
        //weaponManager.enabled = false;
        animZombie.SetBool("idle", true);
        animZombie.SetBool("playerFound", false);
        animZombie.SetBool("zombieAttack", false);
        Invoke("SceneGameOver", 10f);
    }

    private void SceneGameOver()
    {
        SceneManager.LoadScene(2);
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
