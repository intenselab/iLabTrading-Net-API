// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Crc32Algorithm.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IntenseLab.Shared.Utils
{
    namespace Commons
    {
        /// <summary>
        ///     Implements a 32-bit CRC hash algorithm compatible with Zip etc.
        /// </summary>
        /// <remarks>
        ///     Crc32 should only be used for backward compatibility with older file formats
        ///     and algorithms. It is not secure enough for new applications.
        ///     If you need to call multiple times for the same data either use the HashAlgorithm
        ///     interface or remember that the result of one Compute call needs to be ~ (XOR) before
        ///     being passed in as the seed for the next Compute call.
        /// </remarks>
        public sealed class Crc32Algorithm : HashAlgorithm
        {
            private const uint DefaultPolynomial = 0xedb88320u;

            private const uint DefaultSeed = 0xffffffffu;

            private static uint[] defaultTable;

            private readonly uint seed;

            private readonly uint[] table;

            private uint hash;

            /// <summary>
            ///     Create new instance of <see cref="Crc32Algorithm"/> with default polynomial and seed values.
            /// </summary>
            public Crc32Algorithm()
                : this(DefaultPolynomial, DefaultSeed)
            {
            }

            /// <summary>
            ///     Create new instance of <see cref="Crc32Algorithm"/> with specified polynomial and seed values.
            /// </summary>
            /// <param name="polynomial">
            ///     Specified polynomial.
            /// </param>
            /// <param name="seed">
            ///     Specified seed.
            /// </param>
            public Crc32Algorithm(uint polynomial, uint seed)
            {
                table = InitializeTable(polynomial);
                this.seed = hash = seed;
            }


            /// <summary>
            ///     <see cref="HashAlgorithm.HashSize"/>
            /// </summary>
            public override int HashSize => 32;

            /// <summary>
            ///     <see cref="HashAlgorithm.Initialize"/>
            /// </summary>
            public override void Initialize()
            {
                hash = seed;
            }

            /// <summary>
            ///     <see cref="HashAlgorithm.HashCore"/>
            /// </summary>
            protected override void HashCore(byte[] buffer, int start, int length)
            {
                hash = CalculateHash(table, hash, buffer, start, length);
            }

            /// <summary>
            ///     <see cref="HashAlgorithm.HashFinal"/>
            /// </summary>
            protected override byte[] HashFinal()
            {
                var hashBuffer = UInt32ToBigEndianBytes(~hash);
                HashValue = hashBuffer;
                return hashBuffer;
            }

            /// <summary>
            ///     Compute CRC32 sum for specified <see cref="string"/> value.
            /// </summary>
            /// <param name="inputValue">
            ///     Input value of type <see cref="string"/>.
            /// </param>
            /// <returns>
            ///     Computed sum.
            /// </returns>
            public static uint Compute(string inputValue)
            {
                return Compute(Encoding.ASCII.GetBytes(inputValue));
            }

            /// <summary>
            ///     Compute CRC32 sum for specified array of bytes.
            /// </summary>
            /// <param name="buffer">
            ///     Input array of bytes.
            /// </param>
            /// <returns>
            ///     Computed sum.
            /// </returns>
            public static uint Compute(byte[] buffer)
            {
                return Compute(DefaultSeed, buffer);
            }

            /// <summary>
            ///     Compute CRC32 sum for specified array of bytes with specified seed.
            /// </summary>
            /// <param name="seed">
            ///     Specified seed.
            /// </param>
            /// <param name="buffer">
            ///     Input array of bytes.
            /// </param>
            /// <returns>
            ///     Computed sum.
            /// </returns>
            public static uint Compute(uint seed, byte[] buffer)
            {
                return Compute(DefaultPolynomial, seed, buffer);
            }


            /// <summary>
            ///     Compute CRC32 sum for specified array of bytes with specified seed and polynomial.
            /// </summary>
            /// <param name="polynomial">
            ///     Specified polynomial.
            /// </param>
            /// <param name="seed">
            ///     Specified seed.
            /// </param>
            /// <param name="buffer">
            ///     Input array of bytes.
            /// </param>
            /// <returns>
            ///     Computed sum.
            /// </returns>
            public static uint Compute(uint polynomial, uint seed, byte[] buffer)
            {
                return ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
            }

            private static uint[] InitializeTable(uint polynomial)
            {
                if (polynomial == DefaultPolynomial && defaultTable != null)
                {
                    return defaultTable;
                }

                var createTable = new uint[256];
                for (var i = 0; i < 256; i++)
                {
                    var entry = (uint)i;
                    for (var j = 0; j < 8; j++)
                    {
                        if ((entry & 1) == 1)
                        {
                            entry = (entry >> 1) ^ polynomial;
                        }
                        else
                        {
                            entry = entry >> 1;
                        }
                    }
                    createTable[i] = entry;
                }

                if (polynomial == DefaultPolynomial)
                {
                    defaultTable = createTable;
                }

                return createTable;
            }

            private static uint CalculateHash(uint[] table, uint seed, IList<byte> buffer, int start, int size)
            {
                var crc = seed;
                for (var i = start; i < size - start; i++)
                {
                    crc = (crc >> 8) ^ table[buffer[i] ^ crc & 0xff];
                }
                return crc;
            }

            private static byte[] UInt32ToBigEndianBytes(uint uint32)
            {
                var result = BitConverter.GetBytes(uint32);

                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(result);
                }

                return result;
            }
        }
    }
}