﻿

using Assets.Scripts.Refactoring;
using Assets.Utility;
using UnityEngine;

namespace Assets.Scripts.Character.Player.State {
    public class PlayerMoveState : PlayerState {

        public PlayerMoveState(PlayerEnumStates type) : base(type) {
        }

        public override void OnInit() {
            base.OnInit();

        }

        public override void OnEnter() {
            base.OnEnter();
            Debug.Log("Enter move");
        }

        public override void OnUpdate() {
            base.OnUpdate();
            core.TakeFire();
        }

        public override void OnFixedUpdate() {
            base.OnFixedUpdate();
            core.Move();
        }
    }
}
