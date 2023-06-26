using UnityEngine;

public enum FruitType
{
    coins,
}
public class Coin_Item : MonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected SpriteRenderer sr;
    public FruitType myFruitType;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
           
            PlayerManager.instance.coins++;
            AudioManager.instance.PlaySFX(9);
            Destroy(gameObject);
         

        }
    }

    public void FruitSteup(int coinIndex)
    {

        for (int i = 1; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0);
        }
        anim.SetLayerWeight(coinIndex, 1);
    }
}