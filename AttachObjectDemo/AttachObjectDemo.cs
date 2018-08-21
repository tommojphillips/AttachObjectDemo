using MSCLoader;

namespace AttachObjectDemo
{
    public class AttachObjectDemo : Mod
    {
        // Written, 08.08.2018

        #region Mod Fields

        public override string ID => "AttachObjectDemo"; //Your mod ID (unique)
        public override string Name => "Attach Object Demo"; //You mod name
        public override string Author => "tommojphillips"; //Your Username
        public override string Version => "1.0"; //Version
        // Set this to true if you will be load custom assets from Assets folder.
        // This will create subfolder in Assets folder for your mod.
        public override bool UseAssetsFolder => true;

        #endregion

        #region Properties / Fields

        private TruckEngine truckEngine;

        #endregion

        #region Constructors

        public AttachObjectDemo()
        {
            // Written, 08.08.2018
           
        }

        #endregion

        #region Mod Methods

        public override void OnLoad()
        {
            // Written, 08.08.2018
            // Called once, when mod is loading after game is fully loaded            

            // intializing the assemble/disassemble sounds | REQUIRED
            ModAPI.ModAPI.intializeAssembleSounds();
            // Initializing a new truck engine.
            this.truckEngine = new TruckEngine(this);
            
            ModConsole.Print(string.Format("{0} v{1}: Loaded.", this.Name, this.Version));
        }

        public override void Update()
        {
            // You need to update the truckengine every update. (as of testing)
            this.truckEngine.update(); // Testing
        }

        #endregion
    }
}
