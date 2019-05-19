using System.Collections.Generic;
using UnityEngine;

namespace Script.AI.Reaction
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

        public void SetEntity(IEntityReaction[] group)
        {
            foreach (IEntityReaction reaction in group)
            {
                reaction.Entity = Entity;
            }
        }

        public Transform Entity { get; set; }
        
        public bool IsEntityVisible()
        {
            bool vis = false;
            for (int i = 0; i < groups.Count; i++)
            {
                visible[i] = IsEntityVisibleGroup(groups[i]);
                vis = vis || visible[i];
            }
            return vis;
        }

        private bool IsEntityVisibleGroup(IEntityReaction[] group)
        {
            bool vis = true;
            SetEntity(group);
            for (int i = 0; i < group.Length; i++)
            {
                vis = vis && group[i].IsEntityVisible();
            }
            return vis;
        }

        public void Reaction()
        {
            for (int i = 0; i < groups.Count; i++)
            {
                if (visible[i]) InvokeGroupReaction(groups[i]);
            }
        }

        private void InvokeGroupReaction(IEntityReaction[] group)
        {
            for (int j = 0; j < group.Length; j++)
            {
                group[j].Reaction();
            }
        }
    }
}