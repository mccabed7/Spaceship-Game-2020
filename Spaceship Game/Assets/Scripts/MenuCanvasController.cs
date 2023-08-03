using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuCanvasController : MonoBehaviour
{
    public TextMeshProUGUI previousScoreText;
    public TextMeshProUGUI highScoreText;

    public DataStorerController dataStorerController;

    // Start is called before the first frame update
    void Start()
    {
        dataStorerController = GameObject.Find("Data Storer").GetComponent<DataStorerController>();
        previousScoreText.text = dataStorerController.previousScore.ToString();
        highScoreText.text = dataStorerController.highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.C))
        {
            dataStorerController.ClearHighScore();
            highScoreText.text = dataStorerController.highScore.ToString();
        }
    }
}
