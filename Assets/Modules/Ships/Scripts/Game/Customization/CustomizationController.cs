using System.Collections.Generic;
using Ships.Core;
using UnityEngine;

namespace Ships.Game
{
    public class CustomizationController : MonoBehaviour
	{
		[SerializeField] private ModulesStore _modulesStore;
		[SerializeField] private ShipsCustomization _customization;
		[SerializeField] private BattleShips _battleShips;

		public IShipCustomizationSource ShipsCustomization => _customization;
		public IShipSlotModulesStore ModulesStore => _modulesStore;
		public IShipCustomizationState CustomizationControl { get; private set; }

		private void Awake()
		{
			CustomizationControl = ShipCustomizationStateFactory.GetShipCustomizationState(
				_customization, _modulesStore);
		}

		public void StartBattle()
		{
			_battleShips.Init(CreateBattleShips());
			ScenesLoader.LoadBattle();
		}

		private List<ShipState> CreateBattleShips()
		{
			var shipStates = new List<ShipState>();
			foreach (var ship in _customization.Ships)
			{
				shipStates.Add(ShipStateFactory.GetShipState(ship));
			}
			return shipStates;
		}
	}
}