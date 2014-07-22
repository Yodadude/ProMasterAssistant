using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using StructureMap;

namespace ProMasterAssistant.Infrastructure
{

    public interface ICommandHandler<T>
    {
        void Handle(T input);
    }

    public interface ICommandHandler<T, TRet>
    {
        TRet Handle(T input);
    }

    public interface ICommandInvoker
    {
        void Invoke<T>(T input);
        TRet Invoke<T, TRet>(T input);
    }

    public class CommandInvoker : ICommandInvoker
    {
        private IContainer _container;

        public CommandInvoker(IContainer container)
        {
            _container = container;
        }

        public void Invoke<T>(T input)
        {
            var handler = _container.GetInstance<ICommandHandler<T>>();
            handler.Handle(input);


            //Type generic = typeof(ICommandHandler<T>);
            //Type[] typeArgs = { typeof(object) };
            //Type constructed = generic.MakeGenericType(typeArgs);

            //var command = Activator.CreateInstance<T>(constructed);

            //command.Handle(input);


            //Type itemType = typeof(T);
            //ICommandHandler<T> cmd = (ICommandHandler<T>) Activator.CreateInstance(
            //         typeof(ICommandHandler<T>).MakeGenericType(itemType));

            //cmd.Handle(input);
        }

        public TRet Invoke<T, TRet>(T input)
        {

            var handler = _container.GetInstance<ICommandHandler<T, TRet>>();
            return handler.Handle(input);

            //Type def = typeof(ICommandHandler<,>);

            //Type[] typeArgs = { typeof(T), typeof(TRet) };

            //Type constructed = def.MakeGenericType(typeArgs);

            //var cmd = (ICommandHandler<T, TRet>) Activator.CreateInstance(constructed);

            //Type t = def.MakeGenericType(new Type[] { typeof(T), typeof(TRet) });
            //var cmd = (ICommandHandler<T, TRet>)Activator.CreateInstance(t);


            //Type genericType = typeof(ICommandHandler<,>);
            //ICommandHandler<T, TRet> cmd = (ICommandHandler<T, TRet>)Activator.CreateInstance(typeof(ICommandHandler<,>).MakeGenericType(genericType));

            //var allTypes = Assembly.GetExecutingAssembly().GetTypes(); // I assume the class is in the same assembly.
            //var typeToImplement = allTypes.Single(t => t.IsSubclassOf(constructed)); // I assume there is only one implementation for the given type
            //var constructorToCall = typeToImplement.GetConstructors().First(); // I assume there is one constructor
            //var cmd = constructorToCall.Invoke(new object[0]); // I assume there is no parameter

            //var cmd = (ICommandHandler<T, TRet>)Activator.CreateInstance(typeToImplement);

            //return cmd.Handle(input);         
        }
    }
}