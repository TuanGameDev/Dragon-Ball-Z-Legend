
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] Slider healthBar;
    [SerializeField] Text healthTetx;
    float curHealth;

    public InGame_UI gameWin;
    void Start()
    {
        healthBar.value = maxHealth;
        curHealth = healthBar.value;

    }

    // Update is called once per frame
    void Update()
    {
        healthTetx.text = curHealth.ToString() + "%";
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            healthBar.value -= 1f;
            curHealth = healthBar.value;
        }
        Destroy(collision.gameObject);
        maxHealth--;
        healthBar.value = maxHealth;
        if (maxHealth > 0)

        {
            maxHealth -= 1;
        }
        if (maxHealth < 0)
        {
            maxHealth = 0;
        }

        if (maxHealth <= 0)
        {
            gameWin.GamePlayWin();
            Die();
  
        }
        healthBar.value = maxHealth;
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
