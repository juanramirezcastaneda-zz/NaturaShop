using Domain.Common;

namespace Domain.Partners
{
    public class Partner: IEntity
    {
	    public int Id { get; set; }

	    public string Name { get; set; }

	    public uint PhoneNumber { get; set; }
    }
}
