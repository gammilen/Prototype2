using System.Collections.Generic;
using UnityEngine;
using Ships.Core;

namespace Ships.Game.UI
{
	public class ShipModulesSlotsView : MonoBehaviour
	{
		[SerializeField] private ModulesSlotElement _slotElement;
		
		private readonly Dictionary<ShipModuleSlotInfo, ModulesSlotElement> _elements = new();
        private IShipCustomization _shipCustomization;

        public void Init(IShipCustomization shipCustomization, int shipIndex, ModulesSlotElementsGroup slotElementsGroup)
        {
            _shipCustomization = shipCustomization;

            foreach (var modules in _shipCustomization.GetAllModules())
            {
                for (int i = 0; i < modules.modules.Count; i++)
                {
                    IShipModuleData module = modules.modules[i];
                    var element = Instantiate(_slotElement, transform);
                    var info = new ShipModuleSlotInfo(modules.type, shipIndex, i);
                    element.Init(info);
                    element.SetupModule(module);
                    slotElementsGroup.AddElement(element);
                    _elements.Add(info, element);
                }
            }
            _shipCustomization.ShipModuleChangeEvent += UpdateSlotElement;
        }

        private void UpdateSlotElement(ShipModulesSlotType slotType, int index)
        {
            foreach (var element in _elements)
            {
                if (element.Key.SlotType == slotType && element.Key.SlotIndex == index)
                {
                    element.Value.SetupModule(_shipCustomization.GetModules(slotType)[index]);
                    return;
                }    
            }
        }

    }
}