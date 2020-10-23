unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, PortSIPConsts, PortSIPLib,
  Unit2, shellapi, filectrl,
  Vcl.ComCtrls, Vcl.ExtCtrls, Unit3;

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
    Label23: TLabel;
    Label24: TLabel;
    Label27: TLabel;
    Label28: TLabel;
    Label29: TLabel;
    Label30: TLabel;
    Label11: TLabel;
    Label15: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Label10: TLabel;
    Label12: TLabel;
    GroupBox1: TGroupBox;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    Label7: TLabel;
    Label25: TLabel;
    Label26: TLabel;
    EditUserName: TEdit;
    EditPassword: TEdit;
    EditSIPServerPort: TEdit;
    EditSIPServer: TEdit;
    EditStunServerPort: TEdit;
    EditStunServer: TEdit;
    Button1: TButton;
    Button2: TButton;
    Panel1: TPanel;
    EditPhoneNumber: TEdit;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    Button9: TButton;
    Button10: TButton;
    Button11: TButton;
    Button12: TButton;
    Button13: TButton;
    Button14: TButton;
    ComboBoxLines: TComboBox;
    Panel4: TPanel;
    Button28: TButton;
    ListBoxLog: TListBox;
    EditUserDomain: TEdit;
    EditDisplayName: TEdit;
    EditAuthName: TEdit;
    ComboBoxTransport: TComboBox;
    ComboBoxSRTP: TComboBox;
    CheckBoxNeedRegisterServer: TCheckBox;
    Panel7: TPanel;
    GroupBox2: TGroupBox;
    Label17: TLabel;
    Label18: TLabel;
    Button29: TButton;
    EditRecordFilePath: TEdit;
    EditRecordFileName: TEdit;
    Button30: TButton;
    Button31: TButton;
    CheckBoxAudioStreamCallback: TCheckBox;
    GroupBox3: TGroupBox;
    Label20: TLabel;
    Button32: TButton;
    EditPlayAudioFileName: TEdit;
    Button33: TButton;
    Button34: TButton;
    GroupBox4: TGroupBox;
    Label22: TLabel;
    CheckBoxForwardCallBusy: TCheckBox;
    Button37: TButton;
    Button38: TButton;
    EditForwardAddress: TEdit;
    LocalVideo: TPanel;
    RemoteVideo: TPanel;
    Button27: TButton;
    Button26: TButton;
    Button25: TButton;
    Button24: TButton;
    ComboBoxResolution: TComboBox;
    TrackBarQuality: TTrackBar;
    ComboBoxCamera: TComboBox;
    ComboBoxMicrophone: TComboBox;
    ComboBoxSpeaker: TComboBox;
    Panel3: TPanel;
    Panel2: TPanel;
    TrackBarSpeaker: TTrackBar;
    TrackBarMicrophone: TTrackBar;
    CheckBoxMuteMicrophone: TCheckBox;
    CheckBoxAMRWB: TCheckBox;
    CheckBoxG7221: TCheckBox;
    CheckBoxG729: TCheckBox;
    CheckBoxG711U: TCheckBox;
    CheckBoxG711A: TCheckBox;
    CheckBoxAMR: TCheckBox;
    CheckBoxG722: TCheckBox;
    CheckBoxSPEEXWB: TCheckBox;
    CheckBoxSPEEX: TCheckBox;
    CheckBoxILBC: TCheckBox;
    CheckBoxGSM: TCheckBox;
    CheckBoxH2631998: TCheckBox;
    CheckBoxH263: TCheckBox;
    CheckBoxH264: TCheckBox;
    CheckBoxVP8: TCheckBox;
    CheckBoxAGC: TCheckBox;
    CheckBoxVAD: TCheckBox;
    CheckBoxCNG: TCheckBox;
    CheckBoxAEC: TCheckBox;
    Panel6: TPanel;
    OpenDialog1: TOpenDialog;
    CheckBoxANS: TCheckBox;
    CheckBoxOpus: TCheckBox;
    Button23: TButton;
    Button20: TButton;
    Button18: TButton;
    Button19: TButton;
    Button17: TButton;
    Button21: TButton;
    Button15: TButton;
    Button16: TButton;
    CheckBoxAnswerVideoCall: TCheckBox;
    CheckBoxMakeVideoCall: TCheckBox;
    CheckBoxConference: TCheckBox;
    CheckBoxPRACK: TCheckBox;
    CheckBoxDND: TCheckBox;
    CheckBoxAA: TCheckBox;
    CheckBoxSDP: TCheckBox;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Button2Click(Sender: TObject);
    procedure CheckBoxDNDClick(Sender: TObject);
    procedure ComboBoxLinesChange(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
    procedure Button10Click(Sender: TObject);
    procedure Button11Click(Sender: TObject);
    procedure Button12Click(Sender: TObject);
    procedure Button13Click(Sender: TObject);
    procedure Button14Click(Sender: TObject);
    procedure Button15Click(Sender: TObject);
    procedure Button16Click(Sender: TObject);
    procedure Button21Click(Sender: TObject);
    procedure Button17Click(Sender: TObject);
    procedure Button18Click(Sender: TObject);
    procedure Button19Click(Sender: TObject);
    procedure Button20Click(Sender: TObject);
    procedure Button23Click(Sender: TObject);
    procedure ComboBoxResolutionChange(Sender: TObject);
    procedure Button24Click(Sender: TObject);
    procedure Button25Click(Sender: TObject);
    procedure TrackBarQualityChange(Sender: TObject);
    procedure Button26Click(Sender: TObject);
    procedure Button27Click(Sender: TObject);
    procedure Button28Click(Sender: TObject);
    procedure Button29Click(Sender: TObject);
    procedure CheckBoxAudioStreamCallbackClick(Sender: TObject);
    procedure Button30Click(Sender: TObject);
    procedure Button31Click(Sender: TObject);
    procedure Button32Click(Sender: TObject);
    procedure Button33Click(Sender: TObject);
    procedure Button34Click(Sender: TObject);
    procedure TrackBarSpeakerChange(Sender: TObject);
    procedure TrackBarMicrophoneChange(Sender: TObject);
    procedure CheckBoxMuteMicrophoneClick(Sender: TObject);
    procedure ComboBoxSpeakerChange(Sender: TObject);
    procedure ComboBoxMicrophoneChange(Sender: TObject);
    procedure ComboBoxCameraChange(Sender: TObject);
    procedure CheckBoxG711UClick(Sender: TObject);
    procedure CheckBoxG729Click(Sender: TObject);
    procedure CheckBoxG7221Click(Sender: TObject);
    procedure CheckBoxAMRWBClick(Sender: TObject);
    procedure CheckBoxG711AClick(Sender: TObject);
    procedure CheckBoxAMRClick(Sender: TObject);
    procedure CheckBoxG722Click(Sender: TObject);
    procedure CheckBoxSPEEXWBClick(Sender: TObject);
    procedure CheckBoxGSMClick(Sender: TObject);
    procedure CheckBoxILBCClick(Sender: TObject);
    procedure CheckBoxSPEEXClick(Sender: TObject);
    procedure CheckBoxOpusClick(Sender: TObject);
    procedure CheckBoxH263Click(Sender: TObject);
    procedure CheckBoxH2631998Click(Sender: TObject);
    procedure CheckBoxH264Click(Sender: TObject);
    procedure CheckBoxVP8Click(Sender: TObject);
    procedure CheckBoxAECClick(Sender: TObject);
    procedure CheckBoxCNGClick(Sender: TObject);
    procedure CheckBoxVADClick(Sender: TObject);
    procedure CheckBoxAGCClick(Sender: TObject);
    procedure CheckBoxANSClick(Sender: TObject);
    procedure Button37Click(Sender: TObject);
    procedure Button38Click(Sender: TObject);
    procedure Label23Click(Sender: TObject);
    procedure Label24Click(Sender: TObject);
    procedure CheckBoxConferenceClick(Sender: TObject);
    procedure CheckBoxPRACKClick(Sender: TObject);

  private
    { Private declarations }

    sdkLib: TPortSipObject;
    Initialized: Boolean;
    Registered: Boolean;
    CurrentLine: integer;
    Sessions: Array [0 .. 8] of TSession;

    function findSession(sessionId: integer): integer;
    procedure joinConference(const index: integer);
    function getLocalIp(): string;
    procedure loadDevice;
    procedure updateVideoQuality;
    procedure updateVideoResolution;
    procedure updateAudioCodecs;
    procedure updateVideoCodecs;
    procedure initDefaultVideoCodecs;
    procedure initDefaultAudioCodecs;
    procedure initSettings;
    procedure releaseSDK;
    procedure updatePrackSetting;
    procedure setSrtpPolicy();


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
  callbackIndex: NativeInt;
  index: integer;
  i: integer;
  needIgnoreAutoAnswer: Boolean;
  j: integer;
begin
  params := TONInviteIncomingParams(Message.LPARAM);
  index := -1;

  for i := LINE_BASE to MAXLINE do
  begin
    if ((Sessions[i].GetSessionState() = false) and
      (Sessions[i].GetRecvCallState() = false)) then
    begin
      index := i;
      break;
    end;
  end;

  if index = -1 then
  begin
    sdkLib.rejectCall(params.sessionId, 486);
    params.Free;
    Exit;
  end;

  if params.existsVideo = true then
  begin
    // If more than one codecs using, then they are separated with "#",
    // for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
  end;

  if params.existsAudio = true then
  begin
    // If more than one codecs using, then they are separated with "#",
    // for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
  end;

  Sessions[index].SetSessionID(params.sessionId);
  Sessions[index].SetRecvCallState(true);

  needIgnoreAutoAnswer := false;
  for j := LINE_BASE to MAXLINE do
  begin
    if (Sessions[j].GetSessionState = true) then
    begin
      needIgnoreAutoAnswer := true;
      break;
    end;
  end;


  if params.existsVideo = true then
  begin
      sdkLib.setRemoteVideoWindow(Sessions[index].GetSessionID(),
      RemoteVideo.Handle);
  end;


  if (needIgnoreAutoAnswer = false) and (CheckBoxAA.Checked = true) then
  begin
    Sessions[i].SetRecvCallState(false);
    Sessions[i].SetSessionState(true);


    sdkLib.answerCall(Sessions[i].GetSessionID,
      CheckBoxAnswerVideoCall.Checked);

    ListBoxLog.Items.Add
      (Format('Answered the call automatically on line %d ', [i]));
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : call incoming from %s <%s>',
    [i, params.callerDisplayName, params.caller]));

  params.Free;

