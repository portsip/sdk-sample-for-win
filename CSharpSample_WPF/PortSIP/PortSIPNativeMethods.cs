﻿//////////////////////////////////////////////////////////////////////////
//
// IMPORTANT: DON'T EDIT THIS FILE
//
//////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace PortSIP
{
    unsafe class PortSIP_NativeMethods
    {

        // The callbacks of portsip_sdk.dll

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 registerSuccess(Int32 callbackIndex, Int32 callbackObject, String statusText, Int32 statusCode, StringBuilder sipMessage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 registerFailure(Int32 callbackIndex, Int32 callbackObject, String statusText, Int32 statusCode, StringBuilder sipMessage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 inviteIncoming(Int32 callbackIndex, 
                                             Int32 callbackObject,
                                             Int32 sessionId,
                                             String callerDisplayName,
                                             String caller,
                                             String calleeDisplayName,
                                             String callee,
                                             String audioCodecNames,
                                             String videoCodecNames,
                                             [MarshalAs(UnmanagedType.I1)] Boolean existsAudio,
                                             [MarshalAs(UnmanagedType.I1)] Boolean existsVideo,
                                             StringBuilder sipMessage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 inviteTrying(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 inviteSessionProgress(Int32 callbackIndex,
                                            Int32 callbackObject,
                                            Int32 sessionId,
                                             String audioCodecNames,
                                             String videoCodecNames,
                                             [MarshalAs(UnmanagedType.I1)] Boolean existsEarlyMedia,
                                             [MarshalAs(UnmanagedType.I1)] Boolean existsAudio,
                                             [MarshalAs(UnmanagedType.I1)] Boolean existsVideo,
                                             StringBuilder sipMessage);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 inviteRinging(Int32 callbackIndex, 
                                            Int32 callbackObject,
                                            Int32 sessionId,
                                            String statusText,
                                            Int32 statusCode,
                                            StringBuilder sipMessage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 inviteAnswered(Int32 callbackIndex,
                                             Int32 callbackObject,
                                             Int32 sessionId,
                                             String callerDisplayName,
                                             String caller,
                                             String calleeDisplayName,
                                             String callee,
                                             String audioCodecNames,
                                             String videoCodecNames,
                                             [MarshalAs(UnmanagedType.I1)] Boolean existsAudio,
                                             [MarshalAs(UnmanagedType.I1)] Boolean existsVideo,
                                             StringBuilder sipMessage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 inviteFailure(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, String reason, Int32 code, StringBuilder sipMessage);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 inviteUpdated(Int32 callbackIndex,
                                             Int32 callbackObject,
                                             Int32 sessionId,
                                             String audioCodecNames,
                                             String videoCodecNames,
                                             [MarshalAs(UnmanagedType.I1)] Boolean existsAudio,
                                             [MarshalAs(UnmanagedType.I1)] Boolean existsVideo,
                                             StringBuilder sipMessage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 inviteConnected(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 inviteBeginingForward(Int32 callbackIndex, Int32 callbackObject, String forwardTo);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 inviteClosed(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 remoteHold(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 remoteUnHold(Int32 callbackIndex, 
                                                Int32 callbackObject, 
                                                Int32 sessionId, 
                                                String audioCodecNames,
                                                String videoCodecNames,
                                                [MarshalAs(UnmanagedType.I1)] Boolean existsAudio,
                                                [MarshalAs(UnmanagedType.I1)] Boolean existsVideo);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 dialogStateUpdated(Int32 callbackIndex,
                                                Int32 callbackObject,
                                                String BLFMonitoredUri,
                                                String BLFDialogState,
                                                String BLFDialogId,
                                                String BLFDialogDirection);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 receivedRefer(Int32 callbackIndex, 
                                                    Int32 callbackObject, 
                                                    Int32 sessionId, 
                                                    Int32 referId,
                                                    String to, 
                                                    String from,
                                                    StringBuilder referSipMessage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 referAccepted(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 referRejected(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, String reason, Int32 code);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 transferTrying(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 transferRinging(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 ACTVTransferSuccess(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 ACTVTransferFailure(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId,  String reason, Int32 code);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 receivedSignaling(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, StringBuilder signaling);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 sendingSignaling(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, StringBuilder signaling);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 waitingVoiceMessage(Int32 callbackIndex, 
                                                    Int32 callbackObject,
                                                  String messageAccount,
                                                  Int32 urgentNewMessageCount,
                                                  Int32 urgentOldMessageCount,
                                                  Int32 newMessageCount,
                                                  Int32 oldMessageCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 waitingFaxMessage(Int32 callbackIndex,
                                                       Int32 callbackObject,
                                                  String messageAccount,
                                                  Int32 urgentNewMessageCount,
                                                  Int32 urgentOldMessageCount,
                                                  Int32 newMessageCount,
                                                  Int32 oldMessageCount);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 recvDtmfTone(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, Int32 tone);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 presenceRecvSubscribe(Int32 callbackIndex, 
                                                    Int32 callbackObject,
                                                    Int32 subscribeId,
                                                    String fromDisplayName,
                                                    String from,
                                                    String subject);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 presenceOnline(Int32 callbackIndex, 
                                                    Int32 callbackObject, 
                                                    String fromDisplayName, 
                                                    String from, 
                                                    String stateText);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 presenceOffline(Int32 callbackIndex, Int32 callbackObject, String fromDisplayName, String from);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 recvOptions(Int32 callbackIndex, Int32 callbackObject, StringBuilder optionsMessage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 recvInfo(Int32 callbackIndex, Int32 callbackObject, StringBuilder infoMessage);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 recvNotifyOfSubscription(Int32 callbackIndex, 
                                                              Int32 callbackObject,
                                                              Int32 subscribeId, 
                                                              StringBuilder notifyMessage,
                                                              [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] contentData,
                                                              Int32 dataLength);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 subscriptionFailure(Int32 callbackIndex,
                                                      Int32 callbackObject,
                                                      Int32 subscribeId,
                                                      Int32 statusCode);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 subscriptionTerminated(Int32 callbackIndex, Int32 callbackObject, Int32 subscribeId);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 recvMessage(Int32 callbackIndex, 
                                                 Int32 callbackObject,
                                                 Int32 sessionId,
                                                 String mimeType,
                                                 String subMimeType,
                                                 [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] messageData,
                                                 Int32 messageDataLength);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 recvOutOfDialogMessage(Int32 callbackIndex,
                                                 Int32 callbackObject,
                                                 String fromDisplayName,
                                                 String from,
                                                 String toDisplayName,
                                                 String to,
                                                 String mimeType,
                                                 String subMimeType,
                                                 [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 9)] byte[] messageData,
                                                 Int32 messageDataLength);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 sendMessageSuccess(Int32 callbackIndex, 
                                                        Int32 callbackObject,
                                                        Int32 sessionId,
                                                        Int32 messageId);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 sendMessageFailure(Int32 callbackIndex, 
                                                        Int32 callbackObject,
                                                        Int32 sessionId,
                                                        Int32 messageId,
                                                        String reason,
                                                        Int32 code);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 sendOutOfDialogMessageSuccess(Int32 callbackIndex,
                                                        Int32 callbackObject,
                                                        Int32 messageId,
                                                        String fromDisplayName,
                                                        String from,
                                                        String toDisplayName,
                                                        String to);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 sendOutOfDialogMessageFailure(Int32 callbackIndex,
                                                        Int32 callbackObject,
                                                        Int32 messageId,
                                                        String fromDisplayName,
                                                        String from,
                                                        String toDisplayName,
                                                        String to,
                                                        String reason,
                                                        Int32 code);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 playAudioFileFinished(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId, String fileName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 playVideoFileFinished(Int32 callbackIndex, Int32 callbackObject, Int32 sessionId);


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // The delegate methods for callback functions of portsip_sdk.dll
        // These callback functions allows you to access the raw audio and video data.

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 audioRawCallback(IntPtr callbackObject,
                                               Int32 sessionId,
                                               Int32 callbackType,
                                               [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] data,
                                               Int32 dataLength,
                                               Int32 samplingFreqHz);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 videoRawCallback(IntPtr callbackObject,
                                               Int32 sessionId,
                                               Int32 callbackType,
                                               Int32 width,
                                               Int32 height,
                                               [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] data,
                                               Int32 dataLength);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 receivedRTPCallback(IntPtr callbackObject,
                                               Int32 sessionId,
                                               [MarshalAs(UnmanagedType.I1)] Boolean isAudio,
                                               [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] RTPPacket,
                                               Int32 packetSize);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Int32 sendingRTPCallback(IntPtr callbackObject,
                                               Int32 sessionId,
                                               [MarshalAs(UnmanagedType.I1)] Boolean isAudio,
                                               [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] RTPPacket,
                                               Int32 packetSize);


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern IntPtr PSCallback_createCallbackDispatcher();

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_releaseCallbackDispatcher(IntPtr callbackDispatcher);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setRegisterSuccessHandler(IntPtr callbackDispatcher, 
                                                                        registerSuccess eventHandler, 
                                                                        Int32 callbackIndex, 
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setRegisterFailureHandler(IntPtr callbackDispatcher,
                                                                        registerFailure eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setInviteIncomingHandler(IntPtr callbackDispatcher,
                                                                        inviteIncoming eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setInviteTryingHandler(IntPtr callbackDispatcher,
                                                                        inviteTrying eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setInviteSessionProgressHandler(IntPtr callbackDispatcher,
                                                                        inviteSessionProgress eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setInviteRingingHandler(IntPtr callbackDispatcher,
                                                                        inviteRinging eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setInviteAnsweredHandler(IntPtr callbackDispatcher,
                                                                        inviteAnswered eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setInviteFailureHandler(IntPtr callbackDispatcher,
                                                                        inviteFailure eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setInviteUpdatedHandler(IntPtr callbackDispatcher,
                                                                        inviteUpdated eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setInviteConnectedHandler(IntPtr callbackDispatcher,
                                                                        inviteConnected eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setInviteBeginingForwardHandler(IntPtr callbackDispatcher,
                                                                        inviteBeginingForward eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setInviteClosedHandler(IntPtr callbackDispatcher,
                                                                        inviteClosed eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setDialogStateUpdatedHandler(IntPtr callbackDispatcher,
                                                                        dialogStateUpdated eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setRemoteHoldHandler(IntPtr callbackDispatcher,
                                                                        remoteHold eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setRemoteUnHoldHandler(IntPtr callbackDispatcher,
                                                                        remoteUnHold eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setReceivedReferHandler(IntPtr callbackDispatcher,
                                                                        receivedRefer eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setReferAcceptedHandler(IntPtr callbackDispatcher,
                                                                        referAccepted eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);



        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setReferRejectedHandler(IntPtr callbackDispatcher,
                                                                        referRejected eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setTransferTryingHandler(IntPtr callbackDispatcher,
                                                                        transferTrying eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setTransferRingingHandler(IntPtr callbackDispatcher,
                                                                        transferRinging eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setACTVTransferSuccessHandler(IntPtr callbackDispatcher,
                                                                        ACTVTransferSuccess eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setACTVTransferFailureHandler(IntPtr callbackDispatcher,
                                                                        ACTVTransferFailure eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setReceivedSignalingHandler(IntPtr callbackDispatcher,
                                                                        receivedSignaling eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setSendingSignalingHandler(IntPtr callbackDispatcher,
                                                                        sendingSignaling eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setWaitingVoiceMessageHandler(IntPtr callbackDispatcher,
                                                                        waitingVoiceMessage eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setWaitingFaxMessageHandler(IntPtr callbackDispatcher,
                                                                        waitingFaxMessage eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);



        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setRecvDtmfToneHandler(IntPtr callbackDispatcher,
                                                                        recvDtmfTone eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);




        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setPresenceRecvSubscribeHandler(IntPtr callbackDispatcher,
                                                                        presenceRecvSubscribe eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setPresenceOnlineHandler(IntPtr callbackDispatcher,
                                                                        presenceOnline eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setPresenceOfflineHandler(IntPtr callbackDispatcher,
                                                                        presenceOffline eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setRecvOptionsHandler(IntPtr callbackDispatcher,
                                                                        recvOptions eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setRecvInfoHandler(IntPtr callbackDispatcher,
                                                                        recvInfo eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);



        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setPlayAudioFileFinishedHandler(IntPtr callbackDispatcher,
                                                                        playAudioFileFinished eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setPlayVideoFileFinishedHandler(IntPtr callbackDispatcher,
                                                                        playVideoFileFinished eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setRecvMessageHandler(IntPtr callbackDispatcher,
                                                                        recvMessage eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);



        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setRecvOutOfDialogMessageHandler(IntPtr callbackDispatcher,
                                                                        recvOutOfDialogMessage eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);



        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setSendMessageSuccessHandler(IntPtr callbackDispatcher,
                                                                        sendMessageSuccess eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setSendMessageFailureHandler(IntPtr callbackDispatcher,
                                                                        sendMessageFailure eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setSendOutOfDialogMessageSuccessHandler(IntPtr callbackDispatcher,
                                                                        sendOutOfDialogMessageSuccess eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PSCallback_setSendOutOfDialogMessageFailureHandler(IntPtr callbackDispatcher,
                                                                        sendOutOfDialogMessageFailure eventHandler,
                                                                        Int32 callbackIndex,
                                                                        Int32 callbackObject);


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_delCallbackParameters(IntPtr parameters);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern IntPtr PortSIP_initialize(IntPtr callbackDispatcher,
                                                   TRANSPORT_TYPE transportType,
                                                   String localIp,
                                                   Int32 localSIPPort,
                                                   Int32 logLevel,
                                                   String logFilePath,
                                                   Int32 maxCallSessions,
                                                   String sipAgentString,
                                                   Int32 audioDeviceLayer,
                                                   Int32 videoDeviceLayer,
                                                   String TLSCertificatesRootPath,
                                                   String TLSCipherList,
                                                   Boolean verifyTLSCertificate,
                                                   out Int32 errorCode);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_unInitialize(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setLicenseKey(IntPtr libSDK, String key);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getNICNums();

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getLocalIpAddress(Int32 index, StringBuilder ip, Int32 ipSize);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setUser(IntPtr libSDK,
                                                   String userName,
                                                   String displayName,
                                                   String authName,
                                                   String password,
                                                   String sipDomain,
                                                   String sipServerAddr,
                                                   Int32 sipServerPort,
                                                   String stunServerAddr,
                                                   Int32 stunServerPort,
                                                   String outboundServerAddr,
                                                   Int32 outboundServerPort);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_removeUser(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int PortSIP_setInstanceId(IntPtr libSDK, String uuid);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int PortSIP_setDisplayName(IntPtr libSDK, String displayName);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_refreshRegistration(IntPtr libSDK, Int32 regExpires);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_registerServer(IntPtr libSDK, Int32 regExpires, Int32 retryTimes);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_unRegisterServer(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getVersion(IntPtr libSDK, out Int32 majorVersion, out Int32 minorVersion);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_enableRport(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean enable);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_enableEarlyMedia(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean enable);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_enableReliableProvisional(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean enable);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_enable3GppTags(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean enable);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_enableCallbackSignaling(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean enableSending, [MarshalAs(UnmanagedType.I1)] Boolean enableReceived);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setRtpCallback(IntPtr libSDK,
                                                                IntPtr callbackObj,
                                                                receivedRTPCallback receivedRTPCallbackHandler,
                                                                sendingRTPCallback sendingRTPCallbackHandler);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_addAudioCodec(IntPtr libSDK, Int32 codecType);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_addVideoCodec(IntPtr libSDK, Int32 codecType);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe extern Boolean PortSIP_isAudioCodecEmpty(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static unsafe extern Boolean PortSIP_isVideoCodecEmpty(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setAudioCodecPayloadType(IntPtr libSDK, Int32 codecType, Int32 payloadType);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setVideoCodecPayloadType(IntPtr libSDK, Int32 codecType, Int32 payloadType);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_clearAudioCodec(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_clearVideoCodec(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setAudioCodecParameter(IntPtr libSDK, Int32 codecType, String parameter);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setVideoCodecParameter(IntPtr libSDK, Int32 codecType, String parameter);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setSrtpPolicy(IntPtr libSDK, Int32 srtpPolicy, [MarshalAs(UnmanagedType.I1)] Boolean AllowSrtpOverUnsecureTransport);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setRtpPortRange(IntPtr libSDK,
                                                   Int32 minimumRtpAudioPort,
                                                   Int32 maximumRtpAudioPort,
                                                   Int32 minimumRtpVideoPort,
                                                   Int32 maximumRtpVideoPort);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setRtcpPortRange(IntPtr libSDK,
                                                   Int32 minimumRtcpAudioPort,
                                                   Int32 maximumRtcpAudioPort,
                                                   Int32 minimumRtcpVideoPort,
                                                   Int32 maximumRtcpVideoPort);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_enableCallForward(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean forBusyOnly, String forwardTo);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_disableCallForward(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_enableSessionTimer(IntPtr libSDK, Int32 timerSeconds, Int32 refreshMode);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_disableSessionTimer(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_setDoNotDisturb(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean state);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_enableAutoCheckMwi(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean state);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setRtpKeepAlive(IntPtr libSDK,
                                                                [MarshalAs(UnmanagedType.I1)] Boolean state,
                                                                Int32 keepAlivePayloadType,
                                                                Int32 deltaTransmitTimeMS);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setKeepAliveTime(IntPtr libSDK, Int32 keepAliveTime);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getSipMessageHeaderValue(IntPtr libSDK,
                                                                     String sipMessage,
                                                                     String headerName,
                                                                     StringBuilder headerValue,
                                                                     Int32 headerValueLength);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_addSipMessageHeader(IntPtr libSDK, Int32 sessionId, String methodName, Int32 msgType, String headerName, String headerValue);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_removeAddedSipMessageHeader(IntPtr libSDK, Int32 sipMessageHeaderId);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_modifySipMessageHeader(IntPtr libSDK, Int32 sessionId, String methodName, Int32 msgType, String headerName, String headerValue);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_removeModifiedSipMessageHeader(IntPtr libSDK, Int32 sipMessageHeaderId);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_clearAddedSipMessageHeaders(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_clearModifiedSipMessageHeaders(IntPtr libSDK);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_addSupportedMimeType(IntPtr libSDK,
                                                               String methodName,
                                                               String mimeType,
                                                               String subMimeType);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setAudioSamples(IntPtr libSDK, Int32 ptime, Int32 maxPtime);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setAudioDeviceId(IntPtr libSDK, Int32 recordingDeviceId, Int32 playoutDeviceId);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setVideoDeviceId(IntPtr libSDK, Int32 deviceId);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setVideoResolution(IntPtr libSDK, Int32 width, Int32 height);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setAudioBitrate(IntPtr libSDK, Int32 sessionId, Int32 audioCodecType, Int32 bitrateKbps);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setVideoBitrate(IntPtr libSDK, Int32 sessionId, Int32 bitrateKbps);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setVideoFrameRate(IntPtr libSDK, Int32 sessionId, Int32 frameRate);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_sendVideo(IntPtr libSDK, Int32 sessionId, [MarshalAs(UnmanagedType.I1)] Boolean sendState);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_muteMicrophone(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean mute);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_muteSpeaker(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean mute);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_setChannelOutputVolumeScaling(IntPtr libSDK, Int32 sessionId, Int32 scaling);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_setChannelInputVolumeScaling(IntPtr libSDK, Int32 sessionId, Int32 scaling);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_setLocalVideoWindow(IntPtr libSDK, IntPtr localVideoWindow);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setRemoteVideoWindow(IntPtr libSDK, Int32 sessionId, IntPtr remoteVideoWindow);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_displayLocalVideo(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean state, [MarshalAs(UnmanagedType.I1)] Boolean mirror);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setVideoNackStatus(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean state);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_call(IntPtr libSDK, String callTo, [MarshalAs(UnmanagedType.I1)] Boolean sendSdp, [MarshalAs(UnmanagedType.I1)] Boolean videoCall);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_rejectCall(IntPtr libSDK, Int32 sessionId, int code);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_hangUp(IntPtr libSDK, Int32 sessionId);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_answerCall(IntPtr libSDK, Int32 sessionId, [MarshalAs(UnmanagedType.I1)] Boolean videoCall);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_updateCall(IntPtr libSDK, Int32 sessionId, [MarshalAs(UnmanagedType.I1)] Boolean enableAudio, [MarshalAs(UnmanagedType.I1)] Boolean enableVideo);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_hold(IntPtr libSDK, Int32 sessionId);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_unHold(IntPtr libSDK, Int32 sessionId);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_refer(IntPtr libSDK, Int32 sessionId, String referTo);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_attendedRefer(IntPtr libSDK, Int32 sessionId, Int32 replaceSessionId, String referTo);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_attendedRefer2(IntPtr libSDK, 
                                                                Int32 sessionId,
                                                                Int32 replaceSessionId,
                                                                String replaceMethod,
                                                                String target,
                                                                String referTo);

      [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_outOfDialogRefer(IntPtr libSDK, Int32 replaceSessionId, String replaceMethod, String target, String referTo);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_acceptRefer(IntPtr libSDK, Int32 referId, String referSignaling);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_rejectRefer(IntPtr libSDK, Int32 referId);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_muteSession(IntPtr libSDK, 
                                                            Int32 sessionId,
                                                            [MarshalAs(UnmanagedType.I1)] Boolean muteIncomingAudio,
                                                            [MarshalAs(UnmanagedType.I1)] Boolean muteOutgoingAudio,
                                                            [MarshalAs(UnmanagedType.I1)] Boolean muteIncomingVideo,
                                                            [MarshalAs(UnmanagedType.I1)] Boolean muteOutgoingVideo);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_forwardCall(IntPtr libSDK, Int32 sessionId, String forwardTo);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_pickupBLFCall(IntPtr libSDK, String replaceDialogId, [MarshalAs(UnmanagedType.I1)] Boolean  videoCall);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_sendDtmf(IntPtr libSDK, 
                                                            Int32 sessionId, 
                                                            Int32 dtmfMethod,
                                                            Int32 code,
                                                            Int32 dtmfDuration,
                                                            [MarshalAs(UnmanagedType.I1)] Boolean playDtmfTone);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_enableSendPcmStreamToRemote(IntPtr libSDK,
                                                                           Int32 sessionId,
                                                                           [MarshalAs(UnmanagedType.I1)] Boolean state,
                                                                           Int32 streamSamplesPerSec);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_sendPcmStreamToRemote(IntPtr libSDK,
                                                                   Int32 sessionId,
                                                                   [MarshalAs(UnmanagedType.LPArray)] byte[] data,
                                                                   Int32 dataLength);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_enableSendVideoStreamToRemote(IntPtr libSDK,
                                                                           Int32 sessionId,
                                                                           [MarshalAs(UnmanagedType.I1)] Boolean state);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_sendVideoStreamToRemote(IntPtr libSDK,
                                                                   Int32 sessionId,
                                                                   [MarshalAs(UnmanagedType.LPArray)] byte[] data,
                                                                   Int32 dataLength,
                                                                   Int32 width,
                                                                   Int32 height);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_enableAudioStreamCallback(IntPtr libSDK,
                                                                           Int32 sessionId,
                                                                           [MarshalAs(UnmanagedType.I1)] Boolean enable,
                                                                           Int32 callbackMode,
                                                                           IntPtr callbackObject,
                                                                           audioRawCallback callbackHandler);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_enableVideoStreamCallback(IntPtr libSDK,
                                                                           Int32 sessionId,
                                                                           Int32 callbackMode,
                                                                           IntPtr callbackObject,
                                                                           videoRawCallback callbackHandler);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_startRecord(IntPtr libSDK,
                                                             Int32 sessionId,
                                                             String recordFilePath,
                                                             String recordFileName,
                                                             [MarshalAs(UnmanagedType.I1)] Boolean appendTimeStamp,
                                                             Int32 audioFileFormat,
                                                             Int32 audioRecordMode,
                                                             Int32 videoFileCodecType,
                                                             Int32 videoRecordMode);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_stopRecord(IntPtr libSDK, Int32 sessionId);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_playVideoFileToRemote(IntPtr libSDK,
                                                                Int32 sessionId,
                                                                String aviFile,
                                                                [MarshalAs(UnmanagedType.I1)] Boolean loop,
                                                                [MarshalAs(UnmanagedType.I1)] Boolean playAudio);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_stopPlayVideoFileToRemote(IntPtr libSDK, Int32 sessionId);



       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_playAudioFileToRemote(IntPtr libSDK,
                                                                 Int32 sessionId,
                                                                 String fileName,
                                                                 Int32 fileSamplesPerSec,
                                                                 [MarshalAs(UnmanagedType.I1)] Boolean loop);



       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_stopPlayAudioFileToRemote(IntPtr libSDK, Int32 sessionId);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_playAudioFileToRemoteAsBackground(IntPtr libSDK,
                                                                 Int32 sessionId,
                                                                 String fileName,
                                                                 Int32 fileSamplesPerSec);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_stopPlayAudioFileToRemoteAsBackground(IntPtr libSDK, Int32 sessionId);



       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_createAudioConference(IntPtr libSDK);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_createVideoConference(IntPtr libSDK,
                                                                   IntPtr conferenceVideoWindow,
                                                                   Int32 width,
                                                                   Int32 height,
                                                                   [MarshalAs(UnmanagedType.I1)] Boolean displayLocalVideoInConference);



       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern void PortSIP_destroyConference(IntPtr libSDK);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_joinToConference(IntPtr libSDK, Int32 sessionId);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_setConferenceVideoWindow(IntPtr libSDK, IntPtr videoWindow);

        
       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_removeFromConference(IntPtr libSDK, Int32 sessionId);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_setAudioRtcpBandwidth(IntPtr libSDK, 
                                                                      Int32 sessionId,
                                                                      Int32 BitsRR,
                                                                      Int32 BitsRS, 
                                                                      Int32 KBitsAS);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_setVideoRtcpBandwidth(IntPtr libSDK,
                                                                      Int32 sessionId,
                                                                      Int32 BitsRR,
                                                                      Int32 BitsRS,
                                                                      Int32 KBitsAS);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_getAudioStatistics(IntPtr libSDK,
                                                                        Int32 sessionId,
                                                                        out Int32 sendBytes,
                                                                        out Int32 sendPackets,
                                                                        out Int32 sendPacketsLost,
                                                                        out Int32 sendFractionLost,
                                                                        out Int32 sendRttMS,
                                                                        out Int32 sendCodecType,
                                                                        out Int32 sendJitterMS,
                                                                        out Int32 sendAudioLevel,
                                                                        out Int32 recvBytes,
                                                                        out Int32 recvPackets,
                                                                        out Int32 recvPacketsLost,
                                                                        out Int32 recvFractionLost,
                                                                        out Int32 recvCodecType,
                                                                        out Int32 recvJitterMS,
                                                                        out Int32 recvAudioLevel);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_getVideoStatistics(IntPtr libSDK,
                                                                        Int32 sessionId,
                                                                        out Int32 sendBytes,
                                                                        out Int32 sendPackets,
                                                                        out Int32 sendPacketsLost,
                                                                        out Int32 sendFractionLost,
                                                                        out Int32 sendRttMS,
                                                                        out Int32 sendCodecType,
                                                                        out Int32 sendFrameWidth,
                                                                        out Int32 sendFrameHeight,
                                                                        out Int32 sendBitrateBPS,
                                                                        out Int32 sendFramerate,
                                                                        out Int32 recvBytes,
                                                                        out Int32 recvPackets,
                                                                        out Int32 recvPacketsLost,
                                                                        out Int32 recvFractionLost,
                                                                        out Int32 recvCodecType,
                                                                        out Int32 recvFrameWidth,
                                                                        out Int32 recvFrameHeight,
                                                                        out Int32 recvBitrateBPS,
                                                                        out Int32 recvFramerate);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern void PortSIP_enableAEC(IntPtr libSDK, Int32 ecMode);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern void PortSIP_enableVAD(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean state);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern void PortSIP_enableCNG(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean state);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern void PortSIP_enableAGC(IntPtr libSDK, Int32 agcMode);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern void PortSIP_enableANS(IntPtr libSDK, Int32 nsMode);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_enableAudioQos(IntPtr libSDK,
                                                              [MarshalAs(UnmanagedType.I1)] Boolean state);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_enableVideoQos(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean state);


       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_setVideoMTU(IntPtr libSDK, Int32 mtu);

       [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
       public static unsafe extern Int32 PortSIP_sendOptions(IntPtr libSDK, String to, String sdp);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_sendInfo(IntPtr libSDK,
                                                      Int32 sessionId,
                                                      String mimeType,
                                                      String subMimeType,
                                                      String infoContents);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_sendSubscription(IntPtr libSDK,
                                                      String to,
                                                      String eventName);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_terminateSubscription(IntPtr libSDK, Int32 subscritionId);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_sendMessage(IntPtr libSDK, Int32 sessionId, String mimeType, String subMimeType, [MarshalAs(UnmanagedType.LPArray)] byte[] message, Int32 messageLength);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_sendOutOfDialogMessage(IntPtr libSDK, String to, String mimeType, String subMimeType, [MarshalAs(UnmanagedType.I1)] Boolean isSMS, [MarshalAs(UnmanagedType.LPArray)] byte[] message, Int32 messageLength);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setDefaultSubscriptionTime(IntPtr libSDK, Int32 secs);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setDefaultPublicationTime(IntPtr libSDK, Int32 secs);



        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setPresenceMode(IntPtr libSDK, Int32 mode);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_presenceSubscribe(IntPtr libSDK, String to, String subject);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_presenceTerminateSubscribe(IntPtr libSDK, Int32 subscribeId);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_presenceRejectSubscribe(IntPtr libSDK, Int32 subscribeId);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_presenceAcceptSubscribe(IntPtr libSDK, Int32 subscribeId);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setPresenceStatus(IntPtr libSDK, Int32 subscribeId, String stateText);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getNumOfRecordingDevices(IntPtr libSDK);

        
        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getNumOfPlayoutDevices(IntPtr libSDK);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getRecordingDeviceName(IntPtr libSDK, 
                                                             Int32 deviceIndex,
                                                             StringBuilder nameUTF8,
                                                             Int32 nameUTF8Length);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getPlayoutDeviceName(IntPtr libSDK,
                                                            Int32 deviceIndex,
                                                            StringBuilder nameUTF8,
                                                            Int32 nameUTF8Length);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setSpeakerVolume(IntPtr libSDK, Int32 volume);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getSpeakerVolume(IntPtr libSDK);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_setMicVolume(IntPtr libSDK, Int32 volume);

        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getMicVolume(IntPtr libSDK);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void PortSIP_audioPlayLoopbackTest(IntPtr libSDK, [MarshalAs(UnmanagedType.I1)] Boolean enable);


        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getNumOfVideoCaptureDevices(IntPtr libSDK);



        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_getVideoCaptureDeviceName(IntPtr libSDK,
                                                                           Int32 deviceIndex,
                                                                           StringBuilder uniqueIdUTF8,
                                                                           Int32 uniqueIdUTF8Length,
                                                                           StringBuilder deviceNameUTF8,
                                                                           Int32 deviceNameUTF8Length);
        [DllImport("portsip_sdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern Int32 PortSIP_showVideoCaptureSettingsDialogBox(IntPtr libSDK,
                                                                    String uniqueIdUTF8,
                                                                    Int32 uniqueIdUTF8Length,
                                                                    String dialogTitle,
                                                                    IntPtr parentWindow,
                                                                    Int32 x,
                                                                    Int32 y);

    }
}
