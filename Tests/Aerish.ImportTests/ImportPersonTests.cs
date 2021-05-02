using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Aerish.Application;
using Aerish.Commands.Imports;
using Aerish.Commands.JobInstanceCmds;
using Aerish.Constants;
using Aerish.DbMigration.InMemoryDatabase;
using Aerish.Domain.Common;
using Aerish.Domain.Entities.Common;
using Aerish.Imports;
using Aerish.Imports.Commands;
using Aerish.Imports.Commands.ImportCommands;
using Aerish.ImportTests.Common;
using Aerish.Infrastructure.Persistence;
using Aerish.Infrastructure.Persistence.Configurations;
using Aerish.Interfaces;
using Aerish.Queries.JobQrs;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using TasqR;

namespace Aerish.ImportTests
{
    [TestClass]
    public class ImportPersonTests : BaseAerishTests
    {
        [TestMethod]
        public void CanDetectInvalidFistName()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                #region Arrange
                var services = scope.ServiceProvider;

                var tasqR = services.GetService<ITasqR>();
                var dbContext = services.GetService<IAerishDbContext>();

                var data = new StringBuilder()
                    .AppendLine("TAX_ID,Employee_ID,FIRSTNAME,MIDDLENAME,LASTNAME")
                    .AppendLine("00001,1,,Gubantes,Dagpin");

                var mockTracker = new Mock<IProcessTracker>();

                mockTracker.Setup(a => a.ProcessInstanceID).Returns(1);
                #endregion

                #region Act
                var importResult = tasqR.Run(new ImportPersonCmd(mockTracker.Object, data.ToString()));
                var importEntry = importResult.FirstOrDefault();
                #endregion

                #region Assert
                Assert.AreEqual(1, importResult.Count());
                Assert.IsNotNull(importEntry);
                Assert.IsNull(importEntry.MappingError);
                Assert.IsFalse(mockTracker.Object.Aborted.GetValueOrDefault());
                Assert.AreEqual(1, dbContext.ValidationFailures.Count());
                Assert.IsTrue(importEntry.ImportIsValid);
                Assert.IsFalse(importEntry.ValidationIsValid);
                #endregion
            }
        }

        [TestMethod]
        public void CanDetectExistingTaxID()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                #region Arrange
                var services = scope.ServiceProvider;

                var tasqR = services.GetService<ITasqR>();
                var dbContext = services.GetService<IAerishDbContext>();

                dbContext.Persons.Add(new Person { TaxIdNumber = "00001" });
                dbContext.SaveChanges();

                var data = new StringBuilder()
                    .AppendLine("TAX_ID,Employee_ID,FIRSTNAME,MIDDLENAME,LASTNAME")
                    .AppendLine("00001,1,Vincent,Gubantes,Dagpin");

                var mockTracker = new Mock<IProcessTracker>();

                mockTracker.Setup(a => a.ProcessInstanceID).Returns(1);
                #endregion

                #region Act
                var importResult = tasqR.Run(new ImportPersonCmd(mockTracker.Object, data.ToString()));
                var importEntry = importResult.FirstOrDefault();
                #endregion

                #region Assert
                Assert.AreEqual(1, importResult.Count());
                Assert.IsNotNull(importEntry);
                Assert.IsNull(importEntry.MappingError);
                Assert.IsFalse(mockTracker.Object.Aborted.GetValueOrDefault());
                Assert.AreEqual(1, dbContext.ValidationFailures.Count());
                Assert.IsTrue(importEntry.ImportIsValid);
                Assert.IsFalse(importEntry.ValidationIsValid);
                #endregion
            }
        }

        [TestMethod]
        public void CanDetectIncompleteColumn()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                #region Arrange
                var services = scope.ServiceProvider;

                var tasqR = services.GetService<ITasqR>();

                var data = new StringBuilder()
                    .AppendLine("TAX_ID,FIRSTNAME,MIDDLENAME,LASTNAME")
                    .AppendLine("000001,Gubantes,Dagpin");

                var mockTracker = new Mock<IProcessTracker>();

                mockTracker.Setup(a => a.ProcessInstanceID).Returns(1);
                #endregion

                #region Act
                var importResult = tasqR.Run(new ImportPersonCmd(mockTracker.Object, data.ToString()));
                var importEntry = importResult.FirstOrDefault();
                #endregion

                #region Assert
                Assert.AreEqual(1, importResult.Count());
                Assert.IsNotNull(importEntry);
                Assert.IsNotNull(importEntry.MappingError);
                Assert.IsFalse(mockTracker.Object.Aborted.GetValueOrDefault());
                #endregion
            }
        }

        [TestMethod]
        public void CanDetectCompleteColumn()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                #region Arrange
                var services = scope.ServiceProvider;

                var tasqR = services.GetService<ITasqR>();

                var data = new StringBuilder()
                    .AppendLine("TAX_ID,Employee_ID,FIRSTNAME,MIDDLENAME,LASTNAME")
                    .AppendLine("00001,1,Vincent,Gubantes,Dagpin");

                var mockTracker = new Mock<IProcessTracker>();

                mockTracker.Setup(a => a.ProcessInstanceID).Returns(1);
                #endregion

                #region Act
                var importResult = tasqR.Run(new ImportPersonCmd(mockTracker.Object, data.ToString()));
                var importEntry = importResult.FirstOrDefault();
                #endregion

                #region Assert
                Assert.AreEqual(1, importResult.Count());
                Assert.IsNotNull(importEntry);
                Assert.IsNull(importEntry.MappingError);
                Assert.IsTrue(importEntry.ImportIsValid);
                Assert.IsFalse(mockTracker.Object.Aborted.GetValueOrDefault());
                #endregion
            }
        }

        [TestMethod]
        public void CanDisregardExtraEmptyLines()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                #region Arrange
                var services = scope.ServiceProvider;

                var tasqR = services.GetService<ITasqR>();

                var data = new StringBuilder()
                    .AppendLine("TAX_ID,Employee_ID,FIRSTNAME,MIDDLENAME,LASTNAME")
                    .AppendLine("")
                    .AppendLine("00001,1,Vincent,Gubantes,Dagpin")
                    .AppendLine("")
                    .AppendLine("");

                var mockTracker = new Mock<IProcessTracker>();

                mockTracker.Setup(a => a.ProcessInstanceID).Returns(1);
                #endregion

                #region Act
                var importResult = tasqR.Run(new ImportPersonCmd(mockTracker.Object, data.ToString()));
                var importEntry = importResult.FirstOrDefault();
                #endregion

                #region Assert
                Assert.AreEqual(1, importResult.Count());
                Assert.IsNotNull(importEntry);
                Assert.IsNull(importEntry.MappingError);
                Assert.IsTrue(importEntry.ImportIsValid);
                Assert.IsFalse(mockTracker.Object.Aborted.GetValueOrDefault());
                #endregion
            }
        }
    }
}
