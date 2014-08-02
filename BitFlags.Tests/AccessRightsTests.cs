using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitFlags.Tests
{
    [TestClass]
    public class AccessRightsTests
    {
        [TestClass]
        public class Has
        {
            [TestMethod]
            public void Should_check_that_the_object_has_the_flag_and_return_true()
            {
                // Arrange 
                AccessRights rights = AccessRights.Read;

                // Act
                bool hasFlag = rights.Has(AccessRights.Read);

                // Assert
                Assert.IsTrue(hasFlag);
            }

            [TestMethod]
            public void Should_check_that_the_object_has_the_flag_and_return_false()
            {
                // Arrange 
                AccessRights rights = AccessRights.None;

                // Act
                bool hasFlag = rights.Has(AccessRights.Read);

                // Assert
                Assert.IsFalse(hasFlag);
            }

            [TestMethod]
            public void Should_check_that_object_has_multiple_flags()
            {
                // Arrange
                AccessRights rights = AccessRights.Read | AccessRights.Write;

                // Act
                bool canRead = rights.Has(AccessRights.Read);
                bool canWrite = rights.Has(AccessRights.Write);
                bool canExec = rights.Has(AccessRights.Execute);

                // Assert
                Assert.IsTrue(canRead);
                Assert.IsTrue(canWrite);
                Assert.IsFalse(canExec);
            }

            [TestMethod]
            public void Should_check_that_object_has_full_rights_and_return_true_ver1()
            {
                // Arrange
                AccessRights rights = AccessRights.Read | AccessRights.Write | AccessRights.Execute;

                // Act
                bool canRead = rights.Has(AccessRights.Read);
                bool canWrite = rights.Has(AccessRights.Write);
                bool canExec = rights.Has(AccessRights.Execute);
                bool fullRights = rights.Has(AccessRights.Full);

                // Assert
                Assert.IsTrue(canRead);
                Assert.IsTrue(canWrite);
                Assert.IsTrue(canExec);
                Assert.IsTrue(fullRights);
            }

            [TestMethod]
            public void Should_check_that_object_has_full_rights_and_return_true_ver2()
            {
                // Arrange
                AccessRights rights = AccessRights.Full;

                // Act
                bool canRead = rights.Has(AccessRights.Read);
                bool canWrite = rights.Has(AccessRights.Write);
                bool canExec = rights.Has(AccessRights.Execute);
                bool fullRights = rights.Has(AccessRights.Full);

                // Assert
                Assert.IsTrue(canRead);
                Assert.IsTrue(canWrite);
                Assert.IsTrue(canExec);
                Assert.IsTrue(fullRights);
            }

            [TestMethod]
            public void Should_check_that_object_has_full_rights_and_return_false()
            {
                // Arrange
                AccessRights rights = AccessRights.Read | AccessRights.Write;

                // Act
                bool canRead = rights.Has(AccessRights.Read);
                bool canWrite = rights.Has(AccessRights.Write);
                bool canExec = rights.Has(AccessRights.Execute);
                bool fullRights = rights.Has(AccessRights.Full);

                // Assert
                Assert.IsTrue(canRead);
                Assert.IsTrue(canWrite);
                Assert.IsFalse(canExec);
                Assert.IsFalse(fullRights);
            }
        }

        [TestClass]
        public class Is
        {
            [TestMethod]
            public void Should_check_has_no_rights_and_return_true()
            {
                // Arrange
                var rights = AccessRights.None;

                // Act
                bool noRights = rights.Is(AccessRights.None);

                // Assert
                Assert.IsTrue(noRights);
            }

            [TestMethod]
            public void Should_check_has_no_rights_and_return_false()
            {
                // Arrange
                var rights = AccessRights.None | AccessRights.Read;

                // Act
                bool noRights = rights.Is(AccessRights.None);

                // Assert
                Assert.IsFalse(noRights);
            }

            [TestMethod]
            public void Should_check_has_the_same_flags_and_return_true_ver1()
            {
                // Arrange
                var rights = AccessRights.Write;

                // Act
                bool isWrite = rights.Is(AccessRights.Write);

                // Assert
                Assert.IsTrue(isWrite);
            }

            [TestMethod]
            public void Should_check_has_the_same_flags_and_return_true_ver2()
            {
                // Arrange
                var rights = AccessRights.Write | AccessRights.None;

                // Act
                bool isWrite = rights.Is(AccessRights.Write);

                // Assert
                Assert.IsTrue(isWrite);
            }

            [TestMethod]
            public void Should_check_has_the_same_flags_and_return_false_ver1()
            {
                // Arrange
                var rights = AccessRights.Write | AccessRights.Execute;

                // Act
                bool isWrite = rights.Is(AccessRights.Write);

                // Assert
                Assert.IsFalse(isWrite);
            }

            [TestMethod]
            public void Should_check_has_the_same_flags_and_return_false_ver2()
            {
                // Arrange
                var rights = AccessRights.Execute;

                // Act
                bool isWrite = rights.Is(AccessRights.Write);

                // Assert
                Assert.IsFalse(isWrite);
            }

            [TestMethod]
            public void Should_check_are_rights_the_same_and_return_true()
            {
                // Arrange
                var rights1 = AccessRights.Read | AccessRights.Write;
                var rights2 = AccessRights.Read | AccessRights.Write;

                // Act
                bool areSame = rights1.Is(rights2);

                // Assert
                Assert.IsTrue(areSame);
            }

            [TestMethod]
            public void Should_check_are_rights_the_same_and_return_false()
            {
                // Arrange
                var rights1 = AccessRights.Read | AccessRights.Write;
                var rights2 = AccessRights.Execute | AccessRights.Write;

                // Act
                bool areSame = rights1.Is(rights2);

                // Assert
                Assert.IsFalse(areSame);
            }
        }

        [TestClass]
        public class Add
        {
            [TestClass]
            public class WithReturn
            {
                [TestMethod]
                public void Should_add_single_flag()
                {
                    // Arrange
                    AccessRights rights = AccessRights.None;

                    // Act
                    rights = rights.Join(AccessRights.Read);

                    // Assert
                    Assert.IsTrue(rights.Is(AccessRights.Read));
                }

                [TestMethod]
                public void Should_add_single_flag_multiple_times()
                {
                    // Arrange
                    AccessRights rights = AccessRights.None;

                    // Act
                    rights = rights.Join(AccessRights.Read);
                    rights = rights.Join(AccessRights.Read);

                    // Assert
                    Assert.IsTrue(rights.Is(AccessRights.Read));
                }

                [TestMethod]
                public void Should_add_set_of_rights()
                {
                    // Arrange
                    var rights = AccessRights.Execute;
                    var rightsToAdd = AccessRights.Read | AccessRights.Write;

                    // Act
                    rights = rights.Join(rightsToAdd);

                    // Assert
                    Assert.IsTrue(rights.Has(AccessRights.Full));
                }

                [TestMethod]
                public void Should_add_multiple_flags()
                {
                    // Arrange
                    AccessRights rights = AccessRights.None;

                    // Act
                    rights = rights.Join(AccessRights.Read);
                    rights = rights.Join(AccessRights.Write);
                    rights = rights.Join(AccessRights.None);

                    // Assert
                    Assert.IsTrue(rights.Has(AccessRights.Write));
                    Assert.IsTrue(rights.Has(AccessRights.Read));
                    Assert.IsFalse(rights.Is(AccessRights.None));
                    Assert.IsFalse(rights.Is(AccessRights.Full));
                }
            }

            [TestClass]
            public class ByReference
            {
                [TestMethod]
                public void Should_add_single_flag_by_ref()
                {
                    // Arrange
                    AccessRights rights = AccessRights.None;

                    // Act
                    AccessRightsExt.Add(ref rights, AccessRights.Read);

                    // Assert
                    Assert.IsTrue(rights.Is(AccessRights.Read));
                }

                [TestMethod]
                public void Should_add_single_flag_multiple_times()
                {
                    // Arrange
                    AccessRights rights = AccessRights.None;

                    // Act
                    AccessRightsExt.Add(ref rights, AccessRights.Read);
                    AccessRightsExt.Add(ref rights, AccessRights.Read);

                    // Assert
                    Assert.IsTrue(rights.Is(AccessRights.Read));
                }

                [TestMethod]
                public void Should_add_set_of_rights()
                {
                    // Arrange
                    var rights = AccessRights.Execute;
                    var rightsToAdd = AccessRights.Read | AccessRights.Write;

                    // Act
                    AccessRightsExt.Add(ref rights, rightsToAdd);

                    // Assert
                    Assert.IsTrue(rights.Has(AccessRights.Full));
                }

                [TestMethod]
                public void Should_add_multiple_flags()
                {
                    // Arrange
                    AccessRights rights = AccessRights.None;

                    // Act
                    AccessRightsExt.Add(ref rights, AccessRights.Read);
                    AccessRightsExt.Add(ref rights, AccessRights.Write);
                    AccessRightsExt.Add(ref rights, AccessRights.None);

                    // Assert
                    Assert.IsTrue(rights.Has(AccessRights.Write));
                    Assert.IsTrue(rights.Has(AccessRights.Read));
                    Assert.IsFalse(rights.Is(AccessRights.None));
                    Assert.IsFalse(rights.Is(AccessRights.Full));
                }
            }
        }

        [TestClass]
        public class Remove
        {
            [TestClass]
            public class WithReturn
            {
                [TestMethod]
                public void Should_remove_single_flag()
                {
                    // Arrange
                    var rights = AccessRights.Read | AccessRights.Write;

                    // Act
                    rights = rights.Seperate(AccessRights.Read);

                    //Assert
                    Assert.IsTrue(rights.Is(AccessRights.Write));
                }

                [TestMethod]
                public void Should_remove_single_flag_multiple_times()
                {
                    // Arrange
                    var rights = AccessRights.Read | AccessRights.Write;

                    // Act
                    rights = rights.Seperate(AccessRights.Read);
                    rights = rights.Seperate(AccessRights.Read);
                    rights = rights.Seperate(AccessRights.Read);

                    // Assert
                    Assert.IsTrue(rights.Is(AccessRights.Write));
                }

                [TestMethod]
                public void Should_remove_the_only_flag()
                {
                    // Arrange
                    var rights = AccessRights.Read;
                    // Act
                    rights = rights.Seperate(AccessRights.Read);
                    // Assert
                    Assert.IsTrue(rights.Is(AccessRights.None));
                }

                [TestMethod]
                public void Should_remove_missing_flag()
                {
                    // Arrange
                    var rights = AccessRights.None;
                    // Act
                    rights = rights.Seperate(AccessRights.Read);
                    // Assert
                    Assert.IsTrue(rights.Is(AccessRights.None));
                }

                [TestMethod]
                public void Should_remove_multiple_flags()
                {
                    // Arrange
                    var rights = AccessRights.Full;
                    //Act
                    rights = rights.Seperate(AccessRights.Read);
                    rights = rights.Seperate(AccessRights.Execute);
                    //Assert
                    Assert.IsTrue(rights.Is(AccessRights.Write));
                }
            }

            [TestClass]
            public class ByReference
            {

                [TestMethod]
                public void Should_remove_single_flag()
                {
                    // Arrange
                    var rights = AccessRights.Read | AccessRights.Write;

                    // Act
                    AccessRightsExt.Remove(ref rights, AccessRights.Read);

                    //Assert
                    Assert.IsTrue(rights.Is(AccessRights.Write));
                }

                [TestMethod]
                public void Should_remove_single_flag_multiple_times()
                {
                    // Arrange
                    var rights = AccessRights.Read | AccessRights.Write;

                    // Act
                    AccessRightsExt.Remove(ref rights, AccessRights.Read);
                    AccessRightsExt.Remove(ref rights, AccessRights.Read);
                    AccessRightsExt.Remove(ref rights, AccessRights.Read);

                    // Assert
                    Assert.IsTrue(rights.Is(AccessRights.Write));
                }

                [TestMethod]
                public void Should_remove_the_only_flag()
                {
                    // Arrange
                    var rights = AccessRights.Read;
                    // Act
                    AccessRightsExt.Remove(ref rights, AccessRights.Read);
                    // Assert
                    Assert.IsTrue(rights.Is(AccessRights.None));
                }

                [TestMethod]
                public void Should_remove_missing_flag()
                {
                    // Arrange
                    var rights = AccessRights.None;
                    // Act
                    AccessRightsExt.Remove(ref rights, AccessRights.Read);
                    // Assert
                    Assert.IsTrue(rights.Is(AccessRights.None));
                }

                [TestMethod]
                public void Should_remove_multiple_flags()
                {
                    // Arrange
                    var rights = AccessRights.Full;
                    //Act
                    AccessRightsExt.Remove(ref rights, AccessRights.Read);
                    AccessRightsExt.Remove(ref rights, AccessRights.Execute);
                    //Assert
                    Assert.IsTrue(rights.Is(AccessRights.Write));
                }
            }
        }

        [TestClass]
        public class Convert
        {
            [TestMethod]
            public void Should_convert_from_binary_single()
            {
                // Arrange 
                int read = (int)AccessRights.Read;
                // Act
                AccessRights rights = AccessRightsExt.ConvertFromBits(read);
                // Assert
                Assert.IsTrue(rights.Is(AccessRights.Read));
            }

            [TestMethod]
            public void Should_convert_from_binary_multi()
            {
                // Arrange 
                int read = (int)AccessRights.Read;
                int write = (int)AccessRights.Write;
                int readAndWrite = read + write;
                // Act
                AccessRights rights = AccessRightsExt.ConvertFromBits(readAndWrite);
                // Assert
                var expected = AccessRights.Read | AccessRights.Write;
                Assert.IsTrue(rights.Is(expected));
            }

            [TestMethod]
            public void Should_convert_to_binary_single()
            {
                //Arrange
                var rights = AccessRights.Write;
                //Act
                int bin = rights.ConvertToBits();
                //Assert
                int expected = (int)AccessRights.Write;
                Assert.AreEqual<int>(bin, expected);
            }

            [TestMethod]
            public void Should_convert_to_binary_multi()
            {
                //Arrange
                var rights = AccessRights.Write | AccessRights.Execute;
                //Act
                int bin = rights.ConvertToBits();
                //Assert
                int expected = (int)AccessRights.Write + (int)AccessRights.Execute;
                Assert.AreEqual<int>(bin, expected);
            }
        }
    }
}