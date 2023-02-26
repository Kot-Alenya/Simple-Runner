﻿namespace Ecs
{
    public class ComponentsUpdate : ITickable
    {
        public void Tick(float deltaTime)
        {
            for (var i = 0; i < World.Entities.Count; i++)
                World.Entities[i].ComponentsUpdate();
        }
    }
}