using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public InGame_UI gameWin;
    private bool isDead;

    [Header("Coins")]
    public int coins;

    [Header("Attack")]
    [SerializeField] private Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange;
    public int attackDamage;
    public bool isAttack = false;
    public float attackRate;
    float nextAttackTime = 0f;

    [Header("Controlls info")]
    public FixedJoystick joystick;

    [Header("Skill1")]
    [SerializeField] private Transform gunTip;
    [SerializeField] private GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 1f;

   /* [Header("Skill2Kame")]
    [SerializeField] private Transform gunTip1;
    [SerializeField] private GameObject bullet1;*/
    [Header("Picolo")]
    [SerializeField] private Transform gunTipPicolo;
    [SerializeField] private GameObject SkillKamePicolo;

    [Header("GohanMistic")]
    [SerializeField] private Transform gunTipGohan;
    [SerializeField] private GameObject SkillKameGohan;

    [Header("Vegeta")]
    [SerializeField] private Transform gunTipVegeta;
    [SerializeField] private GameObject SkillKameVegeta;

    [Header("Trunks")]
    [SerializeField] private Transform gunTipTrunk;
    [SerializeField] private GameObject SkillKameTrunk;

    [Header("Vegito Blue")]
    [SerializeField] private Transform gunTipVegito;
    [SerializeField] private GameObject SkillKameVegito;

    [Header("Gogeta")]
    [SerializeField] private Transform gunTipGogeta;
    [SerializeField] private GameObject SkillKameGogeta;

    [Header("Vegeta Blue")]
    [SerializeField] private Transform gunTipVegetaBlue;
    [SerializeField] private GameObject SkillKameVegetaBlue;

    [Header("Goku Blue")]
    [SerializeField] private Transform gunTipGokuBlue;
    [SerializeField] private GameObject SkillKameGokuBlue;

    [Header("Goku Vocuc sion 1")]
    [SerializeField] private Transform gunTipVocuc1;
    [SerializeField] private GameObject SkillKameVocuc1;

    [Header("Goku Vocuc sion 2")]
    [SerializeField] private Transform gunTipVocuc2;
    [SerializeField] private GameObject SkillKameVocuc2;

    public Rigidbody2D rb;
    public Animator anim;
    public float moveSpeed;
    private Vector2 movement;
    bool isRight = true;
    // Start is called before the first frame update
   void Start()
   {
       
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SetAnimationLayer();

   }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.difficulty > 1)
        {
            PlayerManager.instance.coins--;
            if (PlayerManager.instance.coins < 0)
            {
                Destroy(gameObject);
            }
        }
        GetInput();

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        currentHealth--;
        if (currentHealth > 0)
        {
            currentHealth -= 0;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Die();
            gameWin.GamePlayLose();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    private void GetInput()
    {
        movement.x = joystick.Horizontal;
        anim.SetFloat("speed", movement.sqrMagnitude);
        movement.y = joystick.Vertical;

        {
            transform.Translate(Vector3.right * Time.deltaTime * movement.x * moveSpeed); //Move follow x
            transform.Translate(Vector3.up * Time.deltaTime * movement.y * moveSpeed);

        }
        if (movement.x != 0 || movement.y != 0)
            if (movement.x > 0 && isRight == false)
            {
                Flip();
            }
        if (movement.x < 0 && isRight == true)
        {
            Flip();
        }

        void Flip()
        {
            isRight = !isRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }

        //rotation
        float hAxis = movement.x;
        float vAxis = movement.y;

        //movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        //anim.SetFloat("Horizontal", movement.x);
        // anim.SetFloat("Vertical", movement.y);
    }
    private void FixedUpdate()
    {
     
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    } 
    
    public void Skill1()
    {
        AudioManager.instance.PlaySFX(15);
        anim.SetTrigger("Gun");
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }

    public void ActiveSkill()
    {
        //AudioManager.instance.PlaySFX(15);
        int hero = PlayerManager.instance.GetHeroName();
        switch(hero)
        {
            case 0:
                AudioManager.instance.PlaySFX(16);
                anim.GetLayerIndex("Base Layer");
                anim.SetTrigger("Kame");
                break;
            case 1:
                AudioManager.instance.PlaySFX(17);
                anim.GetLayerIndex("Picolo Layer");
                anim.SetTrigger("Kame");
                break;
            case 2:
                AudioManager.instance.PlaySFX(17);
                anim.GetLayerIndex("Gohan Layer");
                anim.SetTrigger("Kame");
                break;
            case 3:
                AudioManager.instance.PlaySFX(17);
                anim.GetLayerIndex("Vegeta Layer");
                anim.SetTrigger("Kame");
                break;
            case 4:
                AudioManager.instance.PlaySFX(17);
                anim.GetLayerIndex("Trunks Layer");
                anim.SetTrigger("Kame");
                break;
            case 5:
                AudioManager.instance.PlaySFX(17);
                anim.GetLayerIndex("Vegito_Blue Layer");
                anim.SetTrigger("Kame");
                break;
            case 6:
                AudioManager.instance.PlaySFX(17);
                anim.GetLayerIndex("Gogeta Layer");
                anim.SetTrigger("Kame");
                break;
            case 7:
                AudioManager.instance.PlaySFX(17);
                anim.GetLayerIndex("Vegta_Blue Layer");
                anim.SetTrigger("Kame");
                break;
            case 8:
                AudioManager.instance.PlaySFX(17);
                anim.GetLayerIndex("Goku_Blue Layer");
                anim.SetTrigger("Kame");
                break;
            case 9:
                AudioManager.instance.PlaySFX(17);
                anim.GetLayerIndex("Goku_Vocuc1 Layer");
                anim.SetTrigger("Kame");
                break;
            case 10:
                AudioManager.instance.PlaySFX(17);
                anim.GetLayerIndex("Goku_Vocuc Layer");
                anim.SetTrigger("Kame");
                break;
        }
    }
    //Skill all Hero
    public void SkillPicolo()
    {
        //AudioManager.instance.PlaySFX(16);

        //anim.ResetTrigger("KamePicolo");

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(SkillKamePicolo, gunTipPicolo.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(SkillKamePicolo, gunTipPicolo.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
    public void SkillGohan()
    {
        //AudioManager.instance.PlaySFX(17);
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(SkillKameGohan, gunTipGohan.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(SkillKameGohan, gunTipGohan.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
       
    }
    public void SkillVegeta()
    {
       // AudioManager.instance.PlaySFX(17);
        //anim.ResetTrigger("KameGohan");
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(SkillKameVegeta, gunTipVegeta.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(SkillKameVegeta, gunTipVegeta.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }

    }
    public void SkillTrunk()
    {
        //AudioManager.instance.PlaySFX(17);
        //anim.ResetTrigger("KameGohan");
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(SkillKameTrunk, gunTipTrunk.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(SkillKameTrunk, gunTipTrunk.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }

    }
    public void SkillVegitoBlue()
    {
       // AudioManager.instance.PlaySFX(17);
        //anim.ResetTrigger("KameGohan");
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(SkillKameVegito, gunTipVegito.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(SkillKameVegito, gunTipVegito.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }

    }
    public void SkillGogeta()
    {
       // AudioManager.instance.PlaySFX(17);
        //anim.ResetTrigger("KameGohan");
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(SkillKameGogeta, gunTipGogeta.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(SkillKameGogeta, gunTipGogeta.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }

    }
    public void SkillVegetaBlue()
    {
       // AudioManager.instance.PlaySFX(16);
        //anim.ResetTrigger("KameGohan");
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(SkillKameVegetaBlue, gunTipVegetaBlue.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(SkillKameVegetaBlue, gunTipVegetaBlue.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }

    }
    public void SkillGokuBlue()
    {
       // AudioManager.instance.PlaySFX(17);
        //anim.ResetTrigger("KameGohan");
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(SkillKameGokuBlue, gunTipGokuBlue.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(SkillKameGokuBlue, gunTipGokuBlue.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }

    }
    public void SkillGokuVocuc1()
    {
        //AudioManager.instance.PlaySFX(17);
        //anim.ResetTrigger("KameGohan");
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(SkillKameVocuc1, gunTipVocuc1.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(SkillKameVocuc1, gunTipVocuc1.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }

    }
    public void SkillGokuVocuc2()
    {
      // AudioManager.instance.PlaySFX(17);
        //anim.ResetTrigger("KameGohan");
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (isRight)
            {
                Instantiate(SkillKameVocuc2, gunTipVocuc2.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!isRight)
            {
                Instantiate(SkillKameVocuc2, gunTipVocuc2.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }

    }
    public void Attack()
    {
        AudioManager.instance.PlaySFX(2);
        if (Time.time >= nextAttackTime)
            anim.SetTrigger("Attack");
        //
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //dame them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BossHealth>().TakeDamage(attackDamage);
        }
    }
    public void Skill3()
    {
        AudioManager.instance.PlaySFX(14);
        anim.SetTrigger("Mana");
       
    }
    private void SetAnimationLayer()
    {
        int hero = PlayerManager.instance.GetHeroName();

        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0);
        }
        anim.SetLayerWeight(hero+1,1);
    }

}


