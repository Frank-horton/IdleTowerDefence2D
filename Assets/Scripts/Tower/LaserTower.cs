using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform laserPosition;  

    void Update()
    {
        CreatLaser();
    }

    private void CreatLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        lineRenderer.SetPosition(0, laserPosition.position);      

        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, transform.right * 100);
        }
    }
}