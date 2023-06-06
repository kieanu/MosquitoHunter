using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)

    {

       if (other.gameObject.tag == "Enemy")

        {
            Enemy.EnemyNum -= 1;
            Destroy(other.gameObject);

        }

    }
}
