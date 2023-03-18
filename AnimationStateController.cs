using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour 
{
    private Animator animator;
    private int isWalkingHash;
    private int isRunningHash;
    private int isJumpingHash;

    private void Start() // called before first frame update
    {
        //initialization of animator that holds Animator component
        animator = GetComponent<Animator>();
        
        //calculate and stores the hash value of the parameters
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    private void Update()
    {
        //gets the current status of isRunning parameter
        bool isRunning = animator.GetBool(isRunningHash);
        //gets the current status of isWalking parameter
        bool isWalking = animator.GetBool(isWalkingHash);
        //gets the current status of isJumping parameter
        bool isJumping = animator.GetBool(isJumpingHash); 
        
        // checks whether the below keys are pressed or not and returns true or false
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool jumpPressed = Input.GetKey(KeyCode.Space);

        // checks if the character is not currently jumping and Space key is pressed
        if (!isJumping && jumpPressed)        
        {
            animator.SetBool(isJumpingHash, true); // isJumping in Animator component set to true
        }
        
        // otherwise,checks if character is jumping and Space key is not pressed
        else if (isJumping && !jumpPressed)
        {
            animator.SetBool(isJumpingHash, false);//isJumping in Animator component set to false
        }

        // checks if the character is not currently walking and W key is pressed
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);// isWalking in Animator component set to true
        }
        
        // otherwise,checks if the character is currently walking and W key is not pressed
        else if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);// isWalking in Animator component set to false
        }

        // checks if the character is not currently running and both the W key and leftshift key are pressed
        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);// isRunning in Animator component set to true
        }
        
        // otherwise,checks if the character is currently running and W key or leftshift key are not pressed
        else if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
