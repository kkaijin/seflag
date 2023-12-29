using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject camera;
    public float distance = 5f;
    GameObject currentWeapon;
    bool canPickUp;
    public GameObject text;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();

        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            
            if (hit.transform.tag == "Weapon")
            {
                text.SetActive(true);
            }
            else
            {
                text.SetActive(false);
            }
            
        }
    }

    void PickUp()
    {
        RaycastHit hit;

        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            text.SetActive(true);
            if (hit.transform.tag == "Weapon")
            {
                if (canPickUp) Drop();


                

                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = Vector3.zero;
                currentWeapon.transform.localEulerAngles = new Vector3(-250f, 0f, 0f);
                canPickUp = true;
            }
        }

    }

    void Drop()
    {
        text.SetActive(false);
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        canPickUp = false;
        currentWeapon = null;
    }
}
