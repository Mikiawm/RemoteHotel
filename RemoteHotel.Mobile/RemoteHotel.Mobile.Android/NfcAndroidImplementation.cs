using System;
using Android.App;
using RemoteHotel.Mobile.Interfaces;
using RemoteHotel.Mobile.Droid;
using Android.Nfc;
using Xamarin.Forms;
using System.Runtime.Remoting.Contexts;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(NfcAndroidImplementation))]
namespace RemoteHotel.Mobile.Droid
{
    public class NfcAndroidImplementation : Activity, INfcImplementation
    {
        private NfcAdapter mNfcAdapter;

        public NfcAndroidImplementation()
        {
            //var activity = CrossCurrentActivity.Current.Activity;
            var activity = (Activity)Forms.Context;
            this.mNfcAdapter = NfcAdapter.GetDefaultAdapter(activity);
        }

        public bool IsAvailable => mNfcAdapter == null;

        public string EnableWriteMode()
        {
            if (mNfcAdapter == null)
            {
                return "NFC is not supported on this device.";
            }
            else
            {
                return "NFC is here!";
            }
        }

        public string Speak()
        {
            return "hello from android";
        }

        public string WriteTag(string message)
        {
            throw new NotImplementedException();
        }
        #region IOnInitListener implementation
        public void OnInit()
        {
            
        }
        #endregion
    }

}