using System;
using UnityEngine;
using MSCLoader;

namespace ModAPI.Triggers
{
    public class Trigger : MonoBehaviour
    {
        public const string FOLDER_NAME = "ModAPI";
        public const string GUI_ASSEMBLE_FILE_NAME = "gui_assemble.png";
        private const float DISPLAY_TEXT_WIDTH = 20.0f;
        private const float DISPLAY_TEXT_HEIGHT = 20.0f;
        public static Texture2D gui_assemble
        {
            get;
            private set;
        }
        public static bool assetsLoaded
        {
            get;
            private set;
        }
        public Mod mod
        {
            get;
            set;
        }
        public GameObject parentGameObject
        {
            get;
            set;
        }
        public GameObject triggerGameObject
        {
            get;
            set;
        }
        public Vector3 _localPosition
        {
            get;
            set;
        }
        public Quaternion _localRotation
        {
            get;
            set;
        }

        private void Start()
        {
            this.gameObject.AddComponent<TriggerCallback>().onTriggerStay += new Action<Collider>(this.onTriggerStay);
            this.gameObject.AddComponent<TriggerCallback>().onTriggerExit += new Action<Collider>(this.onTriggerExit);
            this.gameObject.AddComponent<TriggerCallback>().onTriggerEnter += new Action<Collider>(this.onTriggerEnter);
            this.loadAssets();
        }

        private void loadAssets()
        {
            // Written, 08.08.2018

            if (!assetsLoaded)
            {
                gui_assemble = LoadAssets.LoadTexture(this.mod, String.Format("{0}/{1}", FOLDER_NAME, GUI_ASSEMBLE_FILE_NAME));
                assetsLoaded = true;
            }
        }

        private void onTriggerEnter(Collider collider)
        {
            
        }

        private void onTriggerExit(Collider collider)
        {
            ModConsole.Print("Exit");
        }

        private void onTriggerStay(Collider collider)
        {
            //if (this.triggerGameObject == collider.gameObject)
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Transform transform = this.triggerGameObject.transform;
                transform.SetParent(parentGameObject.transform, false);
                transform.localPosition = this._localPosition;
                transform.localRotation = this._localRotation;

                FixedJoint fixedJoint = this.parentGameObject.AddComponent<FixedJoint>();
                fixedJoint.connectedBody = this.triggerGameObject.GetComponent<Collider>().attachedRigidbody;
                fixedJoint.enableCollision = false;
                fixedJoint.breakForce = 10000f;
            }
        }

        private void Update() { }
    }
}
