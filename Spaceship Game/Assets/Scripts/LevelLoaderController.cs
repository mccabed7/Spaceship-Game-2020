using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderController : MonoBehaviour
{
    public string loadsTo;

    public Animation playerFlickerAnimation;

    public string menuSceneName;

    public AudioSource gameOverSound;

    public void Start()
    {
        if ( SceneManager.GetActiveScene().name == "GameScene") 
        {
            playerFlickerAnimation = GameObject.Find("Player").GetComponent<Animation>();
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            playerFlickerAnimation.Play();
        }
    }


    IEnumerator PlayerFlickerAnimation()
    {
        playerFlickerAnimation.Play();

        gameOverSound.Play();

        yield return new WaitForSeconds(1f);

        //I could put another Legacy Animation here.  Perhaps make the spaceship shrink? Might not look good though.

        SceneManager.LoadScene(menuSceneName);
    }

    public void FinishGameScene()
    {
        StartCoroutine(PlayerFlickerAnimation());
        //SceneManager.LoadScene(menuSceneName);
    }

    public void ButtonPressSceneChange()
    {
        SceneManager.LoadScene(loadsTo);
    }

    
}
