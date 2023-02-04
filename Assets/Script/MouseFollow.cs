using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] public float moveSens = 5;
    [SerializeField] SpriteRenderer hands;

    [SerializeField]bool preciscionMove;

    [SerializeField]float swayScale = 1;
    float ogSwayScale;

    private void Start()
    {
        ogSwayScale = swayScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyUp(KeyCode.Space))
            TogglePreciscionMove();

        if ((Input.mousePosition).x > Screen.width / 2)
        {
            hands.flipX = true;
        }
        else
            hands.flipX = false;

        //sway
        transform.position += (Vector3)Random.insideUnitCircle.normalized*Time.deltaTime*swayScale;
        
        transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSens * Time.deltaTime); //Vector3.Lerp(transform.position,transform.position+move,swaySpeed*Time.deltaTime);


    }
    public void TogglePreciscionMove()
    {
        if (swayScale == 1)
        {
            swayScale = ogSwayScale;
            moveSens *= 10;
        }
        else
        {
            swayScale = 1;
            moveSens /= 10;
        }
    }
}
