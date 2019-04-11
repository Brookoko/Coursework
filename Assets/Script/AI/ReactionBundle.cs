using System.Collections.Generic;
using UnityEngine;

namespace Script.AI
{
    public class ReactionBundle : MonoBehaviour, IEntityReaction
    {
        private bool[] visible;
        private List<IEntityReaction[]> groups = new List<IEntityReaction[]>();

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                IEntityReaction[] behaviours = child.GetComponents<IEntityReaction>();
                if (behaviours.Length > 0) groups.Add(behaviours);
            }

            visible = new bool[groups.Count];
        }

        public bool IsEntityVisible(Transform entity)
        {
            bool vis = false;
            for (int i = 0; i < groups.Count; i++)
            {
                visible[i] = IsEntityVisibleGroup(groups[i], entity);
                vis = vis || visible[i];
            }
            return vis;
        }

        private bool IsEntityVisibleGroup(IEntityReaction[] group, Transform entity)
        {
            bool vis = true;
            for (int i = 0; i < group.Length; i++)
            {
                vis = vis && group[i].IsEntityVisible(entity);
            }

            return vis;
        }

        public void Reaction(Transform entity)
        {
            for (int i = 0; i < groups.Count; i++)
            {
                if (visible[i]) InvokeGroupReaction(groups[i], entity);
            }
        }

        private void InvokeGroupReaction(IEntityReaction[] group, Transform entity)
        {
            for (int j = 0; j < group.Length; j++)
            {
                group[j].Reaction(entity);
            }
        }
    }
}