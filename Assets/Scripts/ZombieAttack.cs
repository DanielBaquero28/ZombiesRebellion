using System;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float zombieDamage = 20f;
    public float radius = 1f;

    [SerializeField]
    public LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        if (hits.Length >= 1)
        {   
            Debug.Log("Zombie Attack - Enemy " + hits[0].gameObject.name + " has been hit!");
        } 
    }
}
