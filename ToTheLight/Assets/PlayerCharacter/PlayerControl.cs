using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
    {
        private bool m_Jump;


        private void Awake()
        {
        }


        private void Update()
        {
            if (!m_Jump)
            {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            //    m_Jump = Input.GetKey(KeyCode.W);
            }
        }


    private void FixedUpdate()
    {
        // Read the inputs.
        int speed = 0;
        bool crouch = Input.GetKey(KeyCode.S);
        if (Input.GetKey(KeyCode.A))
        {
            speed = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            speed = 1;
        }
        this.gameObject.GetComponent<CharacterControl>().Move(speed, crouch, m_Jump);
        m_Jump = false;
     }
}