end;

procedure TForm1.onInviteTrying(var Message: TMessage);
var
  params: TONInviteTryingParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONInviteTryingParams(Message.LPARAM);

  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : call is trying...', [index]));

  params.Free;

end;

procedure TForm1.onInviteSessionProgress(var Message: TMessage);
var
  params: TONInviteSessionProgressParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONInviteSessionProgressParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  if params.existsVideo = true then
  begin
    // If more than one codecs using, then they are separated with "#",
    // for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
  end;

  if params.existsAudio = true then
  begin
    // If more than one codecs using, then they are separated with "#",
    // for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
  end;

  Sessions[index].SetSessionState(true);
  ListBoxLog.Items.Add(Format('Line %d : call session progress.', [index]));

  Sessions[index].SetExistsEarlyMedia(params.existsEarlyMedia);

  params.Free;

end;

procedure TForm1.onInviteRinging(var Message: TMessage);
var
  params: TONInviteRingingParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONInviteRingingParams(Message.LPARAM);

  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  if Sessions[index].GetExistsEarlyMedia = true then
  begin
    // No early media, you must play the local WAVE  file for ringing tone
  end;

  ListBoxLog.Items.Add(Format('Line %d : call is ringing...', [index]));

  params.Free;

end;

procedure TForm1.onInviteAnswered(var Message: TMessage);
var
  params: TONInviteAnsweredParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONInviteAnsweredParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  if params.existsVideo = true then
  begin
    // If more than one codecs using, then they are separated with "#",
    // for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
  end;

  if params.existsAudio = true then
  begin
    // If more than one codecs using, then they are separated with "#",
    // for example: "g.729#GSM#AMR", "H264#H263", you have to parse them by yourself.
  end;

  Sessions[index].SetSessionState(true);
  ListBoxLog.Items.Add(Format('Line %d : call is established.', [index]));

  joinConference(index);

  // If this is the refer call then need set it to normal
  if (Sessions[index].GetIsReferCall() = true) then
  begin
    Sessions[index].setReferCall(false, 0);
  end;

  params.Free;

end;

procedure TForm1.onInviteFailure(var Message: TMessage);
var
  params: TONInviteFailureParams;
  callbackIndex: NativeInt;
  index: integer;
  originCallIndex: integer;
  i: integer;
begin
  params := TONInviteFailureParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : call is failure: %s %d.', [index, params.reason, params.code]));
  if Sessions[index].GetIsReferCall = true then
  begin
    // Take off the origin call from HOLD if the refer call is failure
    originCallIndex := -1;
    for i := LINE_BASE to MAXLINE do
    begin
      // Looking for the origin call
      if (Sessions[i].GetSessionID() = Sessions[index].getOriginCallSessionId())
      then
      begin
        originCallIndex := i;
        break;
      end
    end;

    if originCallIndex <> -1 then
    begin
      sdkLib.unHold(Sessions[index].getOriginCallSessionId());
      Sessions[originCallIndex].SetHoldState(false);

      // Switch the currently line to origin call line
      CurrentLine := originCallIndex;
      ComboBoxLines.ItemIndex := CurrentLine - 1;

      ListBoxLog.Items.Add(Format('Current line is set to %d', [CurrentLine]));
    end;
  end;

  Sessions[index].Reset;
  params.Free;

end;

procedure TForm1.onInviteUpdated(var Message: TMessage);
var
  params: TONInviteUpdatedParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONInviteUpdatedParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : call is updated.', [index]));

  params.Free;

end;

procedure TForm1.onInviteConnected(var Message: TMessage);
var
  params: TONInviteConnectedParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONInviteConnectedParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : call is connected.', [index]));
  params.Free;

