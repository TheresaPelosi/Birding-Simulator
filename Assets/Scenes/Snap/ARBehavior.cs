using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using Unity.Collections;

public class ARBehavior : MonoBehaviour
{
    public GameObject placementIndicator;
    private ARRaycastManager rayManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    private bool spawned = false;
    private ARPlane[] planes;
    private GameObject bird;

    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();
        bird = GameObject.FindGameObjectWithTag("Droid");
        //bird.SetActive(false);
    }

    void Update()
    {
        planes = FindObjectsOfType<ARPlane>();

        if (planes.Length > 0 && !spawned)
        {
            int index = Random.Range(0, planes.Length);
            ARPlane chosenPlane = planes[index];
            Vector3 center = chosenPlane.center;
            Vector2 planeSize = chosenPlane.size;
            Vector3 position = new Vector3(center.x - planeSize.x / 2 + Random.Range(0, planeSize.x),
                center.y - planeSize.y / 2 + Random.Range(0, planeSize.y), center.z);
            bird.transform.position = position;
            bird.transform.rotation = chosenPlane.transform.rotation;
            bird.transform.localScale = Vector3.Scale(bird.transform.localScale, new Vector3(0.03f, 0.03f, 0.03f));
            bird.SetActive(true);
            spawned = true;
        }
    }
}
