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
            // Initialize delegate with static funciton
            WhatsYourName myNameIsWhat = null;

            myNameIsWhat().Should().Be("Joe");
        }
        
        
    }
}