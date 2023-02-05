using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    public static MusicHandler instance;

    [SerializeField] PostProcessCode ppcode;

    [SerializeField] AudioSource breathsource;

    bool toggledlowpass;

    float ogcamsize;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ogcamsize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleLowpass();
            ppcode.ToggleVinginette();
            StopAllCoroutines();
            StartCoroutine(CamLerp(ogcamsize, ogcamsize - 2, .25f));
            breathsource.volume = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ToggleLowpass();
            ppcode.ToggleVinginette();
            StopAllCoroutines();
            StartCoroutine(CamLerp(ogcamsize-2, ogcamsize, .25f));
            breathsource.volume = 0;
        }
    }
    public void ToggleLowpass()
    {
        if (toggledlowpass)
        {
            mixer.SetFloat("Lowpass", 22000);
            toggledlowpass = false;
        }
        else
        {
            mixer.SetFloat("Lowpass", 2000);
            toggledlowpass = true;
        }

        //todo also toggle vinginette
    }
    IEnumerator CamLerp(float startVal, float endVal, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            Camera.main.orthographicSize = Mathf.Lerp(startVal, endVal, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        Camera.main.orthographicSize = endVal;
    }
}
