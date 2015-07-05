using System;
using System.Collections.Generic;

namespace LevvionAI.Utility
{
    /// <summary>
    /// A manager for an entity's cooldowns.
    /// </summary>
    public class CooldownManager
    {
        /// <summary>
        /// The cooldowns.
        /// </summary>
        private Dictionary<string, Cooldown> _cooldowns;

        /// <summary>
        /// Initializes a new instance of the <see cref="CooldownManager"/> class.
        /// </summary>
        public CooldownManager()
        {
            _cooldowns = new Dictionary<string, Cooldown>();
        }

        /// <summary>
        /// Updates via the specified deltatime.
        /// </summary>
        /// <param name="deltatime">The deltatime.</param>
        public void Update(TimeSpan deltatime)
        {
            List<string> removelist = new List<string>();
            
            foreach (var cooldown in _cooldowns)
            {
                cooldown.Value.Update(deltatime);

                if (cooldown.Value.IsFinished())
                {
                    removelist.Add(cooldown.Key);
                }
            }

            foreach (var key in removelist)
            {
                ClearCooldown(key);
            }
        }

        /// <summary>
        /// Determines whether or not the key is on cooldown.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool IsOnCooldown(string key)
        {
            return _cooldowns.ContainsKey(key);
        }

        /// <summary>
        /// Adds a cooldown to the manager.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="duration">The duration.</param>
        public void AddCooldown(string key, TimeSpan duration)
        {
            _cooldowns.Add(key, new Cooldown(duration));
        }

        /// <summary>
        /// Clears a cooldown.
        /// </summary>
        /// <param name="key">The key.</param>
        public void ClearCooldown(string key)
        {
            _cooldowns.Remove(key);
        }
    }
}
