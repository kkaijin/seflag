using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput; 

    public float health = 1f;

    public HealthBar HealthBar;

    float moveSpeed = 10f;
    float jumpSpeed = 10f;

    public GameObject winImg;
    public GameObject loseImg;

   

    public int flay = 0;


    private CharacterController controller;

    public GameObject hpBar;
    private Vector3 moveDirection;

    bool flag = false;

    private Animator animator;


    public Transform childObject; // объект, которому нужно установить родителя
    public Transform parentObject; // объект, который будет родительским
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        HealthBar.SetMaxHealth(health);
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {

        if(controller.isGrounded) {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            moveDirection = transform.forward * verticalInput + transform.right *horizontalInput;

            if(Input.GetKeyDown(KeyCode.Space)){
                moveDirection.y += jumpSpeed;
            }

        }else {
            moveDirection.y -= 9.81f * Time.deltaTime;
        }
        
        


        //animations
        if(horizontalInput == 0 && verticalInput == 0)
        {
            print("lo");
            //idle
            animator.SetFloat("Speed", 0);
        }
        else if(!Input.GetKey(KeyCode.LeftShift))
        {
            
            animator.SetFloat("Speed", 0.5f);
            moveSpeed = 10f;
        }
        else
        {
            print("ss");
            moveSpeed = 20f;
            animator.SetFloat("Speed", 1f);
        }
        controller.Move(moveDirection * moveSpeed *Time.deltaTime);
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "flag")
        {
           // winImg.SetActive(true);
            flay++;
            //hpBar.SetActive(false);
            childObject.SetParent(parentObject); // установка родителя
            flag = true;
            GameObject.FindGameObjectWithTag("flag").GetComponent<Animator>().enabled = false;
        }

        if (hit.gameObject.tag == "enemy")
        {
            health = health - Time.deltaTime * 2;
            print(health);
            HealthBar.SetHealth(health);
            
            
            if (health <= 0) 
            {
                loseImg.SetActive(true);
                flay++;
                hpBar.SetActive(false);
            }
        }

        if (hit.gameObject.tag == "plane")
        {
            childObject.SetParent(null); // установка родителя в null
            if(flag==true)
            {
                winImg.SetActive(true);
                hpBar.SetActive(false);
            }
            
        }
    }
}
