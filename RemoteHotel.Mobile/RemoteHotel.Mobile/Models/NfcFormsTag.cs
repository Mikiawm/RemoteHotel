using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RemoteHotel.Mobile.Models
{
    public class NfcFormsTag
    {
        public NfcFormsTag()
        {

        }

        public byte[] Message { get; set; }
        public IList TechList;
        public bool IsNdefSupported;
        public bool IsWriteable;
        public bool IsConnected;
        public byte[] Id;
        public int MaxSize;
    }
}
