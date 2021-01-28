﻿using UnityEngine;

public class LaserInputManager : MonoBehaviour
{
    public static GameObject currentObject;
    int currentID;

    // Start is called before the first frame update
    void Start()
    {
        currentObject = null;
        currentID = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0f);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            int id = hit.collider.gameObject.GetInstanceID();

            if (currentID != id)
            {
                currentID = id;
                currentObject = hit.collider.gameObject;

                string tag = currentObject.tag;
                if (tag == "UI Element")
                {
                    Debug.Log("Touched UI Element");
                }

            }
        }
    }
}
