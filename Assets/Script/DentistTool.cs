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
                        GameManager.instance.mouthManager.toothParticles.transform.position = transform.position;
                        GameManager.instance.mouthManager.toothParticles.GetComponent<ParticleSystem>().Play();
                        GameManager.instance.SetNewButtonPrompt();
                        activeTooth.health--;
                    }
                }
            }
            else
            {
                //death
            }

        }
    }
}