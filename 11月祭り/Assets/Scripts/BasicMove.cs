using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class HandControlCharacter : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    GameObject player;
    private float MoveSpeed;//歩くスピード
    private float horizontal;//AD
    private float vertical;//WS
    private int move_var;
    private Vector3 target_dir = Vector3.zero;
    private int shadowTime;


    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        MoveSpeed = 0;
        move_var = 0;
        shadowTime = 10;
        controller.center = new Vector3(0, 1, 0);
        controller.radius = 0.5f;
        controller.height = 2;

    }

    // Update is called once per frame
    void Update()
    {
        HandControl_Move();
        Submerge();
    }

    public void HandControl_Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0) //ボタン押したら
        {

            if (Input.GetKey(KeyCode.W))
            {
                move_var = 1;
                MoveSpeed = 1.5f;
                transform.rotation = Quaternion.LookRotation(target_dir);
                /*if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
                {
                    move_var = 2;
                    MoveSpeed = 3.5f;
                }
                else*/ if (animator.GetBool("dive") == true)
                {
                    MoveSpeed = 3.5f;
                }
            }

            else if (Input.GetKey(KeyCode.S))
            {
                move_var = 1;
                MoveSpeed = 1.5f;
                transform.rotation = Quaternion.LookRotation(target_dir);
                /*if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
                {
                    move_var = 2;
                    MoveSpeed = 3.5f;
                }
                else*/ if (animator.GetBool("dive") == true)
                {
                    MoveSpeed = 3.5f;
                }
            }

            else if (Input.GetKey(KeyCode.A))
            {
                move_var = 1;
                MoveSpeed = 1.5f;
                transform.rotation = Quaternion.LookRotation(target_dir);
                /*if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
                {
                    move_var = 2;
                    MoveSpeed = 3.5f;
                }
                else*/ if (animator.GetBool("dive") == true)
                {
                    MoveSpeed = 3.5f;
                }
            }

            else if (Input.GetKey(KeyCode.D))
            {
                move_var = 1;
                MoveSpeed = 1.5f;
                transform.rotation = Quaternion.LookRotation(target_dir);
                /*if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
                {
                    move_var = 2;
                    MoveSpeed = 3.5f;
                }
                else*/ if (animator.GetBool("dive") == true)
                {
                    MoveSpeed = 3.5f;
                }
            }
            animator.SetInteger("BasicMotion", move_var);
            target_dir = new Vector3(horizontal, 0, vertical);
            controller.Move(target_dir * MoveSpeed * Time.deltaTime);
        }

        else
        {
            move_var = 0;
            animator.SetInteger("BasicMotion", 0);
            MoveSpeed = 0;
        }
    }

    public void Submerge()
    {
        if (Input.GetKey(KeyCode.C)) 
        {
            if (animator.GetBool("dive") == false)
            {
                StartCoroutine(diving());
            }
        }
    }
    IEnumerator diving()
    {
        animator.SetBool("dive", true);
        yield return new WaitForSeconds(shadowTime);
        animator.SetBool("dive", false);
    }
}