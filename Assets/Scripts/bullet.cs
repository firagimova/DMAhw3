using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class bullet : MonoBehaviour
{
    GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        shield = GameObject.FindGameObjectWithTag("manager").GetComponent<manager>().shield;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "enemy")
        {

            other.gameObject.GetComponent<enemy>().hp -= 10;



            if (other.gameObject.GetComponent<enemy>().hp <= 0 && other.gameObject.GetComponent<enemy>().inR3)
            {
                other.gameObject.GetComponent<enemy>().door2.SetActive(false);
                Destroy(other.gameObject);

            }
            else if(other.gameObject.GetComponent<enemy>().hp <= 0)
            {
                Destroy(other.gameObject);
            }

            Destroy(this.gameObject);

        }
        else if (other.gameObject.tag == "break")
        {
            other.gameObject.GetComponent<ObjectToBreak>().hp -= 10;

            if (other.gameObject.GetComponent<ObjectToBreak>().hp == 0 || other.gameObject.GetComponent<ObjectToBreak>().hp == -50)
            {
                other.gameObject.SetActive(false);
                shield.SetActive(false);
            }

            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }

}
