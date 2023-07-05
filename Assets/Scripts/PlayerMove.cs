using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Joystick joystick;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        joystick = GameObject.FindObjectOfType<Joystick>();
    }

    void FixedUpdate()
    {
        if(joystick.Horizontal > 0 )
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            MoveControl();
        }
        else if(joystick.Horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

            MoveControl();
        }
    }

    private void MoveControl()
    {
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;
        transform.position += rightMovement;
    }
}
