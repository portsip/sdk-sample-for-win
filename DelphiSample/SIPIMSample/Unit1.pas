unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, StrUtils, IniFiles, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ComCtrls, Vcl.ExtCtrls, PortSipConsts, PortSIPLib;

const
  WM_PORTSIP = WM_APP + 100;
  WM_REGISTER_SUCCESS = WM_PORTSIP + 1;
  WM_REGISTER_FAILURE = WM_PORTSIP + 2;
  WM_INVITE_INCOMING = WM_PORTSIP + 3;
  WM_INVITE_TRYING = WM_PORTSIP + 4;
  WM_INVITE_SESSION_PROGRESS = WM_PORTSIP + 5;
  WM_INVITE_RINGING = WM_PORTSIP + 6;
  WM_INVITE_ANSWERED = WM_PORTSIP + 7;
  WM_INVITE_FAILURE = WM_PORTSIP + 8;
  WM_INVITE_UPDATED = WM_PORTSIP + 9;
  WM_INVITE_CONNECTED = WM_PORTSIP + 10;
  WM_INVITE_BEGINING_FORWARD = WM_PORTSIP + 11;
  WM_INVITE_CLOSED = WM_PORTSIP + 12;
  WM_REMOTE_HOLD = WM_PORTSIP + 13;
  WM_REMOTE_UNHOLD = WM_PORTSIP + 14;
  WM_RECEIVED_REFER = WM_PORTSIP + 15;
  WM_REFER_ACCEPTED = WM_PORTSIP + 16;
  WM_REFER_REJECTED = WM_PORTSIP + 17;
  WM_TRANSFER_TRYING = WM_PORTSIP + 18;
  WM_TRANSFER_RINGING = WM_PORTSIP + 19;
  WM_ACTV_TRANSFER_SUCCESS = WM_PORTSIP + 20;
  WM_ACTV_TRANSFER_FAILURE = WM_PORTSIP + 21;
  WM_RECEIVED_SIGNALING = WM_PORTSIP + 22;
  WM_SENDING_SIGNALING = WM_PORTSIP + 23;
  WM_WAITING_VOICEMESSAGE = WM_PORTSIP + 24;
  WM_WAITING_FAXMESSAGE = WM_PORTSIP + 25;
  WM_RECV_DTMFTONE = WM_PORTSIP + 26;
  WM_RECV_MESSAGE = WM_PORTSIP + 27;
  WM_RECV_OUTOFDIALOG_MESSAGE = WM_PORTSIP + 28;
  WM_SEND_MESSAGE_SUCCESS = WM_PORTSIP + 29;
  WM_SEND_MESSAGE_FAILURE = WM_PORTSIP + 30;
  WM_SEND_OUTOFDIALOG_MESSAGE_SUCCESS = WM_PORTSIP + 31;
  WM_SEND_OUTOFDIALOG_MESSAGE_FAILURE = WM_PORTSIP + 32;
  WM_PRESENCE_RECV_SUBSCRIBE = WM_PORTSIP + 33;
  WM_PRESENCE_ONLINE = WM_PORTSIP + 34;
  WM_PRESENCE_OFFLINE = WM_PORTSIP + 35;
  WM_RECV_OPTIONS = WM_PORTSIP + 36;
  WM_RECV_INFO = WM_PORTSIP + 37;
  WM_PLAY_AUDIO_FILE_FINISHED = WM_PORTSIP + 38;
  WM_PLAY_VIDEO_FILE_FINISHED = WM_PORTSIP + 39;
  WM_RAW_AUDIOCALLBACK = WM_PORTSIP + 40;
  WM_RAW_VIDEOCALLBACK = WM_PORTSIP + 41;
  WM_RECEIVED_RTP_PACKETS = WM_PORTSIP + 42;
  WM_SENDING_RTP_PACKETS = WM_PORTSIP + 43;
  WM_DECODER_VIDEOCALLBACK = WM_PORTSIP + 44;
  WM_DIALOG_STATE_UPDATED = WM_PORTSIP + 45;

