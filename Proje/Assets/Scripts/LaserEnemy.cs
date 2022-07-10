﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{

    RaycastHit hit;
    public LayerMask obstacle,player_layer;
    public float laser_multipler = 1;
    public GameObject death_effect;

    private bool laser_hit=false;
    public float range = 100f;
    private void Update()
    {
        //linerenderer
        if(Physics.Raycast(transform.position,transform.forward,out hit, range, obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            laser_hit = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);
            GetComponent<LineRenderer>().startWidth = 0.022f*laser_multipler+Mathf.Sin(Time.time)/80;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            laser_hit = false;
        }

        //killplayer
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, player_layer))
        {

            if (laser_hit)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    hit.transform.gameObject.GetComponent<PlayerMenager>().Death();
                }
            }
        }
    }
}
