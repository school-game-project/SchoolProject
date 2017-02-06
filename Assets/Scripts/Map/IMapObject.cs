using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public interface IMapObject
    {
        float XOffset { get; set; }
        float ZOffset { get; set; }
        bool IsObstacle { get; }
        Transform GetTransform();
    }
}
