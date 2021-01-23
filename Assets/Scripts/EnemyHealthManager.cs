using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthManager : MonoBehaviour
{

    [SerializeField]
    int startingHealth = 100;

    double currentHealth;

    Animator anim;

    NavMeshAgent navMeshAgent;

    public static bool zombieDead = false;

    private void Start()
    {
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
        }
        else
        {
            currentHealth -= damage;
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
        anim.SetTrigger("zombieHit");
    }

    public void Die()
    {
        anim.SetBool("isDead", true);
        anim.SetBool("playerFound", false);
        anim.SetBool("zombieAttack", false);
        navMeshAgent.isStopped = true;
        //zombieDead = true;
        //Destroy(gameObject.GetComponent<NavMeshAgent>());
        //gameObject.SetActive(false);
        Destroy(gameObject, 10f);
    }

}
