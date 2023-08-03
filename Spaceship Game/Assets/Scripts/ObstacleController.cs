using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public Rigidbody2D obstacleRigidbody;
    public Vector2 movementVector;
    public float movementSpeed;

    public int currentTime;
    public int difficultyInterval;
    public float difficultyIncrement;

    

    public void Start()
    {
        movementSpeed = movementSpeed * Random.Range(0.9f, 1.1f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        Move();
    }

    private void Update()
    {
        //Debug.Log(Time.timeSinceLevelLoad);
        currentTime = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        //Debug.Log(currentTime);
        /*
        if(currentTime % 5 == 0)  //MOVE THIS INTO GAMECONTROLLER!!!
        {
            switch (currentTime)
            {
                case 5:
                    movementSpeed = 2;
                    break;
                case 10:
                    movementSpeed = 3;
                    break;
                case 15:
                    movementSpeed = 4;
                    break;
                default:
                    break;
            }
        }
        */
        /*
        currentTime = int.Parse(Time.timeSinceLevelLoad.ToString());   
        if (currentTime % difficultyInterval == 0)
        {
            Debug.Log("DIFFICULTY HAS BEEN INCREASED, currentTime = " + currentTime );
        }
        */
        //movementSpeed += Time.deltaTime * Time.timeSinceLevelLoad * difficultyIncrement;
        /*
        if(Time.timeSinceLevelLoad % 5 <= 0.05)
        {
            Debug.Log("Increased difficulty");
            movementSpeed += difficultyIncrement;
        }
        */
        //movementSpeed = (1 / Time.timeSinceLevelLoad) * 2;
    }

    public void Move()
    {

        //transform.SetPositionAndRotation(movementVector, Quaternion.identity);
        //obstacleRigidbody.MovePosition(movementVector * Time.deltaTime * movementSpeed);
        //transform.position -= transform.up * Time.deltaTime * movementSpeed;
        obstacleRigidbody.velocity = movementVector * movementSpeed;
    }

}
