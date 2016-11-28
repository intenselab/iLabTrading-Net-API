// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataBuffer.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace IntenseLab.Shared
{
    /// <summary>
    ///     Represents helper for buffering data in bytes.
    /// </summary>
    [Serializable]
    public sealed class DataBuffer : ISerializable, IDisposable
    {
        private byte[] buffer;

        /// <summary>
        ///     Represents array of bytes filled up by composed objects of data converted to byte arrays.
        /// </summary>
        private byte[] Buffer
        {
            get
            {
                return buffer;
            }
            set
            {
                buffer = value;
            }
        }

        /// <summary>
        ///     Name of the buffer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Count of bytes that was read from <see cref="Buffer"/>.
        /// </summary>
        private int CountOfReadBytes { get; set; }

        /// <summary>
        ///     Count of bytes that was written to <see cref="Buffer"/>.
        /// </summary>
        private int CountOfWrittenBytes { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataBuffer" /> class.
        /// </summary>
        /// <param name="info">
        ///     <see cref="SerializationInfo" />
        /// </param>
        /// <param name="ctxt">
        ///      <see cref="StreamingContext" />
        /// </param>
        private DataBuffer(SerializationInfo info, StreamingContext ctxt)
        { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataBuffer" /> class.
        /// </summary>
        public DataBuffer()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataBuffer" /> class.
        /// </summary>
        /// <param name="message">
        ///     Message converted to aaray of bytes.
        /// </param>
        public DataBuffer(byte[] message)
        {
            AddBuffer(message);
        }

        /// <summary>
        ///    Create copy from specified data buffer.
        /// </summary>
        /// <param name="buffer">
        ///    Instance of <see cref="DataBuffer"/>  which will be copied.
        /// </param>
        public DataBuffer(DataBuffer buffer)
        {
            if (buffer != null)
                AddBuffer(buffer.GetBuffer());
        }

        /// <summary>
        ///    Dispose buffer.
        /// </summary>
        public void Dispose()
        {
            FreeBuffer();
        }

        /// <summary>
        ///     Get object data.
        /// </summary>
        /// <param name="info">
        ///     <see cref="SerializationInfo"/>
        /// </param>
        /// <param name="context">
        ///     <see cref="StreamingContext"/>
        /// </param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("buff", Buffer);
        }


        /// <summary>
        ///     Allocate buffer of the specified size.
        /// </summary>
        /// <param name="size">
        ///     The size of buffer.
        /// </param>
        public void Allocate(long size)
        {
            Debug.Assert(size > -1);

            Buffer = new byte[size];
            CountOfReadBytes = 0;
        }


        /// <summary>
        ///     Get the buffer of specified size with option to save data 
        ///     if specified size is greated than current buffer size.
        /// </summary>
        /// <param name="desiredSize">
        ///     Desired size of buffer.
        /// </param>
        /// <param name="saveData">
        ///     Option to save old data in buffer if buffer must be reallocated.
        /// </param>
        /// <returns>
        ///     Buffer of desired size.
        /// </returns>
        public byte[] GetBuffer(long desiredSize, bool saveData = false)
        {
            if (Buffer != null && desiredSize == Size)
            {
                return Buffer;
            }

            if (saveData)
            {
                Reallocate(desiredSize);
            }
            else
            {
                Allocate(desiredSize);
            }
            return Buffer;
        }


        /// <summary>
        ///     Get buffer (array of bytes) of current object.
        /// </summary>
        /// <returns>
        ///     Buffer (array of bytes).
        /// </returns>
        public byte[] GetBuffer()
        {
            return Buffer;
        }

        /// <summary>
        ///     Get size of the buffer.
        /// </summary>
        /// <returns>
        ///     <see cref="int"/>
        /// </returns>
        public int Size => Buffer?.Length ?? 0;

        /// <summary>
        ///     Realocate the buffer with new length.
        /// </summary>
        public void Reallocate(long newLength)
        {
            Debug.Assert(newLength > -1);
            if (Buffer == null)
            {
                Allocate(newLength);
                return;
            }

            Array.Resize(ref buffer, (int)newLength);
        }


        /// <summary>
        ///     Set new data to buffer.
        /// </summary>
        /// <param name="newBuffer">
        ///     New buffer.
        /// </param>
        public void SetData(byte[] newBuffer)
        {
            FreeBuffer();
            AddBuffer(newBuffer);
        }

        /// <summary>
        ///     Set new data to buffer.
        /// </summary>
        /// <param name="newBuffer">
        ///     The new buffer.
        /// </param>
        public void SetData(DataBuffer newBuffer)
        {
            SetData(newBuffer.Buffer);
        }

        /// <summary>
        ///     Reset the buffer.
        /// </summary>
        public void FreeBuffer()
        {
            Buffer = null;
            CountOfReadBytes = 0;
            CountOfWrittenBytes = 0;
        }

        /// <summary>
        ///     Represents current buffer as string of UTF-8 characters.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return GetAsUtf8String;
        }

        /// <summary>
        ///     Represents current buffer as string of ASCII characters.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public string GetAsAsciiString => Buffer != null ? Encoding.ASCII.GetString(Buffer) : null;

        /// <summary>
        ///     Represents current buffer as string of UTF-8 characters.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public string GetAsUtf8String => Buffer != null ? Encoding.UTF8.GetString(Buffer) : null;

        /// <summary>
        ///     Read data of type <see cref="T"/> from buffer.
        /// </summary>
        /// <param name="result">
        ///     Result of reading.
        /// </param>
        /// <param name="converter">
        ///     Function for converting from byte's array to types of <see cref="T"/>.
        /// </param>
        /// <typeparam name="T">
        ///     Specified type.
        /// </typeparam>
        /// <returns>
        ///     Result of reading.
        /// </returns>
        public bool ReadData<T>(out T result, Func<byte[], int, T> converter)
        {
            result = default(T);

            var size = Marshal.SizeOf(result);
            if (CountOfReadBytes + size > CountOfWrittenBytes)
            {
                return false;
            }

            result = converter(Buffer, CountOfReadBytes);

            CountOfReadBytes += size;
            return true;
        }

        /// <summary>
        ///     Read the byte value.
        /// </summary>
        /// <param name="result">
        ///     The result.
        /// </param>
        public bool ReadByte(out byte result)
        {
            return ReadData(out result, (bytes, i) => bytes[i]);
        }

        /// <summary>
        ///     Read the UInt16 value.
        /// </summary>
        /// <param name="result">
        ///     The result.
        /// </param>
        public bool ReadUInt16(out ushort result)
        {
            return ReadData(out result, BitConverter.ToUInt16);
        }

        /// <summary>
        ///     Read the UInt32 value.
        /// </summary>
        /// <param name="result">
        ///     The result.
        /// </param>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool ReadUInt32(out uint result)
        {
            return ReadData(out result, BitConverter.ToUInt32);
        }


        /// <summary>
        ///     Read the Int32 value.
        /// </summary>
        /// <param name="result">
        ///     The result.
        /// </param>
        public bool ReadInt32(out int result)
        {
            return ReadData(out result, BitConverter.ToInt32);
        }

        /// <summary>
        ///     Read the Int64 value.
        /// </summary>
        /// <param name="result">
        ///     The result.
        /// </param>
        public bool ReadInt64(out long result)
        {
            return ReadData(out result, BitConverter.ToInt64);
        }

        /// <summary>
        ///     Read the double value.
        /// </summary>
        /// <param name="result">
        ///     The result.
        /// </param>
        public bool ReadDouble(out double result)
        {
            return ReadData(out result, BitConverter.ToDouble);
        }








        /// <summary>
        ///     Add the byte element to current buffer.
        /// </summary>
        /// <param name="element">
        ///     The specified element.
        /// </param>
        public void AddByte(byte element)
        {
            var tmp = new byte[1];
            tmp[0] = element;
            AddBuffer(tmp);
        }


        /// <summary>
        ///     Add element of type unsigned Int16.
        /// </summary>
        /// <param name="element">
        ///     The specified element.
        /// </param>
        public void AddUInt16(ushort element)
        {
            for (byte x = 0; x < 2; x++)
            {
                var adt = (byte)element;
                element = (ushort)(element >> 8);
                AddByte(adt);
            }
        }

        /// <summary>
        ///     Add element of type unsigned Int32.
        /// </summary>
        /// <param name="element">
        ///     The specified element.
        /// </param>
        public void AddUInt32(uint element)
        {
            for (byte x = 0; x < 4; x++)
            {
                var adt = (byte)element;
                element = element >> 8;
                AddByte(adt);
            }
        }


        /// <summary>
        ///     Add element of type Int32.
        /// </summary>
        /// <param name="element">
        ///     The specified element.
        /// </param>
        public void AddInt32(int element)
        {
            AddBuffer(BitConverter.GetBytes(element));
        }

        /// <summary>
        ///     Add element of type Int64.
        /// </summary>
        /// <param name="element">
        ///     The specified element.
        /// </param>
        public void AddInt64(long element)
        {
            AddBuffer(BitConverter.GetBytes(element));
        }

        /// <summary>
        ///     Add element of type Double.
        /// </summary>
        /// <param name="element">
        ///     The specified element.
        /// </param>
        public void AddDouble(double element)
        {
            AddBuffer(BitConverter.GetBytes(element));
        }

        /// <summary>
        ///     Add the specified buffer to current.
        /// </summary>
        /// <param name="dataBuffer">
        ///     The specified buffer.
        /// </param>
        public void AddBuffer(byte[] dataBuffer)
        {
            if (dataBuffer == null)
                return;

            AddBuffer(dataBuffer, dataBuffer.Length);
        }

        /// <summary>
        ///     Add the specified buffer to current.
        /// </summary>
        /// <param name="dataBuffer">
        ///     The buffer.
        /// </param>
        /// <param name="size">
        ///     The size of the buffer.
        /// </param>
        public void AddBuffer(byte[] dataBuffer, int size)
        {
            if (Buffer == null || CountOfWrittenBytes + size > Size)
            {
                Reallocate(CountOfWrittenBytes + size);
            }

            for (long x = 0; x < size; x++)
            {
                if (Buffer != null)
                    Buffer[x + CountOfWrittenBytes] = dataBuffer[x];
            }

            CountOfWrittenBytes += size;
        }

        /// <summary>
        ///     Add the specified buffer to current.
        /// </summary>
        /// <param name="dataBuffer">
        ///     The specified buffer.
        /// </param>
        public void AddBuffer(DataBuffer dataBuffer)
        {
            if (dataBuffer?.Buffer == null)
            {
                return;
            }

            AddBuffer(dataBuffer.Buffer);
        }
    }
}
