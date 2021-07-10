using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

/* Script for handling Smooth Locomotion as movement */
public class SmoothLocomotion : MonoBehaviour
{
    public XRNode inputSource;
    public float speed = 1;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float extraHeight = 0.2f;

    private float fallingSpeed;
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
            // Get and use a device with an input, and return the Vector2 inputAxis
            InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

    }

    private void FixedUpdate()
    {
            CapsuleFollowHMD();

            Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);  // Find look direction
            Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y); // Movement direction is the input multiplied by the look direction
            character.Move(direction * Time.fixedDeltaTime * speed);    // Move in direction given by InputDevice at inputSource

            // Gravity implementation
            //bool grounded = CheckIfGrounded();
            if(CheckIfGrounded())
            {
                fallingSpeed = 0;
            }
            else
            {
                fallingSpeed += gravity * Time.fixedDeltaTime;  // Gradual increase in fall speed over time
            }
            character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }


    void CapsuleFollowHMD()
    {
        character.height = rig.cameraInRigSpaceHeight + extraHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height/2 + character.skinWidth ,capsuleCenter.z);

    }


    private bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);  // Start raycast from the centre of the character controller
        float rayLength = character.center.y + 0.01f;   // Shoot ray of the hight of the character + a little bit
        bool isGrounded = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return isGrounded;
    }
}