end;

procedure TForm1.onInviteBeginingForward(var Message: TMessage);
var
  params: TONInviteBeginingForwardParams;
  callbackIndex: NativeInt;
begin

  params := TONInviteBeginingForwardParams(Message.LPARAM);
  ListBoxLog.Items.Add(Format('Call has been forwarded to %s .',
    [params.forwardTo]));
  params.Free;

end;

procedure TForm1.onInviteClosed(var Message: TMessage);
var
  params: TONInviteClosedParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONInviteClosedParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : call is closed.', [index]));
  Sessions[index].Reset;
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
  index: integer;
begin

  params := TONRemoteHoldParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : Placed on hold by remote.', [index]));
  params.Free;

end;

procedure TForm1.onRemoteUnHold(var Message: TMessage);
var
  params: TONRemoteUnHoldParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONRemoteUnHoldParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : Take off hold by remote.', [index]));
  params.Free;

end;

procedure TForm1.onReceivedRefer(var Message: TMessage);
var
  params: TONReceivedReferParams;
  callbackIndex: NativeInt;
  index: integer;
  i: integer;
  referIndex: integer;
  logText: string;
  referSessionId: NativeInt;
begin

  params := TONReceivedReferParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    sdkLib.rejectRefer(params.referId);
    params.Free;
    Exit;
  end;

   logText := Format('Line %d : Received REFER: , refer to: %s',
    [index, params.referTo]);
  ListBoxLog.Items.Add(logText);


  // Accept the REFER automatically
  referSessionId := sdkLib.acceptRefer(params.referId,
      PAnsiChar(ansistring(params.referTo)));
    if referSessionId = -1 then
    begin
      ListBoxLog.Items.Add('Failed to accept the refer.');
    end
    else
    begin
      sdkLib.hangUp(Sessions[index].GetSessionID());
      Sessions[index].Reset;

      Sessions[index].SetSessionID(referSessionId);
      Sessions[index].SetSessionState(true);

      ListBoxLog.Items.Add('Accepted the REFER');
    end;

  params.Free;

end;

procedure TForm1.onReferAccepted(var Message: TMessage);
var
  params: TONReferAcceptedParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONReferAcceptedParams(Message.LPARAM);

  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : refer(transfer) was accepted.',
    [index]));
  params.Free;

end;

procedure TForm1.onReferRejected(var Message: TMessage);
var
  params: TONReferRejectedParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONReferRejectedParams(Message.LPARAM);

  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : refer(transfer) was rejected.',
    [index]));
  params.Free;

end;

procedure TForm1.onTransferTrying(var Message: TMessage);
var
  params: TONTransferTryingParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONTransferTryingParams(Message.LPARAM);

  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : refer(transfer) is trying.', [index]));
  params.Free;

end;

procedure TForm1.onTransferRinging(var Message: TMessage);
var
  params: TONTransferRingingParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONTransferRingingParams(Message.LPARAM);

  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : refer(transfer) is ringing.',
    [index]));
  params.Free;

end;

procedure TForm1.onACTVTransferSuccess(var Message: TMessage);
var
  params: TONACTVTransferSuccessParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONACTVTransferSuccessParams(Message.LPARAM);

  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

   sdkLib.hangUp(Sessions[index].GetSessionID());
  Sessions[index].Reset;

  ListBoxLog.Items.Add(Format('Line %d : Transfer succeeded, call closed.', [index]));
  params.Free;

end;

procedure TForm1.onACTVTransferFailure(var Message: TMessage);
var
  params: TONACTVTransferFailureParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONACTVTransferFailureParams(Message.LPARAM);

  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : Transfer failure.', [index]));
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
  index: integer;
  dtmfTone: string;
begin

  params := TONRecvDtmfToneParams(Message.LPARAM);

  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  dtmfTone := IntToStr(params.tone);
  case params.tone of
    10:
      dtmfTone := '*';
    11:
      dtmfTone := '#';
    12:
      dtmfTone := 'A';
    13:
      dtmfTone := 'B';
    14:
      dtmfTone := 'C';
    15:
      dtmfTone := 'D';
    16:
      dtmfTone := 'FLASH';
  end;

  ListBoxLog.Items.Add(Format('Line %d : Reveived the DTMF tone: %s',
    [index, dtmfTone]));

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
  index: integer;
  text: string;
begin

  params := TONRecvMessageParams(Message.LPARAM);

  index := findSession(params.sessionId);
  if index = -1 then
  begin
    FreeMem(params.messageData);
    params.Free;
    Exit;
  end;

  text := 'Received a MESSAGE message on line ' + IntToStr(index);
  ShowMessage(text);

  if (params.mimeType = 'text') and (params.subMimeType = 'plain') then
  begin
    // Here is the plain message text: params.messageData
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

procedure TForm1.onRecvOutOfDialogMessage(var Message: TMessage);
var
  params: TONRecvOutOfDialogMessageParams;
  callbackIndex: NativeInt;
  text: string;
begin

  params := TONRecvOutOfDialogMessageParams(Message.LPARAM);
  text := 'Received a MESSAGE message out of dialog.';
  ShowMessage(text);

  if (params.mimeType = 'text') and (params.subMimeType = 'plain') then
  begin
    // Here is the plain message text: params.messageData
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
  index: integer;
begin

  params := TONPlayAudioFileFinishedParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : play audio file %s finished;',
    [index, params.fileName]));

  params.Free;

end;

procedure TForm1.onPlayVideoFileFinished(var Message: TMessage);
var
  params: TONPlayVideoFileFinishedParams;
  callbackIndex: NativeInt;
  index: integer;
begin

  params := TONPlayVideoFileFinishedParams(Message.LPARAM);
  index := findSession(params.sessionId);
  if index = -1 then
  begin
    params.Free;
    Exit;
  end;

  ListBoxLog.Items.Add(Format('Line %d : play video file finished;', [index]));

  params.Free;

end;


///
///

procedure TForm1.releaseSDK;
var
  i: integer;
begin
  if Initialized = false then
  begin
    Exit;
  end;

  for i := LINE_BASE to MAXLINE do
  begin
    if (Sessions[i].GetRecvCallState() = true) then
    begin
      sdkLib.rejectCall(Sessions[i].GetSessionID(), 486);
    end
    else if (Sessions[i].GetSessionState() = true) then
    begin
      sdkLib.hangUp(Sessions[i].GetSessionID());
    end;

    Sessions[i].Reset();
  end;

  if Registered = true then
  begin
    sdkLib.unRegisterServer;
    Registered := false;
  end;

  if Initialized = true then
  begin
    sdkLib.removeUser();
    sdkLib.unInitialize;
    sdkLib.releaseCallbackHandlers;
    Initialized := false;
  end;

  ListBoxLog.Clear();
  CurrentLine := LINE_BASE;
  ComboBoxLines.ItemIndex := 0;
  ComboBoxSpeaker.ItemIndex := 0;
  ComboBoxMicrophone.ItemIndex := 0;
  ComboBoxCamera.ItemIndex := 0;

end;


procedure TForm1.setSrtpPolicy();
var
  srtpPolicy: integer;
