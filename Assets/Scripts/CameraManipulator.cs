using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CameraManipulator : MonoBehaviour
{
    public Camera firstViewCam;
    public Camera hololensCam;
    public void activeFirstPersonView()
    {
        firstViewCam.transform.gameObject.SetActive(true);
        hololensCam.transform.gameObject.SetActive(false);
        /*Vector3 zoomedPos = viewRef.transform.position;
        Debug.Log(zoomedPos);
        Transform camera = gameObject.transform.Find("Main Camera");
        Vector3 cameraTrans = camera.transform.position;
        Quaternion cameraRot = camera.transform.rotation;
        this.transform.position = zoomedPos-cameraTrans-new Vector3(0f,0f,0.2f);
        this.transform.rotation = Quaternion.Euler(-cameraRot.x, -cameraRot.y, -cameraRot.z);*/

    }

    public void resetCamera()
    {
       /* this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.Euler(0, 0, 0);*/
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
