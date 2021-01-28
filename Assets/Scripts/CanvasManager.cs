using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    void Start()
    {
        Invoke("DisableBeginText", 5f);
    }

    private void DisableBeginText()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}
