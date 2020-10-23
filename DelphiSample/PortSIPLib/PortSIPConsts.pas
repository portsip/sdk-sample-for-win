unit PortSipConsts;

interface

uses
  classes,SysUtils;

const

  LINE_BASE = 1;
  MAXLINE = 8;

// DTMF_NUM
  nDTMF_0 = 0;
  nDTMF_1 = 1;
  nDTMF_2 = 2;
  nDTMF_3 = 3;
  nDTMF_4 = 4;
  nDTMF_5 = 5;
  nDTMF_6 = 6;
  nDTMF_7 = 7;
  nDTMF_8 = 8;
  nDTMF_9 = 9;
  nDTMF_STAR = 10;
  nDTMF_POUND = 11;
  nDTMF_A = 12;
  nDTMF_B = 13;
  nDTMF_C = 14;
  nDTMF_D = 15;
  nDTMF_FLASH = 16;

// for audio codecs

	AUDIOCODEC_NONE		= -1;
	AUDIOCODEC_G729		= 18;	//8KHZ
	AUDIOCODEC_PCMA		= 8;	//8KHZ
	AUDIOCODEC_PCMU		= 0;	//8KHZ
	AUDIOCODEC_GSM		= 3;	//8KHZ
	AUDIOCODEC_G722		= 9;	//16KHZ
	AUDIOCODEC_ILBC		= 97;	//8KHZ
	AUDIOCODEC_AMR		= 98;	//8KHZ
	AUDIOCODEC_AMRWB	= 99;	//16KHZ
	AUDIOCODEC_SPEEX	= 100;	//8KHZ
	AUDIOCODEC_SPEEXWB	= 102;	//16KHZ
	AUDIOCODEC_ISACWB	= 103;	//16KHZ
	AUDIOCODEC_ISACSWB	= 104;	//32KHZ
	AUDIOCODEC_G7221	= 121;	//16KHZ
	AUDIOCODEC_OPUS		= 105;	//16KHZ
	AUDIOCODEC_DTMF		= 101;


  // For video codecs
	VIDEO_CODE_NONE				= -1;
	VIDEO_CODEC_I420			= 113;
	VIDEO_CODEC_H263			= 34;
	VIDEO_CODEC_H263_1998		= 115;
	VIDEO_CODEC_H264			= 125;
	VIDEO_CODEC_VP8				= 120;
  VIDEO_CODEC_VP9				= 122;


	VIDEO_NONE	=	0;
	VIDEO_QCIF	=	1;		//	176X144		- for H.263, H.263-1998, H.264
	VIDEO_CIF	=	2;		  //	352X288		- for H.263, H.263-1998, H.264
	VIDEO_VGA	=	3;		  //	640X480		- for H.264 only
	VIDEO_SVGA	=	4;		//	800X600		- for H.264 only
	VIDEO_XVGA	=	5;		//	1024X768	- for H.264 only
	VIDEO_720P	=	6;		//	1280X720	- for H.264 only
	VIDEO_QVGA	=	7;		//	320X240		- for H.264 only


// Audio record file format
	FILEFORMAT_WAVE = 1;
	FILEFORMAT_AMR = 2;

  // Record mode
  RECORD_NONE = 0;
	RECORD_RECV = 1;
	RECORD_SEND = 2;
	RECORD_BOTH = 3;

// For the audio callback
  PORTSIP_LOCAL_MIX_ID = -1;
  PORTSIP_REMOTE_MIX_ID = -2;


// Audio stream callback mode
	AUDIOSTREAM_NONE = 0;
	AUDIOSTREAM_LOCAL_PER_CHANNEL = 1;		//  Callback the audio stream from microphone for one channel base on the session ID
	AUDIOSTREAM_REMOTE_PER_CHANNEL = 2;		//  Callback the received audio stream for one channel base on the session ID.
  AUDIOSTREAM_BOTH = 3;                  //  Callback both of local and remote audio stream for one channel based on the session ID.


  // Access video stream callback mode
	VIDEOSTREAM_NONE = 0;	// Disable video stream callback
	VIDEOSTREAM_LOCAL = 1;		// Local video stream callback
	VIDEOSTREAM_REMOTE = 2;		// Remote video stream callback
	VIDEOSTREAM_BOTH = 3;		// Both of local and remote video stream callback

  // presence
	PRESENCE_P2P = 0;
	PRESENCE_AGENT = 1;

 // LogLevel for Initialize
 	PORTSIP_LOG_NONE = -1;
	PORTSIP_LOG_ERROR = 1;
	PORTSIP_LOG_WARNING = 2;
	PORTSIP_LOG_INFO = 3;
	PORTSIP_LOG_DEBUG = 4;


  // SRTP Policy
  SRTP_POLICY_NONE = 0;
  SRTP_POLICY_FORCE = 1;
  SRTP_POLICY_PREFER = 2;

