
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Contiene los ataques y controles del personaje 2
/// </summary>
public class Warrior2 : WarriorsController
{
    public int Player = 0;
    public int Player1 = 0;
    public int Player2 = 0;

    //Vida del jugador
    public int maxHp;
    public int currentHp;
    public HealthBarScript healthBar;


    //Take dmg
    private int cont = 0;
    private float lastWin = 0;

    //Points
    public int wins = 0;
    private bool Dead = false;


    //InputSystem  
    private bool attacking = false, superAttack = false;

    //Ultimate
    private float ultimateCooldown = 20;
    private float lastUltimate = 0;
    private bool ultimateReady = true;

    //Items
    private float lastTimeShield = 0;
    private bool IsInvencible = false;


    void Start()
    {
        EndGame.End = false;


        rPlayer = gameObject.GetComponent<Rigidbody2D>();
        aPlayer = gameObject.GetComponent<Animator>();

        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        attacking = context.action.triggered;
    }

    public void OnSuperAttack(InputAction.CallbackContext context)
    {
        superAttack = context.action.triggered;
    }


    void Update()
    {
        //Attacks
        if (attacking && !isStunned)
        {

            ++cont;

            if (cont > 25 && cont < 50)
            {
                aPlayer.SetInteger("AttackNumber", 2);
            }
            else if (cont >= 50)
            {
                aPlayer.SetInteger("AttackNumber", 3);
            }
            else
            {
                aPlayer.SetInteger("AttackNumber", 1);
            }
        }

        if (!attacking)
        {
            aPlayer.SetInteger("AttackNumber", 0);
            cont = 0;
        }

        if (superAttack && !isStunned && ultimateReady)
        {
            ultimateReady = false;
            superAttack = true;
            aPlayer.SetBool("superAttack", superAttack);
            lastUltimate = Time.time;
        }


        if (!superAttack)
        {
            superAttack = false;
            aPlayer.SetBool("superAttack", superAttack);
        }

        IsDead();

        if (Dead)
        {
            StartCoroutine(ResetTime());
        }


        if (Player == 1)
        {
            EndGame.P2Score = wins;
        }
        else
        {
            EndGame.P1Score = wins;
        }

        if (wins == 2)
        {
            EndGame.Winner = Player == 1 ? Player2 : Player1;
            EndGame.PlayerId = Player == 1 ? 2 : 1;
            EndGame.End = true;
            wins = 0;
        }

        //Ultimate Cooldown
        if (Time.time - lastUltimate > ultimateCooldown)
        {
            ultimateReady = true;
        }

        if (Time.time - lastTimeShield > 5)
        {
            IsInvencible = false;
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

    #region Colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Cartel"))
        {
            TakeDamage(10);
        }

        #region WARRIOR_1
        if (collision.gameObject.tag.Contains("Arrow"))
        {
            TakeDamage(20);
        }
        #endregion

        #region WARRIOR_3
        if (collision.gameObject.tag.Contains("Attack3_W3"))
        {
            TakeDamage(50);
        }
        if (collision.gameObject.tag.Contains("SuperAttack_W3"))
        {
            TakeDamage(100);
        }
        #endregion    

        #region WARRIOR_4
        if (collision.gameObject.tag.Contains("FireBall"))
        {
            TakeDamage(30);
        }

        #endregion


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        #region WARRIOR_1
        if (collision.gameObject.tag.Contains("Attack1_W1"))
        {
            TakeDamage(30);
        }

        if (collision.gameObject.tag.Contains("Attack2_W1"))
        {
            TakeDamage(35);
        }
        #endregion

        #region WARRIOR_3
        if (collision.gameObject.tag.Contains("Attack1_W3"))
        {
            TakeDamage(35);
        }

        if (collision.gameObject.tag.Contains("Attack2_W3"))
        {
            TakeDamage(45);
        }
        if (collision.gameObject.tag.Contains("Attack3_W3"))
        {
            TakeDamage(50);
        }
        if (collision.gameObject.tag.Contains("Stone"))
        {
            TakeDamage(100);
        }
        #endregion

        #region WARRIOR_4
        if (collision.gameObject.tag.Contains("Attack1_W4"))
        {
            TakeDamage(30);
        }
        if (collision.gameObject.tag.Contains("Attack2_W4"))
        {
            TakeDamage(40);
        }
        #endregion

        #region Items
        if (collision.tag.Equals("Item1"))
        {
            Destroy(collision.gameObject);
            HealHp(100);
        }
        if (collision.tag.Equals("Item2"))
        {
            Destroy(collision.gameObject);
            lastTimeShield = Time.time;
            IsInvencible = true;
        }
        if (collision.tag.Equals("Item3"))
        {
            Destroy(collision.gameObject);
            int a = Random.Range(0, 100);
            if(a < 50)
            {
                TakeDamage(200);
            }
            else if(a >= 50 && a < 85)
            {
                HealHp(100);

            }
            else if(a >= 85)
            {

                SetHp(1);
                StartCoroutine(Alife());
            }
        }
        if (collision.tag.Equals("Item4"))
        {
            Destroy(collision.gameObject);

        }
        #endregion
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        #region WARRIOR_4
        if (collision.gameObject.tag.Contains("Fire"))
        {
            TakeDamage(4);
        }

        #endregion

        if (collision.gameObject.tag.Equals("SuperAttack_W3"))
        {
            isStunned = true;
            lastTimeStuned = Time.time;
        }
    }
    #endregion

    #region Sistemas de los ataques

    void IsDead()
    {
        if (currentHp <= 0)
        {
            aPlayer.SetBool("isDead", true);
            if (Time.time - lastWin > 5)
            {
                healthBar.SetWin();
                wins++;
                lastWin = Time.time;
                Dead = true;
            }
        }
        else
        {
            aPlayer.SetBool("isDead", false);
            Dead = false;
        }
    }

    private IEnumerator ResetTime()
    {
        yield return new WaitForSecondsRealtime(2f);
        Reset();
    }
    private void Reset()
    {
        healthBar.SetHealth(500);
        currentHp = 500;
        gameObject.GetComponent<Transform>().position = new Vector3(Player == 1 ? -70 : 70, 200, 0);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;

    }

    void SetActive()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void ResetHitValue()
    {

        aPlayer.SetBool("takeHit", false);

    }

    private void TakeDamage(int dmg)
    {
        if (!IsInvencible)
        {
            dmg = IsBlocking(dmg);
        }
        else
        {
            dmg = 0;
        }
        currentHp -= dmg;
        healthBar.SetHealth(currentHp);
        aPlayer.SetBool("takeHit", true);
        StartCoroutine(CanTakeDmg());
    }

    private void HealHp(int hp)
    {
        currentHp += hp;
        if(currentHp > 500)
        {
            currentHp = 500;
        }
        healthBar.SetHealth(currentHp);
    }

    private void SetHp(int hp)
    {
        currentHp = hp;

        healthBar.SetHealth(currentHp);
    }

    private IEnumerator Alife()
    {
        yield return new WaitForSecondsRealtime(5f);
        SetHp(500);
    }
    private void Destroy(GameObject go)
    {
        GameObject.Destroy(go);
    }
    private IEnumerator CanTakeDmg()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        ResetHitValue();
    }

    private int IsBlocking(int dmg)
    {


        if (!WarriorsController.IsWeak)
        {
            dmg /= 4;

            return dmg;
        }
        else
        {
            return dmg;
        }



    }

    #endregion
}
