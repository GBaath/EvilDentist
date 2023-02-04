using System.Collections;
using UnityEngine;

public class DentistTool : MonoBehaviour
{
    public string nextInputButton = "HitLeft";
    public Tooth activeTooth;
    [SerializeField] Animator anim;
    [SerializeField] GameObject bloodObject;


    private GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("HitLeft")|| Input.GetButtonDown("HitRight"))
        {
            anim.SetTrigger("Hit");
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
                        GameManager.instance.score++;
                        gm.soundPlayer.PlayAudioDelayed(gm.soundPlayer.tooth,.2f);
                    }
                    else
                    {
                        Blood();
                    }
                }
                else
                {
                    Blood();
                }
            }
            else
            {
                //death instantiate blood
                Blood();
            }

        }
    }
    void Blood()
    {

        //TODO only if on acceptable area
            var blood = Instantiate(bloodObject,transform.position,Quaternion.identity);
            blood.transform.eulerAngles = new Vector3(Random.Range(-180f, 0),90,90);
        gm.score--;
        gm.timeLeft--;
        //gm.soundPlayer.PlayAudioDelayed(gm.soundPlayer.gore,.2f);

    }
}