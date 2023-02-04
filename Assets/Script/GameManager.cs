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
    public SoundPlayer soundPlayer;

    public GameObject gameOverCanvas;
    public GameObject pauseMenuCanvas;

    private int time = 90;
    public int patientCount;

    public bool paused;

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
    private float _timeLeft = 90;
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
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        if (!paused)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                GameOver();
            }
        }
    }
    public void GameOver()
    {
       // tool.GetComponent<MouseFollow>().moveSens = 0;
        //tool.GetComponentInChildren<MouseFollow>().moveSens = 0;
        foreach (var comp in tool.GetComponentsInChildren<MouseFollow>())
        {
            comp.moveSens = 0;
        }
        tool.enabled = false;

        gameOverCanvas.SetActive(true);
        pauseMenuCanvas.SetActive(false);
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
        buttonPrompt.SetActive(false); //anim here

        inputText.text = null;
        tool.activeTooth = null;
    }
    public void NextPatient()
    {
        //add score
        patientCount++;
        score += 10;
        timeLeft = time-5;
        time -= 5;
        //anims 
        //spawn new
        //patient.transform.position out of screen and move in
        patient.GetComponentInChildren<MouthManager>().Invoke("Start",1f);
        mouthManager.patientAnim.SetTrigger("Exit");

    }

}
