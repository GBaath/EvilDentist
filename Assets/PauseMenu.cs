using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    [SerializeField] GameObject notePad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        GameManager.instance.paused = !GameManager.instance.paused;
        pausemenu.SetActive(!pausemenu.activeSelf);
    }
    public void ToggleNotePad(bool enabled)
    {
        if (enabled)
            notePad.GetComponent<Animator>().SetTrigger("Enter");
        else
            notePad.GetComponent<Animator>().SetTrigger("Exit");
    }
}
