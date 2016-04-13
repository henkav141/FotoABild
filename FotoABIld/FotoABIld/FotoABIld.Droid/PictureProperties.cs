using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using Android.OS;
using FotoABIld.Droid;
using Java.Interop;
using Newtonsoft.Json;

namespace FotoABIld
{   
    //Parcelable class to be used as a model for pictures. Will be replaced by the shared class Pictures.
    public sealed class PictureProperties : Java.Lang.Object, IParcelable
    {
        [JsonProperty]
        public string FilePath { get; set; }
        [JsonProperty]
        public int Amount { get; set; }
        [JsonProperty]
        public string Size { get; set; }

        public PictureProperties(string filePath)
        {
            FilePath = filePath;
            Amount = 1;
            Size = "10x15";
        }

        private PictureProperties(Parcel parcel)
        {
            FilePath = parcel.ReadString();
            Amount = parcel.ReadInt();
            Size = parcel.ReadString();
        }

         public PictureProperties(string filePath, int amount, string size)
         {
             FilePath = filePath;
             Amount = amount;
             Size = size;
         }
        public PictureProperties() { }

        public void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
        {
            dest.WriteString(FilePath);
            dest.WriteInt(Amount);
            dest.WriteString(Size);
        }


        public static readonly GenericParcelableCreator<PictureProperties> Creator = new GenericParcelableCreator<PictureProperties>(parcel =>
        new PictureProperties(parcel));

        [ExportField("CREATOR")]
        public static GenericParcelableCreator<PictureProperties> GetCreator()
        {
            return Creator;
        }

        public int DescribeContents()
        {
            return 0;
        }

        public sealed class GenericParcelableCreator<T> : Java.Lang.Object, IParcelableCreator
        where T : Java.Lang.Object, new()
        {
            private readonly Func<Parcel, T> _createFunc;

            public GenericParcelableCreator(Func<Parcel, T> createFromParcelFunc)
            {
                _createFunc = createFromParcelFunc;
            }

            #region IParcelableCreator Implementation

            public Java.Lang.Object CreateFromParcel(Parcel source)
            {
                return _createFunc(source);
            }

            public Java.Lang.Object[] NewArray(int size)
            {
                return new T[size];
            }

            #endregion
        }


    }
}
