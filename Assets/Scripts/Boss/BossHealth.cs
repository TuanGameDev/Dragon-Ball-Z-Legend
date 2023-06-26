using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] Slider healthBar;
    [SerializeField] Text healthTetx;
    float curHealth;

    public bool isInvulnerable = false;
    public InGame_UI gameWin;
    private bool isDead;

    //marutials
    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;
    //kb cac bien de khi enemy chet roi ra vien mau
    public bool drop;
    public GameObject theDrop;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = maxHealth;
        curHealth = healthBar.value;
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;

    }

    // Update is called once per frame
    void Update()
    {
        healthTetx.text = curHealth.ToString() + "%";
    }
    public void TakeDamage(int damage )
    {
        healthBar.value -= 5f;
        curHealth = healthBar.value;
        sr.material = matWhite;
        if (isInvulnerable)
        return;
        curHealth -= damage;
        if (curHealth <= 300)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
            AudioManager.instance.PlaySFX(18);

        }
        curHealth--;
        healthBar.value = curHealth;
        if (curHealth <= 0 && !isDead)
        {
            isDead = true;
            KillSelf();
            gameWin.GamePlayWin();
        }
        else
        {
            Invoke("ResetMaterial", .1f);
        }


        healthBar.value = curHealth;
    }
    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    private void KillSelf()
    {
        Destroy(gameObject);
        if(drop)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            healthBar.value -= 99;
            curHealth = healthBar.value;
        }
        //Destroy(collision.gameObject);
        curHealth--;
        sr.material = matWhite;
        if (isInvulnerable)
            return;
        if (curHealth <= 300)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
            AudioManager.instance.PlaySFX(18);

        }
        curHealth--;
        healthBar.value = curHealth;
        if (curHealth > 0)

        {
            curHealth -= 99;
        }
        if (curHealth < 0)
        {
            curHealth = 0;
        }

        if (curHealth <= 0 && !isDead)
        {
            isDead = true;
            KillSelf();
            gameWin.GamePlayWin();
        }
        else
        {
            Invoke("ResetMaterial", .1f);
        }
        healthBar.value = curHealth;
    }
}
   
    
