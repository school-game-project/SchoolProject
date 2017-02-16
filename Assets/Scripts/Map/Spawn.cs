using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Map
{
    class Spawn : MonoBehaviour, IMapObject
    {
        // Filler Klasse für den Spawnpunkt
        public float XOffset { get; set; }
        public float ZOffset { get; set; }
        public bool IsObstacle { get { return true; } }
        public string SaveString { get { return "Spawn"; } }

        public Transform GetTransform()
        {
            return null;
        }
    }
}
