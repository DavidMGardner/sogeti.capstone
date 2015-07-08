using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using ShortBus;
using StructureMap;

namespace Sogeti.Capstone.Web.Application
{

    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        private readonly IContainer _container;

        public StructureMapControllerFactory(IContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            var container = _container.GetNestedContainer();
            Debug.WriteLine(container.WhatDoIHave());

            var controller = (IController)container.GetInstance(controllerType);
            
            return controller;
        }
    }
}