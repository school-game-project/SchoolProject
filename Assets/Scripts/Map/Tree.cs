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
        public Transform Transform2;
        public Transform Transform3;
        public Transform Palm;
        public Material highlightMat;


        public bool IsObstacle { get { return true; } }
        public float XOffset { get { return xOffset; } set { xOffset = value; } }
        public float ZOffset { get { return zOffset; } set { zOffset = value; } }
        public string SaveString { get { return "Tree"; } }

        private float xOffset = -0.75f;
        private float zOffset = -0.75f;
        Dictionary<GameObject, Material[]> matDic;

        public Transform GetTransform()
        {
            //TODO maybe add some randomisation
            switch (UnityEngine.Random.Range(0, 3))
            {
                case 0:
                    return Transform1;
                case 1:
                    return Transform2;
                case 2:
                    return Transform3;
                default:
                    return null;
            }
        }

        private void Start()
        {
            //mine event von Player subscriben
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).MineTriggered += Tree_MineTriggered;
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).MineCanceled += Tree_MineCanceled;
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).MineFinished += Tree_MineFinished;
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).HighlightObject += Tree_HighlightObject;
            ((ActionDetecter)GameObject.Find("PlayerWithCam(Clone)").GetComponent(typeof(ActionDetecter))).UnHighlightObject += Tree_UnHighlightObject;
            matDic = new Dictionary<GameObject, Material[]>();
        }

        private void Tree_UnHighlightObject(GameObject target)
        {
            if (target.tag == "Tree")
            {
                if (matDic.ContainsKey(target))
                {
                    target.GetComponent<MeshRenderer>().materials = matDic[target];
                    matDic.Remove(target);
                }
            }
        }

        private void Tree_HighlightObject(GameObject target)
        {
            if (target.tag == "Tree")
            {
                //Alle alten Elemente zurücksetzen
                foreach (GameObject currTarget in matDic.Keys)
                {
                    if (currTarget != target)
                    {
                        if (matDic.ContainsKey(currTarget))
                        {
                            currTarget.GetComponent<MeshRenderer>().materials = matDic[target];
                            matDic.Remove(currTarget);
                        }
                    }
                }

                //Highlighten
                Material[] originMats = target.GetComponent<MeshRenderer>().materials;

                if (!matDic.ContainsKey(target))
                    matDic.Add(target, originMats);

                Material[] newMats = new Material[originMats.Length];
                for (int i = 0; i < newMats.Length; i++)
                {
                    newMats[i] = highlightMat;
                }
                target.GetComponent<MeshRenderer>().materials = newMats;
            }
        }

        private void Tree_MineTriggered(GameObject target)
        {
            if (target.tag == "Tree")
                StartMining(target);
        }

        private void Tree_MineCanceled(GameObject target)
        {
            if (target.tag == "Tree")
                StopMining(target);
        }

        private void Tree_MineFinished(GameObject target)
        {
            if (target.tag == "Tree")
                FinishMining(target);
        }

        private void StopMining(GameObject target)
        {
            target.GetComponent<AudioSource>().Stop();
        }

        private void FinishMining(GameObject target)
        {
            target.GetComponent<AudioSource>().Stop();
            target.GetComponent<Animator>().SetBool("falling", true);
            matDic.Remove(target);
            Destroy(target, 1.5f);
        }

        private void StartMining(GameObject target)
        {
            target.GetComponent<AudioSource>().Play();
        }
    }
}