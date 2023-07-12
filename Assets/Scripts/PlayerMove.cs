using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private float jumpForce;

    private Animator animator;
    private Joystick joystick;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    private bool isJumping;
    public float speed;
    public GameObject FireObject;


    public PlayerHP playerHPScript;
    public PlayerMana playerManaScript;

    void Awake()
    {
        playerHPScript = GetComponent<PlayerHP>();
        playerManaScript = GetComponent<PlayerMana>();
        jumpForce = 3.0f;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        joystick = GameObject.FindObjectOfType<Joystick>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            playerHPScript.OnDamaged(5);
        }
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

        if(rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, Vector3.down, 0.5f);

            if(rayhit.collider.CompareTag("Ground"))
            {
                isJumping = true;
                animator.SetBool("isJump", true);
            }
        }
        else if(rigid.velocity.y == 0)
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
    
    public void Skill1()
    {
        Vector3 targetPos;
        if (this.transform.eulerAngles.y > 0)
        {
            targetPos = new Vector3(transform.position.x - 1.0f,transform.position.y + 1.0f, -1.0f);
        }
        else
        {
            targetPos = new Vector3( transform.position.x + 1.0f,  transform.position.y + 1.0f, -1.0f);

        }

        Instantiate(FireObject, targetPos, Quaternion.identity);
        if (playerManaScript.currentMana >= 5)
        {
            playerManaScript.UseMana(5);
        }
        else return;
        animator.SetTrigger("attack");
    }
}