using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class Tree : MonoBehaviour, IMapObject
    {
        public Transform Transform1;

        public bool IsObstacle{ get { return true; } }
        public float XOffset { get { return xOffset; } set { xOffset = value; } }
        public float ZOffset { get { return zOffset; } set { zOffset = value; } }

        private float xOffset = -0.75f;
        private float zOffset = -0.75f;

        public Transform GetTransform()
        {
            //TODO maybe add some randomisation
            return Transform1;
        }
    }
}
