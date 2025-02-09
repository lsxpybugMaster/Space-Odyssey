﻿

using Assets.Scripts.Model.Player;
using Assets.Scripts.Utility.Input_System;
using UnityEngine;

namespace Assets.Scripts.Character {
    public class PlayerCore {
        public Transform mTransform { get; private set; }
        public Rigidbody2D mRigidbody { get; private set; }
        public PlayerController mController { get; private set; }
        public PlayerData_SO mPlayerData { get; private set; }


        Vector2 mouseWorldPos = Vector2.zero;
        Vector2 moveDir = Vector2.zero;
        Vector2 workSpace = Vector2.zero;
        float curSpeed;
        float workSpeed;

        public PlayerCore(PlayerController playerController) { 
            mController = playerController;
            mTransform = mController.GetComponent<Transform>();
        }

        public void OnInit() {
            mPlayerData = mController.PlayerData;
            mRigidbody = mController.GetComponent<Rigidbody2D>();
        }

        public void Move() {
            RotateToMouse();

            if (InputManager.Instance.Move) {
                mRigidbody.velocity = Vector2.SmoothDamp(mRigidbody.velocity, moveDir * mPlayerData.maxMoveSpeed,
                    ref workSpace, mPlayerData.accelerationTime);
            }
            else {
                mRigidbody.velocity = Vector2.Lerp(mRigidbody.velocity, Vector2.zero, mPlayerData.decelerationTime * Time.fixedDeltaTime);
            }
        }

        public void RotateToMouse() {
            mouseWorldPos = Camera.main.ScreenToWorldPoint(InputManager.Instance.MousePosition);
            moveDir = mouseWorldPos - (Vector2)mTransform.position;
            moveDir.Normalize();

            if (moveDir != Vector2.zero) {
                float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg - 90;
                var targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                mTransform.rotation = Quaternion.Slerp(mTransform.rotation, targetRotation, mPlayerData.rotateSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
