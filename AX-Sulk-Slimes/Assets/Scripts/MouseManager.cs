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

    [Header("Lives")]
    public LivesManager livesManager;


    public bool launched = false;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = slimeTransform.position;
        startingRotation = slimeTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (livesManager.lives < 0)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && launched == false)
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            launchVector = new Vector3(
                mouseDifference.x * 1f,
                mouseDifference.y * 1.2f,
                mouseDifference.y * 1.5f
                );
            slimeTransform.position = startingPosition - launchVector / 400;
            launchVector.Normalize();
        }
        if (Input.GetMouseButtonUp(0) && launched == false)
        {
            slimeRigidbody.isKinematic = false;
            slimeRigidbody.AddForce(launchVector * launchForce, ForceMode.Force);
            print("Release!");
            launched = true;
        }
        if (Input.GetKeyDown("space"))
        {
            slimeRigidbody.isKinematic = true;
            slimeTransform.position = startingPosition;
            slimeTransform.rotation = startingRotation;
            livesManager.RemoveLife();
            launched = false;
        }
    }
}
