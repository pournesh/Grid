using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    private Vector3 dragOrigin;
    public Camera cam;
    [SerializeField]
    private float zoomStep, minCamSize, MaxCamSize;



    private void Start()
    {
    }
    private void Update()
    {
        PanCamera();
       // Debug.Log("mouse:" + Input.mouseScrollDelta.y);
        if (Input.mouseScrollDelta.y > 0)
        {
            Debug.Log("mouse:" + Input.mouseScrollDelta.y);
            camIncr();
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            Debug.Log("mouse:" + Input.mouseScrollDelta.y);
            camDecr();
        }
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            //print("origin :" + dragOrigin + " new Pos : " + cam.ScreenToWorldPoint(Input.mousePosition));

            cam.transform.position += difference;
        }
    }
    public void cameraUP()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 pos = cam.transform.position;
            //cam.transform.position = new Vector3(pos.x, pos.y, pos.z-3);
            cam.transform.Translate(new Vector3(pos.x, pos.y, pos.z - 3)*Time.deltaTime, cam.transform);
        }


    }

    public void cameraDown()
    {
        Vector3 pos = cam.transform.position;
        cam.transform.position = new Vector3(pos.x, pos.y , pos.z+3);
    }

    public void zoomIn()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            camIncr();
        }
        

    }

    void camIncr()
    {
        float newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, MaxCamSize);
    }

    public void zoomOut()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            camDecr();
        }
    }

    void camDecr()
    {
        float newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, MaxCamSize);
    }



}
