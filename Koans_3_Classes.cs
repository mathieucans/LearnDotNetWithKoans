using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace LearnDotNet
{
    public class Koans_3_Classes
    {
        [Fact]
        public void create_class_that_implement_IPerson_intefrace()
        {
            var newClass = new object();

            newClass.Should().BeAssignableTo<IPerson>();
        }
        
        [Fact]
        public void add_a_readonly_property_Name_to_class_person()
        {
            var newClass = new object();

            var type = newClass.GetType();
            var properties = type.GetProperties();
            var nameProperty = properties.First(p => p.Name == "Name");
            nameProperty.CanRead.Should().Be(true);
            nameProperty.CanWrite.Should().Be(false);
            var value = type.InvokeMember("Name", BindingFlags.GetProperty, Type.DefaultBinder, newClass, null);
            value.Should().Be("John");
        }    
    }

    public interface IPerson
    {
        string SayHello();
    }
}