begin
  if (Initialized = False)  then
  begin
    Exit;
  end;

  case ComboBoxSRTP.ItemIndex of
  0:  srtpPolicy := SRTP_POLICY_NONE;
  1:  srtpPolicy := SRTP_POLICY_PREFER;
  2:  srtpPolicy := SRTP_POLICY_FORCE;
  end;

  sdkLib.setSrtpPolicy(srtpPolicy, true);

end;

procedure TForm1.updatePrackSetting();
begin
  if (Initialized = False)  then
  begin
    Exit;
  end;

  sdkLib.enableReliableProvisional(checkboxPrack.Checked);

end;

procedure TForm1.initSettings();
var
   SRTPPolicy: integer;
begin

  if (Initialized = False) then
  begin
    Exit;
  end;

  SRTPPolicy := SRTP_POLICY_NONE;
  if ComboBoxSRTP.ItemIndex = 1 then
  begin
     SRTPPolicy := SRTP_POLICY_PREFER;
  end
  else if ComboBoxSRTP.ItemIndex = 2 then
  begin
     SRTPPolicy := SRTP_POLICY_FORCE;
  end;

  sdkLib.setSrtpPolicy(SRTPPolicy, true);

   if CheckBoxAEC.Checked = true then
  begin
    sdkLib.enableAEC(EC_DEFAULT);
  end
  else
  begin
     sdkLib.enableAEC(EC_NONE);
  end;

  sdkLib.enableCNG(CheckBoxCNG.Checked);
  sdkLib.enableVAD(CheckBoxVAD.Checked);
  if CheckBoxAGC.Checked = true then
  begin
    sdkLib.enableAGC(AGC_DEFAULT);
  end
  else
  begin
     sdkLib.enableAGC(AGC_NONE);
  end;

   if CheckBoxANS.Checked = true then
  begin
    sdkLib.enableANS(NS_DEFAULT);
  end
  else
  begin
     sdkLib.enableANS(NS_NONE);
  end;

  sdkLib.setVideoResolution(352, 288);
  sdkLib.setDoNotDisturb(CheckBoxDND.Checked);

end;



procedure TForm1.initDefaultAudioCodecs();
begin

  if (Initialized = False) then
  begin
    Exit;
  end;

    sdkLib.clearAudioCodec();

// Default we just using PCMU, G729, G.722.1
    sdkLib.addAudioCodec(AUDIOCODEC_PCMU);   // G711 uLaw
    sdkLib.addAudioCodec(AUDIOCODEC_G729);   // G729
    sdkLib.addAudioCodec(AUDIOCODEC_PCMA);   // PCMA

    sdkLib.addAudioCodec(AUDIOCODEC_DTMF);   // DTMF
end;




procedure TForm1.initDefaultVideoCodecs();
begin

  if (Initialized = False) then
  begin
    Exit;
  end;

    sdkLib.clearVideoCodec();

// Default we just using H264

    sdkLib.addVideoCodec(VIDEO_CODEC_H264);

end;



procedure TForm1.updateAudioCodecs();
begin
  if (Initialized = False) then
  begin
    Exit;
  end;

  sdkLib.clearAudioCodec();

  if (CheckBoxG711U.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_PCMU);
  end;

   if (CheckBoxG711A.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_PCMA);
  end;

  if (CheckBoxG729.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_G729);
  end;

  if (CheckBoxAMR.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_AMR);
  end;

  if (CheckBoxILBC.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_ILBC);
  end;

  if (CheckBoxGSM.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_GSM);
  end;

  if (CheckBoxG7221.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_G7221);
  end;

  if (CheckBoxG722.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_G722);
  end;

  if (CheckBoxSPEEX.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_SPEEX);
  end;

  if (CheckBoxSPEEXWB.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_SPEEXWB);
  end;

  if (CheckBoxAMRWB.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_AMRWB);
  end;

  if (CheckBoxOpus.Checked = True) then
  begin
    sdkLib.addAudioCodec(AUDIOCODEC_OPUS);
  end;

  sdkLib.addAudioCodec(AUDIOCODEC_DTMF);


end;



procedure TForm1.updateVideoCodecs();
begin
  if (Initialized = False) then
  begin
    Exit;
  end;

  sdkLib.clearVideoCodec();

  if (CheckBoxH263.Checked = True) then
  begin
    sdkLib.addVideoCodec(VIDEO_CODEC_H263);
  end;

   if (CheckBoxH2631998.Checked = True) then
  begin
    sdkLib.addVideoCodec(VIDEO_CODEC_H263_1998);
  end;

  if (CheckBoxH264.Checked = True) then
  begin
    sdkLib.addVideoCodec(VIDEO_CODEC_H264);
  end;

  if (CheckBoxVP8.Checked = True) then
  begin
    sdkLib.addVideoCodec(VIDEO_CODEC_VP8);
  end;


end;




procedure TForm1.updateVideoResolution();
begin
  if (Initialized = False) then
  begin
    Exit;
  end;

  case ComboBoxResolution.ItemIndex of
  0:  sdkLib.setVideoResolution(176, 144);
  1:  sdkLib.setVideoResolution(352, 288);
  2:  sdkLib.setVideoResolution(640, 480);
  3:  sdkLib.setVideoResolution(800, 600);
  4:  sdkLib.setVideoResolution(1024, 768);
  5:  sdkLib.setVideoResolution(1280, 720);
  6:  sdkLib.setVideoResolution(320, 240);
  end;
end;


procedure TForm1.updateVideoQuality();
begin
  if (Initialized = False) then
  begin
    Exit;
  end;
    sdkLib.setVideoBitrate(Sessions[CurrentLine].GetSessionID(), TrackBarQuality.Position);
end;



procedure TForm1.loadDevice;
var
  nums: integer;
  volume: integer;
  deviceName: array[0..255] of AnsiChar;
  uniqueId: array[0..255] of AnsiChar;
  i : integer;
begin
  if (Initialized = False) then
  begin
    Exit;
  end;

   nums := sdkLib.getNumOfPlayoutDevices();
   for i := 0 to nums-1 do
   begin
     if sdkLib.getPlayoutDeviceName(i, @deviceName, 255) = 0 then
     begin
       ComboBoxSpeaker.Items.Add(deviceName);
     end;
   end;

   ComboBoxSpeaker.ItemIndex := 0;

   nums := sdkLib.getNumOfRecordingDevices();
   for i := 0 to nums-1 do
     begin
        if sdkLib.getRecordingDeviceName(i, @deviceName, 255) = 0 then
        begin
          ComboBoxMicrophone.Items.Add(deviceName);
        end;
     end;

     ComboBoxMicrophone.ItemIndex := 0;

     volume := sdkLib.getSpeakerVolume();
     TrackBarSpeaker.Position := volume;

     volume := sdkLib.getMicVolume();
     TrackBarMicrophone.Position := volume;

    nums := sdkLib.getNumOfVideoCaptureDevices();
    for i := 0 to nums-1 do
     begin
        if sdkLib.getVideoCaptureDeviceName(i, @uniqueId, 255, @deviceName, 255) = 0 then
        begin
          ComboBoxCamera.Items.Add(deviceName);
        end;
     end;

     ComboBoxCamera.ItemIndex := 0;

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

