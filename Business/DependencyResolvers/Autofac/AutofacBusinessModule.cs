using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<InMemoryUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<InMemoryContactDal>().As<IContactDal>().SingleInstance();
        }
    }
}
