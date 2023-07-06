using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    public float speed;
    private Joystick joystick;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    private bool isJumping;
    [SerializeField]
    private float jumpForce;

    void Awake()
    {
        jumpForce = 3.0f;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJump", false);
        }
    }
    private void MoveControl()
    {
        animator.SetBool("isRun", true);
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;
        transform.position += rightMovement;
    }

    public void Jump()
    {
        if (!isJumping)
        {
            animator.SetBool("isJump", true);
            rigid.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
        else return;
    }
}