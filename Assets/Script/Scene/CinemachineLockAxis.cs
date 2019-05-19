using UnityEngine;
using Cinemachine;

namespace Script.Scene
{
    [ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
    public class CinemachineLockAxis : CinemachineExtension
    {
        [SerializeField] private float upper = 10;
        [SerializeField] private float lower;
 
        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (enabled && stage == CinemachineCore.Stage.Body)
            {
                if (state.RawPosition.y > upper) SetPosition(ref state, upper);
                if (state.RawPosition.y < lower) SetPosition(ref state, lower);
            }
        }

        private void SetPosition(ref CameraState state, float y)
        {
            var pos = state.RawPosition;
            pos.y = y;
            state.RawPosition = pos;
        }

        public void SetRestriction(float upper, float lower)
        {
            this.upper = upper;
            this.lower = lower;
            GameObject.Find("FallOutController")?
                .GetComponent<FallOutController>()?.SetBoundry(lower);
        }
    }    
}

