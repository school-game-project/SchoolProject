using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class GroundTile : MonoBehaviour, IMapObject
    {
        public Transform Transform1;

        public  bool IsObstacle { get { return false; } }
        public float XOffset { get { return xOffset; } set { xOffset = value; } }
        public float ZOffset { get { return zOffset; } set { zOffset = value; } }
        public string SaveString { get { return "Ground"; } }

        private float xOffset = 0;
        private float zOffset = 0;

        public Transform GetTransform()
        {
            return Transform1;
        }
    }
}
