using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public TextMeshProUGUI scoreText;
    public int score;
    public PlayerController playerController;

    public float leftLimit;
    public float rightLimit;

    public Vector3 obstacleSpawnPosition;

    public float spawnTimer;
    public float spawnInterval;
    public float spawnIntervalIncrement;

    public float obstacleMovementSpeed;
    public float obstacleMovementIncrement;
    public float currentTime;

    public ObstacleController latestObstacleController;

    public void Start()
    {
        leftLimit = playerController.leftLimit.x;
        rightLimit = playerController.rightLimit.x;
        
    }

    private void Update()
    {
        score = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        scoreText.text = score.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiateObstacle(); //Old method.  Replace it or delete it.
        }
        /*
        if (spawnTimer <= Time.timeSinceLevelLoad)
        {
            InstantiateObstacle();
            spawnTimer += spawnInterval;
        }
        */
        if (spawnTimer <= Time.timeSinceLevelLoad)
        {
            obstacleSpawnPosition.x = Random.Range(leftLimit, rightLimit);
            latestObstacleController =  GameObject.Instantiate(obstacle, obstacleSpawnPosition, Quaternion.identity).GetComponent<ObstacleController>();
            latestObstacleController.movementSpeed = obstacleMovementSpeed;
            spawnTimer += spawnInterval;
        }

        UpdateObstacleMovementSpeed();

    }

    public void InstantiateObstacle()  //Old method.  Replace it or delete it.
    {
        obstacleSpawnPosition.x = Random.Range(leftLimit, rightLimit);

        GameObject.Instantiate(obstacle, obstacleSpawnPosition, Quaternion.identity);

        
    }

    public void UpdateObstacleMovementSpeed()
    {
        currentTime = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        if(currentTime % 5 == 0)
        {
            Debug.Log("Difficulty Has Been Increased!");

            switch (currentTime)
            {
                case 5:
                    obstacleMovementSpeed = 3;
                    break;
                case 10:
                    obstacleMovementSpeed = 5;
                    break;
                case 15:
                    obstacleMovementSpeed = 6;
                    break;
                case 20:
                    obstacleMovementSpeed = 7;
                    break;
                case 25:
                    obstacleMovementSpeed = 8;
                    break;
                case 30:
                    obstacleMovementSpeed = 9;
                    break;
                default:
                    break;
            }

            if (currentTime >= 35)
            {
                spawnInterval -= Time.deltaTime * spawnIntervalIncrement;
            }

        }
    }

   
}
