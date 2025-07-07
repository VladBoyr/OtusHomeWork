using System;
using UnityEngine;

namespace Version2.Level
{
    public sealed class LevelBackground : MonoBehaviour
    {
        [SerializeField] private BackgroundParams backgroundParams;

        private Transform _myTransform;
        private float _positionX;
        private float _positionZ;

        private void Awake()
        {
            this._myTransform = this.transform;
            var currentPosition = this._myTransform.position;
            this._positionX = currentPosition.x;
            this._positionZ = currentPosition.z;
        }

        private void FixedUpdate()
        {
            if (this._myTransform.position.y <= this.backgroundParams.endPositionY)
            {
                this._myTransform.position = new Vector3(
                    this._positionX,
                    this.backgroundParams.startPositionY,
                    this._positionZ
                );
            }

            this._myTransform.position -= new Vector3(
                this._positionX,
                this.backgroundParams.movingSpeedY * Time.fixedDeltaTime,
                this._positionZ
            );
        }

        [Serializable]
        public sealed class BackgroundParams
        {
            public float startPositionY;
            public float endPositionY;
            public float movingSpeedY;
        }
    }
}