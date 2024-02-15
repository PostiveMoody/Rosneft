using Rosneft.Domain;
using Rosneft.Domain.Exceptions;

namespace Rosneft.Tests
{
    [TestClass]
    public class DomainTests
    {
        /// <summary>
        /// Naming Convention - ClassName_MethodName_ExpectedResult
        /// </summary>
        [TestMethod("RequestCard_Save_PositiveScenario")]
        public void RequestCard_Save_CardSaved()
        {
            // Arrange
            var now = DateTime.Now;
            var initator = "Иванов Иван";
            var subjectOfAppeal = "Не работает чат поддержки";
            var description = "Не работает чат поддержки банка при нажатии на иконку";
            var deadlineForHiring = DateTime.Now.AddDays(10);
            var category = RequestCategory.Сomplaint;

            // Act 
            var requestCard = RequestCard.Save(
               now,
               initator,
               subjectOfAppeal,
               description,
               deadlineForHiring,
               category);

            // Assert
            Assert.IsNotNull(requestCard);
        }

        /// <summary>
        /// Naming Convention - ClassName_MethodName_ExpectedResult
        /// </summary>
        [ExpectedException(typeof(DomainException))]
        [TestMethod("RequestCard_Save_NegaitiveScenario")]
        public void RequestCard_Save_CardNotSaved()
        {
            // Arrange
            var now = DateTime.MinValue;
            var initator = "Иванов Иван";
            var subjectOfAppeal = "Не работает чат поддержки";
            var description = "Не работает чат поддержки банка при нажатии на иконку";
            var deadlineForHiring = DateTime.Now.AddDays(10);
            var category = RequestCategory.Сomplaint;

            // Act 
            var requestCard = RequestCard.Save(
               now,
               initator,
               subjectOfAppeal,
               description,
               deadlineForHiring,
               category);

            // Assert
        }

    }
}