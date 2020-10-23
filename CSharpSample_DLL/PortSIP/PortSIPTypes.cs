﻿/*
* Copyright (c) 2008-2020 PortSIP Solutions,Inc. All rights reserved.
* version 15
* https://www.portsip.com/
*/

   
//////////////////////////////////////////////////////////////////////////
//
//  !!!IMPORTANT!!! DON'T EDIT BELOW SOURCE CODE  
//
//////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Text;

namespace PortSIP
{
    /// Audio codec type
    public enum AUDIOCODEC_TYPE : int
    {
        AUDIOCODEC_NONE = -1,
        AUDIOCODEC_G729 = 18,	    ///< G729 8KHZ 8kbit/s
        AUDIOCODEC_PCMA = 8,	    ///< PCMA/G711 A-law 8KHZ 64kbit/s
        AUDIOCODEC_PCMU = 0,	    ///< PCMU/G711 μ-law 8KHZ 64kbit/s
        AUDIOCODEC_GSM = 3,	        ///< GSM 8KHZ 13kbit/s
        AUDIOCODEC_G722 = 9,	    ///< G722 16KHZ 64kbit/s
        AUDIOCODEC_ILBC = 97,	    ///< iLBC 8KHZ 30ms-13kbit/s 20 ms-15kbit/s
        AUDIOCODEC_AMR = 98,	    ///< Adaptive Multi-Rate (AMR) 8KHZ (4.75,5.15,5.90,6.70,7.40,7.95,10.20,12.20)kbit/s
        AUDIOCODEC_AMRWB = 99,	    ///< Adaptive Multi-Rate Wideband (AMR-WB)16KHZ (6.60,8.85,12.65,14.25,15.85,18.25,19.85,23.05,23.85)kbit/s
        AUDIOCODEC_SPEEX = 100,	    ///< SPEEX 8KHZ (2-24)kbit/s
        AUDIOCODEC_SPEEXWB = 102,	///< SPEEX 16KHZ (4-42)kbit/s
        AUDIOCODEC_ISACWB = 103,	///< internet Speech Audio Codec(iSAC) 16KHZ (32-54)kbit/s
        AUDIOCODEC_ISACSWB = 104,	///< internet Speech Audio Codec(iSAC) 16KHZ (32-160)kbit/s
        AUDIOCODEC_G7221 = 121,	    ///< G722.1 16KHZ (16,24,32)kbit/s
        AUDIOCODEC_OPUS = 105,	    ///< OPUS 48KHZ 32kbit/s
        AUDIOCODEC_DTMF = 101	    ///< DTMF RFC 2833
    }

    /// Video codec type
    public enum VIDEOCODEC_TYPE : int
    {
        VIDEO_CODE_NONE = -1,	        ///< Do not use Video codec
        VIDEO_CODEC_I420 = 113,	        ///< I420/YUV420 Raw Video format. Used with startRecord only 
        VIDEO_CODEC_H263 = 34,	        ///< H263 video codec
        VIDEO_CODEC_H263_1998 = 115,	///< H263+/H263 1998 video codec
        VIDEO_CODEC_H264 = 125,	        ///< H264 video codec
        VIDEO_CODEC_VP8 = 120,	        ///< VP8 video codec
        VIDEO_CODEC_VP9 = 122	        ///< VP9 video codec
    }

    /// The audio record file format
    public enum AUDIO_RECORDING_FILEFORMAT : int
    {
        FILEFORMAT_WAVE = 1,	///<	The record audio file is in WAVE format. 
        FILEFORMAT_AMR,			///<	The record audio file is in AMR format - all voice data are compressed by AMR codec. 
    }

    ///The audio/Video record mode
    public enum RECORD_MODE : int
    {
        RECORD_NONE = 0,		///<	Not Record. 
        RECORD_RECV = 1,		///<	Only record the received data. 
        RECORD_SEND,			///<	Only record the sent data. 
        RECORD_BOTH				///<	Record both received and sent data. 
    }


    public enum CALLBACK_SESSION_ID : int
    {
        PORTSIP_LOCAL_MIX_ID = -1,	
        PORTSIP_REMOTE_MIX_ID = -2,	
    }

    ///The audio stream callback mode
    public enum AUDIOSTREAM_CALLBACK_MODE : int
    {
        AUDIOSTREAM_NONE = 0,
        AUDIOSTREAM_LOCAL_PER_CHANNEL,		///<  Callback the audio stream from microphone for one channel based on the session ID
        AUDIOSTREAM_REMOTE_PER_CHANNEL,		///<  Callback the received audio stream for one channel based on the session ID.
        AUDIOSTREAM_BOTH,                   ///<  Callback both of local and remote audio stream for one channel based on the session ID.
    }

