using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public GameObject hand;
    public LayerMask obstacleLayer;
    public Vector3 offset;

    RaycastHit hit;

    public GameObject bullet;
    public Transform firePoint;

    private float coolDown;

    public AudioClip gunShot;

    private void Update()
    {
        //look
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer))
        {
            hand.transform.LookAt(hit.point);
            hand.transform.rotation *= Quaternion.Euler(offset);
        }
        //fire
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        //shot
        if (Input.GetMouseButtonDown(0)&& coolDown<=0)
        {
            //create bullet
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
            //reset cooldown
            coolDown = 0.2f;
            //sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunShot);
            //animation
            GetComponent<Animator>().SetTrigger("shot");
        }
    }
}