type
  TForm1 = class(TForm)
    Label15: TLabel;
    Label17: TLabel;
    GroupBox1: TGroupBox;
    Label16: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Label9: TLabel;
    Label6: TLabel;
    Label5: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label8: TLabel;
    Label7: TLabel;
    Label2: TLabel;
    Label1: TLabel;
    Panel4: TPanel;
    ListBoxLog: TListBox;
    ContactsList: TListView;
    AddContactName: TEdit;
    Button3: TButton;
    Panel2: TPanel;
    StatusText: TEdit;
    Button4: TButton;
    Panel3: TPanel;
    SendMessage: TMemo;
    SendTo: TEdit;
    Button5: TButton;
    Button6: TButton;
    EditStunServer: TEdit;
    EditStunServerPort: TEdit;
    EditSIPServerPort: TEdit;
    EditSIPServer: TEdit;
    EditUserDomain: TEdit;
    EditDisplayName: TEdit;
    EditAuthName: TEdit;
    EditPassword: TEdit;
    EditUserName: TEdit;
    Button1: TButton;
    Button2: TButton;
    Panel5: TPanel;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    procedure FormCreate(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private declarations }

    sdkLib: TPortSipObject;
    Initialized: Boolean;
    Registered: Boolean;

    procedure LoadContacts;
    procedure Offline;
    function getLocalIp(): string;
    procedure releaseSDK;


    procedure RegisterSuccess(callbackIndex: NativeInt; reason: PAnsiChar;
      code: integer);
    procedure RegisterFailure(callbackIndex: NativeInt; reason: PAnsiChar;
      code: integer);
    procedure InviteIncoming(callbackIndex: NativeInt; sessionId: NativeInt;
      callerDisplayName: PAnsiChar; caller: PAnsiChar;
      calleeDisplayName: PAnsiChar; callee: PAnsiChar; audioCodecs: PAnsiChar;
      videoCodecs: PAnsiChar; existsAudio: Boolean; existsVideo: Boolean; message:PAnsiChar);
    procedure InviteTrying(callbackIndex: NativeInt; sessionId: NativeInt);
    procedure InviteSessionProgress(callbackIndex: NativeInt;
      sessionId: NativeInt; audioCodecs: PAnsiChar; videoCodecs: PAnsiChar;
      existsEarlyMedia: Boolean; existsAudio: Boolean; existsVideo: Boolean; message:PAnsiChar);
    procedure InviteRinging(callbackIndex: NativeInt; sessionId: NativeInt;
      statusText: PAnsiChar; statusCode: integer; message:PAnsiChar);
    procedure InviteAnswered(callbackIndex: NativeInt; sessionId: NativeInt;
      callerDisplayName: PAnsiChar; caller: PAnsiChar;
      calleeDisplayName: PAnsiChar; callee: PAnsiChar; audioCodecs: PAnsiChar;
      videoCodecs: PAnsiChar; existsAudio: Boolean; existsVideo: Boolean; message:PAnsiChar);
    procedure InviteFailure(callbackIndex: NativeInt; sessionId: NativeInt;
      reason: PAnsiChar; code: integer);
    procedure InviteUpdated(callbackIndex: NativeInt; sessionId: NativeInt;
      audioCodecs: PAnsiChar; videoCodecs: PAnsiChar; existsAudio: Boolean;
      existsVideo: Boolean; message:PAnsiChar);
    procedure InviteConnected(callbackIndex: NativeInt; sessionId: NativeInt);
    procedure InviteBeginingForward(callbackIndex: NativeInt;
      forwardTo: PAnsiChar);
    procedure InviteClosed(callbackIndex: NativeInt; sessionId: NativeInt);
	procedure DialogStateUpdated(callbackIndex: NativeInt; BLFMonitoredUri, BLFDialogState, BLFDialogId, BLFDialogDirection: PAnsiChar);
    procedure RemoteHold(callbackIndex: NativeInt; sessionId: NativeInt);
    procedure RemoteUnHold(callbackIndex: NativeInt; sessionId: NativeInt;
      audioCodecs: PAnsiChar; videoCodecs: PAnsiChar; existsAudio: Boolean;
      existsVideo: Boolean);
    procedure ReceivedRefer(callbackIndex: NativeInt; sessionId: NativeInt;
      referId: NativeInt; referTo: PAnsiChar; from: PAnsiChar;
      referSipMessage: PAnsiChar);
    procedure ReferAccepted(callbackIndex: NativeInt; sessionId: NativeInt);
    procedure ReferRejected(callbackIndex: NativeInt; sessionId: NativeInt);
    procedure TransferTrying(callbackIndex: NativeInt; sessionId: NativeInt);
    procedure TransferRinging(callbackIndex: NativeInt; sessionId: NativeInt);
    procedure ACTVTransferSuccess(callbackIndex: NativeInt;
      sessionId: NativeInt);
    procedure ACTVTransferFailure(callbackIndex: NativeInt;
      sessionId: NativeInt; reason: PAnsiChar; code: integer);
    procedure ReceivedSignaling(callbackIndex: NativeInt; sessionId: NativeInt;
      sipSignaling: PAnsiChar);
    procedure SendingSignaling(callbackIndex: NativeInt; sessionId: NativeInt;
      sipSignaling: PAnsiChar);
    procedure WaitingVoiceMessage(callbackIndex: NativeInt;
      messageAccount: PAnsiChar; urgentNewMessageCount, urgentOldMessageCount,
      newMessageCount, oldMessageCount: integer);
    procedure WaitingFaxMessage(callbackIndex: NativeInt;
      messageAccount: PAnsiChar; urgentNewMessageCount, urgentOldMessageCount,
      newMessageCount, oldMessageCount: integer);
    procedure RecvDtmfTone(callbackIndex: NativeInt; sessionId: NativeInt;
      tone: integer);
    procedure PresenceRecvSubscribe(callbackIndex: NativeInt;
      subscribeId: NativeInt; fromDisplayName: PAnsiChar; from: PAnsiChar;
      subject: PAnsiChar);
    procedure PresenceOnline(callbackIndex: NativeInt;
      fromDisplayName: PAnsiChar; from: PAnsiChar; stateText: PAnsiChar);
    procedure PresenceOffline(callbackIndex: NativeInt;
      fromDisplayName: PAnsiChar; from: PAnsiChar);
    procedure RecvOptions(callbackIndex: NativeInt; optionsMessage: PAnsiChar);
    procedure RecvInfo(callbackIndex: NativeInt; infoMessage: PAnsiChar);
    procedure PlayAudioFileFinished(callbackIndex: NativeInt;
      sessionId: NativeInt; fileName: PAnsiChar);
    procedure PlayVideoFileFinished(callbackIndex: NativeInt;
      sessionId: NativeInt);
    procedure RecvMessage(callbackIndex: NativeInt; sessionId: NativeInt;
      mimeType: PAnsiChar; subMimeType: PAnsiChar; messageData: PByte;
      messageDataLength: integer);
    procedure RecvOutOfDialogMessage(callbackIndex: NativeInt;
      fromDisplayName: PAnsiChar; from: PAnsiChar; toDisplayName: PAnsiChar;
      sendTo: PAnsiChar; mimeType: PAnsiChar; subMimeType: PAnsiChar;
      messageData: PByte; messageDataLength: integer);
    procedure SendMessageSuccess(callbackIndex: NativeInt; sessionId, messageId: NativeInt);
    procedure SendMessageFailure(callbackIndex: NativeInt; sessionId, messageId: NativeInt;
    reason: PAnsiChar; code: integer);
    procedure SendOutOfDialogMessageSuccess(callbackIndex, messageId: NativeInt;
      fromDisplayName: PAnsiChar; from: PAnsiChar; toDisplayName: PAnsiChar;
      sendTo: PAnsiChar);
    procedure SendOutOfDialogMessageFailure(callbackIndex, messageId: NativeInt;
      fromDisplayName: PAnsiChar; from: PAnsiChar; toDisplayName: PAnsiChar;
      sendTo: PAnsiChar; reason: PAnsiChar; code: integer);



    ///
    ///
    procedure onRegisterSuccess(var Message: TMessage);
      message WM_REGISTER_SUCCESS;
    procedure onRegisterFailure(var Message: TMessage);
      message WM_REGISTER_FAILURE;
    procedure onInviteIncoming(var Message: TMessage);
      message WM_INVITE_INCOMING;
    procedure onInviteTrying(var Message: TMessage); message WM_INVITE_TRYING;
    procedure onInviteSessionProgress(var Message: TMessage);
      message WM_INVITE_SESSION_PROGRESS;
    procedure onInviteRinging(var Message: TMessage); message WM_INVITE_RINGING;
    procedure onInviteAnswered(var Message: TMessage);
      message WM_INVITE_ANSWERED;
    procedure onInviteFailure(var Message: TMessage); message WM_INVITE_FAILURE;
    procedure onInviteUpdated(var Message: TMessage); message WM_INVITE_UPDATED;
    procedure onInviteConnected(var Message: TMessage);
      message WM_INVITE_CONNECTED;
    procedure onInviteBeginingForward(var Message: TMessage);
      message WM_INVITE_BEGINING_FORWARD;
    procedure onInviteClosed(var Message: TMessage); message WM_INVITE_CLOSED;
	procedure onDialogStateUpdated(var Message: TMessage); message WM_DIALOG_STATE_UPDATED;
    procedure onRemoteHold(var Message: TMessage); message WM_REMOTE_HOLD;
    procedure onRemoteUnHold(var Message: TMessage); message WM_REMOTE_UNHOLD;
    procedure onReceivedRefer(var Message: TMessage); message WM_RECEIVED_REFER;
    procedure onReferAccepted(var Message: TMessage); message WM_REFER_ACCEPTED;
    procedure onReferRejected(var Message: TMessage); message WM_REFER_REJECTED;
    procedure onTransferTrying(var Message: TMessage);
      message WM_TRANSFER_TRYING;
    procedure onTransferRinging(var Message: TMessage);
      message WM_TRANSFER_RINGING;
    procedure onACTVTransferSuccess(var Message: TMessage);
      message WM_ACTV_TRANSFER_SUCCESS;
    procedure onACTVTransferFailure(var Message: TMessage);
      message WM_ACTV_TRANSFER_FAILURE;
    procedure onReceivedSignaling(var Message: TMessage);
      message WM_RECEIVED_SIGNALING;
    procedure onSendingSignaling(var Message: TMessage);
      message WM_SENDING_SIGNALING;
    procedure onWaitingVoiceMessage(var Message: TMessage);
      message WM_WAITING_VOICEMESSAGE;
    procedure onWaitingFaxMessage(var Message: TMessage);
      message WM_WAITING_FAXMESSAGE;
    procedure onRecvDtmfTone(var Message: TMessage); message WM_RECV_DTMFTONE;
    procedure onPresenceRecvSubscribe(var Message: TMessage);
      message WM_PRESENCE_RECV_SUBSCRIBE;
    procedure onPresenceOnline(var Message: TMessage);
      message WM_PRESENCE_ONLINE;
    procedure onPresenceOffline(var Message: TMessage);
      message WM_PRESENCE_OFFLINE;
    procedure onRecvOptions(var Message: TMessage); message WM_RECV_OPTIONS;
    procedure onRecvInfo(var Message: TMessage); message WM_RECV_INFO;
    procedure onPlayAudioFileFinished(var Message: TMessage);
      message WM_PLAY_AUDIO_FILE_FINISHED;
    procedure onPlayVideoFileFinished(var Message: TMessage);
      message WM_PLAY_VIDEO_FILE_FINISHED;
    procedure onRecvMessage(var Message: TMessage); message WM_RECV_MESSAGE;
    procedure onRecvOutOfDialogMessage(var Message: TMessage);
      message WM_RECV_OUTOFDIALOG_MESSAGE;
    procedure onSendMessageSuccess(var Message: TMessage);
      message WM_SEND_MESSAGE_SUCCESS;
    procedure onSendMessageFailure(var Message: TMessage);
      message WM_SEND_MESSAGE_FAILURE;
    procedure onSendOutOfDialogMessageSuccess(var Message: TMessage);
      message WM_SEND_OUTOFDIALOG_MESSAGE_SUCCESS;
    procedure onSendOutOfDialogMessageFailure(var Message: TMessage);
      message WM_SEND_OUTOFDIALOG_MESSAGE_FAILURE;

   procedure onAudioRawCallback(var Message: TMessage); message WM_RAW_AUDIOCALLBACK;
   procedure onVideoRawCallback(var Message: TMessage); message WM_RAW_VIDEOCALLBACK;

   procedure onReceivdRtpPackets(var Message: TMessage); message WM_RECEIVED_RTP_PACKETS;
   procedure onSendingRtpPackets(var Message: TMessage); message WM_SENDING_RTP_PACKETS;


  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}


