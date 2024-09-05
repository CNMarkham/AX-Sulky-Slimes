using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LivesManager : MonoBehaviour
{
    public int lives;
    public GameObject[] hearts;

  
    // Start is called before the first frame update

    public void RemoveLife()
    {
        lives -= 1;
        hearts[lives].SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        { 
            SceneManager.LoadScene(0);
        }
    }
}
