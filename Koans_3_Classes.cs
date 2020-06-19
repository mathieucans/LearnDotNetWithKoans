using System;
using FluentAssertions;
using LearnDotNet.utils;
using Xunit;

namespace LearnDotNet
{
    internal class Person
    {
    }

    public class Koans_3_Classes : Koan
    {
        [Fact]
        public void k01_a_person_has_a_name_property_that_cant_be_set()
        {
            var person = CreatePerson<object>();

            var nameProperty = person.GetType().GetProperty("Name");

            nameProperty.Named("Name")
                .CanBeRead()
                .HasPrivateSetterIfAny()
                .ReadValueOnInstance(person).Should().Be("Unnamed");
        }

        [Fact]
        public void k02_a_person_implement_IPerson_interface()
        {
            var person = CreatePerson<object>();

            person.Should().BeAssignableTo<IPerson>();
        }

        [Fact]    
        public void k03_when_a_person_is_batised_its_name_is_set()
        {
            IPerson person = CreatePerson<IPerson>();

            person.Baptize("Jo");

            person.Name.Should().Be("Jo");
        }

        [Fact]
        public void k04_a_person_let_its_observer_known_that_its_properties_change_by_implement_ISubject()
        {
            var person = CreatePerson<IPerson>();

            person.Should().BeAssignableTo<ISubject>();
        }

        [Fact]
        public void k05_when_a_person_is_batised_it_is_notified()
        {
            IPerson person = CreatePerson<IPerson>();
            var subject = person as ISubject;
            var notified = false;
            subject.NameChanged += (person, args) => { notified = true; };

            person.Baptize("Jo");

            notified.Should().BeTrue();
        }

        private T CreatePerson<T>() where T : class
        {
            return new Person() as T;
        }
    }

    public interface ISubject
    {
        event EventHandler NameChanged;
    }

    public interface IPerson
    {
        string Name { get; }
        void Baptize(string name);
    }
}