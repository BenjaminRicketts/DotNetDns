using System;
using System.Linq.Expressions;
using Moq;

namespace DotNetDns.TestHelpers
{
    public class Mocker<TENTITY> where TENTITY : class
    {
        private Mock<TENTITY> _mock;

        public Mocker()
        {
            _mock = new Mock<TENTITY>();
        }

        public Mocker<TENTITY> AssertWasCalledOnce<TVALUE>(Expression<Func<TENTITY, TVALUE>> property)
        {
            _mock.Verify(property, Times.Once());
            return this;
        }

        public Mocker<TENTITY> AssertWasCalledOnce(Expression<Action<TENTITY>> action)
        {
            _mock.Verify(action, Times.Once());
            return this;
        }

        public TENTITY ToEntity() 
        {
            return _mock.Object;
        }

        public Mocker<TENTITY> With<TVALUE>(Expression<Func<TENTITY, TVALUE>> property, TVALUE value)
        {
            _mock.Setup(property).Returns(value);

            return this;
        }
    }
}