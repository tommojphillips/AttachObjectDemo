using System;
using UnityEngine;

namespace ModAPI.Triggers
{
    /// <summary>
    /// Represents call back for triggers.
    /// </summary>
    public class TriggerCallback : MonoBehaviour
    {
        public Action<Collider> onTriggerEnter;
        public Action<Collider> onTriggerExit;
        public Action<Collider> onTriggerStay;

        private void OnTriggerEnter(Collider collider)
        {
            this.onTriggerEnter(collider);
        }

        private void OnTriggerExit(Collider collider)
        {
            this.onTriggerExit(collider);
        }

        private void OnTriggerStay(Collider collider)
        {
            this.onTriggerStay(collider);
        }
    }
}
