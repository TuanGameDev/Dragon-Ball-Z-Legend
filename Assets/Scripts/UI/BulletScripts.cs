using UnityEngine;

public class BulletScripts : MonoBehaviour
{
    private GameObject enemy;
    public float bulletSpeed;
    Rigidbody2D myBody;
    public float timer;
    // Start is called before the first frame update
     void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            myBody.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        else myBody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Boss");
        Vector2 moveDir = (enemy.transform.position - transform.position).normalized * bulletSpeed;
        myBody.velocity = new Vector2(moveDir.x, moveDir.y);
       
    }
}
