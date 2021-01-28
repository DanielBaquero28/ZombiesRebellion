using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    Text scoreBox;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Número de muertes: " + EnemyHealthManager.numZombiesDead);
        scoreBox = GetComponent<Text>();       
    }

    void Update()
    {
        scoreBox.text = "" + EnemyHealthManager.numZombiesDead.ToString("F0");
    }
}
