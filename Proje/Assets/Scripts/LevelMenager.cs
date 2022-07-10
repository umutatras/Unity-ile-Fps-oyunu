using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenager : MonoBehaviour
{
    public bool player_enter, player_exit;
    


    private bool spawned = false;
    public Transform[] drone_spawners;
    public GameObject drone;

    public GameObject level;
    public GameObject destroy_level;
    
    private void Start()
    {
        player_enter = false;
        player_exit = false;
        spawned = false;
     
       
    }
    private void Update()
    {
        if(!spawned)
        {
            if(player_enter)
            {
                for (int i = 0; i < drone_spawners.Length; i++)
                {
                    Instantiate(drone, drone_spawners[i].position, Quaternion.identity);
                }
                Spawnlevel();
                spawned = true;
            }
        }
        if(player_exit)
        {
            if (destroy_level != null)
            {
                DestroyLeve();
            }
        }

    }
    private void Spawnlevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 99);        
        GameObject obj=Instantiate(level, pos, Quaternion.identity);
        obj.GetComponent<LevelMenager>().destroy_level = this.gameObject;
        
    }
    private void DestroyLeve()
    {
        Destroy(destroy_level);
    }
}
