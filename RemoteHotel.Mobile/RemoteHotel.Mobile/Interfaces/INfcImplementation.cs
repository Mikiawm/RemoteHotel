
using RemoteHotel.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteHotel.Mobile.Interfaces
{
    public interface INfcImplementation
    {
        /// <summary>
        /// Gets if the device is able to detect NFC tags
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// Writes a Tag if available
        /// </summary>
        /// <param name="message">NDEF Message to write on the tag</param>
        string WriteTag(string message);

        string EnableWriteMode();

        ///// <summary>
        ///// Event raised when a tag is discovered and scanned
        ///// </summary>
        //event EventHandler<string> NewTag;

        ///// <summary>
        ///// Event raised when a tag is discovered
        ///// </summary>
        //event EventHandler<NfcFormsTag> TagConnected;

        ///// <summary>
        ///// Event raised when a tag is lost
        ///// </summary>
        //event EventHandler<NfcFormsTag> TagDisconnected;
    }
}
