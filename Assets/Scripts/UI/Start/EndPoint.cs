using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{

    private Quanly ingameUI;

    private void Start()
    {
        ingameUI = GameObject.Find("ManagerALL").GetComponent<Quanly>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            GetComponent<Animator>().SetTrigger("activated");

            AudioManager.instance.PlaySFX(3);
            ingameUI.OnLevelFinished();

            GameManager.instance.SaveCollectedFruits();
            GameManager.instance.SaveLevelInfo();
            //GameManager.instance.SaveBestTime();

        }
    }

}

