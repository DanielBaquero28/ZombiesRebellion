using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVoid : MonoBehaviour
{
    //int zombieKilled = 0;

    [SerializeField]
    GameObject killsText;

    // Start is called before the first frame update
    private void Update()
    {
        killsText.GetComponent<Text>().text = "" + EnemyHealthManager.numZombiesDead.ToString("F0");
    }

}
