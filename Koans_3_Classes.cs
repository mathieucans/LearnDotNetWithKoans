using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace LearnDotNet
{
    public class Koans_3_Classes : Koan
    {
        [Fact]
        public void create_class_that_implement_IPerson_intefrace()
        {
            var person = FILL_ME_IN;

            person.Should().BeAssignableTo<IPerson>();
        }
        
        [Fact]
        public void add_a_readonly_property_Name_to_class_person_initialized_to_unnamed()
        {
            var person = FILL_ME_IN;

            var nameProperty = person.GetType().GetProperty("Name");
            
            nameProperty.CanRead.Should().Be(true);
            nameProperty.CanWrite.Should().Be(false);
            var propertyValue = InvokeMember(person, nameProperty);
            propertyValue.Should().Be("Unnamed");
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

    public interface IPerson
    {
        string SayHello();
    }
}