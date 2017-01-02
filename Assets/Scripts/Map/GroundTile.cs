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

        public Transform GetTransform()
        {
            return Transform1;
        }
    }
}
