using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.CustomActionFilter
{
    public class TokenAttribute : ActionFilterAttribute
    {
        private readonly ICacheServices _cacheServices;

       public TokenAttribute(ICacheServices cacheServices)
        {
            _cacheServices = cacheServices;
       }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.ActionArguments.Keys.First();
            var model = context.ActionArguments[request] as GetMovisRequestDTO;
            if (model.Token != null)
            {
                CacheModel cacheModel = new CacheModel();
                cacheModel.Token = model.Token;
                if (!_cacheServices.IsAuthentication(cacheModel))
                {
                    context.Result = new UnauthorizedResult(); 
                }
            }
            //else
            //{
            //    context.Result = new UnauthorizedResult();
            //}
            
        }
    }

}
