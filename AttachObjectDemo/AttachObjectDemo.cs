using UnityEngine;
using MSCLoader;
using TommoJProductions.ModApi.Attachable;
using System.IO;
using System;
using TommoJProductions.ModApi.Database;

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
        private Part truckEngine;
        /// <summary>
        /// Represents the save file name.
        /// </summary>
        private const string fileName = "truckengine_partinfosave.txt";
        
        /// <summary>
        /// Occurs on game load.
        /// </summary>
        public override void OnLoad()
        {
            // Written, 18.10.2018
            // Called once, when mod is loading after game is fully loaded

            // Creating truck engine object.
            GameObject truckEngineGo = loadEngine();

            GameObject parent = Database.databaseVehicles.satsuma;
            TriggerData triggerData = TriggerData.createTriggerData("truckEngineTriggerData");

            // Creating trigger for truck engine.
            TriggerSettings triggerSettings = new TriggerSettings() 
            {
                triggerID = "TruckEngineTrigger",
                triggerData = triggerData,
                triggerPosition = new Vector3(0.0f, 1.3f, -0.3f)
            };
            Trigger trigger = new Trigger(parent, triggerSettings);

            // Creating a new instance of the truckengine.
            PartSettings partSettings = new PartSettings()
            {
                assembleType = AssembleType.joint,
                assemblyTypeJointSettings = new AssemblyTypeJointSettings()
                {
                    breakForce = float.PositiveInfinity, // unbreakable joint.
                }
            };
            truckEngine = truckEngineGo.AddComponent<Part>();
            truckEngine.initPart(triggerData);

            ModConsole.Print(string.Format("{0} v{1}: Loaded.", this.Name, this.Version));
        }

        private GameObject loadEngine() 
        {
            GameObject truckEngineGo = LoadOBJ(this, @"truck_engine.obj", rigidbody: true);
            truckEngineGo.name = "Truck Engine";
            // Loading and assigning the texture for the object.
            Texture2D engineTexture = LoadAssets.LoadTexture(this, "Truck_Engine_Texture.png");
            truckEngineGo.GetComponent<Renderer>().material.mainTexture = engineTexture;

            return truckEngineGo;
        }

        public static GameObject LoadOBJ(Mod mod, string fileName, bool collider = true, bool rigidbody = false)
        {
            Mesh mesh = LoadOBJMesh(mod, fileName);
            if (mesh != null)
            {
                GameObject gameObject = new GameObject();
                gameObject.AddComponent<MeshFilter>().mesh = mesh;
                gameObject.AddComponent<MeshRenderer>();
                if (rigidbody)
                {
                    gameObject.AddComponent<Rigidbody>();
                }

                if (collider)
                {
                    if (rigidbody)
                    {
                        gameObject.AddComponent<MeshCollider>().convex = true;
                    }
                    else
                    {
                        gameObject.AddComponent<MeshCollider>();
                    }
                }

                return gameObject;
            }

            return null;
        }
        public static Mesh LoadOBJMesh(Mod mod, string fileName)
        {
            string text = Path.Combine(ModLoader.GetModAssetsFolder(mod), fileName);
            if (!File.Exists(text))
            {
                throw new FileNotFoundException("<b>LoadOBJ() Error:</b> File not found: " + text + Environment.NewLine, text);
            }

            if (Path.GetExtension(text).ToLower() == ".obj")
            {
                Mesh mesh = new OBJLoader().ImportFile(Path.Combine(ModLoader.GetModAssetsFolder(mod), fileName));
                mesh.name = Path.GetFileNameWithoutExtension(text);
                return mesh;
            }

            throw new NotSupportedException("<b>LoadOBJ() Error:</b> Only (*.obj) files are supported" + Environment.NewLine);
        }
    }
}
