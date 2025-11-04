using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BuggyPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jForce = 250;
    Rigidbody2D rb;
    Animator anim;
    float moveInput;
    public bool isMoving=false;
    GroundChecker gr;
    public bool jump;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gr = GetComponent<GroundChecker>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;
            moveInput = Input.GetAxis("Horizontal");
        if (moveInput != 0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);


        if (moveInput < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        if (gr.isGrounded && jump) 
        {
            rb.AddForce(Vector2.up * jForce);

        }
        jump = false;
    }

}
//dodano średniki w brakujące miejsce
//Metoda Update w głównej klasie skryptu
//zmienono metode ruchu na tej z uzyciem rigidbody
//poprawiono literowki w zmiennych i nazwach klas/funkcji
//dodano metodę fixed update na fizykę oraz funkcje skoku
//dodano zmiane osi spritu przy zmianie kierunku