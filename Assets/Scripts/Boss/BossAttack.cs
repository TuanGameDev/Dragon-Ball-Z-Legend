using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int attackDamage = 5;
    public int enragedAttackDamage = 5;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    Animator anim;

    //[SerializeField] GameObject ButtletPrefabs;
    public GameObject bullet;
    public Transform bulletPos;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
     void Update()
    {

    }
    public void RandomSkill()
    {
        int n = Random.Range(1,100);
        {
            if (n > 100) Attack(); else Skill();
            Debug.Log("skill and attack");
        }      
    }
    public void Attack()
    {
        AudioManager.instance.PlaySFX(2);
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }
    public void Skill()
    {
        AudioManager.instance.PlaySFX(15);
        anim.SetTrigger("Gun");
        //if(bullet != null)
        // bullet = Instantiate(bullet);

        //move skill: when skill actived get 2 points, boss and hero, 
        Instantiate(bullet, bulletPos.position, Quaternion.identity);


    }

    public void EnragedAttack()
    {
        AudioManager.instance.PlaySFX(2);
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Player>().TakeDamage(enragedAttackDamage);
        }
    }

   private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Gizmos.DrawWireSphere(pos, attackRange);
       
    }
}