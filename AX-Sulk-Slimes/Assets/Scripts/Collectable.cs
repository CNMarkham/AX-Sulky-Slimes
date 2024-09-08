using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectables : MonoBehaviour
{
    [Header("Movement Values")]
    public float distanceToMove;
    
    public Vector3 startingPosition;
    public Vector3 endingPosition;

    public float speed = 4f;
    public float direction = 4f;

    [Header("Scene to Load")]
    public int sceneNumber;
    // Start is called before the first frame update
    private void LoadNextScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
    void Start()
    {
        startingPosition = transform.position;
        endingPosition = transform.position + new Vector3(3,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startingPosition.x)
        {
            direction = 1f;
        }
        if (transform.position.x > endingPosition.x)
        {
            direction = -1f;
        }
        transform.position += new Vector3(speed * direction * Time.deltaTime,0,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Invoke("LoadNextScene", 2f);
        }
    }
}
