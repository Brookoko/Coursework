using UnityEngine;
using Cinemachine;

namespace Script.Scene
{
    [ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
    public class CinemachineLerpAxis : CinemachineExtension
    {
        [Tooltip("Lock the camera's Y position to this value")]
        public float up;
        public float down;
        
        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime
            )
        {
            if (enabled && stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                var t = pos.y < down ? 0 : pos.y > up ? 0 : (pos.y / (up - down) + 1) / 2;
                var target = Vector3.Lerp( new Vector3(pos.x, up, pos.z), new Vector3(pos.x, down, pos.z), t);
                pos = target;
                state.RawPosition = pos;
            }
        }
    }    
}

