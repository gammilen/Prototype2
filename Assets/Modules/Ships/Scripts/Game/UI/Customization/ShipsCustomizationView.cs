using System;
using System.Collections.Generic;
using UnityEngine;
using Ships.Core;

namespace Ships.Game.UI
{
	public class ModulesSlotElementsGroup
    {
		private readonly List<ModulesSlotElement> _elements = new();
		public ModulesSlotElement SelectedElement { get; private set; }

		public event Action<ModulesSlotElement> SelectionChangeEvent;
		public event Action<ModulesSlotElement> DoubleSelectionEvent;

		public void AddElement(ModulesSlotElement element)
        {
			if (_elements.Contains(element))
            {
				return;
            }
			element.SetSelected(false);
			_elements.Add(element);
			element.OnClick.AddListener(() => Select(element));
		}

		public void SelectFirst()
        {
			if (_elements.Count > 0)
            {
				Select(_elements[0]);
            }
        }

		private void Select(ModulesSlotElement element)
        {
			if (element == SelectedElement)
			{
				DoubleSelectionEvent?.Invoke(element);
			}
			else
            {
				if (SelectedElement != null)
                {
					SelectedElement.SetSelected(false);
				}
				SelectedElement = element;
				SelectedElement.SetSelected(true);
				SelectionChangeEvent?.Invoke(SelectedElement);
			}
		}
	}

	

	public class ShipsCustomizationView : MonoBehaviour
	{
		[SerializeField] private StoredSlotModulesView _modulesView;
		[SerializeField] private CustomizationController _customizationController;
		[SerializeField] private List<ShipModulesSlotsView> _shipsViews;

		private ModulesSlotElementsGroup _slotElementsGroup = new();

		private void OnEnable()
        {
			_slotElementsGroup.SelectionChangeEvent += ShowModules;
			_slotElementsGroup.DoubleSelectionEvent += ResetSlot;
			_modulesView.SelectEvent += SetSlotModule;
		}

		private void OnDisable()
		{
			_slotElementsGroup.SelectionChangeEvent -= ShowModules;
			_slotElementsGroup.DoubleSelectionEvent -= ResetSlot;
			_modulesView.SelectEvent -= SetSlotModule;
		}

		private void Start()
        {
			InitShipSlotsViews();
			_modulesView.Init(_customizationController.ModulesStore);
			_slotElementsGroup.SelectFirst();
        }

		private void InitShipSlotsViews()
        {
			var count = _customizationController.ShipsCustomization.Ships.Count;
			for (int i = 0; i < _shipsViews.Count; i++)
			{
				if (i >= count)
				{
					_shipsViews[i].gameObject.SetActive(false);
					continue;
				}
				_shipsViews[i].Init(_customizationController.ShipsCustomization.Ships[i], i, _slotElementsGroup);
			}
		}

		private void ResetSlot(ModulesSlotElement element)
        {
			_customizationController.CustomizationControl.UnsetModuleInSlot(
				element.SlotInfo.SlotType, element.SlotInfo.ShipIndex, element.SlotInfo.SlotIndex);
		}

		private void ShowModules(ModulesSlotElement element)
        {
			_modulesView.ShowModules(element.SlotInfo.SlotType);
		}

		private void SetSlotModule(StoredSlotModuleInfo moduleInfo)
        {
			var slotInfo = _slotElementsGroup.SelectedElement.SlotInfo;
			_customizationController.CustomizationControl.SetModuleInSlot(
				slotInfo.SlotType, slotInfo.ShipIndex, slotInfo.SlotIndex, moduleInfo.InStoreIndex);
        }
	}
}