procedure TForm1.joinConference(const index: integer);
begin
  if (Initialized = false) then
  begin
    Exit;
  end;

  if CheckBoxConference.Checked = false then
  begin
    Exit;
  end;

  sdkLib.joinToConference(Sessions[index].GetSessionID());

  // We need unhold the line in the conference
  if Sessions[index].GetSessionState = true then
  begin
    sdklib.unHold(Sessions[index].GetSessionID());
    Sessions[index].SetHoldState(false);
  end;
end;

procedure TForm1.Label23Click(Sender: TObject);
begin
ShellExecute(Handle,'open','http://www.portsip.com', nil, nil, sw_shownormal);
end;

procedure TForm1.Label24Click(Sender: TObject);
begin
  ShellExecute(Handle, 'open','mailto:sales@portsip.com', nil, nil, sw_shownormal);
end;

function TForm1.findSession(sessionId: integer): integer;
var
  index: integer;
  i: integer;
begin
  index := -1;
  result:= -1;

  if (Initialized = false) then
  begin
    Exit;
  end;

  for i := LINE_BASE to MAXLINE do
  begin
    if (Sessions[i].GetSessionID() = sessionId) then
    begin
      index := i;
      break;
    end;
  end;

  result := index;
end;

/// /
///

procedure TForm1.FormCreate(Sender: TObject);
var
  text: string;
  i: integer;
begin
  Randomize;

  ComboBoxSpeaker.ItemIndex := 0;
  ComboBoxMicrophone.ItemIndex := 0;
  ComboBoxCamera.ItemIndex := 0;

  for i := 0 to (8) do
  begin
    Sessions[i] := TSession.Create;
    Sessions[i].Reset;
  end;

  Initialized := false;
  Registered := false;
  CurrentLine := LINE_BASE;
  ComboBoxLines.ItemIndex := 0;

  ComboBoxResolution.ItemIndex := 1;
  ComboBoxTransport.ItemIndex := 0;

end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  releaseSDK;
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


  localSipPort := Random(10000) + SIPPORT_MIN;
  localIp := getLocalIp();

 transportType := TRANSPORT_UDP;
  if (ComboBoxTransport.ItemIndex = 1) then
  begin
    transportType := TRANSPORT_TCP;
  end
  else if (ComboBoxTransport.ItemIndex = 2) then
  begin
    transportType := TRANSPORT_TLS;
  end
  else if (ComboBoxTransport.ItemIndex = 3) then
  begin
    transportType := TRANSPORT_PERS;
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



  loadDevice();
  sdkLib.setLocalVideoWindow(LocalVideo.Handle);

  initDefaultAudioCodecs();
  initDefaultVideoCodecs();

  initSettings();

  updateVideoResolution();
  updateVideoQuality();

  if CheckBoxNeedRegisterServer.Checked = true then
  begin
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

end;

procedure TForm1.Button20Click(Sender: TObject);
var
  TransferNumber : String;
  Text : string;
begin
  if ((Initialized = False) or  (checkboxNeedRegisterServer.Checked = True and Registered = False)) then
    begin
      Exit;
    end;

    if (Sessions[CurrentLine].GetSessionState() = False) then
    begin
      ShowMessage('Please make the call established first.');
      Exit;
    end;

    if Form2.ShowModal() <> mrOk then
    begin
      Exit
    end;

    if (length(Form2.Edit1.Text) <= 0) then
    begin
      ShowMessage('The Transfer number is empty');
      Exit;
    end;

    TransferNumber := Form2.Edit1.Text;

    if (sdkLib.refer(Sessions[CurrentLine].GetSessionID(), pansichar(ansistring(TransferNumber))) <> 0) then
    begin
      ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ' : Failed to transfer.');
      Exit
    end;

    ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ' : Transfering...');

end;

procedure TForm1.Button21Click(Sender: TObject);
begin
 if ((Initialized = False) or (checkboxNeedRegisterServer.Checked = True and Registered = False)) then
    begin
      Exit;
    end;

    if (Sessions[CurrentLine].GetRecvCallState() = False) then
    begin
      ShowMessage('Current line do not have incoming call, please switch a line.');
      Exit;
    end;

    Sessions[CurrentLine].SetRecvCallState(False);
    Sessions[CurrentLine].SetSessionState(True);

    if (CheckBoxConference.Checked = False) then
      begin
        sdkLib.setRemoteVideoWindow(Sessions[CurrentLine].GetSessionID(), remoteVideo.Handle);
      end;


    if (sdkLib.answerCall(Sessions[CurrentLine].GetSessionID(), CheckboxAnswerVideoCall.Checked) = 0) then
      begin
        ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ' : Call established');
        JoinConference(CurrentLine);
      end
    else
      begin
        Sessions[CurrentLine].Reset();
        ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ' : Failed to answer call.');
      end;
end;

procedure TForm1.Button23Click(Sender: TObject);
var
  TransferNumber : String;
  Text : string;
  ReplaceLine : Integer;
begin
  if ((Initialized = False) or (checkboxNeedRegisterServer.Checked = True and Registered = False)) then
    begin
      Exit;
    end;

    if (Sessions[CurrentLine].GetSessionState() = False) then
    begin
      ShowMessage('Please make the call established first');
      Exit;
    end;

    if Form2.ShowModal() <> mrOk then
    begin
      Exit
    end;

    if (length(Form2.Edit1.Text) <= 0) then
    begin
      ShowMessage('The Transfer number is empty');
      Exit;
    end;


    if (length(Form2.EditLineNum.Text) <= 0) then
    begin
      ShowMessage('The replace line is empty');
      Exit;
    end;

    ReplaceLine := StrToInt(Form2.EditLineNum.Text);
    if ((ReplaceLine<=0) Or (ReplaceLine>MAXLINE)) then
    begin
      ShowMessage('The replace line out of range');
      Exit;
    end;

    if (Sessions[ReplaceLine].GetSessionState() = False) then
    begin
        ShowMessage('The replace line does not established yet');
      Exit;
    end;

    TransferNumber := Form2.Edit1.Text;

    if (sdkLib.attendedRefer(Sessions[CurrentLine].GetSessionID(), Sessions[ReplaceLine].GetSessionID(), pansichar(ansistring(TransferNumber))) <> 0) then
    begin
      ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ' : Failed to attended transfer.');
      Exit
    end;

    ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ' : Attended transfer: transfering...');
end;

procedure TForm1.Button24Click(Sender: TObject);
var
  deviceName: array[0..256] of Ansichar;
  uniqueId: array[0.. 256] of Ansichar;
  len : integer;
begin
  if sdkLib.getVideoCaptureDeviceName(ComboBoxCamera.ItemIndex,
                                                @uniqueId,
                                                256,
                                                @deviceName,
                                                256) <> 0 then
  begin
    ShowMessage('Failed to get camera name.');
    Exit;
  end;

  if sdkLib.showVideoCaptureSettingsDialogBox(uniqueId,
                                                length(uniqueId),
                                                'Camera settings',
                                                Application.MainForm.Handle,
                                                200,
                                                200 ) <> 0 then
  begin
    ShowMessage('Failed to show the camera settings dialog.');
    Exit;
  end;

