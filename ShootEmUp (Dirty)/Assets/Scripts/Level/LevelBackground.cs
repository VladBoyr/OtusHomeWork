using System;
using UnityEngine;

namespace Level
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
            this._positionX = this.transform.position.x;
            this._positionZ = this.transform.position.z;
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