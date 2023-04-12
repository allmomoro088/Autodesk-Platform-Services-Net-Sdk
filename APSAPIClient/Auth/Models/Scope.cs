using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    [Flags]
    public enum Scope
    {
        Account_Read = 1,
        Account_Write = 2,
        Data_Read = 4,
        Data_Write = 8,
        Data_Create = 16,
        Data_Search = 32,
        User_Read = 64,
        User_Write = 128,
        Viewables = 256,
        Bucket_Create = 512,
        Bucket_Update = 1024,
        Bucket_Read = 2048,
        Bucket_Delete = 4096,
        Code_All = 8192
    }
}
