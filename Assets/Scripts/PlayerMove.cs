using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    const float m_default_moveSpeed = 5;

    Rigidbody2D rigidbody2D;

    [SerializeField]
    float speed;

    #region MonoBehaviour
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        speed = m_default_moveSpeed;
    }

    #endregion

    #region Programmer Defined

    public void move()
    {
        rigidbody2D.AddForce(new Vector2(speed * Time.deltaTime, 0.0f));
    }

    public void jump()
    {

    }

    public void skill()
    {

    }

    #endregion
}
