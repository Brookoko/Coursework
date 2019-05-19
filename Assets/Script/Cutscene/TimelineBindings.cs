using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Script.Cutscene
{
    public class TimelineBindings : MonoBehaviour
    {
        [SerializeField] private RuntimeAnimatorController cutsceneController;
        
        private PlayableDirector timeline;
        private TimelineAsset timelineAsset;

        private GameObject player;
        private Animator anim;
        private RuntimeAnimatorController controller;

        private void Awake()
        {
            timeline = GetComponent<PlayableDirector>();
            player = GameObject.FindWithTag("Player");
            anim = player.GetComponent<Animator>();
            controller = anim.runtimeAnimatorController;
        }

        private void OnEnable()
        {
            BindTimelineTracks();
        }

        private void BindTimelineTracks()
        {
            anim.runtimeAnimatorController = cutsceneController;
            timelineAsset = (TimelineAsset) timeline.playableAsset;
            foreach (PlayableBinding track in timelineAsset.outputs)
            {
                if (track.streamName.Contains("Player"))
                    timeline.SetGenericBinding(track.sourceObject, player);
            }
        }

        private void Update()
        {
            if (timeline.state != PlayState.Playing) Unbind();
        }

        private void Unbind()
        {
            timelineAsset = (TimelineAsset) timeline.playableAsset;
            foreach (PlayableBinding track in timelineAsset.outputs)
            {
                if (track.streamName.Contains("Player"))
                    timeline.SetGenericBinding(track.sourceObject, null);
            }
            anim.runtimeAnimatorController = controller;
            gameObject.SetActive(false);
            Input.Enable();
        }
    }
}