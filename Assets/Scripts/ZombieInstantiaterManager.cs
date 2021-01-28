using UnityEngine;

public class ZombieInstantiaterManager : MonoBehaviour
{
    [SerializeField]
    GameObject zombie1;

    [SerializeField]
    GameObject zombie2;

    [SerializeField]
    GameObject zombie3;

    float timer;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 30f && timer < 30.02f)
        {
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
        }
        else if (timer > 60f && timer < 60.02f)
        {
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
        }
        else if (timer > 90f && timer < 90.02f)
        {
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
        }
        else if (timer > 150f && timer < 150.02f)
        {
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
        }
        else if (timer > 210f && timer < 210.02f)
        {
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
        }
        else if (timer > 240f && timer < 240.02f)
        {
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
        }
        else if (timer > 270f && timer < 270.02f)
        {
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
            Instantiate(zombie1, zombie1.transform.position, zombie1.transform.rotation);
            Instantiate(zombie2, zombie2.transform.position, zombie2.transform.rotation);
            Instantiate(zombie3, zombie3.transform.position, zombie3.transform.rotation);
        }
        
        
    }
}