/// ////////////////////////////////////////////////////////////////////////////
/// ////////////////////////////////////////////////////////////////////////////



function AudioRawCallback(obj: Pointer; sessionId, _type: integer; data:Pointer; dataLength, samplingFreqHz:integer):integer; cdecl;
var
  params: TONAudioRawCallbackParams;
begin
  params := TONAudioRawCallbackParams.Create;
  params.sessionId := sessionId;
  params.callbackType := _type;
  params.samplingFreqHz :=  samplingFreqHz;

  params.data := AllocMem(dataLength);
  CopyMemory(params.data, data, dataLength);
  params.dataLength := dataLength;

  PostMessage(Form1.Handle, WM_RAW_AUDIOCALLBACK, 0, LPARAM(params));  // NativeUInt is for the new x64-compilers. All compilers before use integer
  result := 0;

end;


function VideoRawCallback(obj: Pointer; sessionId, _type: integer; width, height:integer; data:Pointer; dataLength:integer):integer; cdecl;
var
  params: TONVideoRawCallbackParams;
begin
  params := TONVideoRawCallbackParams.Create;
  params.sessionId := sessionId;
  params.callbackType := _type;
  params.width :=  width;
  params.height := height;

  params.data := AllocMem(dataLength);
  CopyMemory(params.data, data, dataLength);
  params.dataLength := dataLength;

  PostMessage(Form1.Handle, WM_RAW_AUDIOCALLBACK, 0, LPARAM(params));  // NativeUInt is for the new x64-compilers. All compilers before use integer
  result := 0;

end;



function ReceivedRTPPacketCallback(obj:Pointer;
                                sessionId: NativeInt;
                                isAudio:boolean;
                                RTPPacket:PByte;
                                packetSize:integer):integer; cdecl;
var
  params: TONReceivedRTPPacketParams;
begin
  params := TONReceivedRTPPacketParams.Create;
  params.obj := obj;
  params.sessionId := sessionId;
  params.isAudio := isAudio;
  params.RTPPacket := AllocMem(packetSize);
  CopyMemory(params.RTPPacket, RTPPacket, packetSize);
  params.packetSize := packetSize;

  PostMessage(Form1.Handle, WM_RECEIVED_RTP_PACKETS, 0, LPARAM(params));  // NativeUInt is for the new x64-compilers. All compilers before use integer
  result := 0;

end;

function SendingRTPPacketCallback(obj:Pointer; sessionId:
                                NativeInt;
                                isAudio:boolean;
                                 RTPPacket:PByte;
                                 packetSize:integer):integer; cdecl;
var
  params: TONSendingRTPPacketParams;
begin
  params := TONSendingRTPPacketParams.Create;
  params.obj := obj;
  params.sessionId := sessionId;
  params.isAudio := isAudio;
  params.RTPPacket := AllocMem(packetSize);
  CopyMemory(params.RTPPacket, RTPPacket, packetSize);
  params.packetSize := packetSize;

  PostMessage(Form1.Handle, WM_SENDING_RTP_PACKETS, 0, LPARAM(params));  // NativeUInt is for the new x64-compilers. All compilers before use integer
  result := 0;

end;



// Callbacks
procedure TForm1.RegisterSuccess(callbackIndex: NativeInt; reason: PAnsiChar;
  code: integer);
var
  params: TONRegisterSuccessParams;
begin

  params := TONRegisterSuccessParams.Create;
  params.callbackIndex := callbackIndex;
  params.reason := reason;
  params.code := code;
  PostMessage(Handle, WM_REGISTER_SUCCESS, 0, LPARAM(params));

end;

procedure TForm1.RegisterFailure(callbackIndex: NativeInt; reason: PAnsiChar;
  code: integer);
var
  params: TONRegisterSuccessParams;
begin

  params := TONRegisterSuccessParams.Create;
  params.reason := reason;
  params.code := code;
  params.callbackIndex := callbackIndex;
  PostMessage(Handle, WM_REGISTER_FAILURE, 0, LPARAM(params));

end;

procedure TForm1.InviteIncoming(callbackIndex: NativeInt; sessionId: NativeInt;
  callerDisplayName: PAnsiChar; caller: PAnsiChar; calleeDisplayName: PAnsiChar;
  callee: PAnsiChar; audioCodecs: PAnsiChar; videoCodecs: PAnsiChar;
  existsAudio: Boolean; existsVideo: Boolean; message: PAnsiChar);
var
  params: TONInviteIncomingParams;
begin

  params := TONInviteIncomingParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.callerDisplayName := callerDisplayName;
  params.caller := caller;
  params.calleeDisplayName := calleeDisplayName;
  params.callee := callee;
  params.audioCodecs := audioCodecs;
  params.videoCodecs := videoCodecs;
  params.existsAudio := existsAudio;
  params.existsVideo := existsVideo;
  params.message := message;
  PostMessage(Handle, WM_INVITE_INCOMING, 0, LPARAM(params));

end;

procedure TForm1.InviteTrying(callbackIndex: NativeInt; sessionId: NativeInt);
var
  params: TONInviteTryingParams;
begin

  params := TONInviteTryingParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  PostMessage(Handle, WM_INVITE_TRYING, 0, LPARAM(params));

end;

procedure TForm1.InviteSessionProgress(callbackIndex: NativeInt;
  sessionId: NativeInt; audioCodecs: PAnsiChar; videoCodecs: PAnsiChar;
  existsEarlyMedia: Boolean; existsAudio: Boolean; existsVideo: Boolean; message: PAnsiChar);
var
  params: TONInviteSessionProgressParams;
begin

  params := TONInviteSessionProgressParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.audioCodecs := audioCodecs;
  params.videoCodecs := videoCodecs;
  params.existsEarlyMedia := existsEarlyMedia;
  params.existsAudio := existsAudio;
  params.existsVideo := existsVideo;
  params.message := message;
  PostMessage(Handle, WM_INVITE_SESSION_PROGRESS, 0, LPARAM(params));

end;

procedure TForm1.InviteRinging(callbackIndex: NativeInt; sessionId: NativeInt;
  statusText: PAnsiChar; statusCode: integer; message: PAnsiChar);
var
  params: TONInviteRingingParams;
begin

  params := TONInviteRingingParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.statusText := statusText;
  params.statusCode := statusCode;
  params.message := message;
  PostMessage(Handle, WM_INVITE_RINGING, 0, LPARAM(params));

end;

procedure TForm1.InviteAnswered(callbackIndex: NativeInt; sessionId: NativeInt;
  callerDisplayName: PAnsiChar; caller: PAnsiChar; calleeDisplayName: PAnsiChar;
  callee: PAnsiChar; audioCodecs: PAnsiChar; videoCodecs: PAnsiChar;
  existsAudio: Boolean; existsVideo: Boolean; message: PAnsiChar);
var
  params: TONInviteAnsweredParams;
begin

  params := TONInviteAnsweredParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.callerDisplayName := callerDisplayName;
  params.caller := caller;
  params.calleeDisplayName := calleeDisplayName;
  params.callee := callee;
  params.audioCodecs := audioCodecs;
  params.videoCodecs := videoCodecs;
  params.message := message;
  PostMessage(Handle, WM_INVITE_ANSWERED, 0, LPARAM(params));

end;

procedure TForm1.InviteFailure(callbackIndex: NativeInt; sessionId: NativeInt;
  reason: PAnsiChar; code: integer);
var
  params: TONInviteFailureParams;
begin

  params := TONInviteFailureParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.reason := reason;
  params.code := code;
  PostMessage(Handle, WM_INVITE_FAILURE, 0, LPARAM(params));

end;

procedure TForm1.InviteUpdated(callbackIndex: NativeInt; sessionId: NativeInt;
  audioCodecs: PAnsiChar; videoCodecs: PAnsiChar; existsAudio: Boolean;
  existsVideo: Boolean; message: PAnsiChar);
var
  params: TONInviteUpdatedParams;
begin

  params := TONInviteUpdatedParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.audioCodecs := audioCodecs;
  params.videoCodecs := videoCodecs;
  params.existsAudio := existsAudio;
  params.existsVideo := existsVideo;
  params.message := message;
  PostMessage(Handle, WM_INVITE_UPDATED, 0, LPARAM(params));

