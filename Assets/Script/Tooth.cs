using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooth : MonoBehaviour
{
    private int _health = 5;
    public int health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (value <= 0)
                Destroy(gameObject);
        }
    }

    public bool canBeSmashed;





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ToothDetector"))
        {
            //set tooth as active interaction
            canBeSmashed = true;

            //show buttonprompt
            //set nextbutton
            GameManager.instance.SetNewButtonPrompt();
            GameManager.instance.tool.activeTooth = this;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ToothDetector"))
        {
            //!set tooth as active interaction
            canBeSmashed = false;
            GameManager.instance.RemoveButtonPrompt();
            GameManager.instance.tool.activeTooth = null;
        }
    }
    private void OnDestroy()
    {
        GameManager.instance.RemoveButtonPrompt();
        transform.parent.TryGetComponent<MouthManager>(out MouthManager mouth);
        mouth.RemoveTooth(this);
    }
}
