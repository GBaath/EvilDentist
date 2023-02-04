using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooth : MonoBehaviour
{
    private SpriteRenderer sprite;
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
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z+Random.Range(-30,30));
            if (value <= 0)
            {
                GameManager.instance.RemoveButtonPrompt();
                transform.parent.TryGetComponent<MouthManager>(out MouthManager mouth);
                mouth.RemoveTooth(this);
                _health = Random.Range(2,6);
                gameObject.SetActive(false);
                GameManager.instance.score+=2;
            }
                //Destroy(gameObject);
        }
    }

    public bool canBeSmashed;



    public void Start()
    {
        _health = Random.Range(3, 7);
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(0.9f, 0.9f, 0.9f);
    }

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
            sprite.color = Color.white;
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
            sprite.color = new Color(0.9f, 0.9f, 0.9f);
        }
    }
    private void OnDestroy()
    {
        //GameManager.instance.RemoveButtonPrompt();
        //transform.parent.TryGetComponent<MouthManager>(out MouthManager mouth);
        //mouth.RemoveTooth(this);
    }
}
