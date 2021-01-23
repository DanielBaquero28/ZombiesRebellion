using System;
using UnityEngine;

public class AggroDetection : MonoBehaviour
{
    public event Action<Transform> OnAggro = delegate {};

    //public event Action OnExitAggro = delegate {};

    private void OnTriggerEnter(Collider other)
    {
        //var player = other.gameObject;
        var player = other.GetComponent<PlayerVoid>();

        if (player != null)
        {
            OnAggro(player.transform);
            Debug.Log("Aggrod");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerVoid>();

        if (player != null)
        {
            //OnExitAggro();
            Debug.Log("Player Exited");
        }
    }


}
