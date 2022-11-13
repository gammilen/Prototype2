using UnityEngine;
using UnityEngine.UI;
using Ships.Core;

namespace Ships.Game.UI
{
	public class ModulesSlotElement : MonoBehaviour
	{
		[SerializeField] private Text _slotName;
		[SerializeField] private Text _setModuleName;
		[SerializeField] private Button _btn;
		[SerializeField] private GameObject _selection;

		public ShipModuleSlotInfo SlotInfo { get; private set; }
		public Button.ButtonClickedEvent OnClick => _btn.onClick;

		public void Init(ShipModuleSlotInfo slotInfo)
		{
			SlotInfo = slotInfo;
			_slotName.text = slotInfo.SlotType.ToString();
		}

		public void SetupModule(IShipModuleData module)
        {
			_setModuleName.text = module == null ? string.Empty : module.Name;
		}

		public void SetSelected(bool isSelected)
		{
			_selection.SetActive(isSelected);
		}
	}
}