// Transport type
  TRANSPORT_UDP= 0;
  TRANSPORT_TLS = 1;
  TRANSPORT_TCP = 2;
  TRANSPORT_PERS = 3;


    // session timer refresh mode
	SESSION_REFERESH_UAC = 0;
	SESSION_REFERESH_UAS = 1;

  //  DTMF method
  DTMF_RFC2833 = 0;
	DTMF_INFO	 = 1;


 /// type of Echo Control

	EC_NONE = 0;		// Disable AEC
	EC_DEFAULT = 1;			// Platform default AEC
	EC_CONFERENCE = 2;		// Desktop platform(windows,MAC) Conferencing default (aggressive AEC)
	EC_AEC = 3;			// Desktop platform(windows,MAC) Acoustic Echo Cancellation(desktop Platform default)
	EC_AECM_1 = 4;			// Mobile platform(iOS,Android) most earpiece use
	EC_AECM_2 = 5;			// Mobile platform(iOS,Android) Loud earpiece or quiet speakerphone use
	EC_AECM_3 = 6;			// Mobile platform(iOS,Android) most speakerphone use (Mobile Platform default)
	EC_AECM_4 = 7;			// Mobile platform(iOS,Android) Loud speakerphone


/// type of Automatic Gain Control

	AGC_NONE = 0;		// Disable AGC
	AGC_DEFAULT = 1;           // platform default
	AGC_ADAPTIVE_ANALOG = 2;	// Desktop platform(windows,MAC) adaptive mode for use when analog volume control exists
	AGC_ADAPTIVE_DIGITAL = 3;	// scaling takes place in the digital domain (e.g. for conference servers and embedded devices)
	AGC_FIXED_DIGITAL = 4;		// can be used on embedded devices where the capture signal level is predictable

/// type of Noise Suppression
	NS_NONE = 0;				// Disable NS
	NS_DEFAULT = 1;				// platform default
	NS_Conference = 2;				// conferencing default
	NS_LOW_SUPPRESSION = 3;			// lowest suppression
	NS_MODERATE_SUPPRESSION = 4;
	NS_HIGH_SUPPRESSION = 5;
	NS_VERY_HIGH_SUPPRESSION = 6;   // highest suppression




