
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Contiene los datos generales que tienen en comun los personajes
/// </summary>
public class WarriorsController : MonoBehaviour
{
    public bool isStunned = false;
    public float lastTimeStuned = 0;

    public float velocity, velocityMax, jumpForce;
    private bool newGame = false;
    public bool lookRight = true;

    public bool isAttacking = false;
    public static bool IsWeak = false;



    //Salto
    int numJump = 0;
    public bool colPies = false;



    //Parametros Jugador
    float mass;
    Vector3 pos;

    //Componentes
    public Animator aPlayer;
    public Rigidbody2D rPlayer;

    //InputSystem
    private Vector2 movementInput = Vector2.zero;
    private bool jump = false;
    private bool pause = false;
    public float run = 0;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.action.triggered;
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        pause = context.action.triggered;
    }



   

    void Start()
    {
        rPlayer = gameObject.GetComponent<Rigidbody2D>();
        aPlayer = gameObject.GetComponent<Animator>();

        mass = rPlayer.mass;


        if (newGame)
        {
            newGame = false;
            gameObject.transform.position = new Vector3(-30f, 25f, 0);
        }

    }
    private void Update()
    {
        IsDoingAnAttack();

        GirarPlayer(run);
        pos = gameObject.transform.position;
        aPlayer.SetFloat("velocityX", Mathf.Abs(rPlayer.velocity.x));
        aPlayer.SetFloat("velocityY", rPlayer.velocity.y);
        aPlayer.SetBool("isGround", colPies);

        //Salto
        colPies = CheckGround.colPies;

        if (jump && !isStunned && !isAttacking)
        {
            if (numJump == 1)
            {
                if (jump && colPies)
                {
                    rPlayer.velocity = new Vector2(rPlayer.velocity.x, 0f);
                    rPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    numJump = 0;
                }
            }
            else
            {
                rPlayer.velocity = new Vector2(rPlayer.velocity.x, 0f);
                rPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                ++numJump;
            }
            jump = false;
        }

        if (pause)
        {
            Pause.IsPaused = true;
        }

        if (isStunned)
        {
            if (Time.time - lastTimeStuned > CartelDestroy.cooldownStun)
            {
                isStunned = false;
                lastTimeStuned = Time.time;
            }
        }

    }


    void FixedUpdate()
    {
        if (!isStunned && !isAttacking)
        {
            run = movementInput.x;
            rPlayer.AddForce(Vector2.right * velocity * run);
            //limitar la velocidad que adquiere el player
            float limitVelocity = Mathf.Clamp(rPlayer.velocity.x, -velocityMax, velocityMax);
            rPlayer.velocity = new Vector2(limitVelocity, rPlayer.velocity.y);
        }





        //Reinicar partida
        if (pos.y < -500f)
        {
            newGame = true;
            Start();
        }

    }

    void GirarPlayer(float horizontal)
    {
        if ((horizontal > 0 && !lookRight) || (horizontal < 0 && lookRight))
        {
            lookRight = !lookRight;
            Vector3 escalaGiro = transform.localScale;
            escalaGiro.x *= -1;
            transform.localScale = escalaGiro;


        }
    }

    private void IsDoingAnAttack()
    {
        if (aPlayer.GetCurrentAnimatorStateInfo(0).IsTag("Attack1") == true || aPlayer.GetCurrentAnimatorStateInfo(0).IsTag("Attack2") == true ||
            aPlayer.GetCurrentAnimatorStateInfo(0).IsTag("Attack3") == true || aPlayer.GetCurrentAnimatorStateInfo(0).IsTag("superAttack") == true)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Cartel"))
        {
            isStunned = true;
            lastTimeStuned = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("SuperAttack_W3"))
        {
            isStunned = true;
            lastTimeStuned = Time.time;
        }
    }




}
