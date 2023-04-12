using APSAPITest.DM.Fixtures;
using Autodesk.PlatformServices.DM;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Systems.DataBuilders
{
    public class DMDataBuilderTests
    {

        #region UseStorageLocation
        [Fact]
        public void UseStorageLocation_1_OnSuccess_ReturnsDataBuilder()
        {
            //Arrange
            var fileName = ProjectsFixtures.RightFileName();
            var folderId = ProjectsFixtures.RightFolderId();

            var sut = new DMDataBuilder();

            //Act
            var result = sut.UseStorageLocation(fileName, folderId);

            //Assert
            result.Should().BeOfType<DMDataBuilder>();
        }

        #endregion

        #region UseFolder

        [Fact]
        public void UseFolder_1_OnSuccess_ReturnsDataBuilder()
        {
            //Arrange
            var folderName = FoldersFixtures.RightFolderName();
            var folderId = ProjectsFixtures.RightFolderId();

            var sut = new DMDataBuilder();

            //Act
            var result = sut.UseFolder(folderName, folderId);

            //Assert
            result.Should().BeOfType<DMDataBuilder>();
        }

        #endregion

        #region UseItem

        [Fact]
        public void UseItem_1_OnSuccess_ReturnsDataBuilder()
        {
            //Arrange
            var storageId = ProjectsFixtures.RightStorageLocation().Id;
            var folderId = ProjectsFixtures.RightFolderId();
            var fileName = ItemsFixtures.RightFileName();

            var sut = new DMDataBuilder();

            //Act
            var result = sut.UseItem(fileName, folderId, storageId);

            //Assert
            result.Should().BeOfType<DMDataBuilder>();
        }

        #endregion

        #region UseBucket


        [Fact]
        public void UseBucket_1_OnSuccess_ReturnsDataBuilder()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;

            var sut = new DMDataBuilder();

            //Act
            var result = sut.UseBucket(bucketKey, policyKey);

            //Assert
            result.Should().BeOfType<DMDataBuilder>();
        }

        #endregion
    }
}
