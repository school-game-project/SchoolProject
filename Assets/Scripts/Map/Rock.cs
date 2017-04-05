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
        public float XOffset { get { return xOffset; } set { xOffset = value; } }
        public float ZOffset { get { return zOffset; } set { zOffset = value; } }
        public string SaveString { get { return "Stone"; } }

        private float xOffset = -0.75f;
        private float zOffset = -0.75f;

        public Transform GetTransform()
        {
            //TODO maybe add some randomisation
            return Transform1;
        }

        private void Start()
        {
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).MineTriggered += Rock_MineTriggered;
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).MineCanceled += Rock_MineCanceled;
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).MineFinished += Rock_MineFinished;
        }

        private void Rock_MineFinished(GameObject target)
        {
            if (target.tag == "Stone")
            {
                FinishMining(target);
            }
        }

        private void Rock_MineCanceled(GameObject target)
        {
            if (target.tag == "Stone")
            {
                
            }
        }

        private void Rock_MineTriggered(GameObject target)
        {
            if (target.tag == "Stone")
            {
               
            }
        }

        private void StopMining()
        {
            //TODO cancle animations
        }

        private void FinishMining(GameObject target)
        {
            target.GetComponent<Animator>().SetBool("falling", true);
            Destroy(target, 1.5f);
        }

        private void StartMining(GameObject target)
        {

        }
    }
}