end;

procedure TForm1.InviteConnected(callbackIndex: NativeInt;
  sessionId: NativeInt);
var
  params: TONInviteConnectedParams;
begin

  params := TONInviteConnectedParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  PostMessage(Handle, WM_INVITE_CONNECTED, 0, LPARAM(params));

end;

procedure TForm1.InviteBeginingForward(callbackIndex: NativeInt;
  forwardTo: PAnsiChar);
var
  params: TONInviteBeginingForwardParams;
begin

  params := TONInviteBeginingForwardParams.Create;
  params.callbackIndex := callbackIndex;
  params.forwardTo := forwardTo;
  PostMessage(Handle, WM_INVITE_BEGINING_FORWARD, 0, LPARAM(params));

end;

procedure TForm1.InviteClosed(callbackIndex: NativeInt; sessionId: NativeInt);
var
  params: TONInviteClosedParams;
begin

  params := TONInviteClosedParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  PostMessage(Handle, WM_INVITE_CLOSED, 0, LPARAM(params));

end;

procedure TForm1.DialogStateUpdated(callbackIndex: NativeInt; BLFMonitoredUri, BLFDialogState, BLFDialogId, BLFDialogDirection: PAnsiChar);
var
  params: TONDialogStateUpdatedParams;
begin

  params := TONDialogStateUpdatedParams.Create;
  params.callbackIndex := callbackIndex;
  params.BLFMonitoredUri := BLFMonitoredUri;
  params.BLFDialogState := BLFDialogState;
  params.BLFDialogId := BLFDialogId;
  params.BLFDialogDirection := BLFDialogDirection;
  PostMessage(Handle, WM_DIALOG_STATE_UPDATED, 0, LPARAM(params));

end;

procedure TForm1.RemoteHold(callbackIndex: NativeInt; sessionId: NativeInt);
var
  params: TONRemoteHoldParams;
begin

  params := TONRemoteHoldParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  PostMessage(Handle, WM_REMOTE_HOLD, 0, LPARAM(params));

end;

procedure TForm1.RemoteUnHold(callbackIndex: NativeInt; sessionId: NativeInt;
  audioCodecs: PAnsiChar; videoCodecs: PAnsiChar; existsAudio: Boolean;
  existsVideo: Boolean);
var
  params: TONRemoteUnHoldParams;
begin

  params := TONRemoteUnHoldParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.audioCodecs := audioCodecs;
  params.videoCodecs := videoCodecs;
  params.existsAudio := existsAudio;
  params.existsVideo := existsVideo;
  PostMessage(Handle, WM_REMOTE_UNHOLD, 0, LPARAM(params));

end;

procedure TForm1.ReceivedRefer(callbackIndex: NativeInt; sessionId: NativeInt;
  referId: NativeInt; referTo: PAnsiChar; from: PAnsiChar;
  referSipMessage: PAnsiChar);
var
  params: TONReceivedReferParams;
begin

  params := TONReceivedReferParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.referId := referId;
  params.referTo := referTo;
  params.from := from;
  params.referSipMessage := referSipMessage;
  PostMessage(Handle, WM_RECEIVED_REFER, 0, LPARAM(params));

end;

procedure TForm1.ReferAccepted(callbackIndex: NativeInt; sessionId: NativeInt);
var
  params: TONReferAcceptedParams;
begin

  params := TONReferAcceptedParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  PostMessage(Handle, WM_REFER_ACCEPTED, 0, LPARAM(params));

end;

procedure TForm1.ReferRejected(callbackIndex: NativeInt; sessionId: NativeInt);
var
  params: TONReferRejectedParams;
begin

  params := TONReferRejectedParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  PostMessage(Handle, WM_REFER_REJECTED, 0, LPARAM(params));

end;

procedure TForm1.TransferTrying(callbackIndex: NativeInt; sessionId: NativeInt);
var
  params: TONTransferTryingParams;
begin

  params := TONTransferTryingParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  PostMessage(Handle, WM_TRANSFER_TRYING, 0, LPARAM(params));

end;



procedure TForm1.TransferRinging(callbackIndex: NativeInt;
  sessionId: NativeInt);
var
  params: TONTransferRingingParams;
begin

  params := TONTransferRingingParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  PostMessage(Handle, WM_TRANSFER_RINGING, 0, LPARAM(params));

end;

procedure TForm1.ACTVTransferSuccess(callbackIndex: NativeInt;
  sessionId: NativeInt);
var
  params: TONACTVTransferSuccessParams;
begin

  params := TONACTVTransferSuccessParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  PostMessage(Handle, WM_ACTV_TRANSFER_SUCCESS, 0, LPARAM(params));

end;

procedure TForm1.Button1Click(Sender: TObject);
const
  SIPPORT_MIN: integer = 8000;
var
  rt: integer;
  localSipPort: integer;
  sipServerPort: integer;
  stunServerport: integer;
  localIp: string;
  transportType: integer;
begin

  if ((Initialized = true) or (Registered = true)) then
  begin
    ShowMessage('alreay logged in');
    Exit;
  end;

  if (length(EditUserName.text) = 0) then
  begin
    ShowMessage('Please enter user name');
    Exit;
  end;

  if (length(EditPassword.text) = 0) then
  begin
    ShowMessage('Please enter password');
    Exit;
  end;

  if (length(EditSIPServer.text) = 0) then
  begin
    ShowMessage('Please enter SIP server');
    Exit;
  end;

  if (length(EditSIPServerPort.text) = 0) then
  begin
    ShowMessage('Please enter SIP server port');
    Exit;
  end;

  sipServerPort := StrToInt(EditSIPServerPort.text);
  stunServerport := 0;
  if (length(EditStunServerPort.text) > 0) then
  begin
    stunServerport := StrToInt(EditStunServerPort.text);
  end;

  sdkLib := TPortSipObject.Create(ExtractFilePath(Application.ExeName), 0);
  sdkLib.createCallbackHandlers;

  sdkLib.onRegisterSuccess := RegisterSuccess;
  sdkLib.onRegisterFailure := RegisterFailure;
  sdkLib.onInviteIncoming := InviteIncoming;
  sdkLib.onInviteTrying := InviteTrying;
  sdkLib.onInviteSessionProgress := InviteSessionProgress;
  sdkLib.onInviteRinging := InviteRinging;
  sdkLib.onInviteAnswered := InviteAnswered;
  sdkLib.onInviteFailure := InviteFailure;
  sdkLib.onInviteUpdated := InviteUpdated;
  sdkLib.onInviteConnected := InviteConnected;
  sdkLib.onInviteBeginingForward := InviteBeginingForward;
  sdkLib.onInviteClosed := InviteClosed;
  sdkLib.onDialogStateUpdated := DialogStateUpdated;
  sdkLib.onRemoteHold := RemoteHold;
  sdkLib.onRemoteUnHold := RemoteUnHold;
  sdkLib.onReceivedRefer := ReceivedRefer;
  sdkLib.onReferAccepted := ReferAccepted;
  sdkLib.onReferRejected := ReferRejected;
  sdkLib.onTransferTrying := TransferTrying;
  sdkLib.onTransferRinging := TransferRinging;
  sdkLib.onACTVTransferSuccess := ACTVTransferSuccess;
  sdkLib.onACTVTransferFailure := ACTVTransferFailure;
  sdkLib.onReceivedSignaling := ReceivedSignaling;
  sdkLib.onSendingSignaling := SendingSignaling;
  sdkLib.onWaitingVoiceMessage := WaitingVoiceMessage;
  sdkLib.onWaitingFaxMessage := WaitingFaxMessage;
  sdkLib.onRecvDtmfTone := RecvDtmfTone;
  sdkLib.onPresenceRecvSubscribe := PresenceRecvSubscribe;
  sdkLib.onPresenceOnline := PresenceOnline;
  sdkLib.onPresenceOffline := PresenceOffline;
  sdkLib.onRecvOptions := RecvOptions;
  sdkLib.onRecvInfo := RecvInfo;
  sdkLib.onRecvMessage := RecvMessage;
  sdkLib.onRecvOutOfDialogMessage := RecvOutOfDialogMessage;
  sdkLib.onSendMessageSuccess := SendMessageSuccess;
  sdkLib.onSendMessageFailure := SendMessageFailure;
  sdkLib.onSendOutOfDialogMessageSuccess := SendOutOfDialogMessageSuccess;
  sdkLib.onSendOutOfDialogMessageFailure := SendOutOfDialogMessageFailure;
  sdkLib.onPlayAudioFileFinished := PlayAudioFileFinished;
  sdkLib.onPlayVideoFileFinished := PlayVideoFileFinished;


    localSipPort := Random(10000) + SIPPORT_MIN;
  localIp := getLocalIp();
  transportType := TRANSPORT_UDP;

  rt := sdkLib.initialize(transportType, 
      // Use 0.0.0.0 for local IP then the SDK will choose an available local IP automatically.
// You also can specify a certain local IP to instead of "0.0.0.0", more details please read the SDK User Manual
                       '0.0.0.0',
                        LocalSIPPort, 
                        PORTSIP_LOG_NONE,
                          '',
                          8,
                          'PortSIP VoIP SDK',
                      0,
                       0,
                       '/',
                       '',
                       false);
  if rt <> 0 then
  begin
    sdkLib.releaseCallbackHandlers;
    ShowMessage('Failed to Initialize');
    Exit;
  end;

  ListBoxLog.Items.Add('Initialize succeeded.');
  Initialized := true;


  rt := sdkLib.setUser(PAnsiChar(ansistring(EditUserName.text)),
                       PAnsiChar(ansistring(EditDisplayName.text)),
                       PAnsiChar(ansistring(EditAuthName.text)),
                       PAnsiChar(ansistring(EditPassword.text)),
                        PAnsiChar(ansistring(EditUserDomain.text)),
                        PAnsiChar(ansistring(EditSIPServer.text)),
                        sipServerPort,
                        PAnsiChar(ansistring(EditStunServer.text)),
                        stunServerport,
                        '',
                        0);
  if rt <> 0 then
  begin
    sdkLib.releaseCallbackHandlers;
    sdkLib.unInitialize;
    Initialized := false;

    ShowMessage('Failed to setUser');
    ListBoxLog.Clear();
    Exit;
  end;

  if RadioButton1.Checked then
  begin
    sdkLib.setPresenceMode(0);
  end
  else if Radiobutton2.Checked then
  begin
        sdkLib.setPresenceMode(1);
  end;


   rt := sdkLib.setLicenseKey('PORTSIP_TEST_LICENSE');
  if rt = ECoreTrialVersionLicenseKey Then
  begin
    Text := 'This sample was built base on evaluation PortSIP VoIP SDK, which allows only three minutes conversation. The conversation will be cut off automatically after';
    Text := Text +  'three minutes, then you can not hearing anything. Feel free contact us at: sales@portsip.com to purchase the official version.';
    ShowMessage(Text);
  end
  else if rt = ECoreWrongLicenseKey then
  begin
    Text := 'The wrong license key was detected, please check with sales@portsip.com or support@portsip.com';
    ShowMessage(Text);
  end;



    rt := sdkLib.registerServer(120, 0);
    if (rt <> 0) then
    begin
      sdklib.removeUser();
      sdkLib.unInitialize();
      sdkLib.releaseCallbackHandlers;

      ListBoxLog.Clear();
      ShowMessage('Register to server failure.');
      Exit;
    end;

    ListBoxLog.Items.Add('Registering....');

