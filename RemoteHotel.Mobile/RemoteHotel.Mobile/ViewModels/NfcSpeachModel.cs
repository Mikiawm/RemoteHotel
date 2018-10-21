using RemoteHotel.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteHotel.Mobile.ViewModels
{
    public class NfcSpeachModel
    {
        private readonly INfcImplementation _infcImplementation;

        public string Message { get; set; }

        public NfcSpeachModel(string message)
        {
            Message = message;
        }

    }
}
