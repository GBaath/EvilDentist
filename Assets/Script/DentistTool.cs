using System.Collections;
using UnityEngine;

public class DentistTool : MonoBehaviour
{
    public string nextInputButton = "HitLeft";
    public Tooth activeTooth;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("HitLeft")|| Input.GetButtonDown("HitRight"))
        {
            if (Input.GetButtonDown(nextInputButton))
            {
                //nice
                if (activeTooth)
                {
                    if (activeTooth.canBeSmashed)
                    {
                        activeTooth.health--;
                    }
                    GameManager.instance.SetNewButtonPrompt();
                }
            }
            else
            {
                //death
            }

        }
    }
}