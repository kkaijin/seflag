using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float damage = 10000f;
    public float range = 100f;

    public ParticleSystem efffect_shoot;

    public Camera fpsCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * 1000f, Color.red);
        if (Input.GetButtonDown("Fire1"))
        {
            if(transform.parent.name == "hand")
            {
                Shoot();
            }
            
        }
    }

    void Shoot()
    {
        efffect_shoot.Play();

        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {


            sphere_enemy sphere_enemy = hit.transform.GetComponent<sphere_enemy>();
            if (sphere_enemy != null)
            {
                sphere_enemy.TakeDamage(damage);
            }
        }
    }
}
