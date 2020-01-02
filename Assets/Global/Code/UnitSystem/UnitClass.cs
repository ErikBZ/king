using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace King.Pieces
{

    [CreateAssetMenu(fileName = "UnitClass", menuName = "king/UnitClass", order = 0)]
    public class UnitClass : ScriptableObject
    {
        public string ClassName;
        // keeps track of what weapons this class can use
        public byte Weapons;
        public byte MaxAttack;
        public byte MaxMagic;
        public byte MaxSkill;
        public byte MaxSpeed;
        public byte MaxLuck;
        public byte MaxDef;
        public byte MaxRes;
    }
}