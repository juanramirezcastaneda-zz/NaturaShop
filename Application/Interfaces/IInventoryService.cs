﻿namespace Application.Interfaces
{
	public interface IInventoryService
	{
		void NotifySaleOcurred(int productId, int quantity);
	}
}