end;


procedure TForm1.Button2Click(Sender: TObject);
begin
  ReleaseSDK;
end;

procedure TForm1.Button3Click(Sender: TObject);
var
  Contact : String;
  Subject : String;
  FilePath : String;
  ContactProfile : TIniFile;
  i : Integer;
  TempItem : TListItem;
begin
  if Initialized = False then
  begin
    Exit;
  end;

  if (length(AddContactName.Text) = 0) then
  begin
    Exit;
  end;

  if (AnsiContainsText(AddContactName.Text, 'sip:')=False) Or (AnsiContainsText(AddContactName.Text, '@')=False)  then
  begin
    ShowMessage('The contact name must likes: sip:username@sip.portsip.com:5060');
    Exit;
  end;

  Contact := AddContactName.Text;
  Subject := 'Hello';

  sdkLib.presenceSubscribe(pansichar(ansistring(Contact)), pansichar(ansistring(subject)));


  FilePath := ExtractFilePath(Application.ExeName);
  FilePath := FilePath + 'Contacts.ini';

  ContactProfile := TInifile.Create(FilePath);
  ContactProfile.WriteString(Contact, 'sipuri', Contact);
  ContactProfile.WriteBool(Contact, 'subscribed', true);
  ContactProfile.Free;

   Text := 'Offline';

    for i := ContactsList.Items.Count-1 downto 0 Do
    if ContactsList.Items[i].Caption = Contact then
    begin
      ContactsList.Items.Item[i].Delete();
      Break;
    end;

    TempItem := ContactsList.Items.Add;
    TempItem.Caption := Contact;
    TempItem.SubItems.Add(Text);
end;


procedure TForm1.Button4Click(Sender: TObject);
var
   ContactProfile : TIniFile;
   FilePath : string;
   SectionNames : TStringList;
   i : Integer;
   SipUri : string;
   MyStatusText : String;
   Contact : String;
   SubscribeId : LongInt;
begin
   if Initialized = False then
   begin
     Exit;
   end;

  filePath := ExtractFilePath(Application.ExeName);
  FilePath := FilePath + 'Contacts.ini';

  ContactProfile := TInifile.Create(FilePath);
  SectionNames := TStringList.Create();

  ContactProfile.ReadSections(SectionNames);

  if length(StatusText.Text) = 0 then
  begin
    Exit;
  end;

  MyStatusText := StatusText.Text;

  if RadioButton2.Checked then
  begin
        sdkLib.setPresenceStatus(0, pansichar(ansistring(MyStatusText)));
        Exit;
  end;

  for i := 0 to SectionNames.Count - 1 do
  begin
    SipUri := SectionNames.Strings[i];
    SubscribeId := ContactProfile.ReadInteger(SipUri, 'subscribeid', 0);

    if ContactProfile.ReadBool(SipUri, 'acceptedsubscribed', False) = True then
    begin
      sdkLib.setPresenceStatus(SubscribeId, pansichar(ansistring(MyStatusText)));
    end;

  end;


end;

procedure TForm1.Button5Click(Sender: TObject);
var
   Contact : String;
   MessageText : String;
   messageId : NativeInt;
begin
   if (Initialized = False) then
  begin
    Exit
  end;

  if length(SendMessage.Text) = 0 then
  begin
    Exit;
  end;

   if length(SendTo.Text) = 0 then
  begin
    Exit;
  end;

  if (AnsiContainsText(SendTo.Text, 'sip:')=False) Or (AnsiContainsText(SendTo.Text, '@')=False)  then
  begin
    ShowMessage('The contact name must likes: sip:username@sip.portsip.com:5060');
    Exit;
  end;

  Contact :=  SendTo.Text;
  MessageText := SendMessage.Text;

  messageId := sdkLib.sendOutOfDialogMessage(pansichar(ansistring(Contact)),
                                'text',
                                'plain',
                                 PByte(pansichar(ansistring(MessageText))),
                                 MessageText.Length);
  if messageId <= 0 then
  begin
    // Send message failure
  end
  else
  begin
    // The message is sending, the rt is message ID, you can save it and use it to identify which message is success or failure
    // in onSendOutOutOfDialogMessageSuccess/onSendOutOutOfDialogMessageFailure events.
  end;

end;
procedure TForm1.Button6Click(Sender: TObject);
var
   ContactProfile : TIniFile;
   FilePath : string;
   Caption : string;
   Index : Integer;
begin
  FilePath := ExtractFilePath(Application.ExeName);
  FilePath := FilePath + 'Contacts.ini';

  ContactProfile := TInifile.Create(FilePath);

  Index := ContactsList.Selected.Index;
  Caption := ContactsList.Items[index].Caption;

  ContactsList.Items.Delete(Index);

  ContactProfile.EraseSection(Caption);

end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  releaseSDK;
end;

procedure TForm1.FormCreate(Sender: TObject);
var
  text: string;
begin
  Randomize;

  text := 'This sample is built base on evaluation PortSIP VoIP SDK, which allows only three minutes conversation. The conversation will be cut off ';
  text := text +
    'automatically after three minutes, then you can not hearing anything. Please contact us at: sales@portsip.com to purchase the official version.';
  ShowMessage(text);


  Initialized := false;
  Registered := false;

