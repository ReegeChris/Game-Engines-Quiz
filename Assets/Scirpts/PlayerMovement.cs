using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

//Code referenced from: https://gamedev.stackexchange.com/questions/88433/how-to-reverse-gravity-in-unity
//https://www.codegrepper.com/code-examples/csharp/change+color+of+object+unity+c%23

//Christian Riggi
//100752293


public class PlayerMovement : MonoBehaviour
{
    //Import DLL
    [DllImport("Quiz DLL Change")]
    
    //Import Function from DLL
    private static extern int ChangeColour(int c1, int c2, int c3);

    private Rigidbody rb;
    private float speed;
    private float dirX = 7f;

    //Jump logic variables
    public float jumpForce = 5f;
    public float gravityForce = 20f;
    private bool isGrounded = false;
    private float Gravity = 1;
    private bool reverseGravity = false;

    // Start is called before the first frame update
    void Start()
    {
        //Set player movement speed
       speed = 20.0f;
       rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Gravity flipping mechanic
            if (isGrounded == true)
            {
                //Set rverse gravity to false
                reverseGravity = !reverseGravity;

                //if the gravity is set to one and is grounded,
                // when the player presses the space bar, gravity is inverted
                if (reverseGravity == false)
                {
                    //If the spacebar is pressed, flip the gravity on the rigid body
                    Physics.gravity = new Vector3(0f, -9.8f, 0f);

                    //Velocity is applied to the rigidbody with transform.up
                   // rb.velocity = transform.up * jumpForce * Time.deltaTime;
                    rb.AddForce(new Vector3(0f, gravityForce, 0f), ForceMode.Impulse);

                    //Change the Gravity value to negative 1
                    // Gravity = -1;

                  //  gameObject.GetComponent<Renderer>().material.color = new Color(ChangeColour(45, 109, 66));

                }
                //Since Gravity is set to -1 once the player flips to the other platform, 
                //jumping again will ignore the first if statement and move to this one.
                //Gravity is inverted once again and becomes positive
                else if (reverseGravity == true)
                {

                    Physics.gravity = new Vector3(0f, 9.8f, 0f);

                    //Velocity is applied to the rigidbody with transform.up
                   // rb.velocity = transform.up * -jumpForce * Time.deltaTime;
                    rb.AddForce(new Vector3(0f, -gravityForce, 0f), ForceMode.Impulse);


                    //Change the Gravity value to positive 1
                    // Gravity = 1;

                  //  gameObject.GetComponent<Renderer>().material.color = new Color(ChangeColour(145, 29, 64));

                }
            }
        }
    }

     //Set Player Input
       void FixedUpdate()
      {
       
   
        //Apply force to rigid body to move character
        rb.velocity = new Vector3(dirX, rb.velocity.y, 0f);

        }

    //Layer Collision Detetction

    void OnCollisionEnter(Collision col)
    {
        //Layer 6 is the ground layer used to identify all platforms in the game
        if(col.gameObject.layer == 6 && !isGrounded)
        {

            isGrounded = true;

          //  Debug.Log("On Ground");
        
        }



    }

    void OnCollisionExit(Collision col)
    {
        //Layer 6 is the ground layer used to identify all platforms in the game
        if (col.gameObject.layer == 6 && isGrounded)
        {

            isGrounded = false;

          //  Debug.Log("Off Ground");
        }



    }


}
