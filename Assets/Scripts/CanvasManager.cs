using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    void Start()
    {
        Invoke("DisableBeginText", 3f);
    }

    private void DisableBeginText()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
}
