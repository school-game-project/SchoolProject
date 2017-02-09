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

        private void Start()
        {
            //mine event von Player subscriben
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).MineTriggered += Tree_MineTriggered;
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).MineCanceled += Tree_MineCanceled;
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).MineFinished += Tree_MineFinished;
        }

        private void Tree_MineTriggered(GameObject target)
        {
            if (target.tag == "Tree")
                StartMining(target);
        }

        private void Tree_MineCanceled(GameObject target)
        {
            if (target.tag == "Tree")
                StopMining();
        }

        private void Tree_MineFinished(GameObject target)
        {
            if (target.tag == "Tree")
                FinishMining(target);
        }

        private void StopMining()
        {
            //TODO cancle animations
        }

        private void FinishMining(GameObject target)
        {
            Destroy(target);
        }

        private void StartMining(GameObject target)
        {
            //TODO animate stuff
        }
    }
}
