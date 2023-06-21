using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    
    private NavMeshAgent navMeshAgent;
    private GameObject player;

    public int hp;
    public float attackDis;

    public int damage;

    public bool inR2;
    public bool inR3;

    
    public GameObject door1;
    public GameObject door2;

    public GameObject shield;
    public GameObject objToBrk;

    

    public bool didSpawn = false;

    // Start is called before the first frame update
    void Start()
    {   
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("player");

        door1 = GameObject.FindGameObjectWithTag("door1");
        door2 = GameObject.FindGameObjectWithTag("door2");

        //make objToBrk and sheild false
        objToBrk.SetActive(false);
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("collectable").Length == 0)
        {
            door1.SetActive(false);
            
            
        }

        //if ((player.GetComponent<player>().inR2 && inR2) || (player.GetComponent<player>().inR3 && inR3))
        //{
            

        //}
        Check();
        whichFase();

        

    }

    // the function that make this object follow "player" by moving 
    public void Chase()
    {

        navMeshAgent.SetDestination(player.transform.position);
        
    }

    public void Check()
    {
        

        float distance = Vector3.Distance(transform.position, player.transform.position);

        

        if (distance <= attackDis)
        {
            
            
            player.GetComponent<player>().hp -= damage;

            if (player.GetComponent<player>().hp <= 0)
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);

            }
        }
        else
        {
            Chase();
            
        }



    }

    

    // if this object is in the object with "r2" then set inR2 to true
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "r2")
        {
            inR2 = true;
            inR3 = false;
        }

        if (other.gameObject.tag == "r3")
        {
            inR3 = true;
            inR2 = false;



        }
    }

    public void whichFase()
    {
        if((inR3 && hp <= 250 && hp > 150))
        {
            //fase1 = true;
            //fase2 = false;
            //fase3 = false;
            //fase4 = false;
            //fase5 = false;

            objToBrk.SetActive(false);
            shield.SetActive(false);

        }
        if ((inR3 && (hp == 150 || hp == 50) && !didSpawn))
        {
            //fase1 = false;
            //fase2 = true;
            //fase3 = false;
            //fase4 = false;
            //fase5 = false;

            didSpawn = true;

            shield.SetActive(true);
            objToBrk.SetActive(true);

        }
        if(inR3 && hp <= 140 && hp !=50)
        {
            didSpawn = false;
            objToBrk.SetActive(false);
            shield.SetActive(false);

        }
    }

}
