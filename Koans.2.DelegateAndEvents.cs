using System;
using System.IO;
using FluentAssertions;
using LearnDotNet.utils;
using Xunit;

namespace LearnDotNet
{
    public class Koans_2_DelegateAndEvents : Koan
    {
        delegate string GetYourName();

        delegate void SayYourName();

        class Person
        {
            private string _name;

            public event Action<string> NameChanged;

            public Person(string name)
            {
                _name = name;
            }

            public string GetName()
            {
                return _name;
            }

            public void SetName(string name)
            {
                _name = name;
                NameChanged?.Invoke(name);
            }

            public void SayYourName()
            {
                Console.WriteLine($"My name is {_name}");
            }
        }

        private Person _bastien = new Person("Bastien");

        private Person _emeric = new Person("Emeric");

        static string MyNameIsThomas() => "Thomas";

        [Fact]
        public void delegates_can_be_assigned_to_static_function()
        {
            GetYourName myNameIsGet = AFFECT_ME();

            myNameIsGet().Should().Be("Joe");
        }

        [Fact]
        public void delegate_can_be_assigned_to_object_method()
        {
            GetYourName myNameIsGet = AFFECT_ME();

            myNameIsGet().Should().Be("Bastien");
        }

        [Fact]
        public void delegate_can_be_assigned_to_lambda()
        {
            GetYourName myNameIsGet = () => "Mathieu";

            myNameIsGet().Should().Be("FILL_ME_IN");
        }

        [Fact]
        public void delegate_have_invocation_list()
        {
            using (var console = new ConsoleCapture())
            {
                SayYourName sayYourName = _bastien.SayYourName;
                sayYourName += _emeric.SayYourName;

                sayYourName();

                console.ToString().Should().Be("FILL_ME_IN");
            }
        }

        [Fact]
        public void but_only_the_last_one_returns()
        {
            GetYourName chainedName = _bastien.GetName;

            chainedName += _emeric.GetName;

            chainedName().Should().Be("FILL_ME_IN");
        }
        
        [Fact]
        public void events_are_delegates_with_restrictions()
        {
            using (var console = new ConsoleCapture())
            {
                var newBorn = new Person("baby");
                newBorn.NameChanged += (name) => Console.WriteLine($"{name} is born!");

                newBorn.SetName("Imen");

                console.ToString().Should().Be("FILL ME IN");
                
                // newBorn.NameChanged = (n) => { Console.WriteLine("you cannot affect an event with operator equal" );}
                // newBorn.NameChanged(); // you cannot invoke event from outside it class
            }
        }
        
        // TODO Event are null until they are affected
        

        private static StringWriter CaptureConsole()
        {
            var console = new StringWriter();
            Console.SetOut(console);
            return console;
        }

        private GetYourName AFFECT_ME()
        {
            throw new NotImplementedException();
        }
    }
}