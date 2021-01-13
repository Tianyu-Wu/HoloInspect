using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UIElements;

public class HouseController : MonoBehaviour
{
    [SerializeField]
    private GameObject smallHouse;
    [SerializeField]
    private float timeToArrive;
    [SerializeField]
    private GameObject constructionLayerPanel;
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private GameObject anchor1;
    [SerializeField]
    private GameObject anchor2;
    [SerializeField]
    private bool inLargeScale=false;

    private Vector3 upstairsPosition;
    private Vector3 downstairsPosition;

    public void ToggleConstructionLayer()
    {
        if (inLargeScale)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(!child.gameObject.activeInHierarchy);
            }
        } else
        {
            constructionLayerPanel.SetActive(true);
            mainPanel.SetActive(false);
            anchor1.SetActive(false);
            anchor2.SetActive(false);
        }
    }

    public void ToggleScale()
    {
        inLargeScale = !gameObject.activeInHierarchy;
        smallHouse.SetActive(!smallHouse.activeInHierarchy);
		gameObject.transform.position = smallHouse.transform.position;
		gameObject.transform.rotation = smallHouse.transform.rotation;
		gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void Upstairs()
    {
        StartCoroutine(UpstairsInTime());
    }
    public IEnumerator UpstairsInTime()
    {
        upstairsPosition = gameObject.transform.position + new Vector3(0f, -3.3f, 0f);
        float timePercentage = 0f;
        while(timePercentage < 1)
        {
            timePercentage += Time.deltaTime / timeToArrive;
            transform.position = Vector3.Lerp(transform.position, upstairsPosition, timePercentage);
            yield return null;
        }

    }

    public void Downstairs()
    {
        StartCoroutine(DownstairsInTime());
    }

    public IEnumerator DownstairsInTime()
    {
        downstairsPosition = gameObject.transform.position + new Vector3(0f, 3.3f, 0f);
        float timePercentage = 0f;
        while (timePercentage < 1)
        {
            timePercentage += Time.deltaTime / timeToArrive;
            transform.position = Vector3.Lerp(transform.position, downstairsPosition, timePercentage);
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
