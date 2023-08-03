using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 mousePosition;

    public float middleOfScreen;

    //public Rigidbody2D playerRigidBody;

    public float movementSpeed;

    public Vector2 movementVector;

    public Vector3 screenSize;
    public Vector3 leftLimit;
    public Vector3 rightLimit;
    public float limitOffset;

    public bool isAlive;

    public LevelLoaderController levelLoaderController;
    public DataStorerController dataStorerController;
    public GameController gameController;

    private void Awake()
    {
        middleOfScreen = Screen.width /2;
        //Debug.Log(middleOfScreen);
        FindLimits();
        isAlive = true;
        dataStorerController = GameObject.Find("Data Storer").GetComponent<DataStorerController>();
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    

    /*private void OnMouseDown()
    {
        Debug.Log("Left Click");
        middleOfScreen = Screen.width;
        mousePosition = Input.mousePosition;
        if (mousePosition.x >= middleOfScreen)  // <--- middleOfScreen goes here
        {
            Move(1);
        }
        else
        {
            Move(2);
        }
    }*/

    public void Move(int moveDirection)
    {
        
        if (moveDirection == 1 && transform.position.x > leftLimit.x + limitOffset) //Moving left
        {
            
            movementVector.x = transform.position.x - 1 * movementSpeed * Time.deltaTime;
            transform.SetPositionAndRotation(movementVector, transform.rotation);  //NOTE:  IF THERE IS STUTTERING, CHANGE THIS TO A RIGIDBODY-BASED MOVEMENT SYSTEM AND ENABLE INTERPOLATION.
            //playerRigidBody.AddForce(movementVector, ForceMode2D.Impulse);
        }
        else if (moveDirection == 2 && transform.position.x < rightLimit.x - limitOffset) //Moving right
        {
            
            movementVector.x = movementSpeed * Time.deltaTime + transform.position.x;
            //playerRigidBody.AddForce(movementVector, ForceMode2D.Impulse);
            transform.SetPositionAndRotation(movementVector, transform.rotation);  //SEE ABOVE NOTE
        }

    }

    public void FindLimits()
    {
        screenSize.x = Screen.width;
        screenSize.y = Screen.height;
        screenSize.z = 0;
        rightLimit = Camera.main.ScreenToWorldPoint(screenSize);
        leftLimit.x = -rightLimit.x;
        Debug.Log("Right Limit = " + rightLimit.x);
        Debug.Log("Left Limit = " + leftLimit.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && isAlive == true)
        {
            isAlive = false;
            Destroy(collision.gameObject);
            dataStorerController.UpdatePreviousScore(gameController.score);
            dataStorerController.UpdateHighScore();
            levelLoaderController.FinishGameScene();
        }
    }

    private void Update()
    {
        //Debug.Log(Input.mousePosition);

        if(Input.GetMouseButton(0) == true)
        {
            //Debug.Log("Left Click");
            mousePosition = Input.mousePosition;
            if (mousePosition.x <= middleOfScreen)
            {
                Move(1);  //Moving left
            }
            else
            {
                Move(2);  //Moving right
            }
        }
    }
}