end;

procedure TForm1.Button25Click(Sender: TObject);
begin
  if (Initialized = False)  then
  begin
    Exit;
  end;

  if (Button25.Caption = 'Local Video') then
  begin
    sdkLib.displayLocalVideo(true,true);
    Button25.Caption := 'Stop Local';
  end
  else
  begin
    sdkLib.displayLocalVideo(false,false);
    Button25.Caption := 'Local Video';
  end;

end;

procedure TForm1.Button26Click(Sender: TObject);
begin
  if (Initialized = False)  then
  begin
    Exit;
  end;

  if (Sessions[CurrentLine].GetSessionState() = True) or (Sessions[CurrentLine].GetRecvCallState() = True)then
  begin
    if sdkLib.sendVideo(Sessions[CurrentLine].GetSessionID(), true) <> 0 then
    begin
      ShowMessage('Failed send video.');
    end;
  end;
end;

procedure TForm1.Button27Click(Sender: TObject);
begin
  if (Initialized = False)  then
  begin
    Exit;
  end;

  if (Sessions[CurrentLine].GetSessionState() = True) then
  begin
    sdkLib.sendVideo(Sessions[CurrentLine].GetSessionID(), false);
  end;
end;

procedure TForm1.Button28Click(Sender: TObject);
begin
  ListboxLog.Clear();
end;

procedure TForm1.Button29Click(Sender: TObject);
var
  FilePath : string;
begin
  if (SelectDirectory('Please select the directory', 'c:\', FilePath) = True) then
  begin
    EditRecordFilePath.Text := FilePath;
  end;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  releaseSDK;
end;

procedure TForm1.Button30Click(Sender: TObject);
var
  filePath: string;
  fileName: string;
  fileFormat: integer;
begin
 if (Initialized = False)  then
  begin
    ShowMessage('Please initialize the SDK first.');
    Exit;
  end;

  if (length(EditRecordFilePath.Text) = 0) then
  begin
    ShowMessage('Please select a directory');
    Exit;
  end;

  filePath := EditRecordFilePath.Text;

  if (length(EditRecordFileName.Text) = 0) then
  begin
    fileName := 'RecordFile';
  end
  else
  begin
    fileName :=  EditRecordFileName.Text;
  end;

  fileFormat := FILEFORMAT_WAVE;

  if sdkLib.startRecord(Sessions[CurrentLine].GetSessionID(),
                        pansichar(ansistring(FilePath)),
                        pansichar(ansistring(FileName)),
                        true,
                        FileFormat,
                        RECORD_BOTH,
                        VIDEO_CODEC_H264,
                        RECORD_RECV) = 0 then
  begin
     ShowMessage('Start recording audio conversation.');
  end
  else
  begin
     ShowMessage('Failed to start recording audio conversation.');
  end;
end;

procedure TForm1.Button31Click(Sender: TObject);
begin
 if (Initialized = False)  then
  begin
    ShowMessage('Please initialize the SDK first.');
    Exit;
  end;

  sdkLib.stopRecord(Sessions[CurrentLine].GetSessionID());

end;

procedure TForm1.Button32Click(Sender: TObject);
begin
  if (OpenDialog1.Execute() = True) then
  begin
    EditPlayAudioFileName.Text := OpenDialog1.FileName;
  end;
end;

procedure TForm1.Button33Click(Sender: TObject);
begin
if (Initialized = False)  then
  begin
    ShowMessage('Please initialize the SDK first.');
    Exit;
  end;


  if (length(EditPlayAudioFileName.Text) = 0) then
  begin
    ShowMessage('The play file is empty.');
    Exit;
  end;

  sdkLib.playAudioFileToRemote(Sessions[CurrentLine].GetSessionID(),
                                  pansichar(ansistring(EditPlayAudioFileName.Text)),
                                  16000,
                                  false);

end;

procedure TForm1.Button34Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

  sdkLib.stopPlayAudioFileToRemote(Sessions[CurrentLine].GetSessionID());
end;

procedure TForm1.Button37Click(Sender: TObject);
var
   forwardTo : String;
begin
  if (Initialized = False)  then
    begin
      ShowMessage('Please initialize the SDK first.');
      Exit;
    end;

  if ((pos('sip:', EditForwardAddress.Text)=0) or  (pos('@', EditForwardAddress.Text)=0))then
    begin
      ShowMessage('The forward address must likes sip:xxxx@sip.portsip.com.');
      Exit;
    end;

  forwardTo := EditForwardAddress.Text;

  if CheckBoxForwardCallBusy.Checked = True then
    begin
      sdkLib.enableCallForward(true, pansichar(ansistring(forwardTo)));
    end
  else
    begin
      sdkLib.enableCallForward(false, pansichar(ansistring(forwardTo)));
    end;

    ShowMessage('Call forward is enabled.');

end;


procedure TForm1.Button38Click(Sender: TObject);
begin
  if (Initialized = False)  then
    begin
      ShowMessage('Please initialize the SDK first.');
      Exit;
    end;

    sdkLib.disableCallForward();
    ShowMessage('Call forward is disabled.');
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '1';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 1, 160, true);
    end;

end;

procedure TForm1.Button4Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '2';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 2, 160, true);
    end;

end;

procedure TForm1.Button5Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '3';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 3, 160, true);
    end;

end;

procedure TForm1.Button6Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '4';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 4, 160, true);
    end;

end;

procedure TForm1.Button7Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '5';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 5, 160, true);
    end;

end;

procedure TForm1.Button8Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '6';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 6, 160, true);
    end;

end;

procedure TForm1.Button9Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '7';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 7, 160, true);
    end;

end;



procedure TForm1.Button10Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '8';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 8, 160, true);
    end;

end;

procedure TForm1.Button11Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '9';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 9, 160, true);
    end;

end;

procedure TForm1.Button12Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '*';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 10, 160, true);
    end;

end;

procedure TForm1.Button13Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '0';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 0, 160, true);
    end;

end;

procedure TForm1.Button14Click(Sender: TObject);
begin
    if (Initialized = false) then
  begin
    Exit;
  end;

   EditPhoneNumber.Text :=  EditPhoneNumber.Text + '#';
  if ((Initialized = True) and (Sessions[CurrentLine].GetSessionState() = True)) then
    begin
      sdkLib.sendDtmf(Sessions[CurrentLine].GetSessionID(), DTMF_RFC2833, 11, 160, true);
    end;

end;

procedure TForm1.TrackBarMicrophoneChange(Sender: TObject);
begin
  if (Initialized = False) then
  begin
    Exit;
  end;

  sdkLib.setMicVolume(TrackBarMicrophone.Position);
end;

procedure TForm1.TrackBarQualityChange(Sender: TObject);
begin
  if (Initialized = False) then
  begin
    Exit;
  end;

  updateVideoQuality();
end;

procedure TForm1.TrackBarSpeakerChange(Sender: TObject);
begin
  if (Initialized = False) then
  begin
    Exit;
  end;

  sdkLib.setSpeakerVolume(TrackBarSpeaker.Position);
end;

procedure TForm1.Button15Click(Sender: TObject);
var
  sessionId: integer;
  sendSdp : boolean;
