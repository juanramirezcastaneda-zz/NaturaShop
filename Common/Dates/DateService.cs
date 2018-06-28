using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dates
{
    public class DateService: IDateService
    {
	    public DateTime GetDate()
	    {
		    return DateTime.Now.Date;
	    }
    }
}
