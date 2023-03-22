using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : MonoBehaviour
{
    [SerializeField] private GameObject effect;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GameManager.Gold += 10;
            Instantiate(effect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}