begin
  if ((Initialized=False) Or (checkboxNeedRegisterServer.Checked = True and Registered = False)) then
  begin
    Exit;
  end;

   if (length(EditPhoneNumber.Text) <= 0) then
  begin
    ShowMessage('The phone number is empty');
    Exit;
  end;

  if ((Sessions[Currentline].GetSessionState() = True) Or (Sessions[Currentline].GetRecvCallState() = True)) then
  begin
     ShowMessage('Current line is busy, please switch a line');
    Exit;
  end;

  updateAudioCodecs();
  updateVideoCodecs();

  if (sdkLib.isAudioCodecEmpty() = true) then
  begin
    InitDefaultAudioCodecs();
  end;

  sdkLib.setAudioDeviceId(comboBoxMicrophone.ItemIndex, comboBoxSpeaker.ItemIndex);

  sendSdp := true;
  if CheckBoxSdp.Checked = True then
  begin
    sendSdp := false;
  end;

  SessionId := sdkLib.call(pansichar(ansistring(EditPhoneNumber.Text)), sendSdp, CheckboxMakeVideoCall.Checked);
  if (SessionId <= 0) then
  begin
    ListBoxLog.Items.Add('Failed to call.');
    Exit;
  end;

  sdkLib.setRemoteVideoWindow(SessionId, remoteVideo.Handle);

  Sessions[CurrentLine].SetSessionID(SessionId);
  Sessions[CurrentLine].SetSessionState(true);

  Text := 'Line ';
  Text := Text + IntToStr(Currentline);
  Text := Text + ' : calling...';
  ListBoxLog.Items.Add(Text);

end;

procedure TForm1.Button16Click(Sender: TObject);
begin
if ((Initialized = False) or (checkboxNeedRegisterServer.Checked = True and Registered = False)) then
    begin
      Exit;
    end;

    if (Sessions[CurrentLine].GetRecvCallState() = True) then
    begin
      sdkLib.rejectCall(Sessions[CurrentLine].GetSessionID(), 486);
      Sessions[CurrentLine].Reset();
      ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ': Reject the call');
      Exit;
    end;


    if (Sessions[CurrentLine].GetSessionState() = True) then
    begin
      sdkLib.hangUp(Sessions[CurrentLine].GetSessionID());
      Sessions[CurrentLine].Reset();

      ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ': Hang up the call');
      Exit;
    end;
end;

procedure TForm1.Button17Click(Sender: TObject);
begin
  if ((Initialized = False) or (checkboxNeedRegisterServer.Checked = True and Registered = False)) then
    begin
      Exit;
    end;

    if (Sessions[CurrentLine].GetRecvCallState() = True) then
    begin
      sdkLib.rejectCall(Sessions[CurrentLine].GetSessionID(), 486);
      Sessions[CurrentLine].Reset();

      ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ': Rejected the call');
    end;
end;

procedure TForm1.Button18Click(Sender: TObject);
begin
  if ((Initialized = False) or (checkboxNeedRegisterServer.Checked = True and Registered = False)) then
    begin
      Exit;
    end;

    if (Sessions[CurrentLine].GetSessionState() = False) then
    begin
      Exit;
    end;

    if (Sessions[CurrentLine].GetHoldState() = True) then
    begin
      Exit;
    end;

    sdkLib.hold(Sessions[CurrentLine].GetSessionID());
    Sessions[CurrentLine].SetHoldState(True);

    ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ': hold');
end;

procedure TForm1.Button19Click(Sender: TObject);
begin
  if ((Initialized = False) or (checkboxNeedRegisterServer.Checked = True and Registered = False)) then
    begin
      Exit;
    end;

    if (Sessions[CurrentLine].GetSessionState() = False) then
    begin
      Exit;
    end;

    if (Sessions[CurrentLine].GetHoldState() = True) then
    begin
      Exit;
    end;

    sdkLib.unHold(Sessions[CurrentLine].GetSessionID());
    Sessions[CurrentLine].SetHoldState(True);

    ListBoxLog.Items.Add('Line ' + IntToStr(Currentline) + ': un-Hold');
end;




procedure TForm1.CheckBoxAudioStreamCallbackClick(Sender: TObject);
var
  rt: integer;
begin
  if (Initialized = False)  then
  begin
    ShowMessage('Please initialize the SDK first.');
    Exit;
  end;

  if (CheckBoxAudioStreamCallback.Checked = True) then
  begin
    rt := sdkLib.enableAudioStreamCallback(Sessions[CurrentLine].GetSessionID(),
                                          true,
                                          AUDIOSTREAM_REMOTE_PER_CHANNEL,
                                          self,
                                          @AudioRawCallback);
    if rt <> 0 then
    begin
      ShowMessage('Failed to enable the audio stream callback.');
      CheckBoxAudioStreamCallback.Checked := false;
    end
  end
  else
  begin
    sdkLib.enableAudioStreamCallback(Sessions[CurrentLine].GetSessionID(),
                                          false,
                                          AUDIOSTREAM_REMOTE_PER_CHANNEL,
                                          self,
                                          @AudioRawCallback);
  end;
end;



procedure TForm1.CheckBoxDNDClick(Sender: TObject);
begin
  if (Initialized = false) then
  begin
    Exit;
  end;

  sdkLib.setDoNotDisturb(CheckBoxDND.Checked);

end;

procedure TForm1.CheckBoxG711AClick(Sender: TObject);
begin
  updateAudioCodecs();
end;

procedure TForm1.CheckBoxG711UClick(Sender: TObject);
begin
  updateAudioCodecs();
end;

procedure TForm1.CheckBoxG7221Click(Sender: TObject);
begin
  updateAudioCodecs();
end;

procedure TForm1.CheckBoxG722Click(Sender: TObject);
begin
  updateAudioCodecs();
end;

procedure TForm1.CheckBoxG729Click(Sender: TObject);
begin
  updateAudioCodecs();
end;


procedure TForm1.CheckBoxGSMClick(Sender: TObject);
begin
  updateAudioCodecs();
end;

procedure TForm1.CheckBoxH2631998Click(Sender: TObject);
begin
  updateVideoCodecs();
end;

procedure TForm1.CheckBoxH263Click(Sender: TObject);
begin
  updateVideoCodecs();
end;

procedure TForm1.CheckBoxH264Click(Sender: TObject);
begin
  updateVideoCodecs();
end;


procedure TForm1.CheckBoxVP8Click(Sender: TObject);
begin
  updateVideoCodecs();
end;

procedure TForm1.CheckBoxILBCClick(Sender: TObject);
begin
  updateAudioCodecs();
end;

procedure TForm1.CheckBoxAECClick(Sender: TObject);
begin
  if Initialized = True then
   begin
  if CheckBoxAEC.Checked = true then
  begin
    sdkLib.enableAEC(EC_DEFAULT);
  end
  else
  begin
     sdkLib.enableAEC(EC_NONE);
  end;
   end;
end;

procedure TForm1.CheckBoxAGCClick(Sender: TObject);
begin
     if Initialized = True then
   begin
  if CheckBoxAGC.Checked = true then
  begin
    sdkLib.enableAGC(AGC_DEFAULT);
  end
  else
  begin
     sdkLib.enableAGC(AGC_NONE);
  end;
   end;
