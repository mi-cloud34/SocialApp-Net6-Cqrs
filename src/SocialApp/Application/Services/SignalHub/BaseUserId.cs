
using Core.Security.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.SignalHub
{
    public  class BaseUserId:ControllerBase
    {
        public int getIdFromRequest() //todo authentication behavior?
        {
            int userId = HttpContext.User.GetUserId();
            return userId;
        }
    }
}