end;

procedure TForm1.ACTVTransferFailure(callbackIndex: NativeInt;
  sessionId: NativeInt; reason: PAnsiChar; code: integer);
var
  params: TONACTVTransferFailureParams;
begin

  params := TONACTVTransferFailureParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.reason := reason;
  params.code := code;
  PostMessage(Handle, WM_ACTV_TRANSFER_FAILURE, 0, LPARAM(params));

end;

procedure TForm1.ReceivedSignaling(callbackIndex: NativeInt;
  sessionId: NativeInt; sipSignaling: PAnsiChar);
var
  params: TONReceivedSignalingParams;
begin

  params := TONReceivedSignalingParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.sipSignaling := sipSignaling;
  PostMessage(Handle, WM_RECEIVED_SIGNALING, 0, LPARAM(params));

end;

procedure TForm1.SendingSignaling(callbackIndex: NativeInt;
  sessionId: NativeInt; sipSignaling: PAnsiChar);
var
  params: TONSendingSignalingParams;
begin

  params := TONSendingSignalingParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.sipSignaling := sipSignaling;
  PostMessage(Handle, WM_SENDING_SIGNALING, 0, LPARAM(params));

end;

procedure TForm1.WaitingVoiceMessage(callbackIndex: NativeInt;
  messageAccount: PAnsiChar; urgentNewMessageCount, urgentOldMessageCount,
  newMessageCount, oldMessageCount: integer);
var
  params: TONWaitingVoiceMessageParams;
begin

  params := TONWaitingVoiceMessageParams.Create;
  params.callbackIndex := callbackIndex;
  params.messageAccount := messageAccount;
  params.urgentNewMessageCount := urgentNewMessageCount;
  params.urgentOldMessageCount := urgentOldMessageCount;
  params.newMessageCount := newMessageCount;
  params.oldMessageCount := oldMessageCount;
  PostMessage(Handle, WM_WAITING_VOICEMESSAGE, 0, LPARAM(params));

end;

procedure TForm1.WaitingFaxMessage(callbackIndex: NativeInt;
  messageAccount: PAnsiChar; urgentNewMessageCount, urgentOldMessageCount,
  newMessageCount, oldMessageCount: integer);
var
  params: TONWaitingFaxMessageParams;
begin

  params := TONWaitingFaxMessageParams.Create;
  params.callbackIndex := callbackIndex;
  params.messageAccount := messageAccount;
  params.urgentNewMessageCount := urgentNewMessageCount;
  params.urgentOldMessageCount := urgentOldMessageCount;
  params.newMessageCount := newMessageCount;
  params.oldMessageCount := oldMessageCount;
  PostMessage(Handle, WM_WAITING_FAXMESSAGE, 0, LPARAM(params));

end;

procedure TForm1.RecvDtmfTone(callbackIndex: NativeInt; sessionId: NativeInt;
  tone: integer);
var
  params: TONRecvDtmfToneParams;
begin

  params := TONRecvDtmfToneParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.tone := tone;
  PostMessage(Handle, WM_RECV_DTMFTONE, 0, LPARAM(params));

end;

procedure TForm1.PresenceRecvSubscribe(callbackIndex: NativeInt;
  subscribeId: NativeInt; fromDisplayName: PAnsiChar; from: PAnsiChar;
  subject: PAnsiChar);
var
  params: TONPresenceRecvSubscribeParams;
begin

  params := TONPresenceRecvSubscribeParams.Create;
  params.callbackIndex := callbackIndex;
  params.subscribeId := subscribeId;
  params.fromDisplayName := fromDisplayName;
  params.from :=  from;
  params.subject := subject;
  PostMessage(Handle, WM_PRESENCE_RECV_SUBSCRIBE, 0, LPARAM(params));

end;

procedure TForm1.PresenceOnline(callbackIndex: NativeInt;
  fromDisplayName: PAnsiChar; from: PAnsiChar; stateText: PAnsiChar);
var
  params: TONPresenceOnlineParams;
begin

  params := TONPresenceOnlineParams.Create;
  params.callbackIndex := callbackIndex;
  params.fromDisplayName :=  fromDisplayName;
  params.from := from;
  params.stateText :=  stateText;
  PostMessage(Handle, WM_PRESENCE_ONLINE, 0, LPARAM(params));

end;

procedure TForm1.PresenceOffline(callbackIndex: NativeInt;
  fromDisplayName: PAnsiChar; from: PAnsiChar);
var
  params: TONPresenceOfflineParams;
begin

  params := TONPresenceOfflineParams.Create;
  params.callbackIndex := callbackIndex;
  params.fromDisplayName :=  fromDisplayName;
  params.from := from;
  PostMessage(Handle, WM_PRESENCE_OFFLINE, 0, LPARAM(params));

end;

procedure TForm1.RecvOptions(callbackIndex: NativeInt;
  optionsMessage: PAnsiChar);
var
  params: TONRecvOptionsParams;
begin

  params := TONRecvOptionsParams.Create;
  params.callbackIndex := callbackIndex;
  params.optionsMessage := optionsMessage;
  PostMessage(Handle, WM_RECV_OPTIONS, 0, LPARAM(params));

end;

procedure TForm1.RecvInfo(callbackIndex: NativeInt; infoMessage: PAnsiChar);
var
  params: TONRecvInfoParams;
begin

  params := TONRecvInfoParams.Create;
  params.callbackIndex := callbackIndex;
  params.callbackIndex := callbackIndex;
  params.infoMessage := infoMessage;
  PostMessage(Handle, WM_RECV_INFO, 0, LPARAM(params));

end;

procedure TForm1.RecvMessage(callbackIndex: NativeInt; sessionId: NativeInt;
  mimeType: PAnsiChar; subMimeType: PAnsiChar; messageData: PByte;
  messageDataLength: integer);
var
  params: TONRecvMessageParams;
begin

  params := TONRecvMessageParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.mimeType := mimeType;
  params.subMimeType := subMimeType;
  params.messageData := AllocMem(messageDataLength);
  CopyMemory(params.messageData, messageData, messageDataLength);
  params.messageDataLength := messageDataLength;
  PostMessage(Handle, WM_RECV_MESSAGE, 0, LPARAM(params));

end;

procedure TForm1.RecvOutOfDialogMessage(callbackIndex: NativeInt;
  fromDisplayName: PAnsiChar; from: PAnsiChar; toDisplayName: PAnsiChar;
  sendTo: PAnsiChar; mimeType: PAnsiChar; subMimeType: PAnsiChar;
  messageData: PByte; messageDataLength: integer);
var
  params: TONRecvOutOfDialogMessageParams;
begin

  params := TONRecvOutOfDialogMessageParams.Create;
  params.callbackIndex := callbackIndex;
  params.fromDisplayName := fromDisplayName;
  params.from := from;
  params.toDisplayName := toDisplayName;
  params.sendTo := sendTo;
  params.mimeType := mimeType;
  params.subMimeType := subMimeType;
  params.messageData := AllocMem(messageDataLength);
  CopyMemory(params.messageData, messageData, messageDataLength);
  params.messageDataLength := messageDataLength;
  PostMessage(Handle, WM_RECV_OUTOFDIALOG_MESSAGE, 0, LPARAM(params));

end;

procedure TForm1.SendMessageSuccess(callbackIndex: NativeInt;
  sessionId, messageId: NativeInt);
var
  params: TONSendMessageSuccessParams;
begin

  params := TONSendMessageSuccessParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.messageId := messageId;
  PostMessage(Handle, WM_SEND_MESSAGE_SUCCESS, 0, LPARAM(params));

end;

procedure TForm1.SendMessageFailure(callbackIndex: NativeInt;
  sessionId, messageId: NativeInt; reason: PAnsiChar;
  code: integer);
var
  params: TONSendMessageFailureParams;
begin

  params := TONSendMessageFailureParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.messageId := messageId;
  PostMessage(Handle, WM_SEND_MESSAGE_FAILURE, 0, LPARAM(params));

end;

procedure TForm1.SendOutOfDialogMessageSuccess(callbackIndex, messageId: NativeInt;
  fromDisplayName: PAnsiChar; from: PAnsiChar; toDisplayName: PAnsiChar;
  sendTo: PAnsiChar);
