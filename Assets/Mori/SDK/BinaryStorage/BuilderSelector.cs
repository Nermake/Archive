using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Mori.SDK.BinaryStorage
{
    public class BuilderSelector
    {
        public BinaryFormatter BinaryFormatter { get; private set; }

        private SurrogateSelector _surrogateSelector;
        public BuilderSelector()
        {
            BinaryFormatter = new BinaryFormatter();
            _surrogateSelector = new SurrogateSelector();
            
            Build();

            BinaryFormatter.SurrogateSelector = _surrogateSelector;
        }

        private void Build()
        {
            BuildVector2();
            BuildQuaternion();
        }
        
        private void BuildVector2()
        {
            var v2Surrogate = new Vector2SerializationSurrogate();
            _surrogateSelector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), v2Surrogate);
        }
        
        private void BuildQuaternion()
        {
            var qSurrogate = new QuaternionSerializationSurrogate();
            _surrogateSelector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), qSurrogate);
        }
    }
}