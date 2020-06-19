using System;
using System.Reflection;
using FluentAssertions;

namespace LearnDotNet.utils
{
    public static class PropertyInfoExtensions {
        public static PropertyInfo CanBeRead(this PropertyInfo nameProperty)
        {
            nameProperty.CanRead.Should().Be(true);
            return nameProperty;
        }
        public static PropertyInfo Named(this PropertyInfo nameProperty, string name)
        {
            nameProperty.Name.Should().Be(name);
            return nameProperty;
        }
        public static object ReadValueOnInstance(this PropertyInfo nameProperty, object instance)
        {
            return InvokeMember(instance, nameProperty);
        }
        public static PropertyInfo HasPrivateSetterIfAny(this PropertyInfo nameProperty)
        {
            nameProperty.SetMethod?.IsPublic.Should().BeFalse();
            return nameProperty;
        }
      
          
        private static object InvokeMember(object person, PropertyInfo propertyInfo)
        {
            return person.GetType()
                .InvokeMember(propertyInfo.Name,
                    BindingFlags.GetProperty,
                    Type.DefaultBinder,
                    person,
                    null);
        }

    }
}