    ///The video stream callback mode
    public enum VIDEOSTREAM_CALLBACK_MODE : int
    {
        VIDEOSTREAM_NONE = 0,	///< Disable video stream callback
        VIDEOSTREAM_LOCAL,		///< Local video stream callback
        VIDEOSTREAM_REMOTE,		///< Remote video stream callback
        VIDEOSTREAM_BOTH,		///< Both of local and remote video stream callback
    }

    /// Log level
    public enum PORTSIP_LOG_LEVEL : int
    {
        PORTSIP_LOG_NONE = -1,
        PORTSIP_LOG_ERROR = 1,
        PORTSIP_LOG_WARNING = 2,
        PORTSIP_LOG_INFO = 3,
        PORTSIP_LOG_DEBUG = 4
    }

    /// SRTP Policy
    public enum SRTP_POLICY : int
    {
        SRTP_POLICY_NONE = 0,	///< Do not use SRTP. The SDK can receive the encrypted call(SRTP) and unencrypted call both, but can't place outgoing encrypted call. 
        SRTP_POLICY_FORCE,		///< All calls must use SRTP. The SDK allows to receive encrypted call and place outgoing encrypted call only.
        SRTP_POLICY_PREFER		///< Top priority for using SRTP. The SDK allows to receive encrypted and decrypted call, and to place outgoing encrypted call and unencrypted call.
    }

    /// Transport for SIP signaling.
    public enum TRANSPORT_TYPE : int
    {
        TRANSPORT_UDP = 0,	///< UDP Transport
        TRANSPORT_TLS,		///< Tls Transport
        TRANSPORT_TCP,		///< TCP Transport
        TRANSPORT_PERS		///< PERS is the PortSIP private transport for anti SIP blocking. It must be used with the PERS Server http://www.portsip.com/pers.html.
    }

    ///The session refreshment by UAC or UAS
   public enum SESSION_REFRESH_MODE : int
    {
        SESSION_REFERESH_UAC = 0,	///< The session refreshment by UAC
        SESSION_REFERESH_UAS		///< The session refreshment by UAS
    }

   ///send DTMF tone with two methods
   public enum DTMF_METHOD
    {
        DTMF_RFC2833 = 0,	///<	Send DTMF tone with RFC 2833. Recommended.
        DTMF_INFO = 1	    ///<	Send DTMF tone with SIP INFO.
    }


/// type of Echo Control
public enum EC_MODES
{
	EC_NONE = 0,			// Disable AEC
	EC_DEFAULT = 1,			// Platform default AEC
	EC_CONFERENCE = 2,		// Desktop platform(windows,MAC) Conferencing default (aggressive AEC)
	EC_AEC = 3,				// Desktop platform(windows,MAC) Acoustic Echo Cancellation(desktop Platform default)
	EC_AECM_1 = 4,			// Mobile platform(iOS,Android) most earpiece use
	EC_AECM_2 = 5,			// Mobile platform(iOS,Android) Loud earpiece or quiet speakerphone use
	EC_AECM_3 = 6,			// Mobile platform(iOS,Android) most speakerphone use (Mobile Platform default)
	EC_AECM_4 = 7,			// Mobile platform(iOS,Android) Loud speakerphone
}

/// type of Automatic Gain Control
public enum AGC_MODES                   
{
	AGC_NONE = 0,			// Disable AGC
	AGC_DEFAULT,            // Platform default
	AGC_ADAPTIVE_ANALOG,	// Desktop platform (windows,MAC) adaptive mode for use when analog volume control exists
	AGC_ADAPTIVE_DIGITAL,	// Scaling takes place in the digital domain (e.g. for conference servers and embedded devices)
	AGC_FIXED_DIGITAL		// Can be used on embedded devices where the capture signal level is predictable
}

/// type of Noise Suppression
public enum NS_MODES 
{
	NS_NONE = 0,				// Disable NS
	NS_DEFAULT,					// platform default
	NS_Conference,				// conferencing default
	NS_LOW_SUPPRESSION,			// lowest suppression
	NS_MODERATE_SUPPRESSION,
	NS_HIGH_SUPPRESSION,
	NS_VERY_HIGH_SUPPRESSION,   // highest suppression
}

}
