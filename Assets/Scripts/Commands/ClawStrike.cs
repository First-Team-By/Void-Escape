﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class ClawStrike : EntityCommand
    {
        void Awake()
        {
            OnExecute = ClawStrikeExec;
            IsEnabled = ClawStrikeEnabled;

            SelfPositions = new List<int>() { 1, 2, 3 };
            EnemyPositions = new List<int>() { 1, 2, 3 };

        }
        protected virtual void ClawStrikeExec()
        {

        }

        private bool ClawStrikeEnabled(EntityBase entity)
        {
            return SelfPositions.Contains(entity.Position);
        }
    }
}