using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [Header("Mouse Info")]
    public Vector3 clickStartLocation;
    public Vector3 startingPosition;
    public Quaternion startingRotation;
    [Header("Physics")]
    public Vector3 launchVector;
    public float launchForce;

    [Header("Slime")]
    public Transform slimeTransform;
    public Rigidbody slimeRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = slimeTransform.position;
        startingRotation = slimeTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            launchVector = new Vector3(
                mouseDifference.x * 1f,
                mouseDifference.y * 1.2f,
                mouseDifference.y * 1.5f
                );
            launchVector.Normalize();
        }
        if (Input.GetMouseButtonUp(0))
        {
            slimeRigidbody.isKinematic = false;
            slimeRigidbody.AddForce(launchVector * launchForce, ForceMode.Force);
            print("Release!");
        }
        if (Input.GetKeyDown("space"))
        {
            slimeRigidbody.isKinematic = true;
            slimeTransform.position = startingPosition;
            slimeTransform.rotation = startingRotation;
            
        }
    }
}
