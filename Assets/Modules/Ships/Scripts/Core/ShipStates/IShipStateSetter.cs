using System;
using System.Collections.Generic;

namespace Ships.Core
{
	public interface IShipStateSetter
    {
		int HP { set; }
		int Shield { set; }
	}
}