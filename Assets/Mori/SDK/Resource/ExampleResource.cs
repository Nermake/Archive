using UnityEngine;
using Random = UnityEngine.Random;

namespace Mori.SDK.Resource
{
    public class ExampleResource : MonoBehaviour
    {
        private ResourcesFeature _resourcesFeature;

        private void Start()
        {
            var resourceSoft = new Resource(ResourceType.SoftCurrency, 10);
            var resourceHard = new Resource(ResourceType.HardCurrency, 20);
            var resources = new[] {resourceSoft, resourceHard};

            _resourcesFeature = new ResourcesFeature(resources);
            
            _resourcesFeature.ResourceChanged += OnResourceChanged;

            Debug.Log($"Created: Resource ({ResourceType.SoftCurrency}) = {_resourcesFeature.GetResourceValueString(ResourceType.SoftCurrency)}");
            Debug.Log($"Created: Resource ({ResourceType.HardCurrency}) = {_resourcesFeature.GetResourceValueString(ResourceType.HardCurrency)}");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Command("Add");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Command("Spend");
            }
        }

        private void Command(string command)
        {
            var resources = new[] {ResourceType.SoftCurrency, ResourceType.HardCurrency};
            var rIndex = Random.Range(0, resources.Length);
            var rResourceType = resources[rIndex];
            var rAmount = Random.Range(0, 100);

            if (command == "Add") _resourcesFeature.AddResource(rResourceType, rAmount);
            if (command == "Spend") _resourcesFeature.SpendResource(rResourceType, rAmount);
        }

        private void OnResourceChanged(ResourceType type, int oldValue, int newValue)
        {
            Debug.Log($"Resource amount changed. Resource type: {type}. OldValue: {oldValue}. NewValue: {newValue}. ");
        }

        private void OnDestroy()
        {
            _resourcesFeature.ResourceChanged -= OnResourceChanged;
        }
    }
}