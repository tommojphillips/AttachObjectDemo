using UnityEngine;
using ModApi.Attachable;

namespace AttachObjectDemo
{
    /// <summary>
    /// Represents a truck engine part for satsuma.
    /// </summary>
    public class TruckEngine : Part
    {
        public TruckEngine(PartSaveInfo inPartSaveInfo, GameObject part, GameObject parent, Trigger inPartTrigger, Vector3 inPartPosition, Quaternion inPartRotation) : base(inPartSaveInfo, part, parent, inPartTrigger, inPartPosition, inPartRotation)
        {
        }

        protected override PartSaveInfo defaultPartSaveInfo => new PartSaveInfo()
        {
            installed = false,
            position = new Vector3(-20.7f, 10, 10.9f),
            rotation = Quaternion.Euler(0, 90, 90),
        };
        protected override GameObject rigidPart
        {
            get;
            set;
        }
        protected override GameObject activePart
        {
            get;
            set;
        }

        protected override void assemble(bool startUp = false)
        {
            base.assemble(startUp);
        }

        protected override void disassemble(bool startup = false)
        {
            base.disassemble(startup);
        }
    }
}       