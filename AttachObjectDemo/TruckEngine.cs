using UnityEngine;
using ModApi.Attachable;

namespace SecureCarJack
{
    /// <summary>
    /// Represents a truck engine part for satsuma.
    /// </summary>
    public class TruckEngine : Part
    {
        public TruckEngine(PartSaveInfo inPartSaveInfo, GameObject inPart, GameObject inParent, Trigger inPartTrigger, Vector3 inPartPosition, Quaternion inPartRotation) : base(inPartSaveInfo, inPart, inParent, inPartTrigger, inPartPosition, inPartRotation)
        {
        }

        public override PartSaveInfo defaultPartSaveInfo => new PartSaveInfo()
        {
            installed = false,
            position = new Vector3(-20.7f, 10, 10.9f),
            rotation = Quaternion.Euler(0, 90, 90),
        };
        public override GameObject rigidPart
        {
            get;
            set;
        }
        public override GameObject activePart
        {
            get;
            set;
        }

        protected override void assemble(bool inStartup = false)
        {
            base.assemble(inStartup);
        }

        protected override void disassemble(bool inStartup = false)
        {
            base.disassemble(inStartup);
        }
    }
}       