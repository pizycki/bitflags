using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitFlags
{
    [Flags]
    public enum AccessRights
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4,
        Full = Read | Write | Execute
    }

    /// <summary>
    /// Extending methods.
    /// </summary>
    public static class AccessRightsExt
    {

        /// <summary>
        /// Checks for the presence of rights in rights set.
        /// </summary>
        /// <param name="rights">Rights set</param>
        /// <param name="toCheck">Rights to check.</param>
        /// <returns>True when all rights are contained.</returns>
        public static bool Has(this AccessRights rights, AccessRights toCheck)
        {
            return rights.HasFlag(toCheck);
        }

        /// <summary>
        /// Checks for the rights set equality.
        /// </summary>
        /// <param name="rights0">Rights set.</param>
        /// <param name="rights">Rights set.</param>
        /// <returns>Are both sets equal.</returns>
        public static bool Is(this AccessRights rights0, AccessRights rights)
        {
            return rights0 == rights;
        }

        /// <summary>
        /// Joins two sets of rights and returns updated set.
        /// </summary>
        /// <param name="rights">Base rights set.</param>
        /// <param name="toAdd">Rights set.</param>
        /// <returns>Updated rights set.</returns>
        public static AccessRights Join(this AccessRights rights, AccessRights toAdd)
        {
            return rights | toAdd;
        }

        /// <summary>
        /// Adds rights set to existing set.
        /// </summary>
        /// <param name="rights0">Existing set.</param>
        /// <param name="rightToAdd">Rights to add.</param>
        public static void Add(ref AccessRights rights, AccessRights rightToAdd)
        {
            rights |= rightToAdd;
        }

        /// <summary>
        /// Seperates one right set from another.
        /// </summary>
        /// <param name="rights0">Base rights set.</param>
        /// <param name="toRemove">Rights to remove.</param>
        public static AccessRights Seperate(this AccessRights rights, AccessRights toRemove)
        {
            return rights & ~toRemove;
        }

        /// <summary>
        /// Remove rights from existing set of rights.
        /// </summary>
        /// <param name="rights0">Existing set of rights.</param>
        /// <param name="toRemove">Rights to remove.</param>
        public static void Remove(ref AccessRights rights, AccessRights toRemove)
        {
            rights &= ~toRemove;
        }

        /// <summary>
        /// Converts rights set from binary format to enum represantation.
        /// </summary>
        /// <param name="bitsAsDec">Binary.</param>
        /// <returns>Enum.</returns>
        public static AccessRights ConvertFromBits(int bitsAsDec)
        {
            return (AccessRights)Enum.ToObject(typeof(AccessRights), bitsAsDec);
        }

        /// <summary>
        /// Converts from enum to binary.
        /// </summary>
        /// <param name="rights">Enum</param>
        /// <returns></returns>
        public static int ConvertToBits(this AccessRights rights)
        {
            return (int)rights;
        }
    }
}