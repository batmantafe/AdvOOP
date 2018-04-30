using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

namespace Commands
{
    [RequireComponent(typeof(PlayerController))]

    public class NetworkUserInput : NetworkBehaviour
    {
        public Camera cam;
        public AudioListener aud;

        [SyncVar] public float inputH, inputV;
        [SyncVar] public float mouseX, mouseY;

        private PlayerController player;

        #region Unity Functions
        void Start()
        {
            player = GetComponent<PlayerController>();

            cam.enabled = isLocalPlayer;
            aud.enabled = isLocalPlayer;
        }

        // Update is called once per frame
        void Update()
        {
            if (isLocalPlayer)
            {
                GetInput();

                player.Move(inputH, inputV);
                player.Look(mouseX, mouseY);

                // Send input across network
                Cmd_Move(inputH, inputV);
                Cmd_Look(mouseX, mouseY);
            }
        }
        #endregion
        
        #region Custom Function
        void GetInput()
        {
            inputH = Input.GetAxis("Horizontal");
            inputV = Input.GetAxis("Vertical");
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }
        #endregion

        #region Commands
        [Command] void Cmd_Move(float inputH, float inputV)
        {
            Rpc_Move(inputH, inputV);
        }

        [Command] void Cmd_Look(float mouseX, float mouseY)
        {
            Rpc_Look(mouseX, mouseY);
        }
        #endregion

        // Functions that get run by the server and run on each client
        #region Remote Procedure Calls (RPCs)
        [ClientRpc] void Rpc_Move(float inputH, float inputV)
        {
            player.Move(inputH, inputV);
        }

        [ClientRpc] void Rpc_Look(float mouseX, float mouseY)
        {
            player.Look(mouseX, mouseY);
        }
        #endregion
    }
}
