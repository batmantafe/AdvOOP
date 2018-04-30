using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{

    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float lookSpeed = 5f;
        public float maxVelocity = 5f;

        [Header("References")]
        public Transform attachedCamera;

        // Private References
        private Rigidbody rigid;

        #region Unity Functions
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        void Update()
        {

        }
        #endregion

        #region Custom Functions
        void LimitVelocity()
        {
            Vector3 vel = rigid.velocity;

            if (vel.magnitude > maxVelocity)
            {
                vel = vel.normalized * maxVelocity;
            }

            rigid.velocity = vel;
        }

        public void Look (float horizontal, float vertical)
        {
            // Rotate Player on the "Horizontal" axis
            Vector3 euler = transform.eulerAngles;
            euler.y += horizontal * lookSpeed * Time.deltaTime;
            transform.localEulerAngles = euler;

            // Rotate Camera on the "Vertical" axis
            Vector3 camEuler = attachedCamera.transform.eulerAngles;
            camEuler.x -= vertical * lookSpeed * Time.deltaTime;
            attachedCamera.localEulerAngles = camEuler;
        }

        public void Move (float horizontal, float vertical)
        {
            Vector3 inputDir = new Vector3(horizontal, 0, -vertical);
            rigid.AddForce(inputDir * moveSpeed);

            LimitVelocity();
        }
        #endregion
    }
}
