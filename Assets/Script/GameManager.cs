using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private const string hitRightBtn = "HitRight";
    private const string hitLeftBtn = "HitLeft";
    private const string hitUpBtn = "HitUp";
    private const string hitDownBtn = "HitDown";

    public GameObject patient;
    public GameObject buttonPrompt;
    public TextMeshProUGUI inputText,scoreText,timeText;
    public DentistTool tool;
    public MouthManager mouthManager;
    public SoundPlayer soundPlayer;

    public GameObject gameOverCanvas;
    public GameObject pauseMenuCanvas;


    [HideInInspector] public List<GameObject> blood =  new List<GameObject>();

    private int time = 90;
    public int patientCount;

    public bool paused;

    char newButton = 'A';

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
        RemoveButtonPrompt();
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
            if (Input.GetKeyDown(KeyCode.Space) && tool.activeTooth)
                inputText.text = "[" + newButton.ToString() + "]";
            else if (Input.GetKeyDown(KeyCode.Space))
                inputText.text = null;
            if (Input.GetKeyUp(KeyCode.Space)&!tool.activeTooth)
                inputText.text = "[SPACE]";

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
        //if (!buttonPrompt.activeSelf)
          //  buttonPrompt.SetActive(true);
        //add anim here
        if(Input.GetKey(KeyCode.Space))
        {
            switch (Random.Range(0,4))
            {
                case 0:
                    newButton = 'A';
                    tool.nextInputButton = hitLeftBtn;
                    break;
                case 1:
                    newButton = 'S';
                    tool.nextInputButton = hitDownBtn;
                    break;
                case 2:
                    newButton = 'D';
                    tool.nextInputButton = hitRightBtn;
                    break;
                case 3:
                    newButton = 'W';
                    tool.nextInputButton = hitUpBtn;
                    break;
            }
           
            inputText.text = "["+newButton.ToString()+"]";

        }



    }
    public void RemoveButtonPrompt()
    {
        //buttonPrompt.SetActive(false); //anim here
        if (!Input.GetKey(KeyCode.Space))
            inputText.text = "[SPACE]";
        else
            inputText.text = "";
        tool.activeTooth = null;
    }
    public void NextPatient()
    {
        //add score
        patientCount++;
        score += 10;
        timeLeft = time-5;
        time -= 5;
        //clear blood
        int i = blood.Count;
        for (int j = 0;  j < i;  j++)
        {
            var bloodParticle = blood[j];
            blood.Remove(blood[j]);
            Destroy(bloodParticle.gameObject);
        }

        //anims 
        //patient.transform.position out of screen and move in
        patient.GetComponentInChildren<MouthManager>().Invoke("Start",1f);
        mouthManager.patientAnim.SetTrigger("Exit");

    }

}