end;

procedure TForm1.CheckBoxCNGClick(Sender: TObject);
begin
    if Initialized = True then
   begin
     sdkLib.enableCNG(CheckBoxCNG.Checked);
   end;
end;


procedure TForm1.CheckBoxConferenceClick(Sender: TObject);
var
  i : Integer;
  Text : string;
  width, height : Integer;
  rt: integer;
begin

  if (Initialized = False) then
    begin
      CheckBoxConference.Checked := False;
      Exit;
    end;

    width := 352;
    height := 288;
    case ComboBoxResolution.ItemIndex of
  0:
  begin
    width := 176;
    height := 144;
  end;
  1:
  begin
    width := 352;
    height := 288;
  end;
  2:
  begin
    width := 640;
    height := 480;
  end;
  3:
  begin
    width := 800;
    height := 600;
  end;
  4:
   begin
    width := 1024;
    height := 768;
  end;
  5:
   begin
    width := 1280;
    height := 720;
  end;
  6:
   begin
    width := 320;
    height := 240;
  end;
    end;



    if CheckBoxConference.Checked = True then
    begin
      rt := sdkLib.createVideoConference(RemoteVideo.Handle, width, height, false);
      if rt = 0  then
        begin
          ListBoxLog.Items.Add('Make conference succeeded');
          for i := LINE_BASE to MAXLINE do
          begin
            if Sessions[i].GetSessionState() = True  then
            begin
               sdkLib.setRemoteVideoWindow(Sessions[i].GetSessionID(), 0);
              JoinConference(i);
            end;
          end;
        end
      else
        begin
          ListBoxLog.Items.Add('Failed to make conference.');
          CheckBoxConference.Checked := False;
        end;

      Exit;
    end
    else
    begin
    // Stop conference
    // Before stop the conference, MUST place all lines to hold state

       for i := LINE_BASE to MAXLINE do
      begin
        if ((Sessions[i].GetSessionState()=True) and
        (Sessions[i].GetHoldState = False) and
         (i <> CurrentLine)) then
        begin
          sdkLib.hold(Sessions[i].GetSessionID());
          Sessions[i].SetHoldState(True);
          ListBoxLog.Items.Add('Line ' + IntToStr(i) + ': ' + ' place on hold.');
        end;
      end;

      sdkLib.destroyConference();

      if ((Sessions[CurrentLine].GetSessionState()=True) and (Sessions[CurrentLine].GetHoldState = False)) then
        begin
         sdkLib.setRemoteVideoWindow(Sessions[CurrentLine].GetSessionID(), remoteVideo.Handle);
        end;
      ListBoxLog.Items.Add('Taken off Conference');

    end;
end;

procedure TForm1.CheckBoxANSClick(Sender: TObject);
begin
    if Initialized = True then
   begin
   if CheckBoxANS.Checked = true then
  begin
    sdkLib.enableANS(NS_DEFAULT);
  end
  else
  begin
     sdkLib.enableANS(NS_NONE);
  end;
   end;
end;



procedure TForm1.CheckBoxVADClick(Sender: TObject);
begin
   if Initialized = True then
   begin
     sdkLib.enableVAD(CheckBoxVAD.Checked);
   end;
end;



procedure TForm1.CheckBoxAMRClick(Sender: TObject);
begin
  updateAudioCodecs();
end;

procedure TForm1.CheckBoxAMRWBClick(Sender: TObject);
begin
  updateAudioCodecs();
end;



procedure TForm1.CheckBoxSPEEXClick(Sender: TObject);
begin
  updateAudioCodecs();
end;

procedure TForm1.CheckBoxSPEEXWBClick(Sender: TObject);
begin
  updateAudioCodecs();
end;




procedure TForm1.CheckBoxOpusClick(Sender: TObject);
begin
  updateAudioCodecs();
end;



procedure TForm1.CheckBoxPRACKClick(Sender: TObject);
begin
  if (Initialized = False) then
  begin
    Exit;
  end;

  updatePrackSetting();
end;

procedure TForm1.CheckBoxMuteMicrophoneClick(Sender: TObject);
begin
  if (Initialized = False) then
  begin
    Exit;
  end;

  if (CheckBoxMuteMicrophone.Checked = True) then
  begin
    sdkLib.muteMicrophone(true);
  end
  else
  begin
    sdkLib.muteMicrophone(false);
  end;
end;




procedure TForm1.ComboBoxCameraChange(Sender: TObject);
begin
   if Initialized = True then
   begin
     sdkLib.setVideoDeviceId(comboBoxCamera.ItemIndex);
   end;
end;

procedure TForm1.ComboBoxLinesChange(Sender: TObject);
var
  Text : string;
begin
  if ((Initialized=False) Or (checkboxNeedRegisterServer.Checked = True and Registered = False)) then
  begin
    ComboBoxLines.ItemIndex := 0;
    Exit;
  end;

  if (CurrentLine =  (ComboBoxLines.ItemIndex+LINE_BASE)) then Exit;

   if CheckBoxConference.Checked = True then
    begin
      CurrentLine := ComboBoxLines.ItemIndex+LINE_BASE;
      Exit;
    end;

  if ((Sessions[CurrentLine].GetSessionState()=True) and (Sessions[CurrentLine].GetHoldState()=False)) then
  begin
    sdkLib.hold(Sessions[CurrentLine].GetSessionID());
    sdkLib.setRemoteVideoWindow(Sessions[CurrentLine].GetSessionID(), 0);
    Sessions[CurrentLine].SetHoldState(True);

    Text := 'Line ';
    Text := Text + IntToStr(CurrentLine);
    Text := Text + ' : Hold';

    ListBoxLog.Items.Add(Text);

  end;

  CurrentLine := ComboBoxLines.ItemIndex+LINE_BASE;

  if ((Sessions[CurrentLine].GetSessionState()=True) and (Sessions[CurrentLine].GetHoldState()=True)) then
  begin
    sdkLib.unHold(Sessions[CurrentLine].GetSessionID());
    sdkLib.setRemoteVideoWindow(Sessions[CurrentLine].GetSessionID(), RemoteVideo.Handle);
    Sessions[CurrentLine].SetHoldState(False);

    Text := 'Line ';
    Text := Text + IntToStr(CurrentLine);
    Text := Text + ' : unHold - Call established';

    ListBoxLog.Items.Add(Text);
  end;

end;

procedure TForm1.ComboBoxMicrophoneChange(Sender: TObject);
begin
   if Initialized = True then
   begin
     sdkLib.setAudioDeviceId(comboBoxMicrophone.ItemIndex, comboBoxSpeaker.ItemIndex);
   end;
end;

procedure TForm1.ComboBoxResolutionChange(Sender: TObject);
begin
  updateVideoResolution();
end;

procedure TForm1.ComboBoxSpeakerChange(Sender: TObject);
begin
   if Initialized = True then
   begin
     sdkLib.setAudioDeviceId(comboBoxMicrophone.ItemIndex, comboBoxSpeaker.ItemIndex);
   end;
end;

end.
