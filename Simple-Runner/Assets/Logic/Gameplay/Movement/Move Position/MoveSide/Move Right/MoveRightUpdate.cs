﻿using InputService;
using Ecs;

namespace MovementSystem
{
    public class MoveRightUpdate : MoveSideSystem
    {
        private Filter<MoveRight> _movable = new();
        private Filter<MoveRightKey> _keys = new();

        public override void FixedTick(float deltaTime)
        {
            foreach (var component in _movable.Components)
                Move(component, deltaTime, _keys.Components.Count > 0, component.IsWallCheck);
        }
    }
}