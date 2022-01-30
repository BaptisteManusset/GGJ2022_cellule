using System;
using System.Collections.Generic;
using Bonys;
using Cinemachine;
using UnityEditor;
using UnityEngine;

namespace Toolbox.Procedural.Tentacle {
    /// <summary>
    ///     tentacule fait a partir d'un linerenderer a placer sur le point ou elle doit etre connecté
    ///     \
    ///     #---#   #---#
    ///     | 1 |---| 2 |
    ///     #---#   #---#
    ///     /
    ///     1   tete        =>  ProceduralTentacleWiggle et LineRenderer
    ///     2   direction   =>  definie la direction avec sa rotation
    /// </summary>
    [DisallowMultipleComponent]
    public class ProceduralSnake : MonoBehaviour {
        [SerializeField] private Transform targetDir;
        [SerializeField] private float targetDist;
        [SerializeField] private float smoothSpeed;

        [Space] [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private List<BodyElement> bodyParts = new List<BodyElement>();
        private int _length;


        private List<Vector3> _segmentPoses = new List<Vector3>();
        private List<Vector3> _segmentV = new List<Vector3>();


        public GameObject bodyPartPrefab;
        public GameObject bodyPartWithPiquePrefab;
        public GameObject bodyPartWithNageoirePrefab;

        private CinemachineTargetGroup _targetGroup;

        private void Awake() {
            _targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        }

        private void Start() {
            _length = bodyParts.Count;

            lineRenderer.positionCount = _length;

            // _segmentPoses = new Vector3[_length];
            // _segmentV = new Vector3[_length];

            for (int i = 0; i < _length; i++) {
                _segmentPoses.Add(Vector3.zero);
                _segmentV.Add(Vector3.zero);
            }


            SetBodyParts();
        }

        [ContextMenu("AddBodyPart")]
        public void AddBodyPart(TypeOfBodyPart pick = TypeOfBodyPart.normal) {
            GameObject bodyPart;
            switch (pick) {
                default:
                    bodyPart = bodyPartPrefab;
                    break;
                case TypeOfBodyPart.pick:

                    bodyPart = bodyPartWithPiquePrefab;
                    break;
                case TypeOfBodyPart.nageoire:
                    bodyPart = bodyPartWithNageoirePrefab;
                    break;
            }


            var g = Instantiate(bodyPart, transform);
            var bp = g.GetComponent<BodyElement>();
            bodyParts.Add(bp);
            _segmentPoses.Add(Vector3.zero);
            _segmentV.Add(Vector3.zero);

            SetBodyParts();
            _targetGroup.AddMember(g.transform, .1f, 1);
        }


        [ContextMenu("Set Body Parts")]
        private void SetBodyParts() {
            if (bodyParts.Count == 0) return;

            for (int i = bodyParts.Count - 1; i >= 1; i--) {
                bodyParts[i].target = bodyParts[i - 1].transform;
            }

            bodyParts[0].target = transform;
            lineRenderer.positionCount = _segmentV.Count;
        }

        private void LateUpdate() {
            if (_segmentPoses.Count == 0) return;
            _segmentPoses[0] = targetDir.position;

            if (bodyParts.Count < 1) return;
            for (int i = 1; i < _segmentPoses.Count; i++) {
                Vector3 targetPos = _segmentPoses[i - 1] +
                                    (_segmentPoses[i] - _segmentPoses[i - 1]).normalized * targetDist;

                Vector3 currentVelocity = _segmentV[i];
                _segmentPoses[i] = Vector3.SmoothDamp(_segmentPoses[i], targetPos, ref currentVelocity, smoothSpeed);

                bodyParts[i - 1].transform.position = _segmentPoses[i];
            }

            lineRenderer.SetPositions(_segmentPoses.ToArray());
        }

#if UNITY_EDITOR
        private void OnValidate() {
            SetBodyParts();
            for (int i = 0; i < bodyParts.Count; i++) {
                bodyParts[i].transform.position = transform.position + -(transform.right * i * targetDist);
            }
        }
#endif

        private Vector3 GetBodyPartsPosition(int index) {
            Vector3 position = Vector3.zero;

            position = transform.position + -(transform.right * index * targetDist);
            return position;
        }
    }
}