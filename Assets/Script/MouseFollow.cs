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

    float ogMoveSens;

    private void Start()
    {
        ogSwayScale = swayScale;
        ogMoveSens = moveSens;
    }

    void Update()
    {
        if (!GameManager.instance.paused)
        {
            if (Input.GetKey(KeyCode.Space))
                EnablePreciscionMove(true);
            else
                EnablePreciscionMove(false);

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

    }
    public void EnablePreciscionMove(bool enable)
    {
        if (!enable)
        {
            swayScale = ogSwayScale;
            moveSens = ogMoveSens;
        }
        else
        {
            swayScale = 1;
            moveSens = ogMoveSens /10;
        }
    }
}
