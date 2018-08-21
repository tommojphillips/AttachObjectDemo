using ModAPI.Objects;
using ModAPI.Triggers;
using MSCLoader;
using UnityEngine;

namespace AttachObjectDemo
{
    /// <summary>
    /// Represents a truck engine part for satsuma.
    /// </summary>
    public class TruckEngine : Part
    {
        // Written, 10.08.2018
        
        #region Properties

        /// <summary>
        /// Represents the truck engine gameobject.
        /// </summary>
        public GameObject truckEngine
        {
            get;
            private set;
        }
        /// <summary>
        /// Represents the texture for the engine.
        /// </summary>
        private Texture2D engineTexture
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="mod">The mod.</param>
        public TruckEngine(Mod mod)
        {
            // Written, 10.08.2018

            // Creating truck engine object.
            this.truckEngine = LoadAssets.LoadOBJ(mod, @"truck_engine.obj", true, true);
            // Getting the game objects rigidbody and assigning the mass.
            Rigidbody engineRigidbody = this.truckEngine.GetComponent<Rigidbody>();
            engineRigidbody.mass = 50;
            // Loading and assigning the texture for the object.
            this.engineTexture = LoadAssets.LoadTexture(mod, "Truck_Engine_Texture.png");
            this.truckEngine.GetComponent<Renderer>().material.mainTexture = this.engineTexture;
            // Setting the breakforce for the gameobject. (how much force it takes to break the gameobject off the trigger).
            this.breakForce = 20000;
            // Naming the object. NOTE, name must follow naming convention of <ObjectName>(xxxxx) where <ObjectName> is the game objects name.
            this.truckEngine.name = "Truck Engine(xxxxx)";
            // Spawning the game object to home.
            this.truckEngine.transform.position = new Vector3(-20.7f, 10, 10.9f); // Home Location (Outside Garage)
            this.truckEngine.transform.rotation = new Quaternion(0, 90, 90, 0);
            // Creating trigger for truck engine. and assigning the local location and scale of the trigger related to the parent. (in this case the satsuma).
            this.parent = GameObject.Find("SATSUMA(557kg, 248)");
            Trigger trigger = new Trigger("TruckEngineTrigger", this.parent, new Vector3(0.0f, 1.3f, -0.3f), new Vector3(1f, 1f, 1f), false);
            // Assigning base properties (ModAPI.Objects.Part) object.
            this.part = this.truckEngine;
            this.makePartPickable(true);
            this.partTrigger = trigger;
            // You need to initialize trigger call backs AFTER you assign the part's trigger (Trigger.partTrigger).
            this.initializeTriggerCallback();
            // Assigning the part's installed-point (related to the parent.)
            this.partTriggerPosition = new Vector3(0.0f, 0.63f, 1.5f);
            this.partTriggerRotation = new Quaternion(0, 90, 90, 0);
        }

        #endregion
    }
}
