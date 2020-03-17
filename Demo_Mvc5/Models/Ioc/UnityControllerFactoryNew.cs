using Demo_Mvc5.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace Demo_Mvc5.Models.Ioc
{
    public class UnityControllerFactoryNew : DefaultControllerFactory
    {
        //private IUnityContainer UnityContainer
        //{
        //    get
        //    {
        //        return IocConfig.IOCContainer;
        //    }
        //}
        private IUnityContainer UnityContainer
        {
            get
            {
                return DIFactory.GetContainer("MyContainer");
            }
        }


        /// <summary>
        /// 创建控制器对象
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (null == controllerType)
            {
                return null;
            }
            IController controller = (IController)this.UnityContainer.Resolve(controllerType);
            return controller;
        }
        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="controller"></param>
        public override void ReleaseController(IController controller)
        {
            //释放对象
            //this.UnityContainer..Teardown(controller);//释放对象
            base.ReleaseController(controller);
        }
    }
}