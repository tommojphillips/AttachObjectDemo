﻿using UnityEngine;
using MSCLoader;
using ModApi.Attachable;

namespace SecureCarJack
{
    public class AttachObjectDemo : Mod
    {
        // Written, 25.10.2018

        public override string ID => "AttachObjectDemo"; //Your mod ID (unique)
        public override string Name => "Attach Object Demo"; //You mod name
        public override string Author => "tommojphillips"; //Your Username
        public override string Version => "1.1"; //Version
        public override bool UseAssetsFolder => true;

        /// <summary>
        /// Represents the truck engine part.
        /// </summary>
        private TruckEngine truckEngine;
        /// <summary>
        /// Represents the save file name.
        /// </summary>
        private const string fileName = "truckengine_partinfosave.txt";
        
        /// <summary>
        /// Loads save data.
        /// </summary>
        /// <returns></returns>
        private PartSaveInfo loadSaveData()
        {
            // Written, 12.10.2018

            try
            {
                return SaveLoad.DeserializeSaveFile<PartSaveInfo>(this, fileName);
            }
            catch (System.NullReferenceException)
            {
                // no save file exists.. //loading default save data.

                return null;
            }
        }
        /// <summary>
        /// Occurs on game load.
        /// </summary>
        public override void OnLoad()
        {
            // Written, 18.10.2018
            // Called once, when mod is loading after game is fully loaded

            // Creating truck engine object. NOTE Mod-API excepts the gameobject to have both a rigidbody and a collider attached before passing the reference.
            GameObject truckEngineGo = LoadAssets.LoadOBJ(this, @"truck_engine.obj", rigidbody: true);
            truckEngineGo.name = "Truck Engine";
            // Loading and assigning the texture for the object.
            Texture2D engineTexture = LoadAssets.LoadTexture(this, "Truck_Engine_Texture.png");
            truckEngineGo.GetComponent<Renderer>().material.mainTexture = engineTexture;
            GameObject parent = GameObject.Find("SATSUMA(557kg, 248)");
            // Creating trigger for truck engine. and assigning the local location and scale of the trigger related to the parent. (in this case the satsuma).
            Trigger trigger = new Trigger("TruckEngineTrigger", parent, new Vector3(0.0f, 1.3f, -0.3f), Quaternion.Euler(0, 0, 0), new Vector3(1f, 1f, 1f), false);
            // Creating a new instance of the truckengine.
            this.truckEngine = new TruckEngine(
                this.loadSaveData(), // The save data, as this is null, default save info will always be loaded.
                truckEngineGo, // The instance of the part to create.
                parent, // The parent for the part; the gameobject the part installs to.
                trigger, // The trigger for the part.
                new Vector3(0.0f, 0.63f, 1.5f), // The installed-position
                new Quaternion(0, 90, 90, 0)); // The installed-rotation 
            ModConsole.Print(string.Format("{0} v{1}: Loaded.", this.Name, this.Version));
        }
        /// <summary>
        /// Occurs on game save.
        /// </summary>
        public override void OnSave()
        {
            // Written, 30.03.2019

            SaveLoad.SerializeSaveFile(this, this.truckEngine.getSaveInfo(), fileName);
        }
    }
}
