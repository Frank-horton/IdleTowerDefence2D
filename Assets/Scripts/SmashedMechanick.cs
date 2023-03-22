using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashedMechanick : MonoBehaviour
{
    [SerializeField] private GameObject[] effects;

    private void Update()
    {
        RayCameraHit();
    }

    private void RayCameraHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
               
                if (hit.collider.CompareTag("Enemy"))
                {
                    GameManager.Gold += 10;
                    Handheld.Vibrate();
                    Instantiate(effects[1], hit.point, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                     
                }
                else
                {
                    Instantiate(effects[0], hit.point, Quaternion.identity);
                }
            }
        }
    }
}