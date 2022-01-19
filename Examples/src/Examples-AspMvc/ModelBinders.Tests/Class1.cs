using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ModelBinders.Controllers;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ModelBinders.Tests
{
  [TestFixture]
  public class GoodPracticeControllerTest
  {
    private PrincipalGoodPracticeController _sut;
    private Mock<IPrincipal> _principalMock;
    private Mock<IIdentity> _identityMock;

    [SetUp]
    public void Setup()
    {
      _sut = new PrincipalGoodPracticeController();
      _principalMock = new Mock<IPrincipal>();
      _identityMock = new Mock<IIdentity>();
      _principalMock.Setup(f => f.Identity).Returns(_identityMock.Object);

    }

    [Test]
    public void Index_should_return_authenticated_view_when_user_is_authenticated()
    {
      // Arrange
      _identityMock.Setup(f => f.IsAuthenticated).Returns(true);

      // Act
      var result = _sut.Index(_principalMock.Object);

      // Assert
      Assert.AreEqual("Authenticated",(result as ViewResult).ViewName);

    }

    [Test]
    public void Index_should_return_not_authenticated_view_when_user_is_not_authenticated()
    {
      // Arrange
      _identityMock.Setup(f => f.IsAuthenticated).Returns(false);

      // Act
      var result = _sut.Index(_principalMock.Object);

      // Assert
      Assert.AreEqual("NotAuthenticated", (result as ViewResult).ViewName);
    }
  }
}
