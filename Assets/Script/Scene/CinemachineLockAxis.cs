using UnityEngine;
using Cinemachine;

namespace Script.Scene
{
    [ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
    public class CinemachineLockAxis : CinemachineExtension
    {
        [Tooltip("Lock the camera's Z position to this value")]
        public float m_YPosition = 10;
 
 
 
        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (enabled && stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                pos.y = m_YPosition;
                state.RawPosition = pos;
            }
        }
    }    
}

