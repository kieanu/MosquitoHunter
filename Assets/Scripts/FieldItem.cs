using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.gameObject.tag == "Enemy")

        {

            other.gameObject.transform.position = new Vector3(0, 0, 0);

        }

    }
}
