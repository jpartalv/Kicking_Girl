using UnityEngine;

/// <summary>
/// Class to control the character movement 
/// </summary>
public class CharacterMovementController : MonoBehaviour
{
    public Animator CharacterAnimator;                  // we'll update the animator parameters
    public GameObject MainCameraRoot;                   // needed to calculate the movement direction 
    public float MovementSpeed = 1;                     // extra multiplier for movement speed
    public CharacterController m_CharacterController;   // the main character controller

    public float JumpPower;                             // extra multiplier for jump movement

    private float m_RunningSpeed;                       // this is for the running animation blend tree
    private Vector3 m_Movement;                         // the controller movement vector variable
 
    void Update()
    {
      

        if (m_CharacterController.isGrounded)
        {
            // we move when we're grounded
            m_Movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            // change movement direction according to camera direction
            m_Movement = MainCameraRoot.transform.TransformDirection(m_Movement);

            // if there's any movement rotate towards movement direction
            if (m_Movement.magnitude > 0)
            { 
                transform.rotation = Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.Atan2(m_Movement.x, m_Movement.z), 0);
                m_RunningSpeed += Time.deltaTime;
            }
            else
            {
                m_RunningSpeed = 0;
            }

            //we jump only if we're on the ground
            if (Input.GetButton("Jump"))
            {
                CharacterAnimator.SetTrigger("Jump");
            }

            if (Input.GetButton("Fire2"))
            {
                CharacterAnimator.SetTrigger("Jump Over");
            }

            if (Input.GetButton("Fire1"))
            {
                CharacterAnimator.SetTrigger("Kick");
            }
        }

        // use the animations root motion to move the character. Multiply by a speed variable
        m_Movement = CharacterAnimator.deltaPosition * MovementSpeed;

        //apply gravity
        m_Movement.y += (Physics.gravity * Time.deltaTime).y;

        // in case we need a smooth jump animation we replace the y movement with a parameter curve
        if (CharacterAnimator.GetFloat("JumpHeight") > 0)
        {
            m_Movement.y = CharacterAnimator.GetFloat("JumpHeight") * JumpPower;
        }
        
        // Add movement to the character controller
        m_CharacterController.Move(m_Movement * Time.deltaTime);

        // Pass the animation parameter for the blend tree
        CharacterAnimator.SetFloat("RunningSpeed", Mathf.Lerp(0,1,m_RunningSpeed));
    }
}
