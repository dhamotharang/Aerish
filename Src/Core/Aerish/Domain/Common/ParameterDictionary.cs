using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Aerish.Domain.Common
{
    public class ParameterDictionary
    {
        private readonly Dictionary<string, ParameterBO> dictionary = new Dictionary<string, ParameterBO>();

        public ParameterBO this[string key]
        {
            get
            {
                if (!dictionary.ContainsKey(key.ToLower()))
                {
                    return null;
                }

                return dictionary[key.ToLower()];
            }
            set
            {
                ParameterBO newParam = value;

                if (newParam.Name == null)
                {
                    newParam.Name = key.ToLower();
                }

                dictionary[key.ToLower()] = newParam;
            }
        }

        public string[] Keys
        {
            get
            {
                return dictionary.Keys.ToArray();
            }
        }

        public ParameterDictionary() { }

        public ParameterDictionary(params ParameterBO[] args)
        {
            if (args != null)
            {
                foreach (var parameter in args)
                {
                    this[parameter.Name.ToLower()] = parameter;
                }
            }
        }

        public ParameterDictionary(IEnumerable<ParameterBO> parameters)
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    this[parameter.Name.ToLower()] = parameter;
                }
            }
        }

        public T GetAs<T>(string key)
        {
            var data = this[key.ToLower()];

            if (data == null)
            {
                return default(T);
            }

            if (string.IsNullOrWhiteSpace(data.Value))
            {
                return default(T);
            }

            // https://stackoverflow.com/a/2961702/403971
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    return (T)converter.ConvertFromString(data.Value);
                }
                return default(T);
            }
            catch (NotSupportedException)
            {
                return default(T);
            }
        }
    }
}
