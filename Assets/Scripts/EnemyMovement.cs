using UnityEngine;
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
        //navMeshAgent.isStopped = true;
    //}

    //private void WeaponManager_HitEnemy()
    //{
        //zombieHit = true;
    //}
    
    private void Update()
    {
        if (target != null)
        {
            navMeshAgent.enabled = true;
            anim.SetBool("playerFound", playerFound);
            //Debug.Log("playerFound Parameter State: " + anim.GetBool("playerFound"));
            //if (zombieHit)
            //{
                //anim.SetBool("zombieHit", zombieHit);
            //}

            //Debug.Log("Enemy Health Manager: " + enemyHealthManager.zombieDead);
            navMeshAgent.SetDestination(target.position);

            //Debug.Log("Remaining Distance = " + navMeshAgent.remainingDistance);
            //float speed = navMeshAgent.velocity.magnitude;
            
        }

        if (navMeshAgent.remainingDistance <= 1.6f)
        {
            anim.SetBool("zombieAttack", true);
            anim.SetBool("playerFound", false);
            //navMeshAgent.isStopped = true;
            //Debug.Log("NavMesh Agent is Stopped");
        }
        else
        {
            //navMeshAgent.isStopped = false;
            anim.SetBool("playerFound", true);
            anim.SetBool("zombieAttack", false);
        }
    }
}
