using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private const string hitRightBtn = "HitRight";
    private const string hitLeftBtn = "HitLeft";

    public GameObject patient;
    public GameObject buttonPrompt;
    public TextMeshProUGUI inputText,scoreText,timeText;
    public DentistTool tool;
    public MouthManager mouthManager;

    public int patientCount;

    private int _score;
    public int score
    {
        get 
        {
            return _score; 
        }
        set 
        {
            _score = value;
            scoreText.text = "Score: "+ value.ToString();
        }
    }
    private float _timeLeft = 60;
    public float timeLeft
    {
        get
        {
            return _timeLeft;
        }
        set
        {
            _timeLeft = value;
            timeText.text = "Time: " + value.ToString("F2");
            if (value <= 0)
                GameOver();
        }
    }


    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
    }
    public void GameOver()
    {

    }

    public void SetNewButtonPrompt()
    {
        if (!buttonPrompt.activeSelf)
            buttonPrompt.SetActive(true);
        //add anim here

        char newButton;
        if (Random.Range(0, 2) == 0)
        {
            newButton = 'D';
            tool.nextInputButton = hitRightBtn;
        }
        else
        {
            newButton = 'A';
            tool.nextInputButton = hitLeftBtn;
        }

        inputText.text = newButton.ToString();

    }
    public void RemoveButtonPrompt()
    {
        Debug.Log("remove");
        buttonPrompt.SetActive(false); //anim here

        inputText.text = null;
        tool.activeTooth = null;
    }
    public void NextPatient()
    {
        //add score
        patientCount++;
        score += 10;
        timeLeft += 5;
        //anims 
        //spawn new
        //patient.transform.position out of screen and move in
        patient.GetComponentInChildren<MouthManager>().Start();


    }

}
