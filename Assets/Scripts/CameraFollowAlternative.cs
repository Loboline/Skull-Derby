using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowAlternative : MonoBehaviour
{
    public GameObject focusPoint;// S� vi kan dra in referens till FocusPoint-gameobject till skriptet p� kameran
    private Vector3 cameraOffset = new Vector3(0, 100, 0); //en offset (s� inte kameran hamnar mitt i playern
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = focusPoint.transform.position + cameraOffset;
        transform.rotation = focusPoint.transform.rotation;

    }
}
