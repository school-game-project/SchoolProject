using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class House : MonoBehaviour, IMapObject
    {
        public Transform Transform1;

        public bool IsObstacle { get { return true; } }
        public float XOffset { get { return xOffset; } set { xOffset = value; } }
        public float ZOffset { get { return zOffset; } set { zOffset = value; } }

        private float xOffset = 0;
        private float zOffset = -0.5f;

        public Transform GetTransform()
        {
            return Transform1;
        }
    }
}