// Errors
  INVALID_SESSION_ID = -1;

  ECoreAlreadyInitialized = -60000;
  ECoreNotInitialized = -60001;
  ECoreSDKObjectNull = -60002;
  ECoreArgumentNull = -60003;
  ECoreInitializeWinsockFailure = -60004;
  ECoreUserNameAuthNameEmpty = -60005;
  ECoreInitializeStackFailure = -60006;
  ECorePortOutOfRange = -60007;
  ECoreAddTcpTransportFailure = -60008;
  ECoreAddTlsTransportFailure = -60009;
  ECoreAddUdpTransportFailure = -60010;
  ECoreMiniAudioPortOutOfRange = -60011;
  ECoreMaxAudioPortOutOfRange = -60012;
  ECoreMiniVideoPortOutOfRange = -60013;
  ECoreMaxVideoPortOutOfRange = -60014;
  ECoreMiniAudioPortNotEvenNumber = -60015;
  ECoreMaxAudioPortNotEvenNumber = -60016;
  ECoreMiniVideoPortNotEvenNumber = -60017;
  ECoreMaxVideoPortNotEvenNumber = -60018;
  ECoreAudioVideoPortOverlapped = -60019;
  ECoreAudioVideoPortRangeTooSmall = -60020;
  ECoreAlreadyRegistered = -60021;
  ECoreSIPServerEmpty = -60022;
  ECoreExpiresValueTooSmall = -60023;
  ECoreCallIdNotFound = -60024;
  ECoreNotRegistered = -60025;
  ECoreCalleeEmpty = -60026;
  ECoreInvalidUri = -60027;
  ECoreAudioVideoCodecEmpty = -60028;
  ECoreNoFreeDialogSession = -60029;
  ECoreCreateAudioChannelFailed = -60030;
  ECoreSessionTimerValueTooSmall = -60040;
  ECoreAudioHandleNull = -60041;
  ECoreVideoHandleNull = -60042;
  ECoreCallIsClosed = -60043;
  ECoreCallAlreadyHold = -60044;
  ECoreCallNotEstablished = -60045;
  ECoreCallNotHold = -60050;
  ECoreSipMessaegEmpty = -60051;
  ECoreSipHeaderNotExist = -60052;
  ECoreSipHeaderValueEmpty = -60053;
  ECoreSipHeaderBadFormed = -60054;
  ECoreBufferTooSmall = -60055;
  ECoreSipHeaderValueListEmpty = -60056;
  ECoreSipHeaderParserEmpty = -60057;
  ECoreSipHeaderValueListNull = -60058;
  ECoreSipHeaderNameEmpty = -60059;
  ECoreAudioSampleNotmultiple = -60060;
  ECoreAudioSampleOutOfRange = -60061;
  ECoreInviteSessionNotFound = -60062;
  ECoreStackException = -60063;
  ECoreMimeTypeUnknown = -60064;
  ECoreDataSizeTooLarge = -60065;
  ECoreSessionNumsOutOfRange = -60066;
  ECoreNotSupportCallbackMode = -60067;
  ECoreNotFoundSubscribeId = -60068;
  ECoreCodecNotSupport  =	-60069;
  ECoreCodecParameterNotSupport =	-60070;
  ECorePayloadOutofRange = -60071;	//  Dynamic Payload range is 96 - 127
  ECorePayloadHasExist = -60072;	//  Duplicate Payload values are not allowed.
  ECoreFixPayloadCantChange = -60073;
  ECoreCodecTypeInvalid		=		-60074;
  ECoreCodecWasExist		=			-60075;
  ECorePayloadTypeInvalid		=		-60076;
  ECoreArgumentTooLong		 =		-60077;
  ECoreMiniRtpPortMustIsEvenNum	=	-60078;
  ECoreCallInHold				 =		-60079;
  ECoreNotIncomingCall		=		-60080;
  ECoreCreateMediaEngineFailure	 =	-60081;
  ECoreAudioCodecEmptyButAudioEnabled = -60082;
  ECoreVideoCodecEmptyButVideoEnabled = -60083;
  ECoreNetworkInterfaceUnavailable =	-60084;
  ECoreWrongDTMFTone		=			-60085;
  ECoreWrongLicenseKey		 =		-60086;
  ECoreTrialVersionLicenseKey	=		-60087;
  ECoreOutgoingAudioMuted		 =		-60088;
  ECoreOutgoingVideoMuted		 =		-60089;

  // audio
  EAudioFileNameEmpty = -70000;
  EAudioChannelNotFound = -70001;
  EAudioStartRecordFailure = -70002;
  EAudioRegisterRecodingFailure = -70003;
  EAudioRegisterPlaybackFailure = -70004;
  EAudioGetStatisticsFailure = -70005;
  EAudioIsPlaying = -70006;
  EAudioPlayObjectNotExist = -70007;
  EAudioPlaySteamNotEnabled = -70008;
  EAudioRegisterCallbackFailure = -70009;
  EAudioCreateAudioConferenceFailure =	-70010;
  EAudioOpenPlayFileFailure		=	-70011;
  EAudioPlayFileModeNotSupport =		-70012;
  EAudioPlayFileFormatNotSupport	=	-70013;
  EAudioPlaySteamAlreadyEnabled	=	-70014;
  EAudioCreateRecordFileFailure	=	-70015 ;
  EAudioCodecNotSupport			=	-70016 ;
  EAudioPlayFileNotEnabled	 =		-70017 ;
  EAudioPlayFileUnknowSeekOrigin	=	-70018 ;
  EAudioCantSetDeviceIdDuringCall	=	-70019 ;

  // video
  EVideoFileNameEmpty = -80000;
  EVideoGetDeviceNameFailure = -80001;
  EVideoGetDeviceIdFailure = -80002;
  EVideoStartCaptureFailure = -80003;
  EVideoChannelNotFound = -80004;
  EVideoStartSendFailure = -80005;
  EVideoGetStatisticsFailure = -80006;
  EVideoStartPlayAviFailure = -80007;
  EVideoSendAviFileFailure = -80008;
  EVideoRecordUnknowCodec		=	-80009;
  EVideoCantSetDeviceIdDuringCall		=	-80010;
  EVideoUnsupportCaptureRotate =		-80011;
  EVideoUnsupportCaptureResolution =	-80012;

  // Device
  EDeviceGetDeviceNameFailure = -90001;


implementation


end.
