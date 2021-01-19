using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace GabrielZ.PA.Lobby
{
    public class Player : NetworkBehaviour
    {
        [SerializeField] private Animator anim;

        private Vector2 movement;

        private Controls controls;
        private Controls Controls
        {
            get
            {
                if (controls != null) { return controls; }
                return controls = new Controls();
            }
        }

        public override void OnStartAuthority()
        {
            movement = Controls.Player.Move.ReadValue<Vector2>();

            enabled = true;

            anim.SetFloat("XInput", movement.x);
            anim.SetFloat("ZInput", movement.y);
        }


        [ClientCallback]
        private void OnEnable() => Controls.Enable();
        [ClientCallback]
        private void OnDisable() => Controls.Disable();
    }
}
