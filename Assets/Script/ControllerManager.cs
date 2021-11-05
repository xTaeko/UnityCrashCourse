using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class ControllerManager : MonoBehaviour
    {
        public bool isRightHand;
        [SerializeField] private GameObject rayController;

        [SerializeField] private GameObject teleportController;
        
        // Start is called before the first frame update
        void Start()
        {
            if (isRightHand)
            {
                InputManager.Controls.XRIRightHand.TeleportModeActivate.performed +=
                    context => EnableTeleportController(true);
            }
            else
            {
                InputManager.Controls.XRILeftHand.TeleportModeActivate.performed +=
                    context => EnableTeleportController(true);
            }
        }

        /// <summary>
        /// This Function enables one controller and disables the other depending on the boolean. <br/>
        /// </summary>
        /// <param name="enable">Enable - Teleport Controller on, Ray Controller off.  and vice versa</param>
        private void EnableTeleportController(bool enable)
        {
            teleportController.SetActive(enable);
            rayController.SetActive(!enable);

        }

        // Please don't do this in the actual code. There are better ways with state machines etc. But at the moment I don't know a better solution for quick solutions to have a teleport Ray separate 
        private void Update()
        {
            
            if (isRightHand)
            {
                if (teleportController.activeSelf == true &&
                    InputManager.Controls.XRIRightHand.TeleportSelect.phase == InputActionPhase.Waiting)
                {
                    EnableTeleportController(false);
                }

            }
            else
            {
                if (teleportController.activeSelf == true &&
                    InputManager.Controls.XRILeftHand.TeleportSelect.phase == InputActionPhase.Waiting)
                {
                    EnableTeleportController(false);
                }
            }
        }
    }
}
