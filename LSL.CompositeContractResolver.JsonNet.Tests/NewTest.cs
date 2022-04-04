using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace LSL.CompositeContractResolver.JsonNet.Tests
{
    public class NewTest
    {
        [Test]
        public void Blah()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new MyTest() { NamingStrategy = new CamelCaseNamingStrategy() }                
            };

            var x = JsonConvert.SerializeObject(new [] { new Test { Value1 = 12, Value2 = 23 }, new Test { Value1 = 22, Value2 = 33 } }, Formatting.Indented, settings);
            var y = JsonConvert.DeserializeObject<IEnumerable<Test>>(x, settings);
            ICompositeContractResolverBuilder builder = new CompositeConCompositeContractResolverBuilder();
            
            builder.Build(c => c.AddResolver(builder.Build(null)));
            x = JsonConvert.SerializeObject(new Test { Value1 = 12, Value2 = 23 }, Formatting.Indented, settings);
            Console.Write(x);
        }

        [TestCase("qwe", 1, "q*****")]
        [TestCase("qw", 2, "qw*****")]
        [TestCase("qw", 3, "qw*****")]
        [TestCase("qwe", -1, "*****e")]
        [TestCase("qw", -2, "*****qw")]       
        [TestCase("qw", -3, "*****qw")]
        public void Blah2(string i, int o, string expectedResult)
        {
            string Obfuscate(string input, int offset)
            {
                if (offset < 0) return "*****" + input.Substring(input.Length - (Math.Min(Math.Abs(offset), input.Length)));

                return input.Substring(0, Math.Min(offset, input.Length)) + "*****";
            }

            Obfuscate(i, o).Should().Be(expectedResult);
        }

        public class TotalAttribute : Attribute
        {
            private readonly string _targetTotalProperty;

            public TotalAttribute(string targetTotalProperty)
            {
                _targetTotalProperty = targetTotalProperty;
            }
        }

        public class Test
        {
            [Total("Total")]
            public int Value1 { get; set; }

            [Total("Total")]
            public int Value2 { get; set; }
        }

        private class DelegatingValueProvider : IValueProvider
        {
            private readonly Func<object, object> _getter;
            private readonly Action<object, object> _setter;

            public DelegatingValueProvider(Func<object, object> getter, Action<object, object> setter = null)
            {
                _getter = getter;
                _setter = setter;
            }

            public object GetValue(object target)
            {
                return _getter(target);
            }

            public void SetValue(object target, object value)
            {
                _setter?.Invoke(target, value);
            }
        }
        private class MyTest : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                return base.CreateProperty(member, memberSerialization);
            }

            protected override JsonObjectContract CreateObjectContract(Type objectType)
            {
                return base.CreateObjectContract(objectType);
            }
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var result = base.CreateProperties(type, memberSerialization);
                
                result.Add( new JsonProperty {
                    PropertyName = "Total",
                    ValueProvider = new DelegatingValueProvider(target => result.Where(t => t.PropertyType == typeof(int) && t.PropertyName != "Total").Select(t => (int)t.ValueProvider.GetValue(target)).Aggregate((t1, t2) => t1 + t2)),
                    DeclaringType = type,
                    PropertyType = typeof(int),
                    Readable = true,
                    Writable = false                    
                });
                
                return result;
            }
        }
    }
}