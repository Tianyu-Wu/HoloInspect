using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConstructionLayerController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleEnvironment()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void ToggleLayer()
    {
        // get parent
        GameObject parent = gameObject.transform.parent.gameObject;

        bool beforeNoneActive = !parent.transform.Find("Electricity").gameObject.activeInHierarchy && !parent.transform.Find("Pipe").gameObject.activeInHierarchy && !parent.transform.Find("Ducts").gameObject.activeInHierarchy;
        
        // toggle the object itself
        gameObject.SetActive(!gameObject.activeInHierarchy);

        bool afterNoneActive = !parent.transform.Find("Electricity").gameObject.activeInHierarchy && !parent.transform.Find("Pipe").gameObject.activeInHierarchy && !parent.transform.Find("Ducts").gameObject.activeInHierarchy;

        if (afterNoneActive || beforeNoneActive)
        {
            // toggle other siblings
            foreach (Transform child in parent.transform)
            {
                if (child.gameObject.name == "Electricity" || child.gameObject.name == "Pipe" || child.gameObject.name == "Ducts" || child.gameObject.name == "Camera")
                {
                    continue;
                }
                else
                {
                    child.gameObject.SetActive(!child.gameObject.activeInHierarchy);
                }
            }
        }

    }
}
