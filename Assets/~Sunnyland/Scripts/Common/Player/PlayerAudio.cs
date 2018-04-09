using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    [RequireComponent(typeof(PlayerController))]

    public class PlayerAudio : MonoBehaviour
    {
        public AudioSource onHurtSound;


        private PlayerController player;

        #region Unity Functions
        void Start()
        {
            player = GetComponent<PlayerController>();

            // Subscribe to onHurt function
            player.onHurt += OnHurt;
        }

        // Update is called once per frame
        void Update()
        {
            // TEST
            if (Input.GetKeyDown(KeyCode.U))
            {
                player.Hurt(10);
            }
        }
        #endregion

        #region Custom Functions
        void OnHurt()
        {
            onHurtSound.Play();
        }
        #endregion
    }
}
