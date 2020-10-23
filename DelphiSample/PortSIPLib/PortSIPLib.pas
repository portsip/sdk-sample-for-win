unit PortSIPLib;

interface

uses SysUtils, Windows;

type



// Audio and video callback function prototype
  TAudioRawCallback = function(obj: Pointer;
                            sessionId: NativeInt;
                            _type: integer;
                            data:PByte;
                            dataLength, samplingFreqHz:integer):integer; cdecl;
  TONAudioRawCallbackParams = class (TObject)
    obj : Pointer;
    sessionId:NativeInt;
    callbackType:integer;
    data:PByte;
    dataLength:integer;
    samplingFreqHz:integer;
  end;

  TVideoRawCallback = function(obj: Pointer;
                              sessionId: NativeInt;
                              _type: integer;
                              width, height:integer;
                              data:PByte;
                              dataLength:integer):integer; cdecl;
  TONVideoRawCallbackParams = class (TObject)
    obj : Pointer;
    sessionId:NativeInt;
    callbackType:integer;
    width: integer;
    height: integer;
    data:PByte;
    dataLength:integer;
  end;

// Callback functions for received and sending RTP packets
  TReceivedRTPPacket = function(obj:Pointer;
                                sessionId: NativeInt;
                                isAudio:boolean;
                                RTPPacket:PByte;
                                packetSize:integer):integer; cdecl;
   TONReceivedRTPPacketParams = class (TObject)
      obj:Pointer;
      sessionId: NativeInt;
      isAudio:boolean;
      RTPPacket:PByte;
      packetSize:integer
  end;

  TSendingRTPPacket = function(obj:Pointer; sessionId:
                                NativeInt;
                                isAudio:boolean;
                                 RTPPacket:PByte;
                                 packetSize:integer):integer; cdecl;
   TONSendingRTPPacketParams = class (TObject)
      obj:Pointer;
      sessionId: NativeInt;
      isAudio:boolean;
      RTPPacket:PByte;
      packetSize:integer
  end;



  // SIP callbacks
  TRegisterSuccess = function(callbackIndex:NativeInt; callbackObject:NativeInt; reason:PAnsiChar; code:integer): integer; cdecl;
  TRegisterFailure = function(callbackIndex:NativeInt; callbackObject:NativeInt; reason:PAnsiChar; code:integer): integer; cdecl;
  TInviteIncoming = function(callbackIndex:NativeInt;
                              callbackObject:NativeInt;
                              sessionId:NativeInt;
                              callerDisplayName:PAnsiChar;
                              caller:PAnsiChar;
                              calleeDisplayName:PAnsiChar;
                              callee:PAnsiChar;
                              audioCodecs:PAnsiChar;
                              videoCodecs:PAnsiChar;
                              existsAudio:boolean;
                              existsVideo:boolean;
                              message:PAnsiChar): integer; cdecl;
  TInviteTrying = function(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
  TInviteSessionProgress = function(callbackIndex, callbackObject:NativeInt;
			                      sessionId:NativeInt;
                            audioCodecs:PAnsiChar;
                            videoCodecs:PAnsiChar;
                            existsEarlyMedia:boolean;
                            existsAudio:boolean;
                            existsVideo:boolean;
                            message:PAnsiChar): integer; cdecl;
  TInviteRinging = function(callbackIndex, callbackObject:NativeInt;
                              sessionId:NativeInt;
                              statusText:PAnsiChar;
                              statusCode:integer;
                              message:PAnsiChar): integer; cdecl;
  TInviteAnswered = function(callbackIndex, callbackObject:NativeInt;
                              sessionId:NativeInt;
                              callerDisplayName:PAnsiChar;
                              caller:PAnsiChar;
                              calleeDisplayName:PAnsiChar;
                              callee:PAnsiChar;
                              audioCodecs:PAnsiChar;
                              videoCodecs:PAnsiChar;
                              existsAudio:boolean;
                              existsVideo:boolean;
                              message:PAnsiChar): integer; cdecl;
  TInviteFailure = function(callbackIndex, callbackObject:NativeInt;
                              sessionId:NativeInt;
                              reason:PAnsiChar;
                              code:integer): integer; cdecl;
  TInviteUpdated = function (callbackIndex,
                              callbackObject:NativeInt;
                              sessionId:NativeInt;
                              audioCodecs:PAnsiChar;
                              videoCodecs:PAnsiChar;
                              existsAudio:boolean;
                              existsVideo:boolean;
                              message:PAnsiChar): integer; cdecl;
  TInviteConnected = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
  TInviteBeginingForward = function (callbackIndex, callbackObject:NativeInt; forwardTo:PAnsiChar): integer; cdecl;
  TInviteClosed = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
  TDialogStateUpdated = function (callbackIndex, callbackObject:NativeInt; BLFMonitoredUri, BLFDialogState, BLFDialogId, BLFDialogDirection: PAnsiChar): integer; cdecl;
  TRemoteHold = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
  TRemoteUnHold = function (callbackIndex,
                        callbackObject:NativeInt;
                        sessionId:NativeInt;
                        audioCodecs,
                        videoCodecs: PAnsiChar;
                        existsAudio,
                        existsVideo: boolean): integer; cdecl;
  TReceivedRefer = function (callbackIndex, callbackObject:NativeInt;
                              sessionId:NativeInt;
                              referId:NativeInt;
                              referTo:PAnsiChar;
                              from:PAnsiChar;
                              referSipMessage:PAnsiChar): integer; cdecl;
  TReferAccepted = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
  TReferRejected = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
  TTransferTrying = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
  TTransferRinging = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
  TACTVTransferSuccess = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
  TACTVTransferFailure = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt; reason:PAnsiChar; code:integer): integer; cdecl;
  TReceivedSignaling = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt; sipSignaling:PAnsiChar): integer; cdecl;
  TSendingSignaling = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt; sipSignaling:PAnsiChar): integer; cdecl;
  TWaitingVoiceMessage = function (callbackIndex, callbackObject:NativeInt;
                                    messageAccount:PAnsiChar;
                                    urgentNewMessageCount,
                                    urgentOldMessageCount,
                                    newMessageCount,
                                    oldMessageCount: integer): integer; cdecl;
  TWaitingFaxMessage = function (callbackIndex, callbackObject:NativeInt;
                                    messageAccount:PAnsiChar;
                                    urgentNewMessageCount,
                                    urgentOldMessageCount,
                                    newMessageCount,
                                    oldMessageCount: integer): integer; cdecl;
  TRecvDtmfTone = function (callbackIndex, callbackObject:NativeInt;
                                    sessionId:NativeInt;
                                    tone:integer): integer; cdecl;
  TPresenceRecvSubscribe = function (callbackIndex, callbackObject:NativeInt;
                                      subscribeId:NativeInt;
                                      fromDisplayName:PAnsiChar;
                                      from:PAnsiChar;
                                      subject:PAnsiChar): integer; cdecl;
  TPresenceOnline = function (callbackIndex, callbackObject:NativeInt;
                                      fromDisplayName:PAnsiChar;
                                      from:PAnsiChar;
                                      stateText:PAnsiChar): integer; cdecl;
  TPresenceOffline = function (callbackIndex, callbackObject:NativeInt;
                                      fromDisplayName:PAnsiChar;
                                      from:PAnsiChar): integer; cdecl;
  TRecvOptions = function (callbackIndex, callbackObject:NativeInt; optionsMessage:PAnsiChar): integer; cdecl;
  TRecvInfo = function (callbackIndex, callbackObject:NativeInt; infoMessage:PAnsiChar): integer; cdecl;
  TPlayAudioFileFinished = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt; fileName:PAnsiChar): integer; cdecl;
  TPlayVideoFileFinished = function (callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
  TRecvMessage = function (callbackIndex, callbackObject:NativeInt;
                            sessionId:NativeInt;
                            mimeType:PAnsiChar;
                            subMimeType:PAnsiChar;
                            messageData:PByte;
                            messageDataLength:integer): integer; cdecl;
  TRecvOutOfDialogMessage = function (callbackIndex, callbackObject:NativeInt;
                            fromDisplayName:PAnsiChar;
                            from:PAnsiChar;
                            toDisplayName:PAnsiChar;
                            sendTo:PAnsiChar;
                            mimeType:PAnsiChar;
                            subMimeType:PAnsiChar;
                            messageData:PByte;
                            messageDataLength:integer): integer; cdecl;
  TSendMessageSuccess = function (callbackIndex, callbackObject:NativeInt;
                            sessionId, messageId:NativeInt): integer; cdecl;
  TSendMessageFailure = function (callbackIndex, callbackObject:NativeInt;
                            sessionId, messageId:NativeInt;
                            reason:PAnsiChar;
                            code:integer): integer; cdecl;
  TSendOutOfDialogMessageSuccess = function(callbackIndex, callbackObject, messageId:NativeInt;
                            fromDisplayName:PAnsiChar;
                            from:PAnsiChar;
                            toDisplayName:PAnsiChar;
                            sendTo:PAnsiChar): integer; cdecl;
  TSendOutOfDialogMessageFailure = function(callbackIndex, callbackObject, messageId:NativeInt;
                            fromDisplayName:PAnsiChar;
                            from:PAnsiChar;
                            toDisplayName:PAnsiChar;
                            sendTo:PAnsiChar;
                            reason:PAnsiChar;
                            code:integer): integer; cdecl;


////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

  TPortSIP_delCallbackParameters = procedure(parameters: pointer);

  TPortSIP_initialize = function(callbackDispatcher:THandle;
                  transportType: integer;
                  localIP: PAnsiChar;
                  localSipPort: integer;
            			logLevel: integer;
            			logFilePath: PAnsiChar;
					      	maxCallSessions: integer;
						      sipAgentString: PAnsiChar;
            			audioDeviceLayer: integer;
            			videoDeviceLayer: integer;
                  TLSCertificatesRootPath : PAnsiChar;
                  TLSCipherist: PAnsiChar;
                  verifyTLSCertificate : boolean;
            			var ErrorCode: integer
            			):THandle; cdecl;


  TPortSIP_setDisplayName = function(SDKLib:THandle; displayName:PAnsiChar):integer; cdecl;
  TPortSIP_setInstanceId = function(SDKLib:THandle; uuid:PAnsiChar):integer; cdecl;
  TPortSIP_unInitialize = procedure(SDKLib:THandle); cdecl;
  TPortSIP_setLicenseKey = function(SDKLib:THandle; key:PAnsiChar):integer; cdecl;
  TPortSIP_getNICNums = function():integer; cdecl;
  TPortSIP_getLocalIpAddress = function(index: integer;
                                        ip:PAnsiChar;
                                        ipSize:integer):integer; cdecl;

  TPortSIP_setUser = function(SIPCoreHandle:THandle;
						      userName: PAnsiChar;
                              displayName: PAnsiChar;
                              authName: PAnsiChar;
                              password: PAnsiChar;
						      sipDomain: PAnsiChar;
						      sipServerAddr: PAnsiChar;
						      sipServerPort: integer;
						      stunServerAddr: PAnsiChar;
						      stunServerPort: integer;
						      outboundServerAddr: PAnsiChar;
						      outboundServerPort: integer):integer; cdecl;
  TPortSIP_removeUser = procedure(SDKLib:THandle); cdecl;

  TPortSIP_registerServer = function(SIPCoreHandle:THandle; regExpires:integer; retryTimes: integer):integer; cdecl;
  TPortSIP_refreshRegistration = function(SIPCoreHandle:THandle; regExpires:integer):integer; cdecl;
  TPortSIP_unRegisterServer = function(SIPCoreHandle:THandle):integer; cdecl;
  TPortSIP_getVersion = function(SIPCoreHandle:THandle; var majorVersion:integer; var minorVersion:integer):integer; cdecl;
  TPortSIP_enableRport = function(SIPCoreHandle:THandle; enable:boolean):integer; cdecl;
  TPortSIP_enableEarlyMedia = function(SIPCoreHandle:THandle; enable:boolean):integer; cdecl;
  TPortSIP_enableReliableProvisional = function(SIPCoreHandle:THandle; enable:boolean):integer; cdecl;
  TPortSIP_enable3GppTags = function(SIPCoreHandle:THandle; enable:boolean):integer; cdecl;
  TPortSIP_enableCallbackSignaling = procedure(SIPCoreHandle:THandle; enableSending:boolean; enableReceived:boolean); cdecl;
  TPortSIP_setRtpCallback = function(SIPCoreHandle:THandle;
                                      receivedCallbackHandler:TReceivedRTPPacket;
                                      sendingCallbackHandler:TReceivedRTPPacket):integer; cdecl;

  TPortSIP_addAudioCodec = function(SIPCoreHandle:THandle; codecType:integer):integer; cdecl;
  TPortSIP_addVideoCodec = function(SIPCoreHandle:THandle; codecType:integer):integer; cdecl;
  TPortSIP_isAudioCodecEmpty = function(SIPCoreHandle:THandle): boolean; cdecl;
  TPortSIP_isVideoCodecEmpty = function(SIPCoreHandle:THandle): boolean; cdecl;
  TPortSIP_setAudioCodecPayloadType = function(SIPCoreHandle:THandle; codecType:integer; payloadType:integer): integer; cdecl;
  TPortSIP_setVideoCodecPayloadType = function(SIPCoreHandle:THandle; codecType:integer; payloadType:integer): integer; cdecl;
  TPortSIP_clearAudioCodec = procedure(SIPCoreHandle:THandle); cdecl;
  TPortSIP_clearVideoCodec = procedure(SIPCoreHandle:THandle); cdecl;
  TPortSIP_setAudioCodecParameter = function(SIPCoreHandle:THandle; codecType:integer; parameter:PAnsiChar): integer; cdecl;
  TPortSIP_setVideoCodecParameter = function(SIPCoreHandle:THandle; codecType:integer; parameter:PAnsiChar): integer; cdecl;
  TPortSIP_setSrtpPolicy = function(SIPCoreHandle:THandle; srtpPolicy:integer; allowSrtpOverUnsecureTransport : boolean): integer; cdecl;
  TPortSIP_setRtpPortRange = function(SIPCoreHandle:THandle;
            minimumRtpAudioPort: integer;
            maximumRtpAudioPort: integer;
            minimumRtpVideoPort: integer;
            maximumRtpVideoPort: integer):integer; cdecl;
  TPortSIP_setRtcpPortRange = function(SIPCoreHandle:THandle;
            minimumRtcpAudioPort: integer;
            maximumRtcpAudioPort: integer;
            minimumRtcpVideoPort: integer;
            maximumRtcpVideoPort: integer):integer; cdecl;

  TPortSIP_enableCallForward = function(SIPCoreHandle:THandle; forBusyOnly:boolean; forwardTo:PAnsiChar):integer; cdecl;
  TPortSIP_disableCallForward = function(SIPCoreHandle:THandle):integer; cdecl;
  TPortSIP_enableSessionTimer = function(SIPCoreHandle:THandle; timerSeconds:integer; refreshMode:integer):integer; cdecl;
  TPortSIP_disableSessionTimer = function(SIPCoreHandle:THandle):integer; cdecl;
  TPortSIP_setDoNotDisturb = procedure(SIPCoreHandle:THandle; enable:boolean); cdecl;
  TPortSIP_enableAutoCheckMwi = function(SIPCoreHandle:THandle; state:boolean):integer; cdecl;
  TPortSIP_setRtpKeepAlive = function(SIPCoreHandle:THandle;
                                      state:boolean;
                                      keepAlivePayloadType:integer;
                                      deltaTransmitTimeMS:integer):integer; cdecl;
  TPortSIP_setKeepAliveTime = function(SIPCoreHandle:THandle; keepAliveTime: integer):integer; cdecl;
  TPortSIP_getSipMessageHeaderValue = function(SIPCoreHandle:THandle;
                                            sipMessage, headerName, headerValue:PAnsiChar;
                                            headerValueLength:integer):integer; cdecl;
  TPortSIP_addSipMessageHeader = function(SIPCoreHandle:THandle;
                                          sessionId:NativeInt;
                                          methodName:PAnsiChar;
                                          msgType:integer;
                                          headerName,
                                          headerValue:PAnsiChar):NativeInt; cdecl;
  TPortSIP_removeAddedSipMessageHeader = function(SIPCoreHandle:THandle; sipMessageHeaderId:Nativeint):integer; cdecl;
  TPortSIP_modifySipMessageHeader = function(SIPCoreHandle:THandle;
                                         sessionId:NativeInt;
                                          methodName:PAnsiChar;
                                          msgType:integer;
                                          headerName,
                                          headerValue:PAnsiChar):NativeInt; cdecl;
  TPortSIP_removeModifiedSipMessageHeader = function(SIPCoreHandle:THandle; sipMessageHeaderId:Nativeint):integer; cdecl;
  TPortSIP_clearModifiedSipMessageHeaders = procedure(SIPCoreHandle:THandle); cdecl;
  TPortSIP_clearAddedSipMessageHeaders = procedure(SIPCoreHandle:THandle); cdecl;
  TPortSIP_addSupportedMimeType = function(SIPCoreHandle:THandle;
                                            methodName,
                                            mimeType,
                                            subMimeType:PAnsiChar):integer; cdecl;

  TPortSIP_setAudioSamples = function(SIPCoreHandle:THandle; ptime, maxPtime:integer):integer; cdecl;
  TPortSIP_setAudioBitrate = function(SIPCoreHandle:THandle; sessionId:NativeInt; codecType, bitrateKbps: integer):integer; cdecl;
  TPortSIP_setAudioDeviceId = function(SIPCoreHandle:THandle; recordingDeviceId:integer; playoutDeviceId:integer):integer; cdecl;
  TPortSIP_setVideoDeviceId = function(SIPCoreHandle:THandle; deviceId:integer):integer; cdecl;
  TPortSIP_setVideoResolution = function(SIPCoreHandle:THandle; width, height:integer):integer; cdecl;
  TPortSIP_setVideoBitrate = function(SIPCoreHandle:THandle;  sessionId:NativeInt; bitrateKbps:integer):integer; cdecl;
  TPortSIP_setVideoFrameRate = function(SIPCoreHandle:THandle;  sessionId:NativeInt; frameRate:integer):integer; cdecl;
  TPortSIP_sendVideo = function(SIPCoreHandle:THandle; sessionId:NativeInt; sendState:boolean):integer; cdecl;
  TPortSIP_muteMicrophone = procedure(SIPCoreHandle:THandle; mute:boolean); cdecl;
  TPortSIP_muteSpeaker = procedure(SIPCoreHandle:THandle; mute:boolean); cdecl;
  TPortSIP_setChannelOutputVolumeScaling = procedure(SIPCoreHandle:THandle; sessionId:NativeInt; scaling:integer); cdecl;
  TPortSIP_setChannelInputVolumeScaling = procedure(SIPCoreHandle:THandle; sessionId:NativeInt; scaling:integer); cdecl;
  TPortSIP_setLocalVideoWindow = procedure(SIPCoreHandle:THandle; localVideoWindow:THandle); cdecl;
  TPortSIP_setRemoteVideoWindow = function(SIPCoreHandle:THandle; sessionId: NativeInt; remoteVideoWindow:THandle):integer; cdecl;
  TPortSIP_displayLocalVideo = function(SIPCoreHandle:THandle; state:boolean; mirror:boolean):integer; cdecl;
  TPortSIP_setVideoNackStatus = function(SIPCoreHandle:THandle; state:boolean):integer; cdecl;
  TPortSIP_call = function(SIPCoreHandle:THandle; callTo:PAnsiChar; sendSdp:boolean; videoCall:boolean):integer; cdecl;
  TPortSIP_rejectCall = function(SIPCoreHandle:THandle; sessionId:NativeInt; code:integer):integer; cdecl;
  TPortSIP_hangUp = function(SIPCoreHandle:THandle; sessionId:NativeInt):integer; cdecl;
  TPortSIP_answerCall = function(SIPCoreHandle:THandle; sessionId:NativeInt; videoCall:boolean):integer; cdecl;
  TPortSIP_updateCall = function(SIPCoreHandle:THandle; sessionId:NativeInt; enableAudio:boolean; enableVideo:boolean):integer; cdecl;
  TPortSIP_hold = function(SIPCoreHandle:THandle; sessionId:NativeInt):integer; cdecl;
  TPortSIP_unHold = function(SIPCoreHandle:THandle; sessionId:NativeInt):integer; cdecl;
  TPortSIP_refer = function(SIPCoreHandle:THandle; sessionId:NativeInt; referTo:PAnsiChar):integer; cdecl;
  TPortSIP_attendedRefer = function(SIPCoreHandle:THandle; sessionId, replaceSessionId:NativeInt; referTo:PAnsiChar):integer; cdecl;
  TPortSIP_attendedRefer2 = function(SIPCoreHandle:THandle; sessionId, replaceSessionId:NativeInt; replaceMethod, target, referTo:PAnsiChar):integer; cdecl;
  TPortSIP_outOfDialogRefer = function(SIPCoreHandle:THandle; replaceSessionId:NativeInt; referTo:PAnsiChar):integer; cdecl;
  TPortSIP_acceptRefer = function (SIPCoreHandle:THandle; referId:NativeInt; referSipMessage:PAnsiChar):integer; cdecl;
  TPortSIP_rejectRefer = function (SIPCoreHandle:THandle; referId:NativeInt):integer; cdecl;
  TPortSIP_muteSession = function (SIPCoreHandle:THandle;
                                   sessionId:NativeInt;
                                   muteIncomingAudio:boolean;
                                   muteOutgoingAudio:boolean;
                                   muteIncomingVideo:boolean;
                                   muteOutgoingVideo:boolean):integer; cdecl;
  TPortSIP_forwardCall = function(SIPCoreHandle:THandle; sessionId:NativeInt; forwardTo:PAnsiChar):integer; cdecl;
  TPortSIP_pickupBLFCall = function(SIPCoreHandle:THandle; replaceDialogId: PAnsiChar; videoCall: boolean):integer; cdecl;
  TPortSIP_sendDtmf = function(SIPCoreHandle:THandle;
                                sessionId: NativeInt;
                                dtmfMethod: integer;
                                code: integer;
                                duration: integer;
                                playDtmfTone: boolean):integer; cdecl;
  TPortSIP_enableSendPcmStreamToRemote = function(SIPCoreHandle:THandle;
                                                  sessionId:NativeInt;
                                                  state:boolean;
                                                  streamSamplesPerSec:integer):integer; cdecl;

  TPortSIP_sendPcmStreamToRemote = function(SIPCoreHandle:THandle;
                                              sessionId:NativeInt;
                                              data:PByte;
                                              dataLength:integer):integer; cdecl;

  TPortSIP_enableSendVideoStreamToRemote = function(SIPCoreHandle:THandle;
                                                  sessionId:NativeInt;
                                                  state:boolean):integer; cdecl;

  TPortSIP_sendVideoStreamToRemote = function(SIPCoreHandle:THandle;
                                              sessionId:NativeInt;
                                              data:PByte;
                                              dataLength,
                                              width,
                                              height: integer):integer; cdecl;

  TPortSIP_enableAudioStreamCallback = function(SIPCoreHandle:THandle;
            sessionId: NativeInt;
            enable: boolean;
            callbackType:integer;
            CallbackObject:Pointer;
            callbackHandler:TaudioRawCallback):integer; cdecl;

  TPortSIP_enableVideoStreamCallback = function(SIPCoreHandle:THandle;
            sessionId: NativeInt;
            enable: boolean;
            callbackType:integer;
            CallbackObject:Pointer;
            callbackHandler:TvideoRawCallback):integer; cdecl;


  TPortSIP_startRecord = function(SIPCoreHandle:THandle;
                                  sessionId:NativeInt;
						                      recordFilePath,
                                  fileName:PAnsiChar;
                                  appendTimestamp:boolean;
						                      audioFileFormat:integer;
                                  audioRecordMode:integer;
                                  videoFileCodecType:integer;
                                  videoRecordMode:integer):integer; cdecl;
  TPortSIP_stopRecord = function(SIPCoreHandle:THandle; sessionId:NativeInt):integer; cdecl;
  TPortSIP_playAudioFileToRemote = function(SIPCoreHandle:THandle;
                                          sessionId: NativeInt;
                                          fileName:PAnsiChar;
                                          fileSamplesPerSec: integer;
                                          loop:boolean):integer; cdecl;
  TPortSIP_stopPlayAudioFileToRemote = function(SIPCoreHandle:THandle; sessionId:NativeInt):integer; cdecl;
  TPortSIP_playVideoFileToRemote = function(SIPCoreHandle:THandle;
                                          sessionId: NativeInt;
                                          fileName:PAnsiChar;
                                          loop:boolean;
                                          playAudio:boolean):integer; cdecl;
  TPortSIP_stopPlayVideoFileToRemote = function(SIPCoreHandle:THandle; sessionId:NativeInt):integer; cdecl;
  TPortSIP_playAudioFileToRemoteAsBackground = function(SIPCoreHandle:THandle;
                                          sessionId: NativeInt;
                                          fileName:PAnsiChar;
                                          fileSamplesPerSec: integer):integer; cdecl;
  TPortSIP_stopPlayAudioFileToRemoteAsBackground = function(SIPCoreHandle:THandle; sessionId:NativeInt):integer; cdecl;
  TPortSIP_createAudioConference = function(SIPCoreHandle:THandle):integer; cdecl;
  TPortSIP_createVideoConference = function(SIPCoreHandle:THandle;
                                       conferenceVideoWindow:THandle;
                                       width, height:integer;
                                       displayLocalVideoInConference:boolean):integer; cdecl;
  TPortSIP_destroyConference = procedure(SIPCoreHandle:THandle); cdecl;

  TPortSIP_setConferenceVideoWindow = function(SIPCoreHandle:THandle; videoWindow:THandle):integer; cdecl;
  TPortSIP_joinToConference = function(SIPCoreHandle:THandle; sessionId:NativeInt):integer; cdecl;
  TPortSIP_removeFromConference = function(SIPCoreHandle:THandle; sessionId:NativeInt):integer; cdecl;
  TPortSIP_setAudioRtcpBandwidth = function(SIPCoreHandle:THandle;
                                            sessionId: NativeInt;
                                            BitsRR: integer;
                                            BitsRS: integer;
                                            KBitsAS: integer):integer; cdecl;

  TPortSIP_setVideoRtcpBandwidth = function(SIPCoreHandle:THandle;
                                            sessionId: NativeInt;
                                            BitsRR: integer;
                                            BitsRS: integer;
                                            KBitsAS: integer):integer; cdecl;


  TPortSIP_getAudioStatistics = function(SIPCoreHandle:THandle;
                                            sessionId:NativeInt;
						                                var sendBytes,
                                            sendPackets,
                                            sendPacketsLost,
                                            sendFractionLost,
                                            sendRttMS,
                                            sendCodecType,
                                            sendJitterMS,
                                            sendAudioLevel,
                                            recvBytes,
                                            recvPackets,
                                            recvPacketsLost,
                                            recvFractionLost,
                                            recvCodecType,
                                            recvJitterMS,
                                            recvAudioLevel:integer):integer; cdecl;


  TPortSIP_getVideoStatistics = function(SIPCoreHandle:THandle;
						                                sessionId:NativeInt;
						                                var sendBytes,
                                            sendPackets,
                                            sendPacketsLost,
                                            sendFractionLost,
                                            sendRttMS,
                                            sendCodecType,
                                            sendFrameWidth,
                                            sendFrameHeight,
                                            sendBitrateBPS,
                                            sendFramerate,
                                            recvBytes,
                                            recvPackets,
                                            recvPacketsLost,
                                            recvFractionLost,
                                            recvCodecType,
                                            recvFrameWidth,
                                            recvFrameHeight,
                                            recvBitrateBPS,
                                            recvFramerate:integer):integer; cdecl;


  TPortSIP_enableVAD = procedure(SIPCoreHandle:THandle; state:boolean); cdecl;
  TPortSIP_enableAEC = procedure(SIPCoreHandle:THandle; mode:integer); cdecl;
  TPortSIP_enableCNG = procedure(SIPCoreHandle:THandle; state:boolean); cdecl;
  TPortSIP_enableAGC = procedure(SIPCoreHandle:THandle; mode:integer); cdecl;
  TPortSIP_enableANS = procedure(SIPCoreHandle:THandle; mode:integer); cdecl;

  TPortSIP_enableAudioQos = function(SIPCoreHandle:THandle; enable:boolean):integer; cdecl;
  TPortSIP_enableVideoQos = function(SIPCoreHandle:THandle;  enable:boolean):integer; cdecl;
  TPortSIP_setVideoMTU = function(SIPCoreHandle:THandle;  mtu:integer):integer; cdecl;

  TPortSIP_sendInfo = function(SIPCoreHandle:THandle; sessionId:NativeInt;
                                mimeType, subMimeType, infoContents:PAnsiChar):integer; cdecl;

  TPortSIP_sendSubscription = function(SIPCoreHandle:THandle; _to, eventName:PAnsiChar):integer; cdecl;
  TPortSIP_terminateSubscription = function(SIPCoreHandle:THandle; subscribeId:NativeInt):integer; cdecl;

  TPortSIP_setDefaultSubscriptionTime = function(SIPCoreHandle:THandle; secs:NativeInt):integer; cdecl;
  TPortSIP_setDefaultPublicationTime = function(SIPCoreHandle:THandle; secs:NativeInt):integer; cdecl;

  TPortSIP_sendOptions = function(SIPCoreHandle:THandle; _to, sdp:PAnsiChar):integer; cdecl;
  TPortSIP_sendMessage = function(SIPCoreHandle:THandle;
                                  sessionId:NativeInt;
                                  mimeType, subMimeType:PAnsiChar;
                                  messageData:PByte;
                                  messageLength:integer):integer; cdecl;
  TPortSIP_sendOutOfDialogMessage = function(SIPCoreHandle:THandle;
                                            _to, mimeType, subMimeType:PAnsiChar;
                                            isSMS: boolean;
                                             messageData:PByte;
                                            messageLength:integer):integer; cdecl;

  TPortSIP_presenceSubscribe = function(SIPCoreHandle:THandle; subscribeTo, subject:PAnsiChar):integer; cdecl;
  TPortSIP_presenceTerminateSubscribe = function(SIPCoreHandle:THandle; subscribeId:NativeInt):integer; cdecl;
  TPortSIP_presenceRejectSubscribe = function(SIPCoreHandle:THandle; subscribeId:NativeInt):integer; cdecl;
  TPortSIP_presenceAcceptSubscribe = function(SIPCoreHandle:THandle; subscribeId:NativeInt):integer; cdecl;

  TPortSIP_setPresenceMode = function(SIPCoreHandle:THandle; mode:Integer):integer; cdecl;
  TPortSIP_setPresenceStatus = function(SIPCoreHandle:THandle; subscribeId:NativeInt; stateText:PAnsiChar):integer; cdecl;

  TPortSIP_getNumOfRecordingDevices = function(SIPCoreHandle:THandle):integer; cdecl;

  TPortSIP_getNumOfPlayoutDevices = function(SIPCoreHandle:THandle):integer; cdecl;

  TPortSIP_getRecordingDeviceName = function(SIPCoreHandle:THandle;
				    index:integer;
						nameUTF8:PAnsiChar;
						nameUTF8Length:integer
            ):integer; cdecl;

  TPortSIP_getPlayoutDeviceName = function(SIPCoreHandle:THandle;
						index:integer;
						nameUTF8:PAnsiChar;
						nameUTF8Length:integer
            ):integer; cdecl;

  TPortSIP_setSpeakerVolume = function(SIPCoreHandle:THandle; volume:integer):integer; cdecl;
  TPortSIP_getSpeakerVolume = function(SIPCoreHandle:THandle):integer; cdecl;
  TPortSIP_setMicVolume = function(SIPCoreHandle:THandle; volume:integer):integer; cdecl;
  TPortSIP_getMicVolume = function(SIPCoreHandle:THandle):integer; cdecl;
  TPortSIP_audioPlayLoopbackTest = procedure(SIPCoreHandle:THandle; enable:boolean); cdecl;
   TPortSIP_getNumOfVideoCaptureDevices = function(SIPCoreHandle:THandle):integer; cdecl;

  TPortSIP_getVideoCaptureDeviceName = function(SIPCoreHandle:THandle;
						index:integer;
						uniqueIdUTF8:PAnsiChar;
						uniqueIdUTF8Length:integer;
						deviceNameUTF8:PAnsiChar;
						deviceNameUTF8Length:integer):integer; cdecl;

  TPortSIP_showVideoCaptureSettingsDialogBox = function(SIPCoreHandle:THandle;
						uniqueIdUTF8:PAnsiChar;
						uniqueIdUTF8Length:integer;
						dialogTitle:PAnsiChar;
            parentWindow:THandle;
						x:integer;
						y:integer):integer; cdecl;


////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
  TONRegisterSuccess = procedure(callbackIndex : NativeInt; reason:PAnsiChar; code:integer) of object;
  TONRegisterSuccessParams = class(TObject)
    callbackIndex : NativeInt;
    reason: Ansistring;
    code: integer;
  end;

  TONRegisterFailure = procedure(callbackIndex : NativeInt; reason:PAnsiChar; code:integer) of object;
  TONRegisterFailureParams = class(TObject)
    callbackIndex : integer;
    reason: Ansistring;
    code: integer;
  end;

  TONInviteIncoming = procedure(callbackIndex : NativeInt;
                              sessionId:NativeInt;
                              callerDisplayName:PAnsiChar;
                              caller:PAnsiChar;
                              calleeDisplayName:PAnsiChar;
                              callee:PAnsiChar;
                              audioCodecs:PAnsiChar;
                              videoCodecs:PAnsiChar;
                              existsAudio:boolean;
                              existsVideo:boolean;
                              message:PAnsiChar) of object;
  TONInviteIncomingParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  callerDisplayName:Ansistring;
  caller:Ansistring;
  calleeDisplayName:Ansistring;
  callee:Ansistring;
  audioCodecs:Ansistring;
  videoCodecs:Ansistring;
  existsAudio:boolean;
  existsVideo:boolean;
  message:Ansistring;
  end;

  TONInviteTrying = procedure(callbackIndex : NativeInt; sessionId:NativeInt) of object;
  TONInviteTryingParams = class(TObject)
    callbackIndex : integer;
    sessionId : integer;
  end;

  TONInviteSessionProgress = procedure(callbackIndex : NativeInt;
												    sessionId:NativeInt;
                            audioCodecs:PAnsiChar;
                            videoCodecs:PAnsiChar;
                            existsEarlyMedia:boolean;
                            existsAudio:boolean;
                            existsVideo:boolean;
                            message:PAnsiChar) of object;
  TONInviteSessionProgressParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  audioCodecs:Ansistring;
  videoCodecs:Ansistring;
  existsEarlyMedia:boolean;
  existsAudio:boolean;
  existsVideo:boolean;
  message:Ansistring;
  end;

  TONInviteRinging = procedure(callbackIndex : NativeInt;
                              sessionId:NativeInt;
                              statusText:PAnsiChar;
                              statusCode:integer;
                              message:PAnsiChar) of object;
  TONInviteRingingParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  statusText:Ansistring;
  statusCode:integer;
  message:Ansistring;
  end;

  TONInviteAnswered = procedure(callbackIndex : NativeInt;
                              sessionId:NativeInt;
                              callerDisplayName:PAnsiChar;
                              caller:PAnsiChar;
                              calleeDisplayName:PAnsiChar;
                              callee:PAnsiChar;
                              audioCodecs:PAnsiChar;
                              videoCodecs:PAnsiChar;
                              existsAudio:boolean;
                              existsVideo:boolean;
                              message:PAnsiChar) of object;
  TONInviteAnsweredParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  callerDisplayName:Ansistring;
  caller:Ansistring;
  calleeDisplayName:Ansistring;
  callee:Ansistring;
  audioCodecs:Ansistring;
  videoCodecs:Ansistring;
  existsAudio:boolean;
  existsVideo:boolean;
  message:Ansistring;
  end;

  TONInviteFailure = procedure(callbackIndex : NativeInt;
                              sessionId:NativeInt;
                              reason:PAnsiChar;
                              code:integer) of object;
  TONInviteFailureParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  reason:Ansistring;
  code:integer
  end;

   TONInviteUpdated = procedure(callbackIndex : NativeInt;
                              sessionId:NativeInt;
                              audioCodecs:PAnsiChar;
                              videoCodecs:PAnsiChar;
                              existsAudio:boolean;
                              existsVideo:boolean;
                              message:PAnsiChar) of object;
  TONInviteUpdatedParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  audioCodecs:Ansistring;
  videoCodecs:Ansistring;
  existsAudio:boolean;
  existsVideo:boolean;
  message:Ansistring;
  end;

  TONInviteConnected = procedure(callbackIndex : NativeInt; sessionId:NativeInt) of object;
  TONInviteConnectedParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  end;


  TONInviteBeginingForward = procedure(callbackIndex : NativeInt; forwardTo:PAnsiChar) of object;
  TONInviteBeginingForwardParams = class(TObject)
  callbackIndex : NativeInt;
  forwardTo:Ansistring;
  end;


  TONInviteClosed = procedure(callbackIndex : NativeInt; sessionId:NativeInt) of object;
  TONInviteClosedParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  end;

  TONDialogStateUpdated = procedure(callbackIndex : NativeInt; BLFMonitoredUri, BLFDialogState, BLFDialogId, BLFDialogDirection: PAnsiChar) of object;
  TONDialogStateUpdatedParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  BLFMonitoredUri: PAnsiChar;
  BLFDialogState: PAnsiChar;
  BLFDialogId: PAnsiChar;
  BLFDialogDirection: PAnsiChar;
  end;

  TONRemoteHold = procedure(callbackIndex : NativeInt; sessionId:NativeInt) of object;
  TONRemoteHoldParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  end;

  TONRemoteUnHold = procedure(callbackIndex : NativeInt;
                              sessionId:NativeInt;
                              audioCodecs:PAnsiChar;
                              videoCodecs:PAnsiChar;
                              existsAudio:boolean;
                              existsVideo:boolean) of object;
  TONRemoteUnHoldParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  audioCodecs:Ansistring;
  videoCodecs:Ansistring;
  existsAudio:boolean;
  existsVideo:boolean
  end;

  TONReceivedRefer = procedure(callbackIndex : NativeInt;
                              sessionId:NativeInt;
                              referId:NativeInt;
                              referTo:PAnsiChar;
                              from:PAnsiChar;
                              referSipMessage:PAnsiChar) of object;
  TONReceivedReferParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  referId:NativeInt;
  referTo:Ansistring;
  from:Ansistring;
  referSipMessage:Ansistring
  end;


  TONReferAccepted = procedure(callbackIndex : NativeInt; sessionId:NativeInt) of object;
  TONReferAcceptedParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  end;


  TONReferRejected = procedure(callbackIndex : NativeInt; sessionId:NativeInt) of object;
  TONReferRejectedParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  reason:Ansistring;
  code:integer;
  end;

  TONTransferTrying = procedure(callbackIndex : NativeInt; sessionId:NativeInt) of object;
  TONTransferTryingParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  end;

  TONTransferRinging = procedure(callbackIndex : NativeInt; sessionId:NativeInt) of object;
  TONTransferRingingParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  end;


  TONACTVTransferSuccess = procedure(callbackIndex : NativeInt; sessionId:NativeInt) of object;
  TONACTVTransferSuccessParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  end;

  TONACTVTransferFailure = procedure(callbackIndex : NativeInt; sessionId:NativeInt; reason:PAnsiChar; code:integer) of object;
  TONACTVTransferFailureParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  reason:Ansistring;
  code:integer;
  end;


  TONReceivedSignaling = procedure(callbackIndex : NativeInt; sessionId:NativeInt; sipSignaling:PAnsiChar) of object;
  TONReceivedSignalingParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  sipSignaling:Ansistring;
  end;

  TONSendingSignaling = procedure(callbackIndex : NativeInt; sessionId:NativeInt; sipSignaling:PAnsiChar) of object;
  TONSendingSignalingParams = class(TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  sipSignaling:Ansistring;
  end;

  TONWaitingVoiceMessage = procedure(callbackIndex : NativeInt;
                                    messageAccount:PAnsiChar;
                                    urgentNewMessageCount,
                                    urgentOldMessageCount,
                                    newMessageCount,
                                    oldMessageCount: integer) of object;
  TONWaitingVoiceMessageParams = class (TObject)
  callbackIndex : NativeInt;
  messageAccount:AnsiString;
  urgentNewMessageCount, urgentOldMessageCount, newMessageCount, oldMessageCount: integer;
  end;

  TONWaitingFaxMessage = procedure(callbackIndex : NativeInt;
                                    messageAccount:PAnsiChar;
                                    urgentNewMessageCount,
                                    urgentOldMessageCount,
                                    newMessageCount,
                                    oldMessageCount: integer) of object;
  TONWaitingFaxMessageParams = class (TObject)
    callbackIndex : NativeInt;
    messageAccount:AnsiString;
    urgentNewMessageCount, urgentOldMessageCount, newMessageCount, oldMessageCount:integer;
  end;

  TONRecvDtmfTone = procedure(callbackIndex : NativeInt;
                                    sessionId:NativeInt;
                                    tone:integer) of object;
  TONRecvDtmfToneParams = class (TObject)
    callbackIndex : NativeInt;
    sessionId:NativeInt;
    tone:integer;
  end;

  TONPresenceRecvSubscribe = procedure(callbackIndex : NativeInt;
                                      subscribeId:NativeInt;
                                      fromDisplayName:PAnsiChar;
                                      from:PAnsiChar;
                                      subject:PAnsiChar) of object;
  TONPresenceRecvSubscribeParams = class (TObject)
  callbackIndex : NativeInt;
  subscribeId:NativeInt;
  fromDisplayName:AnsiString;
  from:AnsiString;
  subject:AnsiString
  end;

  TONPresenceOnline = procedure(callbackIndex : NativeInt;
                                      fromDisplayName:PAnsiChar;
                                      from:PAnsiChar;
                                      stateText:PAnsiChar) of object;
  TONPresenceOnlineParams = class (TObject)
  callbackIndex : NativeInt;
  fromDisplayName:AnsiString;
  from:AnsiString;
  stateText:AnsiString
  end;


  TONPresenceOffline = procedure(callbackIndex : NativeInt;
                                      fromDisplayName:PAnsiChar;
                                      from:PAnsiChar) of object;
  TONPresenceOfflineParams = class (TObject)
  callbackIndex : NativeInt;
  fromDisplayName:AnsiString;
  from:AnsiString;
  end;

  TONRecvOptions = procedure(callbackIndex : NativeInt; optionsMessage:PAnsiChar) of object;
  TONRecvOptionsParams = class (TObject)
  callbackIndex : NativeInt;
  optionsMessage:AnsiString;
  end;

  TONRecvInfo = procedure(callbackIndex : NativeInt; infoMessage:PAnsiChar) of object;
  TONRecvInfoParams = class (TObject)
  callbackIndex : NativeInt;
  infoMessage:AnsiString;
  end;


  TONPlayAudioFileFinished = procedure(callbackIndex : NativeInt; sessionId:NativeInt; fileName:PAnsiChar) of object;
  TONPlayAudioFileFinishedParams = class (TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  fileName:AnsiString;
  end;

  TONPlayVideoFileFinished = procedure(callbackIndex : NativeInt;sessionId:NativeInt) of object;
  TONPlayVideoFileFinishedParams = class (TObject)
  callbackIndex : NativeInt;
  sessionId:NativeInt;
  end;


  TONRecvMessage = procedure(callbackIndex : NativeInt;
                            sessionId:NativeInt;
                            mimeType:PAnsiChar;
                            subMimeType:PAnsiChar;
                            messageData:PByte;
                            messageDataLength:integer) of object;
  TONRecvMessageParams = class (TObject)
    callbackIndex : NativeInt;
    sessionId:NativeInt;
    mimeType:AnsiString;
    subMimeType:AnsiString;
    messageData:PByte;
    messageDataLength:integer;
  end;


  TONRecvOutOfDialogMessage = procedure(callbackIndex : NativeInt;
                            fromDisplayName:PAnsiChar;
                            from:PAnsiChar;
                            toDisplayName:PAnsiChar;
                            sendTo:PAnsiChar;
                            mimeType:PAnsiChar;
                            subMimeType:PAnsiChar;
                            messageData:PByte;
                            messageDataLength:integer) of object;
  TONRecvOutOfDialogMessageParams = class (TObject)
    callbackIndex : NativeInt;
    fromDisplayName:AnsiString;
    from:AnsiString;
    toDisplayName:AnsiString;
    sendTo:AnsiString;
    mimeType:AnsiString;
    subMimeType:AnsiString;
    messageData:PByte;
    messageDataLength:integer;
  end;

  TONSendMessageSuccess = procedure(callbackIndex : NativeInt;
                            sessionId, messageId:NativeInt) of object;
  TONSendMessageSuccessParams = class (TObject)
    callbackIndex : NativeInt;
    sessionId:NativeInt;
    messageId:NativeInt;
  end;


  TONSendMessageFailure = procedure(callbackIndex : NativeInt;
                            sessionId, messageId:NativeInt;
                            reason:PAnsiChar;
                            code:integer) of object;
  TONSendMessageFailureParams = class (TObject)
    callbackIndex : NativeInt;
    sessionId:NativeInt;
    messageId:NativeInt;
    reason:AnsiString;
    code:integer;
  end;

  TONSendOutOfDialogMessageSuccess = procedure(callbackIndex, messageId: NativeInt;
                            fromDisplayName:PAnsiChar;
                            from:PAnsiChar;
                            toDisplayName:PAnsiChar;
                            sendTo:PAnsiChar) of object;
  TONSendOutOfDialogMessageSuccessParams = class (TObject)
    callbackIndex : NativeInt;
    messageId: NativeInt;
    fromDisplayName:AnsiString;
    from:AnsiString;
    toDisplayName:AnsiString;
    sendTo:AnsiString;
  end;

  TONSendOutOfDialogMessageFailure = procedure(callbackIndex, messageId: NativeInt;
                            fromDisplayName:PAnsiChar;
                            from:PAnsiChar;
                            toDisplayName:PAnsiChar;
                            sendTo:PAnsiChar;
                            reason:PAnsiChar;
                            code:integer) of object;
  TONSendOutOfDialogMessageFailureParams = class (TObject)
    callbackIndex : NativeInt;
    messageId: NativeInt;
    fromDisplayName:AnsiString;
    from:AnsiString;
    toDisplayName:AnsiString;
    sendTo:AnsiString;
    reason:AnsiString;
    code:integer;
  end;



  TPSCallback_createCallbackDispatcher = function ():THandle; cdecl;
  TPSCallback_releaseCallbackDispatcher = procedure (callbackDispatcher:THandle); cdecl;

  TPSCallback_setRegisterSuccessHandler = procedure(callbackDispatcher:THandle; eventHandler: TRegisterSuccess; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setRegisterFailureHandler = procedure(callbackDispatcher:THandle; eventHandler: TRegisterFailure; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setInviteIncomingHandler = procedure(callbackDispatcher:THandle; eventHandler: TInviteIncoming; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setInviteTryingHandler = procedure(callbackDispatcher:THandle; eventHandler: TInviteTrying; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setInviteSessionProgressHandler = procedure(callbackDispatcher:THandle; eventHandler: TInviteSessionProgress; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setInviteRingingHandler = procedure(callbackDispatcher:THandle; eventHandler: TInviteRinging; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setInviteAnsweredHandler = procedure(callbackDispatcher:THandle; eventHandler: TInviteAnswered; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setInviteFailureHandler = procedure(callbackDispatcher:THandle; eventHandler: TInviteFailure; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setInviteUpdatedHandler = procedure(callbackDispatcher:THandle; eventHandler: TInviteUpdated; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setInviteConnectedHandler = procedure(callbackDispatcher:THandle; eventHandler: TInviteConnected; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setInviteBeginingForwardHandler = procedure(callbackDispatcher:THandle; eventHandler: TInviteBeginingForward; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setInviteClosedHandler = procedure(callbackDispatcher:THandle; eventHandler: TInviteClosed; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setDialogStateUpdatedHandler = procedure(callbackDispatcher:THandle; eventHandler: TDialogStateUpdated; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setRemoteHoldHandler = procedure(callbackDispatcher:THandle; eventHandler: TRemoteHold; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setRemoteUnHoldHandler = procedure(callbackDispatcher:THandle; eventHandler: TRemoteUnHold; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setReceivedReferHandler = procedure(callbackDispatcher:THandle; eventHandler: TReceivedRefer; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setReferAcceptedHandler = procedure(callbackDispatcher:THandle; eventHandler: TReferAccepted; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setReferRejectedHandler = procedure(callbackDispatcher:THandle; eventHandler: TReferRejected; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setTransferTryingHandler = procedure(callbackDispatcher:THandle; eventHandler: TTransferTrying; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setTransferRingingHandler = procedure(callbackDispatcher:THandle; eventHandler: TTransferRinging; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setACTVTransferSuccessHandler = procedure(callbackDispatcher:THandle; eventHandler: TACTVTransferSuccess; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setACTVTransferFailureHandler = procedure(callbackDispatcher:THandle; eventHandler: TACTVTransferFailure; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setReceivedSignalingHandler = procedure(callbackDispatcher:THandle; eventHandler: TReceivedSignaling; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setSendingSignalingHandler = procedure(callbackDispatcher:THandle; eventHandler: TSendingSignaling; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setWaitingVoiceMessageHandler = procedure(callbackDispatcher:THandle; eventHandler: TWaitingVoiceMessage; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setWaitingFaxMessageHandler = procedure(callbackDispatcher:THandle; eventHandler: TWaitingFaxMessage; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setRecvDtmfToneHandler = procedure(callbackDispatcher:THandle; eventHandler: TRecvDtmfTone; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setPresenceRecvSubscribeHandler = procedure(callbackDispatcher:THandle; eventHandler: TPresenceRecvSubscribe; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setPresenceOnlineHandler = procedure(callbackDispatcher:THandle; eventHandler: TPresenceOnline; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setPresenceOfflineHandler = procedure(callbackDispatcher:THandle; eventHandler: TPresenceOffline; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setRecvOptionsHandler = procedure(callbackDispatcher:THandle; eventHandler: TRecvOptions; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setRecvInfoHandler = procedure(callbackDispatcher:THandle; eventHandler: TRecvInfo; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;

  TPSCallback_setPlayAudioFileFinishedHandler = procedure(callbackDispatcher:THandle; eventHandler: TPlayAudioFileFinished; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setPlayVideoFileFinishedHandler = procedure(callbackDispatcher:THandle; eventHandler: TPlayVideoFileFinished; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setRecvMessageHandler = procedure(callbackDispatcher:THandle; eventHandler: TRecvMessage; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;

  TPSCallback_setRecvOutOfDialogMessageHandler = procedure(callbackDispatcher:THandle;
												                                    eventHandler: TRecvOutOfDialogMessage;
												                                    callbackIndex:NativeInt;
												                                    callbackObject:integer); cdecl;
  TPSCallback_setSendMessageSuccessHandler = procedure(callbackDispatcher:THandle; eventHandler: TSendMessageSuccess; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setSendMessageFailureHandler = procedure(callbackDispatcher:THandle; eventHandler: TSendMessageFailure; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setSendOutOfDialogMessageSuccessHandler = procedure(callbackDispatcher:THandle; eventHandler: TSendOutOfDialogMessageSuccess; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;
  TPSCallback_setSendOutOfDialogMessageFailureHandler = procedure(callbackDispatcher:THandle; eventHandler: TSendOutOfDialogMessageFailure; callbackIndex:NativeInt; callbackObject:NativeInt); cdecl;

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

  TPortSipObject = class(TObject)

  private
    fDLLPath: string;
    fFullDLLPathName: string;
    fCallbackDispatcher: THandle;
    fSDKLib: THandle;
    fSDKLibModule: HModule;
    fCallbackIndex: NativeInt;

  // Functions
	fPortSIP_delCallbackParameters: TPortSIP_delCallbackParameters;
 	fPortSIP_initialize: TPortSIP_initialize;
  fPortSIP_setDisplayName: TPortSIP_setDisplayName;
 	fPortSIP_setInstanceId: TPortSIP_setInstanceId;
 	fPortSIP_unInitialize: TPortSIP_unInitialize;
 	fPortSIP_setLicenseKey: TPortSIP_setLicenseKey;
 	fPortSIP_getNICNums: TPortSIP_getNICNums;
 	fPortSIP_getLocalIpAddress: TPortSIP_getLocalIpAddress;
 	fPortSIP_setUser: TPortSIP_setUser;
 	fPortSIP_removeUser: TPortSIP_removeUser;
 	fPortSIP_registerServer: TPortSIP_registerServer;
  fPortSIP_refreshRegistration: TPortSIP_refreshRegistration;
 	fPortSIP_unRegisterServer: TPortSIP_unRegisterServer;
 	fPortSIP_getVersion: TPortSIP_getVersion;
  fPortSIP_enableRport: TPortSIP_enableRport;
  fPortSIP_enableEarlyMedia: TPortSIP_enableEarlyMedia;
 	fPortSIP_enableReliableProvisional: TPortSIP_enableReliableProvisional;
 	fPortSIP_enable3GppTags: TPortSIP_enable3GppTags;
 	fPortSIP_enableCallbackSignaling: TPortSIP_enableCallbackSignaling;
 	fPortSIP_setRtpCallback: TPortSIP_setRtpCallback;
 	fPortSIP_addAudioCodec: TPortSIP_addAudioCodec;
 	fPortSIP_addVideoCodec: TPortSIP_addVideoCodec;
 	fPortSIP_isAudioCodecEmpty: TPortSIP_isAudioCodecEmpty;
 	fPortSIP_isVideoCodecEmpty: TPortSIP_isVideoCodecEmpty;
 	fPortSIP_setAudioCodecPayloadType: TPortSIP_setAudioCodecPayloadType;
 	fPortSIP_setVideoCodecPayloadType: TPortSIP_setVideoCodecPayloadType;
 	fPortSIP_clearAudioCodec: TPortSIP_clearAudioCodec;
 	fPortSIP_clearVideoCodec: TPortSIP_clearVideoCodec;
 	fPortSIP_setAudioCodecParameter: TPortSIP_setAudioCodecParameter;
 	fPortSIP_setVideoCodecParameter: TPortSIP_setVideoCodecParameter;
 	fPortSIP_setSrtpPolicy: TPortSIP_setSrtpPolicy;
 	fPortSIP_setRtpPortRange: TPortSIP_setRtpPortRange;
 	fPortSIP_setRtcpPortRange: TPortSIP_setRtcpPortRange;
 	fPortSIP_enableCallForward: TPortSIP_enableCallForward;
 	fPortSIP_disableCallForward: TPortSIP_disableCallForward;
 	fPortSIP_enableSessionTimer: TPortSIP_enableSessionTimer;
 	fPortSIP_disableSessionTimer: TPortSIP_disableSessionTimer;
 	fPortSIP_setDoNotDisturb: TPortSIP_setDoNotDisturb;
 	fPortSIP_enableAutoCheckMwi: TPortSIP_enableAutoCheckMwi;
 	fPortSIP_setRtpKeepAlive: TPortSIP_setRtpKeepAlive;
 	fPortSIP_setKeepAliveTime: TPortSIP_setKeepAliveTime;
 	fPortSIP_getSipMessageHeaderValue: TPortSIP_getSipMessageHeaderValue;
 	fPortSIP_addSipMessageHeader: TPortSIP_addSipMessageHeader;
  fPortSIP_removeAddedSipMessageHeader : TPortSIP_removeAddedSipMessageHeader;
 	fPortSIP_clearAddedSipMessageHeaders: TPortSIP_clearAddedSipMessageHeaders;
 	fPortSIP_modifySipMessageHeader: TPortSIP_modifySipMessageHeader;
  fPortSIP_removeModifiedSipMessageHeader : TPortSIP_removeModifiedSipMessageHeader;
 	fPortSIP_clearModifiedSipMessageHeaders: TPortSIP_clearModifiedSipMessageHeaders;
 	fPortSIP_addSupportedMimeType: TPortSIP_addSupportedMimeType;
 	fPortSIP_setAudioSamples: TPortSIP_setAudioSamples;
  fPortSIP_setAudioBitrate: TPortSIP_setAudioBitrate;
 	fPortSIP_setAudioDeviceId: TPortSIP_setAudioDeviceId;
 	fPortSIP_setVideoDeviceId: TPortSIP_setVideoDeviceId;
 	fPortSIP_setVideoResolution: TPortSIP_setVideoResolution;
 	fPortSIP_setVideoBitrate: TPortSIP_setVideoBitrate;
 	fPortSIP_setVideoFrameRate: TPortSIP_setVideoFrameRate;
 	fPortSIP_sendVideo: TPortSIP_sendVideo;
 	fPortSIP_muteMicrophone: TPortSIP_muteMicrophone;
 	fPortSIP_muteSpeaker: TPortSIP_muteSpeaker;
 	fPortSIP_setChannelOutputVolumeScaling: TPortSIP_setChannelOutputVolumeScaling;
	fPortSIP_setChannelInputVolumeScaling: TPortSIP_setChannelInputVolumeScaling;
 	fPortSIP_setLocalVideoWindow: TPortSIP_setLocalVideoWindow;
 	fPortSIP_setRemoteVideoWindow: TPortSIP_setRemoteVideoWindow;
 	fPortSIP_displayLocalVideo: TPortSIP_displayLocalVideo;
 	fPortSIP_setVideoNackStatus: TPortSIP_setVideoNackStatus;
 	fPortSIP_call: TPortSIP_call;
 	fPortSIP_rejectCall: TPortSIP_rejectCall;
 	fPortSIP_hangUp: TPortSIP_hangUp;
 	fPortSIP_answerCall: TPortSIP_answerCall;
 	fPortSIP_updateCall: TPortSIP_updateCall;
 	fPortSIP_hold: TPortSIP_hold;
 	fPortSIP_unHold: TPortSIP_unHold;
 	fPortSIP_refer: TPortSIP_refer;
 	fPortSIP_attendedRefer: TPortSIP_attendedRefer;
  fPortSIP_attendedRefer2: TPortSIP_attendedRefer2;
  fPortSIP_outOfDialogRefer: TPortSIP_outOfDialogRefer;
 	fPortSIP_acceptRefer: TPortSIP_acceptRefer;
 	fPortSIP_rejectRefer: TPortSIP_rejectRefer;
 	fPortSIP_muteSession: TPortSIP_muteSession;
 	fPortSIP_forwardCall: TPortSIP_forwardCall;
  fPortSIP_pickupBLFCall: TPortSIP_pickupBLFCall;
 	fPortSIP_sendDtmf: TPortSIP_sendDtmf;
 	fPortSIP_enableSendPcmStreamToRemote: TPortSIP_enableSendPcmStreamToRemote;
 	fPortSIP_sendPcmStreamToRemote: TPortSIP_sendPcmStreamToRemote;
 	fPortSIP_enableSendVideoStreamToRemote: TPortSIP_enableSendVideoStreamToRemote;
 	fPortSIP_sendVideoStreamToRemote: TPortSIP_sendVideoStreamToRemote;
 	fPortSIP_enableAudioStreamCallback: TPortSIP_enableAudioStreamCallback;
 	fPortSIP_enableVideoStreamCallback: TPortSIP_enableVideoStreamCallback;
 	fPortSIP_startRecord: TPortSIP_startRecord;
 	fPortSIP_stopRecord: TPortSIP_stopRecord;
 	fPortSIP_playVideoFileToRemote: TPortSIP_playVideoFileToRemote;
 	fPortSIP_stopPlayVideoFileToRemote: TPortSIP_stopPlayVideoFileToRemote;
 	fPortSIP_playAudioFileToRemote: TPortSIP_playAudioFileToRemote;
 	fPortSIP_stopPlayAudioFileToRemote: TPortSIP_stopPlayAudioFileToRemote;
 	fPortSIP_playAudioFileToRemoteAsBackground: TPortSIP_playAudioFileToRemoteAsBackground;
 	fPortSIP_stopPlayAudioFileToRemoteAsBackground: TPortSIP_stopPlayAudioFileToRemoteAsBackground;
 	fPortSIP_createAudioConference: TPortSIP_createAudioConference;
 	fPortSIP_createVideoConference: TPortSIP_createVideoConference;
 	fPortSIP_destroyConference: TPortSIP_destroyConference;
 	fPortSIP_joinToConference: TPortSIP_joinToConference;
  fPortSIP_setConferenceVideoWindow: TPortSIP_setConferenceVideoWindow;
 	fPortSIP_removeFromConference: TPortSIP_removeFromConference;
 	fPortSIP_setAudioRtcpBandwidth: TPortSIP_setAudioRtcpBandwidth;
 	fPortSIP_setVideoRtcpBandwidth: TPortSIP_setVideoRtcpBandwidth;
 	fPortSIP_getAudioStatistics: TPortSIP_getAudioStatistics;
 	fPortSIP_getVideoStatistics: TPortSIP_getVideoStatistics;
 	fPortSIP_enableVAD: TPortSIP_enableVAD;
 	fPortSIP_enableAEC: TPortSIP_enableAEC;
 	fPortSIP_enableCNG: TPortSIP_enableCNG;
 	fPortSIP_enableAGC: TPortSIP_enableAGC;
 	fPortSIP_enableANS: TPortSIP_enableANS;
 	fPortSIP_enableAudioQos: TPortSIP_enableAudioQos;
 	fPortSIP_enableVideoQos: TPortSIP_enableVideoQos;
  fPortSIP_setVideoMTU: TPortSIP_setVideoMTU;
 	fPortSIP_sendOptions: TPortSIP_sendOptions;
  fPortSIP_sendSubscription: TPortSIP_sendSubscription;
  fPortSIP_terminateSubscription: TPortSIP_terminateSubscription;
  fPortSIP_setDefaultSubscriptionTime: TPortSIP_setDefaultSubscriptionTime;
  fPortSIP_setDefaultPublicationTime: TPortSIP_setDefaultPublicationTime;
 	fPortSIP_sendInfo: TPortSIP_sendInfo;
 	fPortSIP_sendMessage: TPortSIP_sendMessage;
 	fPortSIP_sendOutOfDialogMessage: TPortSIP_sendOutOfDialogMessage;
 	fPortSIP_presenceSubscribe: TPortSIP_presenceSubscribe;
  fPortSIP_presenceTerminateSubscribe: TPortSIP_presenceTerminateSubscribe;
 	fPortSIP_presenceAcceptSubscribe: TPortSIP_presenceAcceptSubscribe;
 	fPortSIP_presenceRejectSubscribe: TPortSIP_presenceRejectSubscribe;
  fPortSIP_setPresenceMode: TPortSIP_setPresenceMode;
 	fPortSIP_setPresenceStatus: TPortSIP_setPresenceStatus;
 	fPortSIP_getNumOfRecordingDevices: TPortSIP_getNumOfRecordingDevices;
 	fPortSIP_getNumOfPlayoutDevices: TPortSIP_getNumOfPlayoutDevices;
 	fPortSIP_getRecordingDeviceName: TPortSIP_getRecordingDeviceName;
 	fPortSIP_getPlayoutDeviceName: TPortSIP_getPlayoutDeviceName;
 	fPortSIP_setSpeakerVolume: TPortSIP_setSpeakerVolume;
 	fPortSIP_getSpeakerVolume: TPortSIP_getSpeakerVolume;
 	fPortSIP_setMicVolume: TPortSIP_setMicVolume;
 	fPortSIP_getMicVolume: TPortSIP_getMicVolume;
 	fPortSIP_audioPlayLoopbackTest: TPortSIP_audioPlayLoopbackTest;
 	fPortSIP_getNumOfVideoCaptureDevices: TPortSIP_getNumOfVideoCaptureDevices;
 	fPortSIP_getVideoCaptureDeviceName: TPortSIP_getVideoCaptureDeviceName;
 	fPortSIP_showVideoCaptureSettingsDialogBox: TPortSIP_showVideoCaptureSettingsDialogBox;

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

  fPSCallback_createCallbackDispatcher: TPSCallback_createCallbackDispatcher;
  fPSCallback_releaseCallbackDispatcher: TPSCallback_releaseCallbackDispatcher;
  fPSCallback_setRegisterSuccessHandler: TPSCallback_setRegisterSuccessHandler;
  fPSCallback_setRegisterFailureHandler: TPSCallback_setRegisterFailureHandler;
  fPSCallback_setInviteIncomingHandler: TPSCallback_setInviteIncomingHandler;
  fPSCallback_setInviteTryingHandler: TPSCallback_setInviteTryingHandler;
  fPSCallback_setInviteSessionProgressHandler: TPSCallback_setInviteSessionProgressHandler;
  fPSCallback_setInviteRingingHandler: TPSCallback_setInviteRingingHandler;
  fPSCallback_setInviteAnsweredHandler: TPSCallback_setInviteAnsweredHandler;
  fPSCallback_setInviteFailureHandler: TPSCallback_setInviteFailureHandler;
  fPSCallback_setInviteUpdatedHandler: TPSCallback_setInviteUpdatedHandler;
  fPSCallback_setInviteConnectedHandler: TPSCallback_setInviteConnectedHandler;
  fPSCallback_setInviteBeginingForwardHandler: TPSCallback_setInviteBeginingForwardHandler;
  fPSCallback_setInviteClosedHandler: TPSCallback_setInviteClosedHandler;
  fPSCallback_setDialogStateUpdatedHandler: TPSCallback_setDialogStateUpdatedHandler;
  fPSCallback_setRemoteHoldHandler: TPSCallback_setRemoteHoldHandler;
  fPSCallback_setRemoteUnHoldHandler: TPSCallback_setRemoteUnHoldHandler;
  fPSCallback_setReceivedReferHandler: TPSCallback_setReceivedReferHandler;
  fPSCallback_setReferAcceptedHandler: TPSCallback_setReferAcceptedHandler;
  fPSCallback_setReferRejectedHandler: TPSCallback_setReferRejectedHandler;
  fPSCallback_setTransferTryingHandler: TPSCallback_setTransferTryingHandler;
  fPSCallback_setTransferRingingHandler: TPSCallback_setTransferRingingHandler;
  fPSCallback_setACTVTransferSuccessHandler: TPSCallback_setACTVTransferSuccessHandler;
  fPSCallback_setACTVTransferFailureHandler: TPSCallback_setACTVTransferFailureHandler;
  fPSCallback_setReceivedSignalingHandler: TPSCallback_setReceivedSignalingHandler;
  fPSCallback_setSendingSignalingHandler: TPSCallback_setSendingSignalingHandler;
  fPSCallback_setWaitingVoiceMessageHandler: TPSCallback_setWaitingVoiceMessageHandler;
  fPSCallback_setWaitingFaxMessageHandler: TPSCallback_setWaitingFaxMessageHandler;
  fPSCallback_setRecvDtmfToneHandler: TPSCallback_setRecvDtmfToneHandler;
  fPSCallback_setPresenceRecvSubscribeHandler: TPSCallback_setPresenceRecvSubscribeHandler;
  fPSCallback_setPresenceOnlineHandler: TPSCallback_setPresenceOnlineHandler;
  fPSCallback_setPresenceOfflineHandler: TPSCallback_setPresenceOfflineHandler;
  fPSCallback_setRecvOptionsHandler: TPSCallback_setRecvOptionsHandler;
  fPSCallback_setRecvInfoHandler: TPSCallback_setRecvInfoHandler;
  fPSCallback_setPlayAudioFileFinishedHandler: TPSCallback_setPlayAudioFileFinishedHandler;
  fPSCallback_setPlayVideoFileFinishedHandler: TPSCallback_setPlayVideoFileFinishedHandler;
  fPSCallback_setRecvMessageHandler: TPSCallback_setRecvMessageHandler;
  fPSCallback_setRecvOutOfDialogMessageHandler: TPSCallback_setRecvOutOfDialogMessageHandler;
  fPSCallback_setSendMessageSuccessHandler: TPSCallback_setSendMessageSuccessHandler;
  fPSCallback_setSendMessageFailureHandler: TPSCallback_setSendMessageFailureHandler;
  fPSCallback_setSendOutOfDialogMessageSuccessHandler: TPSCallback_setSendOutOfDialogMessageSuccessHandler;
  fPSCallback_setSendOutOfDialogMessageFailureHandler: TPSCallback_setSendOutOfDialogMessageFailureHandler;

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

  fRegisterSuccess: TONRegisterSuccess;
  fRegisterFailure: TONRegisterFailure;
  fInviteIncoming: TONInviteIncoming;
  fInviteTrying: TONInviteTrying;
  fInviteSessionProgress: TONInviteSessionProgress;
  fInviteRinging: TONInviteRinging;
  fInviteAnswered: TONInviteAnswered;
  fInviteFailure: TONInviteFailure;
  fInviteUpdated: TONInviteUpdated;
  fInviteConnected: TONInviteConnected;
  fInviteBeginingForward: TONInviteBeginingForward;
  fInviteClosed: TONInviteClosed;
  fDialogStateUpdated: TONDialogStateUpdated;
  fRemoteHold: TONRemoteHold;
  fRemoteUnHold: TONRemoteUnHold;
  fReceivedRefer: TONReceivedRefer;
  fReferAccepted: TONReferAccepted;
  fReferRejected: TONReferRejected;
  fTransferTrying: TONTransferTrying;
  fTransferRinging: TONTransferRinging;
  fACTVTransferSuccess: TONACTVTransferSuccess;
  fACTVTransferFailure: TONACTVTransferFailure;
  fReceivedSignaling: TONReceivedSignaling;
  fSendingSignaling: TONSendingSignaling;
  fWaitingVoiceMessage: TONWaitingVoiceMessage;
  fWaitingFaxMessage: TONWaitingFaxMessage;
  fRecvDtmfTone: TONRecvDtmfTone;
  fPresenceRecvSubscribe: TONPresenceRecvSubscribe;
  fPresenceOnline: TONPresenceOnline;
  fPresenceOffline: TONPresenceOffline;
  fRecvOptions: TONRecvOptions;
  fRecvInfo: TONRecvInfo;
  fPlayAudioFileFinished: TONPlayAudioFileFinished;
  fPlayVideoFileFinished: TONPlayVideoFileFinished;
  fRecvMessage: TONRecvMessage;
  fRecvOutOfDialogMessage: TONRecvOutOfDialogMessage;
  fSendMessageSuccess: TONSendMessageSuccess;
  fSendMessageFailure: TONSendMessageFailure;
  fSendOutOfDialogMessageSuccess: TONSendOutOfDialogMessageSuccess;
  fSendOutOfDialogMessageFailure: TONSendOutOfDialogMessageFailure;


  ///
  ///
  public

  procedure delCallbackParameters(parameters: pointer);
  function initialize(transportType: integer;
                  localIP: PAnsiChar;
                  localSipPort: integer;
            			logLevel: integer;
            			logFilePath: PAnsiChar;
					      	maxCallSessions: integer;
						      sipAgentString: PAnsiChar;
            			audioDeviceLayer: integer;
            			videoDeviceLayer: integer;
                  TLSCertificatesRootPath : PAnsiChar;
                  TLSCipherist: PAnsiChar;
                  verifyTLSCertificate : boolean):integer;
  function setDisplayName(displayName: PAnsiChar): integer;
  function setInstanceId(uuid: PAnsiChar): integer;

  procedure unInitialize();
  function setLicenseKey(licenseKey: PAnsiChar):integer;
  function getNICNums():integer;
  function getLocalIpAddress(index: integer; ip:PAnsiChar; ipSize:integer): integer;
  function setUser(userName,
                   displayName,
                   authName,
                   password,
                   sipDomain,
                   sipServerAddr: PAnsiChar;
                   sipServerPort: integer;
                   stunServerAddr: PAnsiChar;
                   stunServerPort: integer;
                   outboundServerAddr: PAnsiChar;
                   outboundServerPort: integer): integer;
  procedure removeUser();

  function registerServer(regExpires: integer; retryTimes: integer): integer;
  function refreshRegistration(regExpires: integer): integer;
  function unRegisterServer(): integer;
  function getVersion(var majorVersion:integer; var minorVersion:integer): integer;
  function enableRport(enable: boolean): integer;
  function enableEarlyMedia(enable: boolean): integer;
  function enableReliableProvisional(enable: boolean): integer;
  function enable3GppTags(enable: boolean): integer;
  procedure enableCallbackSignaling(enableSending:boolean; enableReceived:boolean);
  function setRtpCallback(obj: pointer; receivedCallback: TReceivedRTPPacket; sendingCallback: TSendingRTPPacket): integer;
  function addAudioCodec(codecType: integer): integer;
  function addVideoCodec(codecType: integer): integer;
  function isAudioCodecEmpty(): boolean;
  function isVideoCodecEmpty(): boolean;
  function setAudioCodecPayloadType(codecType: integer; payloadType: integer): integer;
  function setVideoCodecPayloadType(codecType: integer; payloadType: integer): integer;
  procedure clearAudioCodec();
  procedure clearVideoCodec();
  function setAudioCodecParameter(codecType: integer; parameter: PAnsiChar): integer;
  function setVideoCodecParameter(codecType: integer; parameter: PAnsiChar): integer;
  function setSrtpPolicy(srtpPolicy:integer; allowSrtpOverUnsecureTransport : boolean): integer;
  function setRtpPortRange(
            minimumRtpAudioPort: integer;
            maximumRtpAudioPort: integer;
            minimumRtpVideoPort: integer;
            maximumRtpVideoPort: integer): integer;
    function setRtcpPortRange(
            minimumRtcpAudioPort: integer;
            maximumRtcpAudioPort: integer;
            minimumRtcpVideoPort: integer;
            maximumRtcpVideoPort: integer):integer;
    function enableCallForward(forBusyOnly:boolean; forwardTo:PAnsiChar): integer;
    function disableCallForward(): integer;
    function enableSessionTimer(timerSeconds: integer; refreshMode: integer): integer;
    function disableSessionTimer(): integer;
    procedure setDoNotDisturb(state: boolean);
    function enableAutoCheckMwi(state: boolean): integer;
    function setRtpKeepAlive(state: boolean; keepAlivePayloadType: integer; deltaTransmitTimeMS: integer): integer;
    function setKeepAliveTime(keepAliveTime: integer): integer;
    function getSipMessageHeaderValue(sipMessage, headerName, headerValue: PAnsiChar; headerValueLength: integer): integer;

    function addSipMessageHeader(sessionId:NativeInt;
                                          methodName:PAnsiChar;
                                          msgType:integer;
                                          headerName,
                                          headerValue:PAnsiChar):NativeInt;
    function removeAddedSipMessageHeader(sipMessageHeaderId : NativeInt): integer;
    function modifySipMessageHeader(sessionId:NativeInt;
                                          methodName:PAnsiChar;
                                          msgType:integer;
                                          headerName,
                                          headerValue:PAnsiChar):NativeInt;
    function removeModifiedSipMessageHeader(sipMessageHeaderId : NativeInt): integer;
    procedure clearModifiedSipMessageHeaders();
    procedure clearAddedSipMessageHeaders();

    function addSupportedMimeType(methodName, mimeType, subMimeType: PAnsiChar): integer;
    function setAudioSamples(ptime, maxPtime: integer): integer;
    function setAudioBitrate(sessionId: NativeInt; codecType, bitrateKbps: integer): integer;
    function setAudioDeviceId(inputDeviceId, outputDeviceId: integer): integer;
    function setVideoDeviceId(deviceId: integer): integer;
    function setVideoResolution(width, height:integer): integer;
    function setVideoBitrate(sessionId: NativeInt; bitrateKbps: integer): integer;
    function setVideoFrameRate(sessionId: NativeInt; frameRate: integer): integer;
    function sendVideo(sessionId: NativeInt; sendState: boolean): integer;
    procedure muteMicrophone(mute: boolean);
    procedure muteSpeaker(mute: boolean);
    procedure setChannelOutputVolumeScaling(sessionId:NativeInt; scaling:integer);
	procedure setChannelInputVolumeScaling(sessionId:NativeInt; scaling:integer);
    procedure setLocalVideoWindow(localVideoWindow: THandle);
    function setRemoteVideoWindow(sessionId: NativeInt; remoteVideoWindow: THandle): integer;
    function displayLocalVideo(state: boolean): integer;
    function setVideoNackStatus(state: boolean): integer;

    function call(callee: PAnsiChar; sendSdp: boolean; videoCall: boolean): integer;
    function rejectCall(sessionId: NativeInt; code: integer): integer;
    function hangUp(sessionId: NativeInt): integer;
    function answerCall(sessionId: NativeInt; videoCall: boolean): integer;
    function updateCall(sessionId: NativeInt; enableAudio: boolean; enableVideo: boolean): integer;
    function hold(sessionId: NativeInt): integer;
    function unHold(sessionId: NativeInt): integer;

    function refer(sessionId: NativeInt; referTo: PAnsiChar): integer;
    function attendedRefer(sessionId: NativeInt; replaceSessonId: integer; referTo: PAnsiChar): integer;
    function attendedRefer2(sessionId, replaceSessionId:NativeInt; replaceMethod, target, referTo:PAnsiChar):integer; cdecl;
    function outOfDialogRefer(replaceSessionId:NativeInt; referTo:PAnsiChar):integer; cdecl;

    function acceptRefer(referId: NativeInt; referSignaling: PAnsiChar): integer;
    function rejectRefer(referId: NativeInt): integer;

    function muteSession(sessioinId: NativeInt;
                        muteIncomingAudio,
						            muteOutgoingAudio,
						            muteIncomingVideo,
						            muteOutgoingVideo: boolean): integer;

     function forwardCall(sessionId: NativeInt; forwardTo: PAnsiChar):integer;
     function pickupBLFCall(replaceDialogId: PAnsiChar; videoCall: boolean):integer;
     function sendDtmf(sessionId: NativeInt; dtmfMethod: integer; code: integer; duration: integer; playDtmfTone: boolean): integer;
     function enableSendPcmStreamToRemote(sessionId: NativeInt; state: boolean; streamSamplesPerSec: integer): integer;
     function sendPcmStreamToRemote(sessionId: NativeInt; data: PByte; dataLength: integer): integer;

     function enableSendVideoStreamToRemote(sessionId: NativeInt; state: boolean): integer;
     function sendVideoStreamToRemote(sessionId: NativeInt; data: PByte; dataLength, width, height: integer): integer;

     function enableAudioStreamCallback(sessionId: NativeInt;
                                        enable: boolean;
                                        callbackMode: integer;
                                        obj: pointer;
                                        audioRawCallback: TAudioRawCallback): integer;
     function enableVideoStreamCallback(sessionId: NativeInt;
                                        enable: boolean;
                                        callbackMode: integer;
                                        obj: pointer;
                                        videoRawCallback: TVideoRawCallback): integer;

     function startRecord(sessionId: NativeInt;
                          recordFilePath: PAnsiChar;
                          recordFileName: PAnsiChar;
                          appendTimeStamp: boolean;
                          audioFileFormat: integer;
                          audioRecordMode: integer;
                          videoFileCodecType: integer;
                          videoRecordMode: integer): integer;
     function stopRecord(sessionId: NativeInt): integer;

     function playVideoFileToRemote(sessionId: NativeInt;
                                    aviFile: PAnsiChar;
                                    loop,
                                    playAudio: boolean): integer;
     function stopPlayVideoFileToRemote(sessionId: NativeInt): integer;
     function playAudioFileToRemote(sessionId: NativeInt;
                                    fileName: PAnsiChar;
                                    fileSamplesPerSec: integer;
                                    loop: boolean): integer;
     function stopPlayAudioFileToRemote(sessionId: NativeInt): integer;

     function playAudioFileToRemoteAsBackground(sessionId: NativeInt;
                                    fileName: PAnsiChar;
                                    fileSamplesPerSec: integer): integer;
     function stopPlayAudioFileToRemoteAsBackground(sessionId: NativeInt): integer;
     function createAudioConference():integer;
     function createVideoConference(
            conferenceVideoWindow: THandle;
            width, height: integer;
            displayLocalVideoInConference: boolean):integer;
     procedure destroyConference();
     function setConferenceVideoWindow(videoWindow:THandle): integer;
     function joinToConference(sessionId:NativeInt): integer;
     function removeFromConference(sessionId:NativeInt): integer;

    function setAudioRtcpBandwidth(
                                  sessionId: NativeInt;
                                  BitsRR: integer;
                                  BitsRS: integer;
                                  KBitsAS: integer): integer;

    function setVideoRtcpBandwidth(
                                  sessionId: NativeInt;
                                  BitsRR: integer;
                                  BitsRS: integer;
                                  KBitsAS: integer): integer;

    function getAudioStatistics(
                                  sessionId: NativeInt;
						                      var sendBytes,
                                            sendPackets,
                                            sendPacketsLost,
                                            sendFractionLost,
                                            sendRttMS,
                                            sendCodecType,
                                            sendJitterMS,
                                            sendAudioLevel,
                                            recvBytes,
                                            recvPackets,
                                            recvPacketsLost,
                                            recvFractionLost,
                                            recvCodecType,
                                            recvJitterMS,
                                            recvAudioLevel:integer): integer;

    function getVideoStatistics(
						                      sessionId:NativeInt;
						                     var sendBytes,
                                            sendPackets,
                                            sendPacketsLost,
                                            sendFractionLost,
                                            sendRttMS,
                                            sendCodecType,
                                            sendFrameWidth,
                                            sendFrameHeight,
                                            sendBitrateBPS,
                                            sendFramerate,
                                            recvBytes,
                                            recvPackets,
                                            recvPacketsLost,
                                            recvFractionLost,
                                            recvCodecType,
                                            recvFrameWidth,
                                            recvFrameHeight,
                                            recvBitrateBPS,
                                            recvFramerate:integer): integer;
    procedure enableVAD(state:boolean);
    procedure enableAEC(mode:integer);
    procedure enableCNG(state:boolean);
    procedure enableAGC(mode:integer);
    procedure enableANS(mode:integer);
    function enableAudioQos(enable: boolean):integer;
    function enableVideoQos(enable: boolean):integer;
    function setVideoMTU(mtu: integer):integer;

    function sendInfo(sessionId:NativeInt; mimeType, subMimeType, infoContents: PAnsiChar): integer;
    function sendSubscription(_to, eventName:PAnsiChar):integer;
    function terminateSubscription(subscribeId:NativeInt):integer;
    function setDefaultPublicationTime(secs:NativeInt):integer;
    function setDefaultSubscriptionTime(secs:NativeInt):integer;

    function sendOptions(sendTo, sdp: PAnsiChar): integer;
    function sendMessage(sessionId: NativeInt; mimeType, subMimeType: PAnsiChar; messageData: PByte; messageDataLength: integer):integer;
    function sendOutOfDialogMessage(sendTo, mimeType, subMimeType: PAnsiChar; isSMS: boolean; messageData: PByte; messageDataLength: integer):integer;

    function presenceSubscribe(subscribeTo, subject: PAnsiChar): integer;
    function presenceTerminateSubscribe(subscribeId: NativeInt): integer;
    function presenceRejectSubscribe(subscribeId: NativeInt): integer;
    function presenceAcceptSubscribe(subscribeId: NativeInt): integer;
    function setPresenceMode(mode : integer): integer;
    function setPresenceStatus(subscribeId: NativeInt; stateText:PAnsiChar):integer;

    function getNumOfRecordingDevices(): integer;
    function getNumOfPlayoutDevices(): integer;
    function getRecordingDeviceName(
				    index: integer;
						nameUTF8: PAnsiChar;
						nameUTF8Length: integer
            ): integer;

    function getPlayoutDeviceName(
						index: integer;
						nameUTF8: PAnsiChar;
						nameUTF8Length: integer
            ): integer;

    function setSpeakerVolume(volume: integer): integer;
    function getSpeakerVolume(): integer;
    function setMicVolume(volume: integer): integer;
    function getMicVolume(): integer;
    procedure audioPlayLoopbackTest(enable: boolean);
    function getNumOfVideoCaptureDevices(): integer;
    function getVideoCaptureDeviceName(
						index: integer;
						uniqueIdUTF8: PAnsiChar;
						uniqueIdUTF8Length: integer;
						deviceNameUTF8: PAnsiChar;
						deviceNameUTF8Length: integer): integer;

    function showVideoCaptureSettingsDialogBox(
						uniqueIdUTF8: PAnsiChar;
						uniqueIdUTF8Length: integer;
						dialogTitle: PAnsiChar;
            parentWindow: THandle;
						x: integer;
						y: integer): integer;

    // property

    property DLLPath: string read fDLLPath;
    property onRegisterSuccess: TONRegisterSuccess write fRegisterSuccess;

    property onRegisterFailure: TONRegisterFailure write fRegisterFailure;

    property onInviteIncoming: TONInviteIncoming write fInviteIncoming;

    property onInviteTrying: TONInviteTrying write fInviteTrying;

    property onInviteSessionProgress: TONInviteSessionProgress write fInviteSessionProgress;

    property onInviteRinging: TONInviteRinging write fInviteRinging;

    property onInviteAnswered: TONInviteAnswered write fInviteAnswered;

    property onInviteFailure: TONInviteFailure write fInviteFailure;

    property onInviteUpdated: TONInviteUpdated write fInviteUpdated;

    property onInviteConnected: TONInviteConnected write fInviteConnected;

    property onInviteBeginingForward: TONInviteBeginingForward write fInviteBeginingForward;

    property onInviteClosed: TONInviteClosed write fInviteClosed;
	property onDialogStateUpdated: TONDialogStateUpdated write fDialogStateUpdated;

    property onRemoteHold: TONRemoteHold write fRemoteHold;

    property onRemoteunHold: TONRemoteunHold write fRemoteunHold;

    property onReceivedRefer: TONReceivedRefer write fReceivedRefer;

    property onReferAccepted: TONReferAccepted write fReferAccepted;

    property onReferRejected: TONReferRejected write fReferRejected;

    property onTransferTrying: TONTransferTrying write fTransferTrying;

    property onTransferRinging: TONTransferRinging write fTransferRinging;

    property onACTVTransferSuccess: TONACTVTransferSuccess write fACTVTransferSuccess;

    property onACTVTransferFailure: TONACTVTransferFailure write fACTVTransferFailure;

    property onReceivedSignaling: TONReceivedSignaling write fReceivedSignaling;

    property onSendingSignaling: TONSendingSignaling write fSendingSignaling;

    property onWaitingVoiceMessage: TONWaitingVoiceMessage write fWaitingVoiceMessage;

    property onWaitingFaxMessage: TONWaitingFaxMessage write fWaitingFaxMessage;

    property onRecvDtmfTone: TONRecvDtmfTone write fRecvDtmfTone;

    property onPresenceRecvSubscribe: TONPresenceRecvSubscribe write fPresenceRecvSubscribe;

    property onPresenceOnline: TONPresenceOnline write fPresenceOnline;

    property onPresenceOffline: TONPresenceOffline write fPresenceOffline;

    property onRecvOptions: TONRecvOptions write fRecvOptions;

    property onRecvInfo: TONRecvInfo write fRecvInfo;

    property onRecvMessage: TONRecvMessage write fRecvMessage;

    property onRecvOutOfDialogMessage: TONRecvOutOfDialogMessage write fRecvOutOfDialogMessage;

    property onSendMessageSuccess: TONSendMessageSuccess write fSendMessageSuccess;

    property onSendMessageFailure: TONSendMessageFailure write fSendMessageFailure;

    property onSendOutOfDialogMessageSuccess: TONSendOutOfDialogMessageSuccess write fSendOutOfDialogMessageSuccess;

    property onSendOutOfDialogMessageFailure: TONSendOutOfDialogMessageFailure write fSendOutOfDialogMessageFailure;

    property onPlayAudioFileFinished: TONPlayAudioFileFinished write fPlayAudioFileFinished;

    property onPlayVideoFileFinished: TONPlayVideoFileFinished write fPlayVideoFileFinished;

    constructor Create(DLLPath: string; callbackIndex: NativeInt);
    function createCallbackHandlers(): boolean;
    procedure releaseCallbackHandlers();
    destructor Destroy(); override;



  end;

implementation

{ Callback Functions }

function cbRegisterSuccess(callbackIndex:NativeInt; callbackObject:NativeInt; reason:PAnsiChar; code:integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fRegistersuccess) then
    TPortSipObject(callbackObject).fRegistersuccess(callbackIndex, reason, code);
end;

function cbRegisterFailure(callbackIndex:NativeInt; callbackObject:NativeInt; reason:PAnsiChar; code:integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fRegisterFailure) then
    TPortSipObject(callbackObject).fRegisterFailure(callbackIndex, reason, code);
end;

function cbInviteIncoming(callbackIndex:NativeInt;
                              callbackObject:NativeInt;
                              sessionId:NativeInt;
                              callerDisplayName:PAnsiChar;
                              caller:PAnsiChar;
                              calleeDisplayName:PAnsiChar;
                              callee:PAnsiChar;
                              audioCodecs:PAnsiChar;
                              videoCodecs:PAnsiChar;
                              existsAudio:boolean;
                              existsVideo:boolean;
                              sipMessage:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fInviteIncoming) then
    TPortSipObject(callbackObject).fInviteIncoming(callbackIndex,
                                                    sessionId,
                                                    callerDisplayName,
                                                    caller,
                                                    calleeDisplayName,
                                                    callee,
                                                    audioCodecs,
                                                    videoCodecs,
                                                    existsAudio,
                                                    existsVideo,
                                                    sipMessage);
end;

function cbInviteTrying(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fInviteTrying) then
    TPortSipObject(callbackObject).fInviteTrying(callbackIndex, sessionId);
end;


function cbInviteSessionProgress(callbackIndex, callbackObject:NativeInt;
												    sessionId:NativeInt;
                            audioCodecs:PAnsiChar;
                            videoCodecs:PAnsiChar;
                            existsEarlyMedia:boolean;
                            existsAudio:boolean;
                            existsVideo:boolean;
                            message:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fInviteSessionProgress) then
    TPortSipObject(callbackObject).fInviteSessionProgress(callbackIndex,
												          sessionId,
                                                          audioCodecs,
                                                          videoCodecs,
                                                          existsEarlyMedia,
                                                          existsAudio,
                                                          existsVideo,
                                                          message);
end;


function cbInviteRinging(callbackIndex, callbackObject:NativeInt;
                              sessionId:NativeInt;
                              statusText:PAnsiChar;
                              statusCode:integer;
                              message:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fInviteRinging) then
    TPortSipObject(callbackObject).fInviteRinging(callbackIndex, sessionId, statusText, statusCode, message);
end;


function cbInviteAnswered(callbackIndex, callbackObject:NativeInt;
                              sessionId:NativeInt;
                              callerDisplayName:PAnsiChar;
                              caller:PAnsiChar;
                              calleeDisplayName:PAnsiChar;
                              callee:PAnsiChar;
                              audioCodecs:PAnsiChar;
                              videoCodecs:PAnsiChar;
                              existsAudio:boolean;
                              existsVideo:boolean;
                              message:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fInviteAnswered) then
    TPortSipObject(callbackObject).fInviteAnswered(callbackIndex,
                              sessionId,
                              callerDisplayName,
                              caller,
                              calleeDisplayName,
                              callee,
                              audioCodecs,
                              videoCodecs,
                              existsAudio,
                              existsVideo,
                              message);
end;



function cbInviteFailure(callbackIndex, callbackObject:NativeInt;
                              sessionId:NativeInt;
                              reason:PAnsiChar;
                              code:integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fInviteFailure) then
    TPortSipObject(callbackObject).fInviteFailure(callbackIndex,
                              sessionId,
                              reason,
                              code);

end;


function cbInviteUpdated(callbackIndex,
                              callbackObject:NativeInt;
                              sessionId:NativeInt;
                              audioCodecs:PAnsiChar;
                              videoCodecs:PAnsiChar;
                              existsAudio:boolean;
                              existsVideo:boolean;
                              message:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fInviteUpdated) then
    TPortSipObject(callbackObject).fInviteUpdated(callbackIndex,
                              sessionId,
                              audioCodecs,
                              videoCodecs,
                              existsAudio,
                              existsVideo,
                              message);
end;

function cbInviteConnected(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fInviteConnected ) then
    TPortSipObject(callbackObject).fInviteConnected (callbackIndex, sessionId);
end;



function cbInviteBeginingForward(callbackIndex, callbackObject:NativeInt; forwardTo:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fInviteBeginingForward) then
    TPortSipObject(callbackObject).fInviteBeginingForward(callbackIndex, forwardTo);
end;


function cbInviteClosed(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fInviteClosed) then
    TPortSipObject(callbackObject).fInviteClosed(callbackIndex, sessionId);
end;

function cbDialogStateUpdated(callbackIndex, callbackObject:NativeInt; BLFMonitoredUri, BLFDialogState, BLFDialogId, BLFDialogDirection: PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fDialogStateUpdated) then
    TPortSipObject(callbackObject).fDialogStateUpdated(callbackIndex, BLFMonitoredUri, BLFDialogState, BLFDialogId, BLFDialogDirection);
end;


function cbRemoteHold(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fRemoteHold) then
    TPortSipObject(callbackObject).fRemoteHold(callbackIndex, sessionId);
end;


function cbRemoteUnHold(callbackIndex,
                        callbackObject:NativeInt;
                        sessionId:NativeInt;
                        audioCodecs,
                        videoCodecs: PAnsiChar;
                        existsAudio,
                        existsVideo: boolean): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fRemoteUnHold) then
    TPortSipObject(callbackObject).fRemoteUnHold(callbackIndex,
                                                sessionId,
                                                audioCodecs,
                                                videoCodecs,
                                                existsAudio,
                                                existsVideo);
end;


function cbReceivedRefer(callbackIndex, callbackObject:NativeInt;
                              sessionId:NativeInt;
                              referId:NativeInt;
                              referTo:PAnsiChar;
                              from:PAnsiChar;
                              referSipMessage:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fReceivedRefer) then
    TPortSipObject(callbackObject).fReceivedRefer(callbackIndex,
                                                  sessionId,
                                                  referId,
                                                  referTo,
                                                  from,
                                                  referSipMessage);
end;



function cbReferAccepted(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fReferAccepted) then
    TPortSipObject(callbackObject).fReferAccepted(callbackIndex, sessionId);
end;


function cbReferRejected(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fReferRejected) then
    TPortSipObject(callbackObject).fReferRejected(callbackIndex, sessionId);
end;



function cbTransferTrying(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fTransferTrying) then
    TPortSipObject(callbackObject).fTransferTrying(callbackIndex, sessionId);
end;


function cbTransferRinging(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fTransferRinging) then
    TPortSipObject(callbackObject).fTransferRinging(callbackIndex, sessionId);
end;



function cbACTVTransferSuccess(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fACTVTransferSuccess) then
    TPortSipObject(callbackObject).fACTVTransferSuccess(callbackIndex, sessionId);
end;


function cbACTVTransferFailure(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt; reason:PAnsiChar; code:integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fACTVTransferFailure) then
    TPortSipObject(callbackObject).fACTVTransferFailure(callbackIndex, sessionId, reason, code);
end;


function cbReceivedSignaling(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt; sipSignaling:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fReceivedSignaling) then
    TPortSipObject(callbackObject).fReceivedSignaling(callbackIndex,  sessionId, sipSignaling);
end;


function cbSendingSignaling(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt; sipSignaling:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fSendingSignaling) then
    TPortSipObject(callbackObject).fSendingSignaling(callbackIndex,  sessionId, sipSignaling);
end;


function cbWaitingVoiceMessage(callbackIndex, callbackObject:NativeInt;
                                    messageAccount:PAnsiChar;
                                    urgentNewMessageCount,
                                    urgentOldMessageCount,
                                    newMessageCount,
                                    oldMessageCount: integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fWaitingVoiceMessage) then
    TPortSipObject(callbackObject).fWaitingVoiceMessage(callbackIndex,
                                    messageAccount,
                                    urgentNewMessageCount,
                                    urgentOldMessageCount,
                                    newMessageCount,
                                    oldMessageCount);
end;


function cbWaitingFaxMessage(callbackIndex, callbackObject:NativeInt;
                                    messageAccount:PAnsiChar;
                                    urgentNewMessageCount,
                                    urgentOldMessageCount,
                                    newMessageCount,
                                    oldMessageCount: integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fWaitingFaxMessage) then
    TPortSipObject(callbackObject).fWaitingFaxMessage(callbackIndex,
                                    messageAccount,
                                    urgentNewMessageCount,
                                    urgentOldMessageCount,
                                    newMessageCount,
                                    oldMessageCount);
end;



function cbRecvDtmfTone(callbackIndex, callbackObject:NativeInt;
                                    sessionId:NativeInt;
                                    tone:integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fRecvDtmfTone) then
    TPortSipObject(callbackObject).fRecvDtmfTone(callbackIndex, sessionId, tone);
end;


function cbPresenceRecvSubscribe(callbackIndex, callbackObject:NativeInt;
                                      subscribeId:NativeInt;
                                      fromDisplayName:PAnsiChar;
                                      from:PAnsiChar;
                                      subject:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fPresenceRecvSubscribe) then
    TPortSipObject(callbackObject).fPresenceRecvSubscribe(callbackIndex,
                                      subscribeId,
                                      fromDisplayName,
                                      from,
                                      subject);
end;



function cbPresenceOnline(callbackIndex, callbackObject:NativeInt;
                                      fromDisplayName:PAnsiChar;
                                      from:PAnsiChar;
                                      stateText:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fPresenceOnline) then
    TPortSipObject(callbackObject).fPresenceOnline(callbackIndex, fromDisplayName, from, stateText);
end;


function cbPresenceOffline(callbackIndex, callbackObject:NativeInt;
                                      fromDisplayName:PAnsiChar;
                                      from:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fPresenceOffline) then
    TPortSipObject(callbackObject).fPresenceOffline(callbackIndex, fromDisplayName, from);
end;


function cbRecvOptions(callbackIndex, callbackObject:NativeInt; optionsMessage:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fRecvOptions) then
    TPortSipObject(callbackObject).fRecvOptions(callbackIndex, optionsMessage);
end;

function cbRecvInfo(callbackIndex, callbackObject:NativeInt; infoMessage:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fRecvInfo) then
    TPortSipObject(callbackObject).fRecvInfo(callbackIndex, infoMessage);
end;

function cbPlayAudioFileFinished(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt; fileName:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fPlayAudioFileFinished) then
    TPortSipObject(callbackObject).fPlayAudioFileFinished(callbackIndex, sessionId, fileName);
end;


function cbPlayVideoFileFinished(callbackIndex, callbackObject:NativeInt; sessionId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fPlayVideoFileFinished) then
    TPortSipObject(callbackObject).fPlayVideoFileFinished(callbackIndex, sessionId);
end;


function cbRecvMessage(callbackIndex, callbackObject:NativeInt;
                            sessionId:NativeInt;
                            mimeType:PAnsiChar;
                            subMimeType:PAnsiChar;
                            messageData:PByte;
                            messageDataLength:integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fRecvMessage) then
    TPortSipObject(callbackObject).fRecvMessage(callbackIndex,
                            sessionId,
                            mimeType,
                            subMimeType,
                            messageData,
                            messageDataLength);
end;


function cbRecvOutOfDialogMessage(callbackIndex, callbackObject:NativeInt;
                            fromDisplayName:PAnsiChar;
                            from:PAnsiChar;
                            toDisplayName:PAnsiChar;
                            sendTo:PAnsiChar;
                            mimeType:PAnsiChar;
                            subMimeType:PAnsiChar;
                            messageData:PByte;
                            messageDataLength:integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fRecvOutOfDialogMessage) then
    TPortSipObject(callbackObject).fRecvOutOfDialogMessage(callbackIndex,
                            fromDisplayName,
                            from,
                            toDisplayName,
                            sendTo,
                            mimeType,
                            subMimeType,
                            messageData,
                            messageDataLength);
end;

function cbSendMessageSuccess(callbackIndex, callbackObject:NativeInt;
                            sessionId, messageId:NativeInt): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fSendMessageSuccess) then
    TPortSipObject(callbackObject).fSendMessageSuccess(callbackIndex,
                            sessionId, messageId);
end;


function cbSendMessageFailure(callbackIndex, callbackObject:NativeInt;
                            sessionId, messageId:NativeInt;
                            reason:PAnsiChar;
                            code:integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fSendMessageFailure) then
    TPortSipObject(callbackObject).fSendMessageFailure(callbackIndex,
                            sessionId,
                            messageId,
                            reason,
                            code);
end;


function cbSendOutOfDialogMessageSuccess(callbackIndex, callbackObject, messageId:NativeInt;
                            fromDisplayName:PAnsiChar;
                            from:PAnsiChar;
                            toDisplayName:PAnsiChar;
                            sendTo:PAnsiChar): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fSendOutOfDialogMessageSuccess) then
    TPortSipObject(callbackObject).fSendOutOfDialogMessageSuccess(callbackIndex,
                            messageId,
                            fromDisplayName,
                            from,
                            toDisplayName,
                            sendTo);
end;


function cbSendOutOfDialogMessageFailure(callbackIndex, callbackObject, messageId:NativeInt;
                            fromDisplayName:PAnsiChar;
                            from:PAnsiChar;
                            toDisplayName:PAnsiChar;
                            sendTo:PAnsiChar;
                            reason:PAnsiChar;
                            code:integer): integer; cdecl;
begin
  result := 0;
  if not assigned(pointer(callbackObject)) then
    exit;
  if assigned(TPortSipObject(callbackObject).fSendOutOfDialogMessageFailure) then
    TPortSipObject(callbackObject).fSendOutOfDialogMessageFailure(callbackIndex,
                            messageId,
                            fromDisplayName,
                            from,
                            toDisplayName,
                            sendTo,
                            reason,
                            code);
end;



{ TPortSipObject functions}

procedure TPortSIPObject.delCallbackParameters(parameters: Pointer);
begin
  fPortSIP_delCallbackParameters(parameters);
end;

function  TPortSipObject.initialize(transportType: Integer;
                                    localIp: PAnsiChar;
                                    localSipPort: Integer;
                                    logLevel: Integer;
                                    logFilePath: PAnsiChar;
                                    maxCallSessions: Integer;
                                    sipAgentString: PAnsiChar;
                                    audioDeviceLayer: integer;
                                    videoDeviceLayer: integer;
                                    TLSCertificatesRootPath : PAnsiChar;
                                    TLSCipherist: PAnsiChar;
                                    verifyTLSCertificate : boolean): integer;
var
  errorCode: integer;
begin
  result := 0;
  fSDKLib := fPortSIP_initialize(fCallbackDispatcher,
								                 transportType,
								                  localIp,
                                  localSipport,
                                  logLevel,
                                  logFilePath,
                                  maxCallSessions,
                                  sipAgentString,
                                  audioDeviceLayer,
                                  videoDeviceLayer,
                                  TLSCertificatesRootPath,
                                  TLSCipherist,
                                  verifyTLSCertificate,
                                  errorCode);
  if errorCode <> 0 then
  begin
    fSDKLib := 0;
  end;

  result := errorCode;
end;

function TPortSipObject.setDisplayName(displayName: PAnsiChar): integer;
begin
  result := fPortSIP_setDisplayName(fSDKLib, displayName);
end;

function TPortSipObject.setInstanceId(uuid: PAnsiChar): integer;
begin
  result := fPortSIP_setInstanceId(fSDKLib, uuid);
end;

procedure TPortSipObject.unInitialize;
begin
  fPortSIP_unInitialize(fSDKLib);
  fSDKLib := 0;
end;


function TPortSipObject.setLicenseKey(licenseKey: PAnsiChar): integer;
begin
  result := fPortSIP_setLicenseKey(fSDKLib, licenseKey);
end;

function TPortSipObject.getNICNums(): integer;
begin
  result := fPortSIP_getNICNums();
end;

function TPortSipObject.getLocalIpAddress(index: Integer; ip: PAnsiChar; ipSize: Integer): integer;
begin
  result := fPortSIP_getLocalIpAddress(index, ip, ipsize);
end;


function TPortSipObject.setUser(userName: PAnsiChar;
                                displayName: PAnsiChar;
                                authName: PAnsiChar;
                                password: PAnsiChar;
                                sipDomain: PAnsiChar;
                                sipServerAddr: PAnsiChar;
                                sipServerPort: Integer;
                                stunServerAddr: PAnsiChar;
                                stunServerPort: Integer;
                                outboundServerAddr: PAnsiChar;
                                outboundServerPort: Integer): integer;
begin
  result := fPortSIP_setUser(fSDKLib,
                              userName,
                              displayName,
                              authName,
                              password,
                              sipDomain,
                              sipServerAddr,
                              sipServerPort,
                              stunServerAddr,
                              stunServerPort,
                              outboundServerAddr,
                              outboundServerPort);
end;



procedure TPortSipObject.removeUser;
begin
  fPortSIP_removeUser(fSDKLib);
end;


function TPortSipObject.registerServer(regExpires: Integer; retryTimes: integer): integer;
begin
  result := fPortSIP_registerServer(fSDKLib, regExpires, retryTimes);
end;


function TPortSipObject.refreshRegistration(regExpires: Integer): integer;
begin
  result := fPortSIP_refreshRegistration(fSDKLib, regExpires);
end;


function TPortSipObject.unRegisterServer: integer;
begin
  result := fPortSIP_unRegisterServer(fSDKLib);
end;


function TPortSipObject.getVersion(var majorVersion: Integer; var minorVersion: Integer): integer;
begin
  result := fPortSIP_getVersion(fSDKLib, majorVersion, minorVersion);
end;

function TPortSipObject.enableRport(enable: Boolean): integer;
begin
   result := fPortSIP_enableRport(fSDKLib, enable);
end;

function TPortSipObject.enableEarlyMedia(enable: Boolean): integer;
begin
   result := fPortSIP_enableEarlyMedia(fSDKLib, enable);
end;

function TPortSipObject.enableReliableProvisional(enable: Boolean): integer;
begin
   result := fPortSIP_enableReliableProvisional(fSDKLib, enable);
end;


function TPortSipObject.enable3GppTags(enable: Boolean): integer;
begin
  result := fPortSIP_enable3GppTags(fSDKLib, enable);
end;

procedure TPortSipObject.enableCallbackSignaling(enableSending:boolean; enableReceived:boolean);
begin
  fPortSIP_enableCallbackSignaling(fSDKLib, enableSending, enableReceived);
end;

function TPortSipObject.setRtpCallback(obj: Pointer; receivedCallback: TReceivedRTPPacket; sendingCallback: TSendingRTPPacket): integer;
begin
   result := fPortSIP_setRtpCallback(fSDKLib, receivedCallback, sendingCallback);
end;

function TPortSipObject.addAudioCodec(codecType: Integer): integer;
begin
  result := fPortSIP_addAudioCodec(fSDKLib, codecType);
end;


function TPortSipObject.addVideoCodec(codecType: Integer): integer;
begin
  result := fPortSIP_addVideoCodec(fSDKLib, codecType);
end;

function TPortSipObject.isAudioCodecEmpty: boolean;
begin
  result := fPortSIP_isAudioCodecEmpty(fSDKLib);
end;

function TPortSipObject.isVideoCodecEmpty: boolean;
begin
  result := fPortSIP_isVideoCodecEmpty(fSDKLib);
end;


function TPortSipObject.setAudioCodecPayloadType(codecType: Integer; payloadType: Integer): integer;
begin
  result := fPortSIP_setAudioCodecPayloadType(fSDKLib, codecType, payloadType);
end;


function TPortSipObject.setVideoCodecPayloadType(codecType: Integer; payloadType: Integer): integer;
begin
  result := fPortSIP_setVideoCodecPayloadType(fSDKLib, codecType, payloadType);
end;


procedure TPortSipObject.clearAudioCodec;
begin
  fPortSIP_clearAudioCodec(fSDKLib);
end;

procedure TPortSipObject.clearVideoCodec;
begin
  fPortSIP_clearVideoCodec(fSDKLib);
end;


function TPortSipObject.setAudioCodecParameter(codecType: Integer; parameter: PAnsiChar): integer;
begin
  result := fPortSIP_setAudioCodecParameter(fSDKLib, codecType, parameter);
end;


function TPortSipObject.setVideoCodecParameter(codecType: Integer; parameter: PAnsiChar): integer;
begin
  result := fPortSIP_setVideoCodecParameter(fSDKLib, codecType, parameter);
end;


function TPortSipObject.setSrtpPolicy(srtpPolicy: Integer; allowSrtpOverUnsecureTransport : boolean): integer;
begin
   result := fPortSIP_setSrtpPolicy(fSDKLib, srtpPolicy, allowSrtpOverUnsecureTransport);
end;

function TPortSipObject.setRtpPortRange(minimumRtpAudioPort: Integer;
                                        maximumRtpAudioPort: Integer;
                                        minimumRtpVideoPort: Integer;
                                        maximumRtpVideoPort: Integer): integer;
begin
   result := fPortSIP_setRtpPortRange(fSDKLib,
                                        minimumRtpAudioPort,
                                        maximumRtpAudioPort,
                                        minimumRtpVideoPort,
                                        maximumRtpVideoPort);
end;


function TPortSipObject.setRtcpPortRange(minimumRtcpAudioPort: Integer;
                                        maximumRtcpAudioPort: Integer;
                                        minimumRtcpVideoPort: Integer;
                                        maximumRtcpVideoPort: Integer): integer;
begin
   result := fPortSIP_setRtcpPortRange(fSDKLib,
                                        minimumRtcpAudioPort,
                                        maximumRtcpAudioPort,
                                        minimumRtcpVideoPort,
                                        maximumRtcpVideoPort);
end;


function TPortSipObject.enableCallForward(forBusyOnly: Boolean; forwardTo: PAnsiChar): integer;
begin
  result := fPortSIP_enableCallForward(fSDKLib, forBusyOnly, forwardTo);
end;


function TPortSipObject.disableCallForward: integer;
begin
  result := fPortSIP_disableCallForward(fSDKLib);
end;

function TPortSipObject.enableSessionTimer(timerSeconds: Integer; refreshMode: Integer): integer;
begin
  result := fPortSIP_enableSessionTimer(fSDKLib, timerSeconds, refreshMode);
end;

function TPortSipObject.disableSessionTimer: integer;
begin
  result := fPortSIP_disableSessionTimer(fSDKLib);
end;

procedure TPortSipObject.setDoNotDisturb(state: Boolean);
begin
  fPortSIP_setDoNotDisturb(fSDKLib, state);
end;


function TPortSipObject.enableAutoCheckMwi(state: Boolean): integer;
begin
  result := fPortSIP_enableAutoCheckMwi(fSDKLib, state);
end;

function TPortSipObject.setRtpKeepAlive(state: Boolean; keepAlivePayloadType: Integer; deltaTransmitTimeMS: Integer): integer;
begin
  result := fPortSIP_setRtpKeepAlive(fSDKLib, state, keepAlivePayloadType, deltaTransmitTimeMS);
end;

function TPortSipObject.setKeepAliveTime(keepAliveTime: Integer): integer;
begin
  result := fPortSIP_setKeepAliveTime(fSDKLib, keepAliveTime);
end;

function TPortSipObject.getSipMessageHeaderValue(sipMessage: PAnsiChar; headerName: PAnsiChar; headerValue: PAnsiChar; headerValueLength: Integer): integer;
begin
  result := fPortSIP_getSipMessageHeaderValue(fSDKLib, sipMessage, headerName, headerValue, headerValueLength);
end;

function TPortSipObject.addSipMessageHeader(sessionId: NativeInt; methodName: PAnsiChar; msgType: Integer; headerName: PAnsiChar; headerValue: PAnsiChar): NativeInt;
begin
  result := fPortSIP_addSipMessageHeader(fSDKLib, sessionid, methodName, msgType, headerName, headerValue);
end;

function TPortSipObject.removeAddedSipMessageHeader(sipMessageHeaderId: NativeInt) : integer;
begin
  result := fPortSIP_removeAddedSipMessageHeader(fSDKLib, sipMessageHeaderId);
end;


procedure TPortSipObject.clearAddedSipMessageHeaders;
begin

  fPortSIP_clearAddedSipMessageHeaders(fSDKLib);
end;

function TPortSipObject.modifySipMessageHeader(sessionId: NativeInt; methodName: PAnsiChar; msgType: Integer; headerName: PAnsiChar; headerValue: PAnsiChar) : NativeInt;
begin
 result := fPortSIP_addSipMessageHeader(fSDKLib, sessionId, methodName, msgType, headerName, headerValue);
end;


function TPortSipObject.removeModifiedSipMessageHeader(sipMessageHeaderId: NativeInt) : integer;
begin
  result := fPortSIP_removeAddedSipMessageHeader(fSDKLib, sipMessageHeaderId);
end;

procedure TPortSipObject.clearModifiedSipMessageHeaders;
begin
   fPortSIP_clearModifiedSipMessageHeaders(fSDKLib);
end;

function TPortSipObject.addSupportedMimeType(methodName: PAnsiChar; mimeType: PAnsiChar; subMimeType: PAnsiChar): integer;
begin
  result := fPortSIP_addSupportedMimeType(fSDKLib, methodName, mimeType, subMimeType);
end;

function TPortSipObject.setAudioSamples(ptime: Integer; maxPtime: Integer): integer;
begin
  result := fPortSIP_setAudioSamples(fSDKLib, ptime, maxPtime);
end;

function TPortSipObject.setAudioBitrate(sessionId:NativeInt; codecType, bitrateKbps: integer): integer;
begin
  result := fPortSIP_setAudioBitrate(fSDKLib, sessionId, codecType, bitrateKbps);
end;


function TPortSipObject.setAudioDeviceId(inputDeviceId: Integer; outputDeviceId: Integer): integer;
begin
  result := fPortSIP_setAudioDeviceId(fSDKLib, inputDeviceId, outputDeviceId);
end;


function TPortSipObject.setVideoDeviceId(deviceId: Integer): integer;
begin
  result := fPortSIP_setVideoDeviceId(fSDKLib, deviceId);
end;

function TPortSipObject.setVideoResolution(width, height:integer): integer;
begin
  result := fPortSIP_setVideoResolution(fSDKLib, width, height);
end;

function TPortSipObject.setVideoBitrate(sessionId: NativeInt; bitrateKbps: Integer): integer;
begin
  result := fPortSIP_setVideoBitrate(fSDKLib, sessionId, bitrateKbps);
end;

function TPortSipObject.setVideoFrameRate(sessionId: NativeInt; frameRate: Integer): integer;
begin
  result := fPortSIP_setVideoFrameRate(fSDKLib, sessionId, frameRate);
end;


function TPortSipObject.sendVideo(sessionId: NativeInt; sendState: Boolean): integer;
begin
  result := fPortSIP_sendVideo(fSDKLib, sessionId, sendState);
end;


procedure TPortSipObject.muteMicrophone(mute: Boolean);
begin
  fPortSIP_muteMicrophone(fSDKLib, mute);
end;

procedure TPortSipObject.muteSpeaker(mute: Boolean);
begin
  fPortSIP_muteSpeaker(fSDKLib, mute);
end;

procedure TPortSIPObject.setChannelOutputVolumeScaling( sessionId:NativeInt; scaling:integer);
begin
	fPortSIP_setChannelOutputVolumeScaling(fSDKLib, sessionId, scaling);
end;

procedure TPortSIPObject.setChannelInputVolumeScaling( sessionId:NativeInt; scaling:integer);
begin
	fPortSIP_setChannelInputVolumeScaling(fSDKLib, sessionId, scaling);
end;

procedure TPortSipObject.setLocalVideoWindow(localVideoWindow: THandle);
begin
  fPortSIP_setLocalVideoWindow(fSDKLib, localVideoWindow);
end;


function TPortSipObject.setRemoteVideoWindow(sessionId: NativeInt; remoteVideoWindow: THandle): integer;
begin
  result := fPortSIP_setRemoteVideoWindow(fSDKLib, sessionId, remoteVideoWindow);
end;

function TPortSipObject.displayLocalVideo(state: Boolean, mirror:Boolean): integer;
begin
  result := fPortSIP_displayLocalVideo(fSDKLib, state, mirror);
end;

function TPortSipObject.setVideoNackStatus(state: Boolean): integer;
begin
  result := fPortSIP_setVideoNackStatus(fSDKLib, state);
end;


function TPortSipObject.call(callee: PAnsiChar; sendSdp: Boolean; videoCall: Boolean): integer;
begin
  result := fPortSIP_call(fSDKLib, callee, sendSdp, videoCall);
end;


function TPortSipObject.rejectCall(sessionId: NativeInt; code: Integer): integer;
begin
  result := fPortSIP_rejectCall(fSDKLib, sessionId, code);
end;

function TPortSipObject.hangUp(sessionId: NativeInt): integer;
begin
  result := fPortSIP_hangUp(fSDKLib, sessionId);
end;


function TPortSipObject.answerCall(sessionId: NativeInt; videoCall: Boolean): integer;
begin
  result := fPortSIP_answerCall(fSDKLib, sessionId, videoCall);
end;


function TPortSipObject.updateCall(sessionId: NativeInt; enableAudio: Boolean; enableVideo: Boolean): integer;
begin
  result := fPortSIP_updateCall(fSDKLib, sessionId, enableAudio, enableVideo);
end;


function TPortSipObject.hold(sessionId: NativeInt): integer;
begin
  result := fPortSIP_hold(fSDKLib, sessionId);
end;


function TPortSipObject.unHold(sessionId: NativeInt): integer;
begin
  result := fPortSIP_unHold(fSDKLib, sessionId);
end;

function TPortSipObject.refer(sessionId: NativeInt; referTo: PAnsiChar): integer;
begin
  result := fPortSIP_refer(fSDKLib, sessionId, referTo);
end;


function TPortSipObject.attendedRefer(sessionId: NativeInt; replaceSessonId: Integer; referTo: PAnsiChar): integer;
begin
  result := fPortSIP_attendedRefer(fSDKLib, sessionId, replaceSessonId, referTo);
end;


function TPortSipObject.attendedRefer2(sessionId, replaceSessionId:NativeInt; replaceMethod, target, referTo:PAnsiChar):integer;
begin
  result := fPortSIP_attendedRefer2(fSDKLib, sessionId, replaceSessionId, replaceMethod, target, referTo);
end;

function TPortSipObject.outOfDialogRefer(replaceSessionId:NativeInt; referTo:PAnsiChar):integer;
begin
  result := fPortSIP_outOfDialogRefer(fSDKLib, replaceSessionId, referTo);
end;

function TPortSipObject.acceptRefer(referId: NativeInt; referSignaling: PAnsiChar): integer;
begin
  result := fPortSIP_acceptRefer(fSDKLib, referId, referSignaling);
end;

function TPortSipObject.rejectRefer(referId: NativeInt): integer;
begin
  result := fPortSIP_rejectRefer(fSDKLib, referId);
end;


function TPortSipObject.muteSession(sessioinId: NativeInt;
                                    muteIncomingAudio: Boolean;
                                    muteOutgoingAudio: Boolean;
                                    muteIncomingVideo: Boolean;
                                    muteOutgoingVideo: Boolean): integer;
begin
  result := fPortSIP_muteSession(fSDKLib, sessioinId,
                                    muteIncomingAudio,
                                    muteOutgoingAudio,
                                    muteIncomingVideo,
                                    muteOutgoingVideo);
end;


function TPortSipObject.forwardCall(sessionId: NativeInt; forwardTo: PAnsiChar): integer;
begin
  result := fPortSIP_forwardCall(fSDKLib, sessionId, forwardTo);
end;

function TPortSipobject.pickupBLFCall(replaceDialogId: PAnsiChar; videoCall: boolean):integer;
begin
  result := fPortSIP_pickupBLFCall(fSDKLib, replaceDialogId, videoCall);
end;


function TPortSipObject.sendDtmf(sessionId: NativeInt;
                                  dtmfMethod: Integer;
                                  code: Integer;
                                  duration: Integer;
                                  playDtmfTone: Boolean): integer;
begin
  result := fPortSIP_sendDtmf(fSDKLib, sessionId,
                                  dtmfMethod,
                                  code,
                                  duration,
                                  playDtmfTone)
end;

function TPortSipObject.enableSendPcmStreamToRemote(sessionId: NativeInt; state: Boolean; streamSamplesPerSec: Integer): integer;
begin
  result := fPortSIP_enableSendPcmStreamToRemote(fSDKLib, sessionId, state, streamSamplesPerSec);
end;


function TPortSipObject.sendPcmStreamToRemote(sessionId: NativeInt; data: PByte; dataLength: Integer): integer;
begin
  result := fPortSIP_sendPcmStreamToRemote(fSDKLib, sessionId, data, dataLength);
end;

function TPortSipObject.enableSendVideoStreamToRemote(sessionId: NativeInt; state: Boolean): integer;
begin
  result := fPortSIP_enableSendVideoStreamToRemote(fSDKLib, sessionId, state);
end;


function TPortSipObject.sendVideoStreamToRemote(sessionId: NativeInt; data: PByte; dataLength, width, height: Integer): integer;
begin
  result := fPortSIP_sendVideoStreamToRemote(fSDKLib, sessionId, data, dataLength, width, height);
end;

function TPortSipObject.enableAudioStreamCallback(sessionId: NativeInt;
                                                    enable: Boolean;
                                                    callbackMode: Integer;
                                                    obj: Pointer;
                                                    audioRawCallback: TAudioRawCallback): integer;
begin
  result := fPortSIP_enableAudioStreamCallback(fSDKLib, sessionId, enable, callbackMode, obj, audioRawCallback);
end;



function TPortSipObject.enableVideoStreamCallback(sessionId: NativeInt;
                                                  enable: Boolean;
                                                  callbackMode: Integer;
                                                  obj: Pointer;
                                                  videoRawCallback: TVideoRawCallback): integer;
begin
  result := fPortSIP_enableVideoStreamCallback(fSDKLib, sessionId, enable, callbackMode, obj, videoRawCallback);
end;

function TPortSipObject.startRecord(sessionId: NativeInt;
                                      recordFilePath: PAnsiChar;
                                      recordFileName: PAnsiChar;
                                      appendTimeStamp: Boolean;
                                      audioFileFormat: Integer;
                                      audioRecordMode: Integer;
                                      videoFileCodecType: Integer;
                                      videoRecordMode: Integer): integer;
begin
  result := fPortSIP_startRecord(fSDKLib, sessionId, recordFilePath,
                                      recordFileName,
                                      appendTimeStamp,
                                      audioFileFormat,
                                      audioRecordMode,
                                      videoFileCodecType,
                                      videoRecordMode);
end;

function TPortSipObject.stopRecord(sessionId: NativeInt): integer;
begin
  result := fPortSIP_stopRecord(fSDKLib, sessionId);
end;

function TPortSipObject.playVideoFileToRemote(sessionId: NativeInt;
                                              aviFile: PAnsiChar;
                                              loop: Boolean;
                                              playAudio: Boolean): integer;
begin
  result := fPortSIP_playVideoFileToRemote(fSDKLib, sessionId,
                                              aviFile,
                                              loop,
                                              playAudio);
end;

function TPortSipObject.stopPlayVideoFileToRemote(sessionId: NativeInt): integer;
begin
  result := fPortSIP_stopPlayVideoFileToRemote(fSDKLib, sessionId);
end;


function TPortSipObject.playAudioFileToRemote(sessionId: NativeInt;
                                              fileName: PAnsiChar;
                                              fileSamplesPerSec: Integer;
                                              loop: Boolean): integer;
begin
  result := fPortSIP_playAudioFileToRemote(fSDKLib, sessionId, fileName,
                                              fileSamplesPerSec,
                                              loop);
end;

function TPortSipObject.stopPlayAudioFileToRemote(sessionId: NativeInt): integer;
begin
  result := fPortSIP_stopPlayAudioFileToRemote(fSDKLib, sessionId);
end;



function TPortSipObject.playAudioFileToRemoteAsBackground(sessionId: NativeInt;
                                                          fileName: PAnsiChar;
                                                          fileSamplesPerSec: Integer): integer;
begin
  result := fPortSIP_playAudioFileToRemoteAsBackground(fSDKLib, sessionId, fileName, fileSamplesPerSec);
end;



function TPortSipObject.stopPlayAudioFileToRemoteAsBackground(sessionId: NativeInt): integer;
begin
  result := fPortSIP_stopPlayAudioFileToRemoteAsBackground(fSDKLib, sessionId);
end;

function TPortSipObject.createAudioConference(): integer;
begin
  result := fPortSIP_createAudioConference(fSDKLib);
end;

function TPortSipObject.createVideoConference(conferenceVideoWindow: THandle;
                                        width, height: Integer;
                                        displayLocalVideoInConference: Boolean): integer;
begin
  result := fPortSIP_createVideoConference(fSDKLib, conferenceVideoWindow, width, height, displayLocalVideoInConference);
end;


procedure TPortSipObject.destroyConference();
begin
  fPortSIP_destroyConference(fSDKLib);
end;

function TPortSipObject.setConferenceVideoWindow(videoWindow: THandle): integer;
begin
  result := fPortSIP_setConferenceVideoWindow(fSDKLib, videoWindow);
end;

function TPortSipObject.joinToConference(sessionId: NativeInt): integer;
begin
  result := fPortSIP_joinToConference(fSDKLib, sessionId);
end;

function TPortSipObject.removeFromConference(sessionId: NativeInt): integer;
begin
  result := fPortSIP_removeFromConference(fSDKLib, sessionId);
end;


function TPortSipObject.setAudioRtcpBandwidth(sessionId: NativeInt;
                                              BitsRR: Integer;
                                              BitsRS: Integer;
                                              KBitsAS: Integer): integer;
begin
  result := fPortSIP_setAudioRtcpBandwidth(fSDKLib, sessionId, BitsRR, BitsRS, KBitsAS);
end;


function TPortSipObject.setVideoRtcpBandwidth(sessionId: NativeInt;
                                              BitsRR: Integer;
                                              BitsRS: Integer;
                                              KBitsAS: Integer): integer;
begin
  result := fPortSIP_setVideoRtcpBandwidth(fSDKLib, sessionId, BitsRR, BitsRS, KBitsAS);
end;

function TPortSipObject.getAudioStatistics(
                                  sessionId: NativeInt;
						                      var sendBytes,
                                            sendPackets,
                                            sendPacketsLost,
                                            sendFractionLost,
                                            sendRttMS,
                                            sendCodecType,
                                            sendJitterMS,
                                            sendAudioLevel,
                                            recvBytes,
                                            recvPackets,
                                            recvPacketsLost,
                                            recvFractionLost,
                                            recvCodecType,
                                            recvJitterMS,
                                            recvAudioLevel:integer): integer;
begin
  result := fPortSIP_getAudioStatistics(fSDKLib,
                                          sessionId,
                                          sendBytes,
                                            sendPackets,
                                            sendPacketsLost,
                                            sendFractionLost,
                                            sendRttMS,
                                            sendCodecType,
                                            sendJitterMS,
                                            sendAudioLevel,
                                            recvBytes,
                                            recvPackets,
                                            recvPacketsLost,
                                            recvFractionLost,
                                            recvCodecType,
                                            recvJitterMS,
                                            recvAudioLevel);
end;

function TPortSipObject.getVideoStatistics(sessionId: NativeInt;
                                           var sendBytes,
                                            sendPackets,
                                            sendPacketsLost,
                                            sendFractionLost,
                                            sendRttMS,
                                            sendCodecType,
                                            sendFrameWidth,
                                            sendFrameHeight,
                                            sendBitrateBPS,
                                            sendFramerate,
                                            recvBytes,
                                            recvPackets,
                                            recvPacketsLost,
                                            recvFractionLost,
                                            recvCodecType,
                                            recvFrameWidth,
                                            recvFrameHeight,
                                            recvBitrateBPS,
                                            recvFramerate:integer): integer;
begin
  result := fPortSIP_getVideoStatistics(fSDKLib,
                                          sessionId,
                                          sendBytes,
                                            sendPackets,
                                            sendPacketsLost,
                                            sendFractionLost,
                                            sendRttMS,
                                            sendCodecType,
                                            sendFrameWidth,
                                            sendFrameHeight,
                                            sendBitrateBPS,
                                            sendFramerate,
                                            recvBytes,
                                            recvPackets,
                                            recvPacketsLost,
                                            recvFractionLost,
                                            recvCodecType,
                                            recvFrameWidth,
                                            recvFrameHeight,
                                            recvBitrateBPS,
                                            recvFramerate);
end;

procedure TPortSipObject.enableVAD(state: Boolean);
begin
  fPortSIP_enableVAD(fSDKLib, state);
end;

procedure TPortSipObject.enableAEC(mode:integer);
begin
  fPortSIP_enableAEC(fSDKLib, mode);
end;


procedure TPortSipObject.enableCNG(state: Boolean);
begin
  fPortSIP_enableCNG(fSDKLib, state);
end;



procedure TPortSipObject.enableAGC(mode:integer);
begin
  fPortSIP_enableAGC(fSDKLib, mode);
end;


procedure TPortSipObject.enableANS(mode:integer);
begin
  fPortSIP_enableANS(fSDKLib, mode);
end;

function TPortSipObject.enableAudioQos(enable: Boolean): integer;
begin
  result := fPortSIP_enableAudioQos(fSDKLib, enable);
end;


function TPortSipObject.enableVideoQos(enable: Boolean): integer;
begin
  result := fPortSIP_enableVideoQos(fSDKLib, enable);
end;

function TPortSipObject.setVideoMTU(mtu: Integer): integer;
begin
  result := fPortSIP_setVideoMTU(fSDKLib, mtu);
end;


function TPortSipObject.sendSubscription(_to, eventName:PAnsiChar):integer;
begin
  result := fPortSIP_sendSubscription(fSDKLib, _to, eventName);
end;

function TPortSIPObject.terminateSubscription(subscribeId:NativeInt):integer;
begin
  result :=  fPortSIP_terminateSubscription(fSDKLib, subscribeId);
end;

function TPortSipObject.setDefaultSubscriptionTime(secs:NativeInt):integer;
begin
    result :=  fPortSIP_setDefaultSubscriptionTime(fSDKLib, secs);
end;


function TPortSipObject.setDefaultPublicationTime(secs:NativeInt):integer;
begin
   result :=  fPortSIP_setDefaultPublicationTime(fSDKLib, secs);
end;



function TPortSipObject.sendInfo(sessionId: NativeInt;
                                  mimeType: PAnsiChar;
                                  subMimeType: PAnsiChar;
                                  infoContents: PAnsiChar): integer;
begin
  result := fPortSIP_sendInfo(fSDKLib, sessionId,
                                  mimeType,
                                  subMimeType,
                                  infoContents);
end;


function TPortSipObject.sendOptions(sendTo: PAnsiChar; sdp: PAnsiChar): integer;
begin
  result := fPortSIP_sendOptions(fSDKLib, sendTo, sdp);
end;



function TPortSipObject.sendMessage(sessionId: NativeInt;
                                    mimeType: PAnsiChar;
                                    subMimeType: PAnsiChar;
                                    messageData: PByte;
                                    messageDataLength: Integer): integer;
begin
  result := fPortSIP_sendMessage(fSDKLib, sessionId,
                                    mimeType,
                                    subMimeType,
                                    messageData,
                                    messageDataLength);
end;

function TPortSipObject.sendOutOfDialogMessage(sendTo: PAnsiChar;
                                                mimeType: PAnsiChar;
                                                subMimeType: PAnsiChar;
                                                isSMS: boolean;
                                                 messageData: PByte;
                                                 messageDataLength: Integer): integer;
begin
  result := fPortSIP_sendOutOfDialogMessage(fSDKLib, sendTo,
                                    mimeType,
                                    subMimeType,
                                    isSMS,
                                    messageData,
                                    messageDataLength);
end;

function TPortSipObject.presenceSubscribe(subscribeTo: PAnsiChar; subject: PAnsiChar): integer;
begin
  result := fPortSIP_presenceSubscribe(fSDKLib, subscribeTo, subject);
end;

function TPortSipObject.presenceTerminateSubscribe(subscribeId: NativeInt): integer;
begin
  result := fPortSIP_presenceTerminateSubscribe(fSDKLib, subscribeId);
end;


function TPortSipObject.presenceRejectSubscribe(subscribeId: NativeInt): integer;
begin
  result := fPortSIP_presenceRejectSubscribe(fSDKLib, subscribeId);
end;

function TPortSipObject.presenceAcceptSubscribe(subscribeId: NativeInt): integer;
begin
  result := fPortSIP_presenceAcceptSubscribe(fSDKLib, subscribeId);
end;

function TPortSipObject.setPresenceMode(mode: integer): integer;
begin
  result := fPortSIP_setPresenceMode(fSDKLib, mode);
end;

function TPortSipObject.setPresenceStatus(subscribeId: NativeInt; stateText:PAnsiChar): integer;
begin
  result := fPortSIP_setPresenceStatus(fSDKLib, subscribeId, stateText);
end;


function TPortSipObject.getNumOfRecordingDevices: integer;
begin
  result := fPortSIP_getNumOfRecordingDevices(fSDKLib);
end;

function TPortSipObject.getNumOfPlayoutDevices: integer;
begin
  result := fPortSIP_getNumOfPlayoutDevices(fSDKLib);
end;


function TPortSipObject.getRecordingDeviceName(index: Integer; nameUTF8: PAnsiChar; nameUTF8Length: Integer): integer;
begin
  result := fPortSIP_getRecordingDeviceName(fSDKLib, index, nameUTF8, nameUTF8Length);
end;

function TPortSipObject.getPlayoutDeviceName(index: Integer; nameUTF8: PAnsiChar; nameUTF8Length: Integer): integer;
begin
  result := fPortSIP_getPlayoutDeviceName(fSDKLib, index, nameUTF8, nameUTF8Length);
end;


function TPortSipObject.setSpeakerVolume(volume: Integer): integer;
begin
  result := fPortSIP_setSpeakerVolume(fSDKLib, volume);
end;


function TPortSipObject.getSpeakerVolume: integer;
begin
  result := fPortSIP_getSpeakerVolume(fSDKLib);
end;

function TPortSipObject.setMicVolume(volume: Integer): integer;
begin
  result := fPortSIP_setMicVolume(fSDKLib, volume);
end;


function TPortSipObject.getMicVolume: integer;
begin
  result := fPortSIP_getMicVolume(fSDKLib);
end;

procedure TPortSipObject.audioPlayLoopbackTest(enable: Boolean);
begin
  fPortSIP_audioPlayLoopbackTest(fSDKLib, enable);
end;


function TPortSipObject.getNumOfVideoCaptureDevices: integer;
begin
  result := fPortSIP_getNumOfVideoCaptureDevices(fSDKLib);
end;

function TPortSipObject.getVideoCaptureDeviceName(index: Integer;
                                                  uniqueIdUTF8: PAnsiChar;
                                                  uniqueIdUTF8Length: Integer;
                                                   deviceNameUTF8: PAnsiChar;
                                                   deviceNameUTF8Length: Integer): integer;
begin
  result := fPortSIP_getVideoCaptureDeviceName(fSDKLib, index,
                                                  uniqueIdUTF8,
                                                  uniqueIdUTF8Length,
                                                   deviceNameUTF8,
                                                   deviceNameUTF8Length);
end;


function TPortSipObject.showVideoCaptureSettingsDialogBox(uniqueIdUTF8: PAnsiChar;
                                                          uniqueIdUTF8Length: Integer;
                                                          dialogTitle: PAnsiChar;
                                                          parentWindow: THandle;
                                                          x: Integer;
                                                          y: Integer): integer;
begin
  result := fPortSIP_showVideoCaptureSettingsDialogBox(fSDKLib,
                                                          uniqueIdUTF8,
                                                          uniqueIdUTF8Length,
                                                          dialogTitle,
                                                          parentWindow,
                                                          x,
                                                          y);
end;


///
constructor TPortSipObject.create(DLLPath: string; callbackIndex:NativeInt);
begin
  inherited Create();

  fDLLPath:= DLLPath;
  fCallbackIndex := callbackIndex;

  fFullDLLPathName := '';
  fCallbackDispatcher := 0;
  fSDKLib := 0;
  fSDKLibModule := 0;


	fPortSIP_delCallbackParameters := nil;
 	fPortSIP_initialize := nil;
  fPortSIP_setDisplayName := nil;
 	fPortSIP_setInstanceId := nil;
 	fPortSIP_unInitialize := nil;
 	fPortSIP_setLicenseKey := nil;
 	fPortSIP_getNICNums := nil;
 	fPortSIP_getLocalIpAddress := nil;
 	fPortSIP_setUser := nil;
 	fPortSIP_removeUser := nil;
 	fPortSIP_registerServer := nil;
  fPortSIP_refreshRegistration := nil;
 	fPortSIP_unRegisterServer := nil;
 	fPortSIP_getVersion := nil;
  fPortSIP_enableRport := nil;
  fPortSIP_enableEarlyMedia := nil;
 	fPortSIP_enableReliableProvisional := nil;
 	fPortSIP_enable3GppTags := nil;
 	fPortSIP_enableCallbackSignaling := nil;
 	fPortSIP_setRtpCallback := nil;
 	fPortSIP_addAudioCodec := nil;
 	fPortSIP_addVideoCodec := nil;
 	fPortSIP_isAudioCodecEmpty := nil;
 	fPortSIP_isVideoCodecEmpty := nil;
 	fPortSIP_setAudioCodecPayloadType := nil;
 	fPortSIP_setVideoCodecPayloadType := nil;
 	fPortSIP_clearAudioCodec := nil;
 	fPortSIP_clearVideoCodec := nil;
 	fPortSIP_setAudioCodecParameter := nil;
 	fPortSIP_setVideoCodecParameter := nil;
 	fPortSIP_setSrtpPolicy := nil;
 	fPortSIP_setRtpPortRange := nil;
 	fPortSIP_setRtcpPortRange := nil;
 	fPortSIP_enableCallForward := nil;
 	fPortSIP_disableCallForward := nil;
 	fPortSIP_enableSessionTimer := nil;
 	fPortSIP_disableSessionTimer := nil;
 	fPortSIP_setDoNotDisturb := nil;
 	fPortSIP_enableAutoCheckMwi := nil;
 	fPortSIP_setRtpKeepAlive := nil;
 	fPortSIP_setKeepAliveTime := nil;
 	fPortSIP_getSipMessageHeaderValue := nil;
 	fPortSIP_addSipMessageHeader := nil;
 	fPortSIP_clearAddedSipMessageHeaders := nil;
  fPortSIP_removeAddedSipMessageHeader := nil;
 	fPortSIP_modifySipMessageHeader := nil;
 	fPortSIP_clearModifiedSipMessageHeaders := nil;
  fPortSIP_removeModifiedSipMessageHeader := nil;
 	fPortSIP_addSupportedMimeType := nil;
 	fPortSIP_setAudioSamples := nil;
  fPortSIP_setAudioBitrate := nil;
 	fPortSIP_setAudioDeviceId := nil;
 	fPortSIP_setVideoDeviceId := nil;
 	fPortSIP_setVideoResolution := nil;
 	fPortSIP_setVideoBitrate := nil;
 	fPortSIP_setVideoFrameRate := nil;
 	fPortSIP_sendVideo := nil;
 	fPortSIP_muteMicrophone := nil;
 	fPortSIP_muteSpeaker := nil;
 	fPortSIP_setChannelOutputVolumeScaling := nil;
	fPortSIP_setChannelInputVolumeScaling := nil;
 	fPortSIP_setLocalVideoWindow := nil;
 	fPortSIP_setRemoteVideoWindow := nil;
 	fPortSIP_displayLocalVideo := nil;
 	fPortSIP_setVideoNackStatus := nil;
 	fPortSIP_call := nil;
 	fPortSIP_rejectCall := nil;
 	fPortSIP_hangUp := nil;
 	fPortSIP_answerCall := nil;
 	fPortSIP_updateCall := nil;
 	fPortSIP_hold := nil;
 	fPortSIP_unHold := nil;
 	fPortSIP_refer := nil;
 	fPortSIP_attendedRefer := nil;
  fPortSIP_attendedRefer2 := nil;
  fPortSIP_outOfDialogRefer := nil;
 	fPortSIP_acceptRefer := nil;
 	fPortSIP_rejectRefer := nil;
 	fPortSIP_muteSession := nil;
 	fPortSIP_forwardCall := nil;
  fPortSIP_pickupBLFCall := nil;
 	fPortSIP_sendDtmf := nil;
 	fPortSIP_enableSendPcmStreamToRemote := nil;
 	fPortSIP_sendPcmStreamToRemote := nil;
 	fPortSIP_enableSendVideoStreamToRemote := nil;
 	fPortSIP_sendVideoStreamToRemote := nil;
 	fPortSIP_enableAudioStreamCallback := nil;
 	fPortSIP_enableVideoStreamCallback := nil;
 	fPortSIP_startRecord := nil;
 	fPortSIP_stopRecord := nil;
 	fPortSIP_playVideoFileToRemote := nil;
 	fPortSIP_stopPlayVideoFileToRemote := nil;
 	fPortSIP_playAudioFileToRemote := nil;
 	fPortSIP_stopPlayAudioFileToRemote := nil;
 	fPortSIP_playAudioFileToRemoteAsBackground := nil;
 	fPortSIP_stopPlayAudioFileToRemoteAsBackground := nil;
 	fPortSIP_createAudioConference := nil;
 	fPortSIP_createVideoConference := nil;
 	fPortSIP_destroyConference := nil;
  fPortSIP_setConferenceVideoWindow := nil;
 	fPortSIP_joinToConference := nil;
 	fPortSIP_removeFromConference := nil;
 	fPortSIP_setAudioRtcpBandwidth := nil;
 	fPortSIP_setVideoRtcpBandwidth := nil;
 	fPortSIP_getAudioStatistics := nil;
 	fPortSIP_getVideoStatistics := nil;
 	fPortSIP_enableVAD := nil;
 	fPortSIP_enableAEC := nil;
 	fPortSIP_enableCNG := nil;
 	fPortSIP_enableAGC := nil;
 	fPortSIP_enableANS := nil;
 	fPortSIP_enableAudioQos := nil;
 	fPortSIP_enableVideoQos := nil;
  fPortSIP_setVideoMTU := nil;
 	fPortSIP_sendOptions := nil;
 	fPortSIP_sendInfo := nil;
  fPortSIP_sendSubscription := nil;
  fPortSIP_terminateSubscription := nil;
  fPortSIP_setDefaultSubscriptionTime := nil;
  fPortSIP_setDefaultPublicationTime := nil;
 	fPortSIP_sendMessage := nil;
 	fPortSIP_sendOutOfDialogMessage := nil;
 	fPortSIP_presenceSubscribe := nil;
  fPortSIP_presenceTerminateSubscribe := nil;
 	fPortSIP_presenceAcceptSubscribe := nil;
 	fPortSIP_presenceRejectSubscribe := nil;
  fPortSIP_setPresenceMode := nil;
 	fPortSIP_setPresenceStatus := nil;
 	fPortSIP_getNumOfRecordingDevices := nil;
 	fPortSIP_getNumOfPlayoutDevices := nil;
 	fPortSIP_getRecordingDeviceName := nil;
 	fPortSIP_getPlayoutDeviceName := nil;
 	fPortSIP_setSpeakerVolume := nil;
 	fPortSIP_getSpeakerVolume := nil;
 	fPortSIP_setMicVolume := nil;
 	fPortSIP_getMicVolume := nil;
 	fPortSIP_audioPlayLoopbackTest := nil;
 	fPortSIP_getNumOfVideoCaptureDevices := nil;
 	fPortSIP_getVideoCaptureDeviceName := nil;
 	fPortSIP_showVideoCaptureSettingsDialogBox := nil;


  fPSCallback_createCallbackDispatcher := nil;
  fPSCallback_releaseCallbackDispatcher := nil;
  fPSCallback_setRegisterSuccessHandler := nil;
  fPSCallback_setRegisterFailureHandler := nil;
  fPSCallback_setInviteIncomingHandler := nil;
  fPSCallback_setInviteTryingHandler := nil;
  fPSCallback_setInviteSessionProgressHandler := nil;
  fPSCallback_setInviteRingingHandler := nil;
  fPSCallback_setInviteAnsweredHandler := nil;
  fPSCallback_setInviteFailureHandler := nil;
  fPSCallback_setInviteUpdatedHandler := nil;
  fPSCallback_setInviteConnectedHandler := nil;
  fPSCallback_setInviteBeginingForwardHandler := nil;
  fPSCallback_setInviteClosedHandler := nil;
  fPSCallback_setDialogStateUpdatedHandler := nil;
  fPSCallback_setRemoteHoldHandler := nil;
  fPSCallback_setRemoteUnHoldHandler := nil;
  fPSCallback_setReceivedReferHandler := nil;
  fPSCallback_setReferAcceptedHandler := nil;
  fPSCallback_setReferRejectedHandler:= nil;
  fPSCallback_setTransferTryingHandler:= nil;
  fPSCallback_setTransferRingingHandler:= nil;
  fPSCallback_setACTVTransferSuccessHandler := nil;
  fPSCallback_setACTVTransferFailureHandler := nil;
  fPSCallback_setReceivedSignalingHandler := nil;
  fPSCallback_setSendingSignalingHandler := nil;
  fPSCallback_setWaitingVoiceMessageHandler := nil;
  fPSCallback_setWaitingFaxMessageHandler:= nil;
  fPSCallback_setRecvDtmfToneHandler:= nil;
  fPSCallback_setPresenceRecvSubscribeHandler := nil;
  fPSCallback_setPresenceOnlineHandler := nil;
  fPSCallback_setPresenceOfflineHandler:= nil;
  fPSCallback_setRecvOptionsHandler:= nil;
  fPSCallback_setRecvInfoHandler := nil;
  fPSCallback_setPlayAudioFileFinishedHandler := nil;
  fPSCallback_setPlayVideoFileFinishedHandler := nil;
  fPSCallback_setRecvMessageHandler := nil;
  fPSCallback_setRecvOutOfDialogMessageHandler := nil;
  fPSCallback_setSendMessageSuccessHandler:= nil;
  fPSCallback_setSendMessageFailureHandler := nil;
  fPSCallback_setSendOutOfDialogMessageSuccessHandler := nil;
  fPSCallback_setSendOutOfDialogMessageFailureHandler:= nil;

  // Callback functions
  fRegisterSuccess  := nil;
  fRegisterFailure  := nil;
  fInviteIncoming  := nil;
  fInviteTrying  := nil;
  fInviteSessionProgress  := nil;
  fInviteRinging  := nil;
  fInviteAnswered  := nil;
  fInviteFailure  := nil;
  fInviteUpdated  := nil;
  fInviteConnected  := nil;
  fInviteBeginingForward  := nil;
  fInviteClosed  := nil;
  fDialogStateUpdated := nil;
  fRemoteHold  := nil;
  fRemoteUnHold  := nil;
  fReceivedRefer  := nil;
  fReferAccepted  := nil;
  fReferRejected  := nil;
  fTransferTrying  := nil;
  fTransferRinging  := nil;
  fACTVTransferSuccess   := nil;
  fACTVTransferFailure  := nil;
  fReceivedSignaling  := nil;
  fSendingSignaling  := nil;
  fWaitingVoiceMessage  := nil;
  fWaitingFaxMessage  := nil;
  fRecvDtmfTone  := nil;
  fPresenceRecvSubscribe  := nil;
  fPresenceOnline  := nil;
  fPresenceOffline  := nil;
  fRecvOptions  := nil;
  fRecvInfo    := nil;
  fPlayAudioFileFinished   := nil;
  fPlayVideoFileFinished   := nil;
  fRecvMessage   := nil;
  fRecvOutOfDialogMessage   := nil;
  fSendMessageSuccess  := nil;
  fSendMessageFailure   := nil;
  fSendOutOfDialogMessageSuccess    := nil;
  fSendOutOfDialogMessageFailure   := nil;

end;


function TPortSipObject.createCallbackHandlers(): boolean;
begin
  result := false;

  fDLLPath := IncludeTrailingPathDelimiter(DLLPath);
  fFullDLLPathName := fDLLPath+'portsip_sdk.dll';
  fSDKLibModule := LoadLibrary(PChar(fFullDLLPathName));

  if fSDKLibModule = 0 then
  begin
    Exit;
  end;

  @fPortSIP_delCallbackParameters := GetProcAddress(fSDKLibModule, 'PortSIP_delCallbackParameters');
  @fPortSIP_initialize := GetProcAddress(fSDKLibModule, 'PortSIP_initialize');
  @fPortSIP_setDisplayName := GetProcAddress(fSDKLibModule, 'PortSIP_setDisplayName');
  @fPortSIP_setInstanceId := GetProcAddress(fSDKLibModule, 'PortSIP_setInstanceId');

  @fPortSIP_unInitialize := GetProcAddress(fSDKLibModule, 'PortSIP_unInitialize');
  @fPortSIP_setLicenseKey := GetProcAddress(fSDKLibModule, 'PortSIP_setLicenseKey');
  @fPortSIP_getNICNums := GetProcAddress(fSDKLibModule, 'PortSIP_getNICNums');
  @fPortSIP_getLocalIpAddress := GetProcAddress(fSDKLibModule, 'PortSIP_getLocalIpAddress');
  @fPortSIP_setUser := GetProcAddress(fSDKLibModule, 'PortSIP_setUser');
  @fPortSIP_removeUser := GetProcAddress(fSDKLibModule, 'PortSIP_removeUser');
  @fPortSIP_registerServer := GetProcAddress(fSDKLibModule, 'PortSIP_registerServer');
  @fPortSIP_refreshRegistration := GetProcAddress(fSDKLibModule, 'PortSIP_refreshRegistration');
  @fPortSIP_unRegisterServer := GetProcAddress(fSDKLibModule, 'PortSIP_unRegisterServer');
  @fPortSIP_getVersion := GetProcAddress(fSDKLibModule, 'PortSIP_getVersion');
  @fPortSIP_enableRport := GetProcAddress(fSDKLibModule, 'PortSIP_enableRport');
  @fPortSIP_enableEarlyMedia := GetProcAddress(fSDKLibModule, 'PortSIP_enableEarlyMedia');
  @fPortSIP_enableReliableProvisional := GetProcAddress(fSDKLibModule, 'PortSIP_enableReliableProvisional');
  @fPortSIP_enable3GppTags := GetProcAddress(fSDKLibModule, 'PortSIP_enable3GppTags');
  @fPortSIP_enableCallbackSignaling := GetProcAddress(fSDKLibModule, 'PortSIP_enableCallbackSignaling');
  @fPortSIP_setRtpCallback := GetProcAddress(fSDKLibModule, 'PortSIP_setRtpCallback');
  @fPortSIP_addAudioCodec := GetProcAddress(fSDKLibModule, 'PortSIP_addAudioCodec');
  @fPortSIP_addVideoCodec := GetProcAddress(fSDKLibModule, 'PortSIP_addVideoCodec');
  @fPortSIP_isAudioCodecEmpty := GetProcAddress(fSDKLibModule, 'PortSIP_isAudioCodecEmpty');
  @fPortSIP_isVideoCodecEmpty := GetProcAddress(fSDKLibModule, 'PortSIP_isVideoCodecEmpty');
  @fPortSIP_setAudioCodecPayloadType := GetProcAddress(fSDKLibModule, 'PortSIP_setAudioCodecPayloadType');
  @fPortSIP_setVideoCodecPayloadType := GetProcAddress(fSDKLibModule, 'PortSIP_setVideoCodecPayloadType');
  @fPortSIP_clearAudioCodec := GetProcAddress(fSDKLibModule, 'PortSIP_clearAudioCodec');
  @fPortSIP_clearVideoCodec := GetProcAddress(fSDKLibModule, 'PortSIP_clearVideoCodec');
  @fPortSIP_setAudioCodecParameter := GetProcAddress(fSDKLibModule, 'PortSIP_setAudioCodecParameter');
  @fPortSIP_setVideoCodecParameter := GetProcAddress(fSDKLibModule, 'PortSIP_setVideoCodecParameter');
  @fPortSIP_setSrtpPolicy := GetProcAddress(fSDKLibModule, 'PortSIP_setSrtpPolicy');
  @fPortSIP_setRtpPortRange := GetProcAddress(fSDKLibModule, 'PortSIP_setRtpPortRange');
  @fPortSIP_setRtcpPortRange := GetProcAddress(fSDKLibModule, 'PortSIP_setRtcpPortRange');
  @fPortSIP_enableCallForward := GetProcAddress(fSDKLibModule, 'PortSIP_enableCallForward');
  @fPortSIP_disableCallForward := GetProcAddress(fSDKLibModule, 'PortSIP_disableCallForward');
  @fPortSIP_enableSessionTimer := GetProcAddress(fSDKLibModule, 'PortSIP_enableSessionTimer');
  @fPortSIP_disableSessionTimer := GetProcAddress(fSDKLibModule, 'PortSIP_disableSessionTimer');
  @fPortSIP_setDoNotDisturb := GetProcAddress(fSDKLibModule, 'PortSIP_setDoNotDisturb');
  @fPortSIP_enableAutoCheckMwi := GetProcAddress(fSDKLibModule, 'PortSIP_enableAutoCheckMwi');
  @fPortSIP_setRtpKeepAlive := GetProcAddress(fSDKLibModule, 'PortSIP_setRtpKeepAlive');
  @fPortSIP_setKeepAliveTime := GetProcAddress(fSDKLibModule, 'PortSIP_setKeepAliveTime');
  @fPortSIP_getSipMessageHeaderValue := GetProcAddress(fSDKLibModule, 'PortSIP_getSipMessageHeaderValue');
  @fPortSIP_addSipMessageHeader := GetProcAddress(fSDKLibModule, 'PortSIP_addSipMessageHeader');
  @fPortSIP_clearAddedSipMessageHeaders := GetProcAddress(fSDKLibModule, 'PortSIP_clearAddedSipMessageHeaders');
  @fPortSIP_modifySipMessageHeader := GetProcAddress(fSDKLibModule, 'PortSIP_modifySipMessageHeader');
  @fPortSIP_clearModifiedSipMessageHeaders := GetProcAddress(fSDKLibModule, 'PortSIP_clearModifiedSipMessageHeaders');
  @fPortSIP_removeModifiedSipMessageHeader := GetProcAddress(fSDKLibModule, 'PortSIP_removeModifiedSipMessageHeader');
  @fPortSIP_removeAddedSipMessageHeader := GetProcAddress(fSDKLibModule, 'PortSIP_removeAddedSipMessageHeader');
  @fPortSIP_addSupportedMimeType := GetProcAddress(fSDKLibModule, 'PortSIP_addSupportedMimeType');
  @fPortSIP_setAudioSamples := GetProcAddress(fSDKLibModule, 'PortSIP_setAudioSamples');
  @fPortSIP_setAudioBitrate := GetProcAddress(fSDKLibModule, 'PortSIP_setAudioBitrate');
  @fPortSIP_setAudioDeviceId := GetProcAddress(fSDKLibModule, 'PortSIP_setAudioDeviceId');
  @fPortSIP_setVideoDeviceId := GetProcAddress(fSDKLibModule, 'PortSIP_setVideoDeviceId');
  @fPortSIP_setVideoResolution := GetProcAddress(fSDKLibModule, 'PortSIP_setVideoResolution');
  @fPortSIP_setVideoBitrate := GetProcAddress(fSDKLibModule, 'PortSIP_setVideoBitrate');
  @fPortSIP_setVideoFrameRate := GetProcAddress(fSDKLibModule, 'PortSIP_setVideoFrameRate');
  @fPortSIP_sendVideo := GetProcAddress(fSDKLibModule, 'PortSIP_sendVideo');
  @fPortSIP_muteMicrophone := GetProcAddress(fSDKLibModule, 'PortSIP_muteMicrophone');
  @fPortSIP_muteSpeaker := GetProcAddress(fSDKLibModule, 'PortSIP_muteSpeaker');
  @fPortSIP_setChannelOutputVolumeScaling := GetProcAddress(fSDKLibModule, 'PortSIP_setChannelOutputVolumeScaling');
  @fPortSIP_setChannelInputVolumeScaling := GetProcAddress(fSDKLibModule, 'PortSIP_setChannelInputVolumeScaling');
  @fPortSIP_setLocalVideoWindow := GetProcAddress(fSDKLibModule, 'PortSIP_setLocalVideoWindow');
  @fPortSIP_setRemoteVideoWindow := GetProcAddress(fSDKLibModule, 'PortSIP_setRemoteVideoWindow');
  @fPortSIP_displayLocalVideo := GetProcAddress(fSDKLibModule, 'PortSIP_displayLocalVideo');
  @fPortSIP_setVideoNackStatus := GetProcAddress(fSDKLibModule, 'PortSIP_setVideoNackStatus');
  @fPortSIP_call := GetProcAddress(fSDKLibModule, 'PortSIP_call');
  @fPortSIP_rejectCall := GetProcAddress(fSDKLibModule, 'PortSIP_rejectCall');
  @fPortSIP_hangUp := GetProcAddress(fSDKLibModule, 'PortSIP_hangUp');
  @fPortSIP_answerCall := GetProcAddress(fSDKLibModule, 'PortSIP_answerCall');
  @fPortSIP_updateCall := GetProcAddress(fSDKLibModule, 'PortSIP_updateCall');
  @fPortSIP_hold := GetProcAddress(fSDKLibModule, 'PortSIP_hold');
  @fPortSIP_unHold := GetProcAddress(fSDKLibModule, 'PortSIP_unHold');
  @fPortSIP_refer := GetProcAddress(fSDKLibModule, 'PortSIP_refer');
  @fPortSIP_attendedRefer := GetProcAddress(fSDKLibModule, 'PortSIP_attendedRefer');
  @fPortSIP_attendedRefer2 := GetProcAddress(fSDKLibModule, 'PortSIP_attendedRefer2');
  @fPortSIP_outOfDialogRefer := GetProcAddress(fSDKLibModule, 'PortSIP_outOfDialogRefer');
  @fPortSIP_acceptRefer := GetProcAddress(fSDKLibModule, 'PortSIP_acceptRefer');
  @fPortSIP_rejectRefer := GetProcAddress(fSDKLibModule, 'PortSIP_rejectRefer');
  @fPortSIP_muteSession := GetProcAddress(fSDKLibModule, 'PortSIP_muteSession');
  @fPortSIP_forwardCall := GetProcAddress(fSDKLibModule, 'PortSIP_forwardCall');
  @fPortSIP_pickupBLFCall := GetProcAddress(fSDKLibModule, 'PortSIP_pickupBLFCall');
  @fPortSIP_sendDtmf := GetProcAddress(fSDKLibModule, 'PortSIP_sendDtmf');
  @fPortSIP_enableSendPcmStreamToRemote := GetProcAddress(fSDKLibModule, 'PortSIP_enableSendPcmStreamToRemote');
  @fPortSIP_sendPcmStreamToRemote := GetProcAddress(fSDKLibModule, 'PortSIP_sendPcmStreamToRemote');
  @fPortSIP_enableSendVideoStreamToRemote := GetProcAddress(fSDKLibModule, 'PortSIP_enableSendVideoStreamToRemote');
  @fPortSIP_sendVideoStreamToRemote := GetProcAddress(fSDKLibModule, 'PortSIP_sendVideoStreamToRemote');
  @fPortSIP_enableAudioStreamCallback := GetProcAddress(fSDKLibModule, 'PortSIP_enableAudioStreamCallback');
  @fPortSIP_enableVideoStreamCallback := GetProcAddress(fSDKLibModule, 'PortSIP_enableVideoStreamCallback');
  @fPortSIP_startRecord := GetProcAddress(fSDKLibModule, 'PortSIP_startRecord');
     @fPortSIP_stopRecord := GetProcAddress(fSDKLibModule, 'PortSIP_stopRecord');
     @fPortSIP_playVideoFileToRemote := GetProcAddress(fSDKLibModule, 'PortSIP_playVideoFileToRemote');
     @fPortSIP_stopPlayVideoFileToRemote := GetProcAddress(fSDKLibModule, 'PortSIP_stopPlayVideoFileToRemote');
     @fPortSIP_playAudioFileToRemote := GetProcAddress(fSDKLibModule, 'PortSIP_playAudioFileToRemote');
     @fPortSIP_stopPlayAudioFileToRemote := GetProcAddress(fSDKLibModule, 'PortSIP_stopPlayAudioFileToRemote');
     @fPortSIP_playAudioFileToRemoteAsBackground := GetProcAddress(fSDKLibModule, 'PortSIP_playAudioFileToRemoteAsBackground');
     @fPortSIP_stopPlayAudioFileToRemoteAsBackground := GetProcAddress(fSDKLibModule, 'PortSIP_stopPlayAudioFileToRemoteAsBackground');
     @fPortSIP_createAudioConference := GetProcAddress(fSDKLibModule, 'PortSIP_createAudioConference');
     @fPortSIP_createVideoConference := GetProcAddress(fSDKLibModule, 'PortSIP_createVideoConference');
     @fPortSIP_destroyConference := GetProcAddress(fSDKLibModule, 'PortSIP_destroyConference');
     @fPortSIP_setConferenceVideoWindow := GetProcAddress(fSDKLibModule, 'PortSIP_setConferenceVideoWindow');
     @fPortSIP_joinToConference := GetProcAddress(fSDKLibModule, 'PortSIP_joinToConference');
     @fPortSIP_removeFromConference := GetProcAddress(fSDKLibModule, 'PortSIP_removeFromConference');
     @fPortSIP_setAudioRtcpBandwidth := GetProcAddress(fSDKLibModule, 'PortSIP_setAudioRtcpBandwidth');
     @fPortSIP_setVideoRtcpBandwidth := GetProcAddress(fSDKLibModule, 'PortSIP_setVideoRtcpBandwidth');
     @fPortSIP_getAudioStatistics := GetProcAddress(fSDKLibModule, 'PortSIP_getAudioStatistics');
     @fPortSIP_getVideoStatistics := GetProcAddress(fSDKLibModule, 'PortSIP_getVideoStatistics');
     @fPortSIP_enableVAD := GetProcAddress(fSDKLibModule, 'PortSIP_enableVAD');
     @fPortSIP_enableAEC := GetProcAddress(fSDKLibModule, 'PortSIP_enableAEC');
     @fPortSIP_enableCNG := GetProcAddress(fSDKLibModule, 'PortSIP_enableCNG');
     @fPortSIP_enableAGC := GetProcAddress(fSDKLibModule, 'PortSIP_enableAGC');
     @fPortSIP_enableANS := GetProcAddress(fSDKLibModule, 'PortSIP_enableANS');
     @fPortSIP_enableAudioQos := GetProcAddress(fSDKLibModule, 'PortSIP_enableAudioQos');
     @fPortSIP_enableVideoQos := GetProcAddress(fSDKLibModule, 'PortSIP_enableVideoQos');
     @fPortSIP_setVideoMTU := GetProcAddress(fSDKLibModule, 'PortSIP_setVideoMTU');
     @fPortSIP_sendOptions := GetProcAddress(fSDKLibModule, 'PortSIP_sendOptions');
     @fPortSIP_sendSubscription := GetProcAddress(fSDKLibModule, 'PortSIP_sendSubscription');
     @fPortSIP_terminateSubscription := GetProcAddress(fSDKLibModule, 'PortSIP_te rminateSubscription');
     @fPortSIP_setDefaultSubscriptionTime := GetProcAddress(fSDKLibModule, 'PortSIP_setDefaultSubscriptionTime');
     @fPortSIP_setDefaultPublicationTime := GetProcAddress(fSDKLibModule, 'PortSIP_setDefaultPublicationTime');
     @fPortSIP_sendInfo := GetProcAddress(fSDKLibModule, 'PortSIP_sendInfo');
     @fPortSIP_sendMessage := GetProcAddress(fSDKLibModule, 'PortSIP_sendMessage');
     @fPortSIP_sendOutOfDialogMessage := GetProcAddress(fSDKLibModule, 'PortSIP_sendOutOfDialogMessage');
     @fPortSIP_presenceSubscribe := GetProcAddress(fSDKLibModule, 'PortSIP_presenceSubscribe');
     @fPortSIP_presenceTerminateSubscribe := GetProcAddress(fSDKLibModule, 'PortSIP_presenceTerminateSubscribe');
     @fPortSIP_presenceAcceptSubscribe := GetProcAddress(fSDKLibModule, 'PortSIP_presenceAcceptSubscribe');
     @fPortSIP_presenceRejectSubscribe := GetProcAddress(fSDKLibModule, 'PortSIP_presenceRejectSubscribe');
     @fPortSIP_setPresenceMode := GetProcAddress(fSDKLibModule, 'PortSIP_setPresenceMode');
     @fPortSIP_setPresenceStatus := GetProcAddress(fSDKLibModule, 'PortSIP_setPresenceStatus');
     @fPortSIP_getNumOfRecordingDevices := GetProcAddress(fSDKLibModule, 'PortSIP_getNumOfRecordingDevices');
     @fPortSIP_getNumOfPlayoutDevices := GetProcAddress(fSDKLibModule, 'PortSIP_getNumOfPlayoutDevices');
     @fPortSIP_getRecordingDeviceName := GetProcAddress(fSDKLibModule, 'PortSIP_getRecordingDeviceName');
     @fPortSIP_getPlayoutDeviceName := GetProcAddress(fSDKLibModule, 'PortSIP_getPlayoutDeviceName');
     @fPortSIP_setSpeakerVolume := GetProcAddress(fSDKLibModule, 'PortSIP_setSpeakerVolume');
     @fPortSIP_getSpeakerVolume := GetProcAddress(fSDKLibModule, 'PortSIP_getSpeakerVolume');
     @fPortSIP_setMicVolume := GetProcAddress(fSDKLibModule, 'PortSIP_setMicVolume');
     @fPortSIP_getMicVolume := GetProcAddress(fSDKLibModule, 'PortSIP_getMicVolume');
     @fPortSIP_audioPlayLoopbackTest := GetProcAddress(fSDKLibModule, 'PortSIP_audioPlayLoopbackTest');
     @fPortSIP_getNumOfVideoCaptureDevices := GetProcAddress(fSDKLibModule, 'PortSIP_getNumOfVideoCaptureDevices');
     @fPortSIP_getVideoCaptureDeviceName := GetProcAddress(fSDKLibModule, 'PortSIP_getVideoCaptureDeviceName');
     @fPortSIP_showVideoCaptureSettingsDialogBox := GetProcAddress(fSDKLibModule, 'PortSIP_showVideoCaptureSettingsDialogBox');

///
///

     @fPSCallback_createCallbackDispatcher := GetProcAddress(fSDKLibModule, 'PSCallback_createCallbackDispatcher');
     @fPSCallback_releaseCallbackDispatcher := GetProcAddress(fSDKLibModule, 'PSCallback_releaseCallbackDispatcher');
     @fPSCallback_setRegisterSuccessHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setRegisterSuccessHandler');
     @fPSCallback_setRegisterFailureHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setRegisterFailureHandler');
     @fPSCallback_setInviteIncomingHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setInviteIncomingHandler');
     @fPSCallback_setInviteTryingHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setInviteTryingHandler');
     @fPSCallback_setInviteSessionProgressHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setInviteSessionProgressHandler');
     @fPSCallback_setInviteRingingHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setInviteRingingHandler');
     @fPSCallback_setInviteAnsweredHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setInviteAnsweredHandler');
     @fPSCallback_setInviteFailureHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setInviteFailureHandler');
     @fPSCallback_setInviteUpdatedHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setInviteUpdatedHandler');
     @fPSCallback_setInviteConnectedHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setInviteConnectedHandler');
     @fPSCallback_setInviteBeginingForwardHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setInviteBeginingForwardHandler');
     @fPSCallback_setInviteClosedHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setInviteClosedHandler');
	 @fPSCallback_setDialogStateUpdatedHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setDialogStateUpdatedHandler');
     @fPSCallback_setRemoteHoldHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setRemoteHoldHandler');
     @fPSCallback_setRemoteUnHoldHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setRemoteUnHoldHandler');
     @fPSCallback_setReceivedReferHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setReceivedReferHandler');
     @fPSCallback_setReferAcceptedHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setReferAcceptedHandler');
     @fPSCallback_setReferRejectedHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setReferRejectedHandler');
     @fPSCallback_setTransferTryingHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setTransferTryingHandler');
     @fPSCallback_setTransferRingingHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setTransferRingingHandler');
     @fPSCallback_setACTVTransferSuccessHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setACTVTransferSuccessHandler');
     @fPSCallback_setACTVTransferFailureHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setACTVTransferFailureHandler');
     @fPSCallback_setReceivedSignalingHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setReceivedSignalingHandler');
     @fPSCallback_setSendingSignalingHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setSendingSignalingHandler');
     @fPSCallback_setWaitingVoiceMessageHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setWaitingVoiceMessageHandler');
     @fPSCallback_setWaitingFaxMessageHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setWaitingFaxMessageHandler');
     @fPSCallback_setRecvDtmfToneHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setRecvDtmfToneHandler');
     @fPSCallback_setPresenceRecvSubscribeHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setPresenceRecvSubscribeHandler');
     @fPSCallback_setPresenceOnlineHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setPresenceOnlineHandler');
     @fPSCallback_setPresenceOfflineHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setPresenceOfflineHandler');
     @fPSCallback_setRecvOptionsHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setRecvOptionsHandler');
     @fPSCallback_setRecvInfoHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setRecvInfoHandler');
     @fPSCallback_setPlayAudioFileFinishedHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setPlayAudioFileFinishedHandler');
     @fPSCallback_setPlayVideoFileFinishedHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setPlayVideoFileFinishedHandler');
     @fPSCallback_setRecvMessageHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setRecvMessageHandler');
     @fPSCallback_setRecvOutOfDialogMessageHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setRecvOutOfDialogMessageHandler');
     @fPSCallback_setSendMessageSuccessHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setSendMessageSuccessHandler');
     @fPSCallback_setSendMessageFailureHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setSendMessageFailureHandler');
     @fPSCallback_setSendOutOfDialogMessageSuccessHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setSendOutOfDialogMessageSuccessHandler');
     @fPSCallback_setSendOutOfDialogMessageFailureHandler := GetProcAddress(fSDKLibModule, 'PSCallback_setSendOutOfDialogMessageFailureHandler');

     fCallbackDispatcher := fPSCallback_createCallbackDispatcher();
     if fCallbackDispatcher = 0 then
     begin
        Exit;
     end;

    fPSCallback_setRegisterSuccessHandler(fCallbackDispatcher, cbRegisterSuccess, fCallbackIndex, NativeInt(Self));
        fPSCallback_setRegisterFailureHandler(fCallbackDispatcher, cbRegisterFailure, fCallbackIndex, NativeInt(Self));
        fPSCallback_setInviteIncomingHandler(fCallbackDispatcher, cbInviteIncoming, fCallbackIndex, NativeInt(Self));
        fPSCallback_setInviteTryingHandler(fCallbackDispatcher, cbInviteTrying, fCallbackIndex, NativeInt(Self));
        fPSCallback_setInviteSessionProgressHandler(fCallbackDispatcher, cbInviteSessionProgress, fCallbackIndex, NativeInt(Self));
        fPSCallback_setInviteRingingHandler(fCallbackDispatcher, cbInviteRinging, fCallbackIndex, NativeInt(Self));
        fPSCallback_setInviteAnsweredHandler(fCallbackDispatcher, cbInviteAnswered, fCallbackIndex, NativeInt(Self));
        fPSCallback_setInviteFailureHandler(fCallbackDispatcher, cbInviteFailure, fCallbackIndex, NativeInt(Self));
        fPSCallback_setInviteUpdatedHandler(fCallbackDispatcher, cbInviteUpdated, fCallbackIndex, NativeInt(Self));
        fPSCallback_setInviteConnectedHandler(fCallbackDispatcher, cbInviteConnected, fCallbackIndex, NativeInt(Self));
        fPSCallback_setInviteBeginingForwardHandler(fCallbackDispatcher, cbInviteBeginingForward, fCallbackIndex, NativeInt(Self));
        fPSCallback_setInviteClosedHandler(fCallbackDispatcher, cbInviteClosed, fCallbackIndex, NativeInt(Self));
		fPSCallback_setDialogStateUpdatedHandler(fCallbackDispatcher, cbDialogStateUpdated, fCallbackIndex, NativeInt(Self));
        fPSCallback_setRemoteHoldHandler(fCallbackDispatcher, cbRemoteHold, fCallbackIndex, NativeInt(Self));
        fPSCallback_setRemoteUnHoldHandler(fCallbackDispatcher, cbRemoteUnHold, fCallbackIndex, NativeInt(Self));
        fPSCallback_setReceivedReferHandler(fCallbackDispatcher, cbReceivedRefer, fCallbackIndex, NativeInt(Self));
        fPSCallback_setReferAcceptedHandler(fCallbackDispatcher, cbReferAccepted, fCallbackIndex, NativeInt(Self));
        fPSCallback_setReferRejectedHandler(fCallbackDispatcher, cbReferRejected, fCallbackIndex, NativeInt(Self));
        fPSCallback_setTransferTryingHandler(fCallbackDispatcher, cbTransferTrying, fCallbackIndex, NativeInt(Self));
        fPSCallback_setTransferRingingHandler(fCallbackDispatcher, cbTransferRinging, fCallbackIndex, NativeInt(Self));
        fPSCallback_setACTVTransferSuccessHandler(fCallbackDispatcher, cbACTVTransferSuccess, fCallbackIndex, NativeInt(Self));
        fPSCallback_setACTVTransferFailureHandler(fCallbackDispatcher, cbACTVTransferFailure, fCallbackIndex, NativeInt(Self));
        fPSCallback_setReceivedSignalingHandler(fCallbackDispatcher, cbReceivedSignaling, fCallbackIndex, NativeInt(Self));
        fPSCallback_setSendingSignalingHandler(fCallbackDispatcher, cbSendingSignaling, fCallbackIndex, NativeInt(Self));
        fPSCallback_setWaitingVoiceMessageHandler(fCallbackDispatcher, cbWaitingVoiceMessage, fCallbackIndex, NativeInt(Self));
        fPSCallback_setWaitingFaxMessageHandler(fCallbackDispatcher, cbWaitingFaxMessage, fCallbackIndex, NativeInt(Self));
        fPSCallback_setRecvDtmfToneHandler(fCallbackDispatcher, cbRecvDtmfTone, fCallbackIndex, NativeInt(Self));
        fPSCallback_setPresenceRecvSubscribeHandler(fCallbackDispatcher, cbPresenceRecvSubscribe, fCallbackIndex, NativeInt(Self));
        fPSCallback_setPresenceOnlineHandler(fCallbackDispatcher, cbPresenceOnline, fCallbackIndex, NativeInt(Self));
        fPSCallback_setPresenceOfflineHandler(fCallbackDispatcher, cbPresenceOffline, fCallbackIndex, NativeInt(Self));
        fPSCallback_setRecvOptionsHandler(fCallbackDispatcher, cbRecvOptions, fCallbackIndex, NativeInt(Self));
        fPSCallback_setRecvInfoHandler(fCallbackDispatcher, cbRecvInfo, fCallbackIndex, NativeInt(Self));
        fPSCallback_setPlayAudioFileFinishedHandler(fCallbackDispatcher, cbPlayAudioFileFinished, fCallbackIndex, NativeInt(Self));
        fPSCallback_setPlayVideoFileFinishedHandler(fCallbackDispatcher, cbPlayVideoFileFinished, fCallbackIndex, NativeInt(Self));
        fPSCallback_setRecvMessageHandler(fCallbackDispatcher, cbRecvMessage, fCallbackIndex, NativeInt(Self));
        fPSCallback_setRecvOutOfDialogMessageHandler(fCallbackDispatcher, cbRecvOutOfDialogMessage, fCallbackIndex, NativeInt(Self));
        fPSCallback_setSendMessageSuccessHandler(fCallbackDispatcher, cbSendMessageSuccess, fCallbackIndex, NativeInt(Self));
        fPSCallback_setSendMessageFailureHandler(fCallbackDispatcher, cbSendMessageFailure, fCallbackIndex, NativeInt(Self));
        fPSCallback_setSendOutOfDialogMessageSuccessHandler(fCallbackDispatcher, cbSendOutOfDialogMessageSuccess, fCallbackIndex, NativeInt(Self));
        fPSCallback_setSendOutOfDialogMessageFailureHandler(fCallbackDispatcher, cbSendOutOfDialogMessageFailure, fCallbackIndex, NativeInt(Self));

        result := true;

end;

procedure TPortSipObject.releaseCallbackHandlers;
begin
    if (assigned(fPSCallback_releaseCallbackDispatcher) and (fCallbackDispatcher<>0))then
      fPSCallback_releaseCallbackDispatcher(fCallbackDispatcher);
      fCallbackDispatcher := 0;
end;

destructor TPortSipObject.destroy;
begin
    if fSDKLibModule <> 0 then
    begin
      FreeLibrary(fSDKLibModule);
      fSDKLibModule := 0;
    end;
end;


end.
