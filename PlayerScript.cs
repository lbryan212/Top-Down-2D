using UnityEngine;
using System.Collections;

// PlayerScript requires the GameObject to have a Rigidbody2D component

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerScript : MonoBehaviour
{

    public UpperHandler upperHandler;
    public FeetHandler feetHandler;


    public GunControl theGun;

    public bool isMoving;



    







    //Custom Mouse Cursor
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    public float playerSpeed = 10f;

    void Start()
    {
        

        


    }



    void Update()
    {




        //Primary

        bool Primary = Input.GetButton("Primary");
        if (Primary == true)
        {

            upperHandler.anim.SetBool("Primary", true);
            upperHandler.anim.SetBool("Secondary",false);
            upperHandler.anim.SetBool("Knife", false);



        }
        else
        {



        }







        //Secondary
       bool Secondary = Input.GetButton("Secondary");
        if (Secondary == true)
        {
            upperHandler.anim.SetBool("Primary", false);
            upperHandler.anim.SetBool("Secondary", true);
            upperHandler.anim.SetBool("Knife", false);




        }
        else
        {



        }



        //Knife
        bool Knife = Input.GetButton("Knife");
        if (Knife == true)
        {
            upperHandler.anim.SetBool("Primary", false);
            upperHandler.anim.SetBool("Secondary", false);
            upperHandler.anim.SetBool("Knife", true);



        }
        else
        {



        }

































        if (Input.GetButton("Fire1"))
        {
            theGun.isFiring = true;

        }
        else
        {
            theGun.isFiring = false;
        }

      /*  if (Input.GetButtonUp("Fire1"))
        {
            theGun.isFiring = false;

        }

    */

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);



        Vector3 mousePos = Input.mousePosition;                                             //get mouse position                                     
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);             //Get object position and put it "on the screen" (same as mouse)                
        Vector3 offset = new Vector3(mousePos.x - screenPos.x, mousePos.y - screenPos.y);   //Check where the mouse is relative to the object 

        float angle = Mathf.Atan2(offset.x, offset.y) * Mathf.Rad2Deg;                      //Turn that into an angle and convert to degrees
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);                     //Set the object's rotation to be of the angle over -Z




        

        
       

        


        


    }






    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().velocity = targetVelocity * playerSpeed;
    }
}