var
  params: TONSendOutOfDialogMessageSuccessParams;
begin

  params := TONSendOutOfDialogMessageSuccessParams.Create;
  params.callbackIndex := callbackIndex;
  params.messageId := messageId;
  params.fromDisplayName := fromDisplayName;
  params.from := from;
  params.toDisplayName := toDisplayName;
  params.sendTo := sendTo;
  PostMessage(Handle, WM_SEND_OUTOFDIALOG_MESSAGE_SUCCESS, 0, LPARAM(params));

end;

procedure TForm1.SendOutOfDialogMessageFailure(callbackIndex, messageId: NativeInt;
  fromDisplayName: PAnsiChar; from: PAnsiChar; toDisplayName: PAnsiChar;
  sendTo: PAnsiChar; reason: PAnsiChar; code: integer);
var
  params: TONSendOutOfDialogMessageFailureParams;
begin

  params := TONSendOutOfDialogMessageFailureParams.Create;
  params.callbackIndex := callbackIndex;
  params.messageId := messageId;
  params.fromDisplayName := fromDisplayName;
  params.from := from;
  params.toDisplayName := toDisplayName;
  params.sendTo := sendTo;
  PostMessage(Handle, WM_SEND_OUTOFDIALOG_MESSAGE_FAILURE, 0, LPARAM(params));

end;

procedure TForm1.PlayAudioFileFinished(callbackIndex: NativeInt;
  sessionId: NativeInt; fileName: PAnsiChar);
var
  params: TONPlayAudioFileFinishedParams;
begin

  params := TONPlayAudioFileFinishedParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  params.fileName := fileName;
  PostMessage(Handle, WM_PLAY_AUDIO_FILE_FINISHED, 0, LPARAM(params));

end;

procedure TForm1.PlayVideoFileFinished(callbackIndex: NativeInt;
  sessionId: NativeInt);
var
  params: TONPlayVideoFileFinishedParams;
begin

  params := TONPlayVideoFileFinishedParams.Create;
  params.callbackIndex := callbackIndex;
  params.sessionId := sessionId;
  PostMessage(Handle, WM_PLAY_VIDEO_FILE_FINISHED, 0, LPARAM(params));

end;

/// /////////////////////////////////////////////////////////////////////////////
/// /////////////////////////////////////////////////////////////////////////////

procedure TForm1.onRegisterSuccess(var Message: TMessage);
var
  params: TONRegisterSuccessParams;
  callbackIndex: NativeInt;
begin

  ListBoxLog.Items.Add('Registration succeeded');
  Registered := true;

  params := TONRegisterSuccessParams(Message.LPARAM);
  params.Free;

end;

procedure TForm1.onRegisterFailure(var Message: TMessage);
var
  params: TONRegisterFailureParams;
  callbackIndex: NativeInt;
begin

  params := TONRegisterFailureParams(Message.LPARAM);
  ListBoxLog.Items.Add('Registration failure: ' + params.reason + ' ' +
    IntToStr(params.code));
  Registered := false;

  params.Free;

end;

procedure TForm1.onInviteIncoming(var Message: TMessage);
var
  params: TONInviteIncomingParams;
begin
  params := TONInviteIncomingParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onInviteTrying(var Message: TMessage);
var
  params: TONInviteTryingParams;
  callbackIndex: NativeInt;
begin

  params := TONInviteTryingParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onInviteSessionProgress(var Message: TMessage);
var
  params: TONInviteSessionProgressParams;
  callbackIndex: NativeInt;
begin

  params := TONInviteSessionProgressParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onInviteRinging(var Message: TMessage);
var
  params: TONInviteRingingParams;
  callbackIndex: NativeInt;
begin

  params := TONInviteRingingParams(Message.LPARAM);


  params.Free;

end;

procedure TForm1.onInviteAnswered(var Message: TMessage);
var
  params: TONInviteAnsweredParams;
  callbackIndex: NativeInt;
begin

  params := TONInviteAnsweredParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onInviteFailure(var Message: TMessage);
var
  params: TONInviteFailureParams;
  callbackIndex: NativeInt;
begin
  params := TONInviteFailureParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onInviteUpdated(var Message: TMessage);
var
  params: TONInviteUpdatedParams;
  callbackIndex: NativeInt;

begin

  params := TONInviteUpdatedParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onInviteConnected(var Message: TMessage);
var
  params: TONInviteConnectedParams;
  callbackIndex: NativeInt;
begin

  params := TONInviteConnectedParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onInviteBeginingForward(var Message: TMessage);
var
  params: TONInviteBeginingForwardParams;
  callbackIndex: NativeInt;
begin

  params := TONInviteBeginingForwardParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onInviteClosed(var Message: TMessage);
var
  params: TONInviteClosedParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONInviteClosedParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onDialogStateUpdated(var Message: TMessage);
var
  params: TONDialogStateUpdatedParams;
  callbackIndex: NativeInt;
  
begin

  params := TONDialogStateUpdatedParams(Message.LPARAM);
  ListBoxLog.Items.Add(Format('User %s dialog state is updated: %s, dialog id is: %s, direction is %s.', [params.BLFMonitoredUri, params.BLFDialogState, params.BLFDialogId, params.BLFDialogDirection]));
  params.Free;

end;

procedure TForm1.onRemoteHold(var Message: TMessage);
var
  params: TONRemoteHoldParams;
  callbackIndex: NativeInt;
begin

  params := TONRemoteHoldParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onRemoteUnHold(var Message: TMessage);
var
  params: TONRemoteUnHoldParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONRemoteUnHoldParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onReceivedRefer(var Message: TMessage);
var
  params: TONReceivedReferParams;
  callbackIndex: NativeInt;

begin

  params := TONReceivedReferParams(Message.LPARAM);
  
  params.Free;

end;

procedure TForm1.onReferAccepted(var Message: TMessage);
var
  params: TONReferAcceptedParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONReferAcceptedParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onReferRejected(var Message: TMessage);
var
  params: TONReferRejectedParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONReferRejectedParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onTransferTrying(var Message: TMessage);
var
  params: TONTransferTryingParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONTransferTryingParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onTransferRinging(var Message: TMessage);
var
  params: TONTransferRingingParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONTransferRingingParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onACTVTransferSuccess(var Message: TMessage);
var
  params: TONACTVTransferSuccessParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONACTVTransferSuccessParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onACTVTransferFailure(var Message: TMessage);
var
  params: TONACTVTransferFailureParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONACTVTransferFailureParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onReceivedSignaling(var Message: TMessage);
var
  params: TONReceivedSignalingParams;
  callbackIndex: NativeInt;
begin

  params := TONReceivedSignalingParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onSendingSignaling(var Message: TMessage);
var
  params: TONSendingSignalingParams;
  callbackIndex: NativeInt;
begin

  params := TONSendingSignalingParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onWaitingVoiceMessage(var Message: TMessage);
var
  params: TONWaitingVoiceMessageParams;
  callbackIndex: NativeInt;
begin

  params := TONWaitingVoiceMessageParams(Message.LPARAM);
  ListBoxLog.Items.Add('Has waiting voice message.');
  params.Free;

end;

procedure TForm1.onWaitingFaxMessage(var Message: TMessage);
var
  params: TONWaitingFaxMessageParams;
  callbackIndex: NativeInt;
begin

  params := TONWaitingFaxMessageParams(Message.LPARAM);
  ListBoxLog.Items.Add('Has waiting Fax message.');
  params.Free;

end;

procedure TForm1.onRecvDtmfTone(var Message: TMessage);
var
  params: TONRecvDtmfToneParams;
  callbackIndex: NativeInt;

begin

  params := TONRecvDtmfToneParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onPresenceRecvSubscribe(var Message: TMessage);
var
  params: TONPresenceRecvSubscribeParams;
  callbackIndex: NativeInt;
begin

  params := TONPresenceRecvSubscribeParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onPresenceOnline(var Message: TMessage);
var
  params: TONPresenceOnlineParams;
  callbackIndex: NativeInt;
begin

  params := TONPresenceOnlineParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onPresenceOffline(var Message: TMessage);
var
  params: TONPresenceOfflineParams;
  callbackIndex: NativeInt;
