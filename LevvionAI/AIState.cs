using System.Collections.Generic;

namespace LevvionAI.Data
{
    /// <summary>
    /// A class holding the state of an entity's AI.
    /// </summary>
    public class AIState
    {
        /// <summary>
        /// The bools
        /// </summary>
        private Dictionary<string, bool> _bools;
        /// <summary>
        /// The ints
        /// </summary>
        private Dictionary<string, int> _ints;
        /// <summary>
        /// The floats
        /// </summary>
        private Dictionary<string, float> _floats;
        /// <summary>
        /// The _strings
        /// </summary>
        private Dictionary<string, string> _strings; 

        /// <summary>
        /// Initializes a new instance of the <see cref="AIState"/> class.
        /// </summary>
        public AIState()
        {
            _bools = new Dictionary<string, bool>();
            _ints = new Dictionary<string, int>();
            _floats = new Dictionary<string, float>();
            _strings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets the bool.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool? GetBool(string key)
        {
            if (_bools.ContainsKey(key))
            {
                return _bools[key];
            }

            return null;
        }

        /// <summary>
        /// Gets the int.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public int? GetInt(string key)
        {
            if (_ints.ContainsKey(key))
            {
                return _ints[key];
            }

            return null;
        }

        /// <summary>
        /// Gets the float.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public float? GetFloat(string key)
        {
            if (_floats.ContainsKey(key))
            {
                return _floats[key];
            }

            return null;
        }

        /// <summary>
        /// Gets the float.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GetString(string key)
        {
            if (_strings.ContainsKey(key))
            {
                return _strings[key];
            }

            return "";
        }

        /// <summary>
        /// Sets the bool.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void SetBool(string key, bool value)
        {
            _bools.Remove(key);
            _bools.Add(key, value);
        }

        /// <summary>
        /// Sets the int.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetInt(string key, int value)
        {
            _ints.Remove(key);
            _ints.Add(key, value);
        }

        /// <summary>
        /// Sets the float.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetFloat(string key, float value)
        {
            _floats.Remove(key);
            _floats.Add(key, value);
        }

        /// <summary>
        /// Sets the float.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetString(string key, string value)
        {
            _strings.Remove(key);
            _strings.Add(key, value);
        }
    }
}
