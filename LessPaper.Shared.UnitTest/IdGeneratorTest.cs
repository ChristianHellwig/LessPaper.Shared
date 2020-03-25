using System;
using System.Collections.Generic;
using System.Text;
using LessPaper.Shared.Enums;
using LessPaper.Shared.Helper;
using Xunit;

namespace LessPaper.Shared.UnitTest
{

    public class IdGeneratorTest
    {
        [Fact]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Assertions", 
            "xUnit2017:Do not use Contains() to check if a value exists in a collection", Justification = "Faster test")]
        public void UniqueId()
        {
            var generatedIds = new HashSet<string>(10000 * 3);
            for (var i = 0; i < 10000; i++)
            {
                var newFileId = IdGenerator.NewId(IdType.File);
                Assert.False(generatedIds.Contains(newFileId));
                Assert.Equal(IdGenerator.IdLength, newFileId.Length);
                generatedIds.Add(newFileId);

                var newDirectoryId = IdGenerator.NewId(IdType.Directory);
                Assert.False(generatedIds.Contains(newDirectoryId));
                Assert.Equal(IdGenerator.IdLength, newDirectoryId.Length);
                generatedIds.Add(newDirectoryId);

                var newUndefinedId = IdGenerator.NewId(IdType.Undefined);
                Assert.False(generatedIds.Contains(newUndefinedId));
                Assert.Equal(IdGenerator.IdLength, newUndefinedId.Length);
                generatedIds.Add(newUndefinedId);
            }
        }


        [Fact]
        public void GetTypeFromId()
        {
            // Valid Ids
            var newFileId = IdGenerator.NewId(IdType.File);
            Assert.True(IdGenerator.TypeFromId(newFileId, out var typeOfId));
            Assert.Equal(IdType.File, typeOfId);
            
            var newDirectoryId = IdGenerator.NewId(IdType.Directory);
            Assert.True(IdGenerator.TypeFromId(newDirectoryId, out typeOfId));
            Assert.Equal(IdType.Directory, typeOfId);
            
            var newUndefinedId = IdGenerator.NewId(IdType.Undefined);
            Assert.True(IdGenerator.TypeFromId(newUndefinedId, out typeOfId));
            Assert.Equal(IdType.Undefined, typeOfId);


            // Check the length to ensure invalid ids are configured correct
            Assert.Equal(34, IdGenerator.IdLength);

            // Invalid Ids
            var invalidIdToShort = "000bf11826bbb44842ad90837989fbe2f";
            Assert.False(IdGenerator.TypeFromId(invalidIdToShort, out typeOfId));
            var invalidIdToLong = "000bf11826bbb44842ad90837989fbe2f5d";
            Assert.False(IdGenerator.TypeFromId(invalidIdToLong, out typeOfId));
            var invalidIdNoLeadingNumber = "XX0bf11826bbb44842ad90837989fbe2f5";
            Assert.False(IdGenerator.TypeFromId(invalidIdNoLeadingNumber, out typeOfId));
            var invalidIdNoTypeValidNumber = "990bf11826bbb44842ad90837989fbe2f5";
            Assert.False(IdGenerator.TypeFromId(invalidIdNoTypeValidNumber, out typeOfId));
        }

    }
}
