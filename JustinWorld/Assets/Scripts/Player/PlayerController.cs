using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    //Declarations
    protected Animator anim;
    protected Rigidbody2D rBody;
    protected Collider2D col;
    protected float direction;
    public int speed;
    public float jumpForce;
    public Transform feet;
    public Transform cameraTarget;
    private Collider2D lastTrigger;

    private Vector3 previousPos;
    private bool wasOnGround;

    //Input System
    public PlayerActionControls controls;

    [SerializeField] private LayerMask ground;

    public ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmission;

    public ParticleSystem poofEffect;

    private bool isInteractable;

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

        ////Grabs the PlayerControls
        controls = new PlayerActionControls();

        //Creating Dpad movement
        controls.Basic.Move.started += context => OnMove(context.ReadValue<float>());
        controls.Basic.Move.canceled += context => AfterMove();

        //Makes the look up animation
        controls.Basic.LookUp.started += _ => OnLookUp();
        controls.Basic.LookUp.canceled += _ => AfterLookUp();

        //Makes the crouch animation
        controls.Basic.Crouch.started += _ => OnCrouch();
        controls.Basic.Crouch.canceled += _ => AfterCrouch();

        //Creates jump
        controls.Basic.Jump.performed += _ => OnJump();
        controls.Basic.Jump.canceled += _ => AfterJump();

        //Creates interact
        controls.Basic.Interact.performed += _ => OnInteract();

        //Creates pause button 
        controls.Basic.Pause.performed += _ => PauseMenuManager.instance.OnPauseButton();

    }

    //This runs every frame
    private void Update() {
        //Check if you can move player
        if(controls.Basic.Move.enabled) {
            rBody.velocity = new Vector2(direction * speed, rBody.velocity.y);
        }
        SetAnim();
    }

    //This get user input and moves in correct direction
    public void OnMove(float movement) {
        if (movement != 0) {
            if (movement > 0f) {
                direction = 1;

            } else if (movement < -0f) {
                direction = -1;

            }
        }
        SetCamTarget();
    }

    //This resets the direction after player stops moving
    public void AfterMove() {
        direction = 0;
    }

    //Function that will make the character look up
    private void OnLookUp() {
        if(!isMoving && isGrounded()) {
            DisableMovement();
            previousPos = cameraTarget.localPosition;
            cameraTarget.localPosition = new Vector3(cameraTarget.localPosition.x, cameraTarget.localPosition.y + 2, cameraTarget.localPosition.z);
            anim.SetBool("isLookingUp", true);
        }
    }

    //Function that will make the character look back down
    private void AfterLookUp() {
        EnableMovement();
        cameraTarget.localPosition = previousPos;
        anim.SetBool("isLookingUp", false);
    }

    //Function that will make the character crouch
    private void OnCrouch() {
        if(!isMoving && isGrounded()) {
            DisableMovement();
            anim.SetBool("isCrouching", true);
        }
    }

    //Function that will cancel crouch
    private void AfterCrouch() {
        EnableMovement();
        anim.SetBool("isCrouching", false);
    }

    //Funtion that will make character jump
    private void OnJump() {
        if (isGrounded()) {
            rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
        }

    }

    //Function that makes the character jump small
    private void AfterJump() {
        if (rBody.velocity.y > 0) {
            rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y * 0.5f);
        }
    }

    //Function that runs when the player interacts with items
    private void OnInteract() {
        if(lastTrigger != null) {
            if (isInteractable) {
                //activate dialogue box and stuff
                DisableMostControls();
                lastTrigger.GetComponent<Interactable>().Interact();
                isInteractable = false;
            } else {
                //deactivate dialogue box and stuff
                EnableMostControls();
                lastTrigger.GetComponent<Interactable>().StopInteracting();
                isInteractable = true;
            }
        }
    }

    //When player is in range of an interactable
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Interactable")) {
            lastTrigger = collision;
            isInteractable = true;
        }
    }

    //When player leaves the range of an interactable
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Interactable")) {
            lastTrigger = null;
            isInteractable = false;
        }
    }






    //Set camera position along the x axis
    private void SetCamTarget() {
        if(isMoving) {
            cameraTarget.localPosition = new Vector3(2f * direction, cameraTarget.localPosition.y, cameraTarget.localPosition.z);
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
    public void OnEnable() {
        controls.Basic.Enable();
    }

    public void OnDisable() {
        controls.Basic.Disable();
        controls.Basic.Pause.Enable();
    }

    public void EnableMovement() {
        controls.Basic.Move.Enable();
        controls.Basic.Jump.Enable();
    }

    public void DisableMovement() {
        controls.Basic.Move.Disable();
        controls.Basic.Jump.Disable();
    }

    //Enables all controls except interact button
    public void EnableMostControls() {
        controls.Basic.Move.Enable();
        controls.Basic.Jump.Enable();
        controls.Basic.Crouch.Enable();
        controls.Basic.LookUp.Enable();
    }

    //Disables all controls except interact button
    public void DisableMostControls() {
        controls.Basic.Move.Disable();
        controls.Basic.Jump.Disable();
        controls.Basic.Crouch.Disable();
        controls.Basic.LookUp.Disable();
    }
}
