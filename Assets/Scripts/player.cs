using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //bool enemySpawn = false;
    //bool isDone = false;
    float speed = 20f;
    //GameObject[] enemies;
    public int hp = 150;

    public GameObject bulletPrefab;
    public GameObject rifle;

    public bool inR2;
    public bool inR3;

    bool canFire = false;



    // Start is called before the first frame update
    void Start()
    {

        transform.position = GameObject.FindGameObjectWithTag("manager").transform.position;
        GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = transform.rotation;

        rifle.SetActive(false);

        //enemies = GameObject.FindGameObjectsWithTag("enemy");



    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);


        transform.Rotate(0f, Input.GetAxis("Mouse X") * 5f, 0f);

        


        if (Input.GetMouseButtonDown(0) && canFire)
        {
            Fire();
        }

    }


    

    

    public void Fire()
    {

        Vector3 offset = transform.forward * 1.2f + transform.up * 0.4f + transform.right * 0.5f;


        Vector3 bulletPos = transform.position + offset;

        GameObject bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);


        Vector3 playerRotation = transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(90f, playerRotation.y, playerRotation.z);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {

            rb.AddForce(transform.forward * 1000f);
        }

    }

    
    private void OnTriggerEnter(Collider other)
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
        if (other.gameObject.tag == "gun")
        {
            rifle.SetActive(true);
            canFire = true;
            Destroy(other.gameObject);
        }


    }



}