begin

  params := TONPresenceOfflineParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onRecvOptions(var Message: TMessage);
var
  params: TONRecvOptionsParams;
  callbackIndex: NativeInt;
begin

  params := TONRecvOptionsParams(Message.LPARAM);

  // The OPTIONS SIP message, it's params.optionsMessage.

  params.Free;

end;

procedure TForm1.onRecvInfo(var Message: TMessage);
var
  params: TONRecvInfoParams;
  callbackIndex: NativeInt;
begin

  params := TONRecvInfoParams(Message.LPARAM);

  // The INFO SIP message, it's params.infosMessage.

  params.Free;

end;

procedure TForm1.onRecvMessage(var Message: TMessage);
var
  params: TONRecvMessageParams;
  callbackIndex: NativeInt;
begin

  params := TONRecvMessageParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onRecvOutOfDialogMessage(var Message: TMessage);
var
  params: TONRecvOutOfDialogMessageParams;
  callbackIndex: NativeInt;
  text: string;
begin

  params := TONRecvOutOfDialogMessageParams(Message.LPARAM);

  if (params.mimeType = 'text') and (params.subMimeType = 'plain') then
  begin
    // Here is the plain message text: params.messageData

      text := 'Received a MESSAGE message out of dialog: ';
      text := text + PAnsiChar(params.messageData);
      ShowMessage(text);

  end
  else if (params.mimeType = 'application') and
    (params.subMimeType = 'vnd.3gpp.sms') then
  begin
    // Here is the binary message:
    // params.messageData
    // params.messageDataLength
  end
  else if (params.mimeType = 'application') and
    (params.subMimeType = 'vnd.3gpp2.sms') then
  begin
    // Here is the binary message:
    // params.messageData
    // params.messageDataLength
  end;

  FreeMem(params.messageData);
  params.Free;

end;

procedure TForm1.onSendMessageSuccess(var Message: TMessage);
var
  params: TONSendMessageSuccessParams;
  callbackIndex: NativeInt;
begin

  params := TONSendMessageSuccessParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onSendMessageFailure(var Message: TMessage);
var
  params: TONSendMessageFailureParams;
  callbackIndex: NativeInt;
begin

  params := TONSendMessageFailureParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onSendOutOfDialogMessageSuccess(var Message: TMessage);
var
  params: TONSendOutOfDialogMessageSuccessParams;
  callbackIndex: NativeInt;
begin

  params := TONSendOutOfDialogMessageSuccessParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onSendOutOfDialogMessageFailure(var Message: TMessage);
var
  params: TONSendOutOfDialogMessageFailureParams;
  callbackIndex: NativeInt;
begin

  params := TONSendOutOfDialogMessageFailureParams(Message.LPARAM);

  params.Free;

end;

procedure TForm1.onPlayAudioFileFinished(var Message: TMessage);
var
  params: TONPlayAudioFileFinishedParams;
  callbackIndex: NativeInt;
begin

  params := TONPlayAudioFileFinishedParams(Message.LPARAM);
  params.Free;

end;

procedure TForm1.onPlayVideoFileFinished(var Message: TMessage);
var
  params: TONPlayVideoFileFinishedParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONPlayVideoFileFinishedParams(Message.LPARAM);

  params.Free;

end;


procedure TForm1.onAudioRawCallback(var Message: TMessage);
var
  params: TONAudioRawCallbackParams;
  callbackIndex: NativeInt;
  index: integer;
begin
  params := TONAudioRawCallbackParams(Message.LPARAM);

  FreeMem(params.data);
  params.Free;
end;

procedure TForm1.onVideoRawCallback(var Message: TMessage);
var
  params: TONVideoRawCallbackParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONVideoRawCallbackParams(Message.LPARAM);

  FreeMem(params.data);
  params.Free;
end;

procedure TForm1.onReceivdRtpPackets(var Message: TMessage);
var
  params: TONReceivedRTPPacketParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONReceivedRTPPacketParams(Message.LPARAM);

  // Process the received RTP packets here.

  FreeMem(params.RTPPacket);
  params.Free;
end;


procedure TForm1.onSendingRtpPackets(var Message: TMessage);
var
  params: TONSendingRTPPacketParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONSendingRTPPacketParams(Message.LPARAM);

  // Process the callback sending RTP packets here.

  FreeMem(params.RTPPacket);
  params.Free;
end;



///
///

procedure TForm1.releaseSDK;
begin
  if Initialized = false then
  begin
    Exit;
  end;

  if Registered = true then
  begin
    sdkLib.unRegisterServer;
    Registered := false;
  end;

  if Initialized = true then
  begin
    sdkLib.removeUser;
    sdkLib.unInitialize;
    sdkLib.releaseCallbackHandlers;
    Initialized := false;
  end;

  ListBoxLog.Clear();

end;




procedure TForm1.LoadContacts;
var
   ContactProfile : TIniFile;
   FilePath : string;
   SectionNames : TStringList;
   i : Integer;
   j : Integer;
   SipUri : string;
   Blocked : Bool;
   Subscribed : Bool;
   Text : String;
   TempItem : TListItem;
   Contact : String;
   Subject : String;
begin
  FilePath := ExtractFilePath(Application.ExeName);
  FilePath := FilePath + 'Contacts.ini';

  ContactProfile := TInifile.Create(FilePath);
  SectionNames := TStringList.Create();

  ContactProfile.ReadSections(SectionNames);

  for i := 0 to SectionNames.Count - 1 do
  begin
    SipUri := SectionNames.Strings[i];

    Blocked := ContactProfile.ReadBool(SipUri, 'Blocked', false);
    Subscribed := ContactProfile.ReadBool(SipUri, 'subscribed', false);

    ContactProfile.WriteInteger(SipUri, 'subscribeid', 0);

    if Subscribed = false then
    begin
      continue;
    end;

    Text := 'Offline';
    if Blocked = true then
    begin
      Text := 'Blocked';
    end;

    for j := ContactsList.Items.Count-1 downto 0 Do
    if ContactsList.Items[j].Caption = SipUri then
    begin
      ContactsList.Items.Item[j].Delete();
      Break;
    end;

    TempItem := ContactsList.Items.Add;
    TempItem.Caption := SipUri;
    TempItem.SubItems.Add(Text);

  end;


  Subject := 'Hello';

  for i := 0 to SectionNames.Count - 1 do
  begin
    SipUri := SectionNames.Strings[i];
    Subscribed := ContactProfile.ReadBool(SipUri, 'subscribed', false);

    Contact :=  SipUri;

    if Subscribed = true then
    begin
      sdkLib.presenceSubscribe(pansichar(ansistring(Contact)), pansichar(ansistring(subject)));
    end;

  end;

  ContactProfile.Free;


end;



function TForm1.getLocalIp(): string;
var
  localIp: Array [0 .. 64] of AnsiChar;
  tempIp: string;
  nics: integer;
  i: integer;
begin
  if (Initialized = false) then
  begin
    Exit;
  end;

  result := '';

  nics := sdkLib.getNICNums;
  for i := 0 to nics do
  begin
    sdkLib.getLocalIpAddress(i, @localIp, 64);
    tempIp := string(localIp);
    if Pos(':', tempIp) = 0 then
    begin
      result := string(localIp);
      break
    end;
  end;

end;

procedure TForm1.Offline;
var
   ContactProfile : TIniFile;
   FilePath : string;
   SectionNames : TStringList;
   SipUri : string;
   i : Integer;
   subscribeId : LongInt;
begin
  if Registered = False then
  begin
    Exit;
  end;

  FilePath := ExtractFilePath(Application.ExeName);
  FilePath := FilePath + 'Contacts.ini';

  ContactProfile := TInifile.Create(FilePath);
  SectionNames := TStringList.Create();

  ContactProfile.ReadSections(SectionNames);

  if Radiobutton2.Checked then
  begin
    sdkLib.setPresenceStatus(0, 'Offlie');
    Exit;
  end;

   for i := 0 to SectionNames.Count - 1 do
  begin
    SipUri := SectionNames.Strings[i];
    subscribeId :=  ContactProfile.ReadInteger(SipUri, 'subscribeid', 0);
    if ContactProfile.ReadBool(SipUri, 'acceptedsubscribed', False) = True  then
    begin
      sdkLib.setPresenceStatus(subscribeId, 'offline');
    end;
  end;


end;



end.
