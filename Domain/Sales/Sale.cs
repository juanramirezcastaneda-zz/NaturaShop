using System;
using Domain.Common;
using Domain.Customers;
using Domain.Partners;
using Domain.Products;

namespace Domain.Sales
{
    public class Sale: IEntity
    {
	    private int _quantity;
	    private decimal _totalPrice;
	    private decimal _unitPrice;

	    public int Id { get; set; }

	    public DateTime Date { get; set; }

	    public Customer Customer { get; set; }

	    public Partner Partner { get; set; }

	    public Product Product { get; set; }

	    public decimal UnitPrice
	    {
		    get => _unitPrice;
		    set
		    {
			    _unitPrice = value;
				UpdateTotalPrice();
		    }
	    }

	    public decimal TotalPrice
	    {
		    get => _totalPrice;
		    private set => _totalPrice = value;
	    }

	    public int Quantity
	    {
		    get => _quantity;
		    set
		    {
			    _quantity = value;
			    UpdateTotalPrice();
		    }
	    }

		private void UpdateTotalPrice()
	    {
		    _totalPrice = _unitPrice * _quantity;
	    }

    }
}
