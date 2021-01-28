using System;
using UnityEngine;
using Valve.VR;

public class WeaponManager : MonoBehaviour
{
    public SteamVR_Input_Sources hand;

    public SteamVR_Action_Boolean isTriggered;

    int triggered = 0;

    AudioSource fireSound;

    [SerializeField]
    ParticleSystem muzzleFlash;

    [SerializeField]
    Transform muzzlePoint;

    [SerializeField]
    [Range(0.5f, 1.5f)]
    float fireRate = 1;

    [SerializeField]
    [Range(20, 100)]
    int gunDamage = 20;

    [SerializeField]
    public GameObject zombieDecal;


    // Start is called before the first frame update
    void Start()
    {
        fireSound = GetComponent<AudioSource>();
        isTriggered.AddOnStateDownListener(TriggerDown, hand);
        isTriggered.AddOnStateUpListener(TriggerUp, hand);    
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //Debug.Log("Trigger Up");
        triggered = 0;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //Debug.Log("Trigger Down");
        triggered = 1;
        fireSound.Play();
        FireGun();
        muzzleFlash.Clear();
        muzzleFlash.Play();
        //var muzzleflash = Instantiate(muzzleFlash, muzzlePoint.position, muzzlePoint.rotation);
        //Destroy(muzzleflash.gameObject, 0.04f);
    }

    private void FireGun()
    {
        Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * 10, Color.red, 15f);
        Ray ray = new Ray(muzzlePoint.position, muzzlePoint.forward);
        RaycastHit hitInfo;
        if (ZombieHitDetection.playerDead == false)
        {
            if (Physics.Raycast(ray, out hitInfo, 5000) && hitInfo.collider.gameObject.CompareTag("ZombieBodyPart"))
            {
                GameObject subGameObject = hitInfo.collider.gameObject;
                //Debug.Log("SubGameObject 1 Name: " + subGameObject.name);
                //Debug.Log("SubGameObject Root Name: " + subGameObject.transform.root.gameObject);
                GameObject zombieRoot = subGameObject.transform.root.gameObject;
                if (zombieRoot.tag != "IsDead")
                {
                    var impactEffect = Instantiate(zombieDecal, hitInfo.point, Quaternion.FromToRotation(Vector3.forward, hitInfo.normal));
                    impactEffect.transform.parent = zombieRoot.transform;
                    var health = zombieRoot.GetComponent<EnemyHealthManager>();
                    if (health != null)
                    {
                        if (subGameObject.name == "HeadCollider")
                        {
                            health.TakeDamage(gunDamage, 1);
                            Destroy(impactEffect, 0.5f);
                        }
                        else
                        {
                            health.TakeDamage(gunDamage, 0);
                            Destroy(impactEffect, 0.5f);
                        }
                    }
                }
            }
        }
    }

}
