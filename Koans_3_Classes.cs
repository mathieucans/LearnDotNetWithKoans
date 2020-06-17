using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using FluentAssertions.Primitives;
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
        public void add_a_readonly_property_Name_to_class_person_initialized_with_unnamed()
        {
            var person = FILL_ME_IN;

            var nameProperty = person.GetType().GetProperty("Name");
            
            nameProperty.Named("Name")
                .CanBeRead()
                .HasPrivateSetterIfAny()
                .ReadValueOnInstance(person).Should().Be("Unnamed");
        }
    }
    
    public interface IPerson
    {
        string SayHello();
    }
}