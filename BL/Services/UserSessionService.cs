using System;
using System.IO;

namespace BL.Services
{
    public class UserSessionService
    {
        private const string filePath = @"UserSession.dat";

        public int GetCurrentWarehousehouseIndex()
        {
            if (!File.Exists(filePath))
                return -1;
            return ToInt32(File.ReadAllBytes(filePath));
        }

        public void SetCurrentWarehousehouseIndex(int value)
        {
            File.WriteAllBytes(filePath, ToBytes(value) );
        }

        private int ToInt32(byte[] bytes)
        {
            if (bytes.Length != 4)
                throw new ArgumentException();

            return bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3];
        }

        private byte[] ToBytes(int int32)
        {
            return new byte[] { (byte)(int32 >> 24), (byte)(int32 >> 16), (byte)(int32 >> 8), (byte)int32 };
        }
    }
}
