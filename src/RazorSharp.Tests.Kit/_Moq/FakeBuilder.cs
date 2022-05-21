namespace RazorSharp.Tests.Kit._Moq;

using RazorSharp.Core.Contracts;

public sealed partial class Fake
{
    public sealed class FakeBuilder<T>
        where T : class
    {
        private readonly IList<Action<Mock<T>>> _customizers = new List<Action<Mock<T>>>();

        public T Build()
        {
            var fake = Mock.Of<T>();
            var fakeSetup = Mock.Get(fake);

            foreach (var customizer in _customizers)
            {
                customizer(fakeSetup);
            }

            return fake;
        }

        public FakeBuilder<T> Customize(ICustomization<T> customization)
        {
            Precondition.IsNotNull(customization);

            _customizers.Add(customization.Configure);

            return this;
        }
    }
}