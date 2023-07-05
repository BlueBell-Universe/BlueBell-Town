using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    public float speed;
    private Joystick joystick;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        animator = GetComponent<Animator>();

        joystick = GameObject.FindObjectOfType<Joystick>();
    }
    void FixedUpdate()
    {
        if (joystick.Horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //animator.SetBool("isRun", true);
            MoveControl();
        }
        else if (joystick.Horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
           // animator.SetBool("isRun", true);
            MoveControl();
        }
        else  animator.SetBool("isRun", false);
    }

    private void MoveControl()
    {
        animator.SetBool("isRun", true);

        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;
        transform.position += rightMovement;
    }
}