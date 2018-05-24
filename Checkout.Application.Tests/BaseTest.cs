using AutoMapper;
using Checkout.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;

namespace Checkout.Application.Tests
{

    public class BaseTest
    {
        public CheckoutContext context { get; set; }

        public void ConfigureMapper()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ApplicationMappingProfile>();
            });
        }

        public void MockContext()
        {
            var options = new DbContextOptionsBuilder<CheckoutContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .Options;

            context = new CheckoutContext(options);
            DbInitialiser.Initialize(context);
        }


    }
}
