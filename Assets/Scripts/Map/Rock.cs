using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class Rock : MonoBehaviour, IMapObject
    {
        public Transform Transform1;

        public bool IsObstacle { get { return true; } }

        public Transform GetTransform()
        {
            //TODO maybe add some randomisation
            return Transform1;
        }
    }
}
