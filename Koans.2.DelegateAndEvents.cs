using System;
using FluentAssertions;
using Xunit;

namespace LearnDotNet
{
    public class Koans_2_DelegateAndEvents : Koan
    {
        delegate string WhatsYourName();
        [Fact]
        public void delegates_are_objects()
        {
            typeof(WhatsYourName).Should().BeAssignableTo<object>();
        }

        static string MyNameIsJoe() => "Joe";
        
        [Fact]
        public void delegates_can_be_assigned_to_static_function()
        {
            WhatsYourName myNameIsWhat = AFFECT_ME();

            myNameIsWhat().Should().Be("Joe");
        }

        class Person
        {
            private string _name;

            public Person(string name)
            {
                _name = name;
            }
            public string SayName()
            {
                return _name;
            }
        }
        
        [Fact]
        public void delegate_can_be_assigned_to_object_funciton()
        {
            var bastien = new Person("Bastien");

            WhatsYourName myNameIsWhat = AFFECT_ME();

            myNameIsWhat().Should().Be("Bastien");
        }

        private WhatsYourName AFFECT_ME()
        {
            throw new NotImplementedException();
        }
    }
}