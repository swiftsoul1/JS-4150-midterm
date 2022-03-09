using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float timeRemaining = 3;
    public int score = 0;
    [SerializeField]
    Transform zombagSpawnPoint1;
    [SerializeField]
    Transform zombagSpawnPoint2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelOne")) 
            {
                timeRemaining = UnityEngine.Random.Range(3, 5); 
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelTwo"))
            {
                timeRemaining = UnityEngine.Random.Range(1, 3);
            }
            // had random but the game moved to slow
            if(zombagSpawnPoint1 != null)
            {
                Instantiate(Resources.Load("Enemy"), zombagSpawnPoint1.transform.position, Quaternion.identity);
                Instantiate(Resources.Load("Enemy"), zombagSpawnPoint2.transform.position, Quaternion.identity);
            }
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("WinScene"))
            {
                score = 0;
                SceneManager.LoadScene("LevelOne");
            }
        }
    }


    public void UpdateScore() 
    {
        score++;
        Debug.Log(score.ToString());
        if (score > 14 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelOne"))
        {
            SceneManager.LoadScene("LevelTwo");
        }
        else if(score > 29 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelTwo"))
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
