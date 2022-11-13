using System;
using System.Collections.Generic;
using UnityEngine;
using Ships.Core;

namespace Ships.Game.UI
{
	public class StoredSlotModulesView : MonoBehaviour
	{
		[SerializeField] private StoredSlotModuleElement _elementTemplate;
		private List<StoredSlotModuleElement> _elements = new List<StoredSlotModuleElement>();

		public event Action<StoredSlotModuleInfo> SelectEvent;

		public void Init(IShipSlotModulesStore modulesStore)
        {
			foreach (var modules in modulesStore.GetAllModules())
            {
                for (int i = 0; i < modules.Value.Count; i++)
                {
					var info = new StoredSlotModuleInfo(modules.Key, modules.Value[i], i);
					var element = Instantiate(_elementTemplate, transform);
					element.Init(info);
					element.ClickEvent += SelectModule;
					_elements.Add(element);
				}
            }
		}

		public void ShowModules(ShipModulesSlotType slotType)
        {
			foreach (var element in _elements)
            {
				element.gameObject.SetActive(element.ModuleInfo.SlotType == slotType);
            }
        }

		private void SelectModule(StoredSlotModuleInfo moduleInfo)
        {
			SelectEvent?.Invoke(moduleInfo);
        }
	}
}