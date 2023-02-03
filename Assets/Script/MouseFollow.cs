using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] float moveSens = 5;
    [SerializeField] SpriteRenderer hands;
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSens*Time.deltaTime);
        if (Camera.main.WorldToScreenPoint(transform.position).x > Screen.width / 2)
        {
            hands.flipX = true;
        }
        else
            hands.flipX = false;
    }
}
