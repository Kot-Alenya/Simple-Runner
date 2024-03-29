﻿using System.Collections.Generic;
using UnityEngine;

namespace Ecs
{
    public static class World
    {
        private static List<Entity> _entities = new();
        private static List<Filter> _filters = new();
        private static Entity _events = new(null, null);

        public static List<Entity> Entities
            => _entities;

        public static Entity Events
            => _events;

        internal static List<Filter> Filters
            => _filters;

        public static bool TryGetEntity(GameObject gameObject, out Entity result)
        {
            foreach (var entity in _entities)
            {
                if (entity.GameObject == gameObject)
                {
                    result = entity;
                    return true;
                }
            }

            result = null;
            return false;
        }

        public static bool TryGetComponent<ComponentType>(out ComponentType result)
            where ComponentType : IComponent
        {
            foreach (var entity in _entities)
            {
                if (entity.Contains<ComponentType>())
                {
                    result = entity.Get<ComponentType>();
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}
