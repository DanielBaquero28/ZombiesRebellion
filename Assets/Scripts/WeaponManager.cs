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
    ParticleSystem muzzleFlashPrefab;

    [SerializeField]
    Transform muzzlePoint;

    [SerializeField]
    [Range(0.5f, 1.5f)]
    float fireRate = 1;

    [SerializeField]
    [Range(20, 100)]
    int gunDamage = 20;


    // Start is called before the first frame update
    void Start()
    {
        fireSound = GetComponent<AudioSource>();
        isTriggered.AddOnStateDownListener(TriggerDown, hand);
        isTriggered.AddOnStateUpListener(TriggerUp, hand);    
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger Up");
        triggered = 0;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger Down");
        triggered = 1;
        fireSound.Play();
        FireGun();
        muzzleFlashPrefab.Play();
        //var muzzleflash = Instantiate(muzzleFlashPrefab, muzzlePoint.position, muzzlePoint.rotation);
        //Destroy(muzzleflash.gameObject, 0.04f);
    }

    private void FireGun()
    {
        Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * 10, Color.red, 15f);
        Ray ray = new Ray(muzzlePoint.position, muzzlePoint.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100) && hitInfo.collider.gameObject.tag == "ZombieBodyPart")
        {
            GameObject subGameObject = hitInfo.collider.gameObject;
            Debug.Log("SubGameObject 1 Name: " + subGameObject.name);
            Debug.Log("SubGameObject Root Name: " + subGameObject.transform.root.gameObject);
            GameObject zombieRoot = subGameObject.transform.root.gameObject;
            var health = zombieRoot.GetComponent<EnemyHealthManager>();
            if (health != null)
            {
                if (subGameObject.name == "Head")
                {
                    health.TakeDamage(gunDamage, 1);
                }
                else
                {
                    health.TakeDamage(gunDamage, 0);
                }
            }
        }
    }

}
