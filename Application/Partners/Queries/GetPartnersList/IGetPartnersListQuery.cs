using System.Collections.Generic;
using Domain.Partners;

namespace Application.Partners.Queries.GetPartnersList
{
    public interface IGetPartnersListQuery
    {
	    List<PartnerModel> Execute();
    }
}
