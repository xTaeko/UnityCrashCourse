using System;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace Script
{
    public class InputManager : MonoBehaviour
    {
        private const string XRHMD = "XRI HMD";
        private const string XRLeftHand = "XRI LeftHand";
        private const string XRRightHand = "XRI RightHand";
        
        
        private static XRIDefaultInputActions controls;

        public static XRIDefaultInputActions Controls
        {
            get
            {
                if (controls != null)
                {
                    return controls;
                }

                return controls = new XRIDefaultInputActions();
            }
        }
        

        private void Start()
        {
            Controls.asset.FindActionMap(XRHMD).Enable();
            Controls.asset.FindActionMap(XRLeftHand).Enable();
            Controls.asset.FindActionMap(XRRightHand).Enable();


        }
    }
}