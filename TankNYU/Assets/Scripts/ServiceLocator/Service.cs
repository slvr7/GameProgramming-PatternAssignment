using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceSpace
{
    public class Service
    {
        public enum Status
        {
            GameStart,
            GamePlaying,
            GameOver,
        }
        private Status currentStatus;

        public Status GetTaskStatus()
        {
            return currentStatus;
        }

        public void SetServiceStatus(Status a)
        {
            if (currentStatus == a) return;
            else currentStatus = a;
        }

        internal virtual void Update() { }

        internal virtual void Start() { }
    }
}
