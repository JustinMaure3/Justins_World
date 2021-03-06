using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour {

    //Declarations
    protected Animator anim;
    protected Rigidbody2D rBody;
    protected Collider2D col;
    protected float direction;
    public int speed;
    public int jumpForce;
    public Transform feet;
    public Transform cameraTarget;

    private Vector3 previousPos;
    private bool wasOnGround;

    //Input System
    PlayerActionControls controls;

    [SerializeField] private LayerMask ground;

    public ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmission;

    public ParticleSystem poofEffect;

    //Returns true if the characters x or y value changes
    private bool isMoving {
        get {
            return direction != 0;
        }
    }

    //Returns true if the player is on the ground
    private bool isGrounded() {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.1f, ground);

        if (groundCheck != null) {
            return true;
        }
        return false;
    }

    //This runs first before anything
    public void Awake() {
        //Set up the variables
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        footEmission = footsteps.emission;

        //Grabs the PlayerControls
        controls = new PlayerActionControls();

        //Creates movement using the left joystick
        controls.Basic.Move.performed += context => OnMove(context.ReadValue<Vector2>().x);
        //Creates jump
        controls.Basic.Jump.performed += _ => OnJump();
        controls.Basic.Jump.canceled += _ => AfterJump();
        //Makes the look up animation
        controls.Basic.LookUp.performed += _ => OnLookUp();
        controls.Basic.LookUp.canceled += _ => AfterLookUp();
    }

    //This runs every frame
    private void FixedUpdate() {
        SetAnim();
    }

    //This function gets user input and changes the direction accordingly
    private void OnMove(float movement) {
        if (movement != 0) {
            //Reset direction
            direction = 0;

            if (movement > 0f) {
                direction += 1;

            } else if (movement < -0f) {
                direction += -1;

            }
        } else {
            direction = 0;
        }
        //Move Character
        rBody.velocity = new Vector2(direction * speed, rBody.velocity.y);
        SetCamTarget();
    }

    //Funtion that will make character jump
    private void OnJump() {
        if(isGrounded()) {
            rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
        } 

    }

    //Function that makes the character jump small
    private void AfterJump() {
        if (rBody.velocity.y > 0) {
            rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y * 0.5f);
        }
    }

    //Function that will make the character look up
    private void OnLookUp() {
        if(!isMoving && isGrounded()) {
            DisableMovement();
            previousPos = cameraTarget.localPosition;
            cameraTarget.localPosition = new Vector3(cameraTarget.localPosition.x, cameraTarget.localPosition.y + 1, cameraTarget.localPosition.z);
            anim.SetBool("isLookingUp", true);
        }
    }

    //Function that will make the character look back down
    private void AfterLookUp() {
        EnableMovement();
        cameraTarget.localPosition = previousPos;
        anim.SetBool("isLookingUp", false);
    }

    //Set camera position along the x axis
    private void SetCamTarget() {
        if(isMoving) {
            cameraTarget.localPosition = new Vector3(1f * direction, cameraTarget.localPosition.y, cameraTarget.localPosition.z);
        }

    }

    //This function is used to set the animations for the player
    private void SetAnim() {
        if (isMoving) {
            //Set walking animation
            anim.SetBool("isMoving", true);
            anim.SetFloat("x", direction);
        }else {
            //Set idle animation
            anim.SetBool("isMoving", false);
        }

        //Turns on and off the jumping animation
        if (isGrounded()) {
            anim.SetBool("isJumping", false);
        } else {
            anim.SetBool("isJumping", true);
        }

        //Turns on and off the walking particles
        if(isMoving && isGrounded()) {
            footEmission.rateOverTime = 35f;
        } else {
            footEmission.rateOverTime = 0f;
        }

        //Turn on poof effect
        if(!wasOnGround && isGrounded()) {
            poofEffect.gameObject.SetActive(true);
            poofEffect.Stop();
            poofEffect.transform.position = footsteps.transform.position;
            poofEffect.Play();
        }

        wasOnGround = isGrounded();
    }

    //On Enable and disable for button presses
    void OnEnable() {
        controls.Basic.Enable();
    }

    void OnDisable() {
        controls.Basic.Disable();
    }

    void EnableMovement() {
        controls.Basic.Move.Enable();
        controls.Basic.Jump.Enable();
    }

    void DisableMovement() {
        controls.Basic.Move.Disable();
        controls.Basic.Jump.Disable();
    }
}
