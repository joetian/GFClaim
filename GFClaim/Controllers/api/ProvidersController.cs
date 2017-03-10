using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GFClaim.Models;
using GFClaim.DTO;
using AutoMapper;

namespace GFClaim.Controllers.api
{
    public class ProvidersController : ApiController
    {
        private ApplicationDbContext context;

        public ProvidersController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        // GET /api/providers
        public IHttpActionResult GetProviders()
        {
            return Ok(context.Providers.ToList().Select(Mapper.Map<Provider, ProviderDto>));
        }

        //GET /api/providers/1
        public IHttpActionResult GetProvider(int id)  //正常情况下叫GetProvider...似乎只要以GetXXX, 方法名并不影响URL
        {
            var provider = context.Providers.SingleOrDefault(p => p.Id == id);
            if (provider == null)
                return NotFound();

            return Ok(Mapper.Map<Provider, ProviderDto>(provider));  // Ok里放要返回的Json数据class : 由autoMapper转换provider的providerDto
        }


        //POST /api/providers
        [HttpPost]
        public IHttpActionResult CreateProvider(ProviderDto providerDto)  // if name PostProvider, then can omit [HttpPost]
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Provider provider = Mapper.Map<ProviderDto, Provider>(providerDto);
            context.Providers.Add(provider);
            context.SaveChanges();
            providerDto.Id = provider.Id;
            return Created(new Uri(Request.RequestUri + "/" + provider.Id), providerDto);  // Created里放要： 1. 新创建的resource的URL， 2. 返回的Json数据class : providerDto
        }

        //PUT /api/providers/1
        [HttpPut]
        public void UpdateProvider(int id, ProviderDto providerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var providerInDb = context.Providers.SingleOrDefault(p => p.Id == id);
            if (providerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map<ProviderDto, Provider>(providerDto, providerInDb);
            // Mapper.Map(providerDto, providerInDb); // <ProviderDto, Provider>可以被省略，因为通过参数已知道其类型
            context.SaveChanges();            
        }

        [HttpDelete]
        public void DeleteProvider(int id)
        {
            var provider = context.Providers.SingleOrDefault(p => p.Id == id);
            if (provider == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Providers.Remove(provider);
            context.SaveChanges();
        }

        
    }
}
