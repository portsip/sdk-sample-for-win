object Form1: TForm1
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 
    'PortSIP Solutions, Inc. http://www.portsip.com   sales@portsip.c' +
    'om'
  ClientHeight = 684
  ClientWidth = 1244
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label23: TLabel
    Left = 25
    Top = 8
    Width = 167
    Height = 13
    Caption = 'Click here to visit PortSIP'#39's website'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsUnderline]
    ParentFont = False
    OnClick = Label23Click
  end
  object Label24: TLabel
    Left = 314
    Top = 8
    Width = 164
    Height = 13
    Caption = 'Click here to send email to PortSIP'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsUnderline]
    ParentFont = False
    OnClick = Label24Click
  end
  object Label27: TLabel
    Left = 26
    Top = 571
    Width = 54
    Height = 13
    Caption = 'Resolution:'
  end
  object Label28: TLabel
    Left = 214
    Top = 602
    Width = 38
    Height = 13
    Caption = 'Quality:'
  end
  object Label29: TLabel
    Left = 259
    Top = 571
    Width = 33
    Height = 13
    Caption = 'Normal'
  end
  object Label30: TLabel
    Left = 413
    Top = 571
    Width = 21
    Height = 13
    Caption = 'best'
  end
  object Label11: TLabel
    Left = 864
    Top = 50
    Width = 39
    Height = 13
    Caption = 'Speaker'
  end
  object Label15: TLabel
    Left = 860
    Top = 156
    Width = 37
    Height = 13
    Caption = 'Camera'
  end
  object Label13: TLabel
    Left = 860
    Top = 135
    Width = 55
    Height = 13
    Caption = 'Microphone'
  end
  object Label14: TLabel
    Left = 860
    Top = 114
    Width = 39
    Height = 13
    Caption = 'Speaker'
  end
  object Label10: TLabel
    Left = 863
    Top = 36
    Width = 34
    Height = 13
    Caption = 'Volume'
  end
  object Label12: TLabel
    Left = 864
    Top = 72
    Width = 55
    Height = 13
    Caption = 'Microphone'
  end
  object GroupBox1: TGroupBox
    Left = 26
    Top = 28
    Width = 824
    Height = 373
    Caption = 'SIP'
    TabOrder = 0
    object Label1: TLabel
      Left = 16
      Top = 16
      Width = 52
      Height = 13
      Caption = 'User Name'
    end
    object Label2: TLabel
      Left = 212
      Top = 16
      Width = 46
      Height = 13
      Caption = 'Password'
    end
    object Label3: TLabel
      Left = 212
      Top = 82
      Width = 55
      Height = 13
      Caption = 'Server Port'
    end
    object Label4: TLabel
      Left = 16
      Top = 82
      Width = 51
      Height = 13
      Caption = 'SIP Server'
    end
    object Label5: TLabel
      Left = 212
      Top = 104
      Width = 49
      Height = 13
      Caption = 'STUN Port'
    end
    object Label6: TLabel
      Left = 16
      Top = 104
      Width = 61
      Height = 13
      Caption = 'STUN Server'
    end
    object Label8: TLabel
      Left = 11
      Top = 38
      Width = 64
      Height = 13
      Caption = 'Display Name'
    end
    object Label9: TLabel
      Left = 11
      Top = 60
      Width = 60
      Height = 13
      Caption = 'User Domain'
    end
    object Label7: TLabel
      Left = 207
      Top = 38
      Width = 53
      Height = 13
      Caption = 'Auth Name'
    end
    object Label25: TLabel
      Left = 16
      Top = 131
      Width = 51
      Height = 13
      Caption = 'Transport:'
    end
    object Label26: TLabel
      Left = 138
      Top = 131
      Width = 29
      Height = 13
      Caption = 'SRTP:'
    end
    object EditUserName: TEdit
      Left = 81
      Top = 13
      Width = 121
      Height = 21
      TabOrder = 0
    end
    object EditPassword: TEdit
      Left = 273
      Top = 13
      Width = 121
      Height = 21
      PasswordChar = '*'
      TabOrder = 1
    end
    object EditSIPServerPort: TEdit
      Left = 274
      Top = 79
      Width = 121
      Height = 21
      TabOrder = 6
      Text = '5060'
    end
    object EditSIPServer: TEdit
      Left = 81
      Top = 79
      Width = 121
      Height = 21
      TabOrder = 5
    end
    object EditStunServerPort: TEdit
      Left = 274
      Top = 101
      Width = 121
      Height = 21
      TabOrder = 8
    end
    object EditStunServer: TEdit
      Left = 81
      Top = 101
      Width = 121
      Height = 21
      TabOrder = 7
    end
    object Button1: TButton
      Left = 238
      Top = 150
      Width = 75
      Height = 22
      Caption = 'Online'
      TabOrder = 9
      OnClick = Button1Click
    end
    object Button2: TButton
      Left = 319
      Top = 150
      Width = 75
      Height = 22
      Caption = 'Offline'
      TabOrder = 10
      OnClick = Button2Click
    end
    object Panel1: TPanel
      Left = 16
      Top = 181
      Width = 379
      Height = 2
      BevelOuter = bvLowered
      TabOrder = 12
    end
    object EditPhoneNumber: TEdit
      Left = 16
      Top = 196
      Width = 186
      Height = 21
      TabOrder = 11
    end
    object Button3: TButton
      Left = 16
      Top = 223
      Width = 62
      Height = 22
      Caption = '1'
      TabOrder = 13
      OnClick = Button3Click
    end
    object Button4: TButton
      Left = 78
      Top = 223
      Width = 62
      Height = 22
      Caption = '2'
      TabOrder = 14
      OnClick = Button4Click
    end
    object Button5: TButton
      Left = 140
      Top = 223
      Width = 62
      Height = 22
      Caption = '3'
      TabOrder = 15
      OnClick = Button5Click
    end
    object Button6: TButton
      Left = 16
      Top = 247
      Width = 62
      Height = 22
      Caption = '4'
      TabOrder = 16
      OnClick = Button6Click
    end
    object Button7: TButton
      Left = 78
      Top = 247
      Width = 62
      Height = 22
      Caption = '5'
      TabOrder = 17
      OnClick = Button7Click
    end
    object Button8: TButton
      Left = 140
      Top = 247
      Width = 62
      Height = 22
      Caption = '6'
      TabOrder = 18
      OnClick = Button8Click
    end
    object Button9: TButton
      Left = 16
      Top = 271
      Width = 62
      Height = 22
      Caption = '7'
      TabOrder = 19
      OnClick = Button9Click
    end
    object Button10: TButton
      Left = 78
      Top = 271
      Width = 62
      Height = 22
      Caption = '8'
      TabOrder = 20
      OnClick = Button10Click
    end
    object Button11: TButton
      Left = 140
      Top = 271
      Width = 62
      Height = 22
      Caption = '9'
      TabOrder = 21
      OnClick = Button11Click
    end
    object Button12: TButton
      Left = 16
      Top = 295
      Width = 62
      Height = 22
      Caption = '*'
      TabOrder = 22
      OnClick = Button12Click
    end
    object Button13: TButton
      Left = 78
      Top = 295
      Width = 62
      Height = 22
      Caption = '0'
      TabOrder = 23
      OnClick = Button13Click
    end
    object Button14: TButton
      Left = 140
      Top = 295
      Width = 62
      Height = 22
      Caption = '#'
      TabOrder = 24
      OnClick = Button14Click
    end
    object ComboBoxLines: TComboBox
      Left = 16
      Top = 323
      Width = 186
      Height = 21
      Style = csDropDownList
      TabOrder = 25
      OnChange = ComboBoxLinesChange
      Items.Strings = (
        'LINE-1'
        'LINE-2'
        'LINE-3'
        'LINE-4'
        'LINE-5'
        'LINE-6'
        'LINE-7'
        'LINE-8')
    end
    object Panel4: TPanel
      Left = 410
      Top = 16
      Width = 2
      Height = 340
      BevelOuter = bvLowered
      TabOrder = 26
    end
    object Button28: TButton
      Left = 418
      Top = 345
      Width = 75
      Height = 22
      Caption = 'Clear'
      TabOrder = 27
      OnClick = Button28Click
    end
    object ListBoxLog: TListBox
      Left = 418
      Top = 15
      Width = 391
      Height = 324
      ItemHeight = 13
      TabOrder = 28
    end
    object EditUserDomain: TEdit
      Left = 81
      Top = 57
      Width = 121
      Height = 21
      TabOrder = 4
    end
    object EditDisplayName: TEdit
      Left = 81
      Top = 35
      Width = 121
      Height = 21
      TabOrder = 2
    end
    object EditAuthName: TEdit
      Left = 273
      Top = 35
      Width = 121
      Height = 21
      TabOrder = 3
    end
    object ComboBoxTransport: TComboBox
      Left = 73
      Top = 128
      Width = 48
      Height = 21
      Style = csDropDownList
      TabOrder = 29
      Items.Strings = (
        'UDP'
        'TCP'
        'TLS'
        'PERS')
    end
    object ComboBoxSRTP: TComboBox
      Left = 168
      Top = 128
      Width = 49
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 30
      Text = 'None'
      Items.Strings = (
        'None'
        'Prefer'
        'Force')
    end
    object CheckBoxNeedRegisterServer: TCheckBox
      Left = 238
      Top = 127
      Width = 143
      Height = 17
      Caption = 'Register to server'
      Checked = True
      State = cbChecked
      TabOrder = 31
    end
    object Button23: TButton
      Left = 288
      Top = 348
      Width = 105
      Height = 22
      Caption = 'Attended Transfer'
      TabOrder = 32
      OnClick = Button23Click
    end
    object Button20: TButton
      Left = 207
      Top = 348
      Width = 75
      Height = 22
      Caption = 'Transfer'
      TabOrder = 33
      OnClick = Button20Click
    end
    object Button18: TButton
      Left = 207
      Top = 326
      Width = 75
      Height = 22
      Caption = 'Hold'
      TabOrder = 34
      OnClick = Button18Click
    end
    object Button19: TButton
      Left = 288
      Top = 326
      Width = 105
      Height = 22
      Caption = 'UnHold'
      TabOrder = 35
      OnClick = Button19Click
    end
    object Button17: TButton
      Left = 288
      Top = 304
      Width = 105
      Height = 22
      Caption = 'Reject'
      TabOrder = 36
      OnClick = Button17Click
    end
    object Button21: TButton
      Left = 207
      Top = 304
      Width = 75
      Height = 22
      Caption = 'Answer'
      TabOrder = 37
      OnClick = Button21Click
    end
    object Button15: TButton
      Left = 207
      Top = 282
      Width = 75
      Height = 22
      Caption = 'Dial'
      TabOrder = 38
      OnClick = Button15Click
    end
    object Button16: TButton
      Left = 288
      Top = 282
      Width = 105
      Height = 22
      Caption = 'Hang Up'
      TabOrder = 39
      OnClick = Button16Click
    end
    object CheckBoxAnswerVideoCall: TCheckBox
      Left = 208
      Top = 262
      Width = 121
      Height = 17
      Caption = 'Answer video call'
      Checked = True
      State = cbChecked
      TabOrder = 40
    end
    object CheckBoxMakeVideoCall: TCheckBox
      Left = 208
      Top = 244
      Width = 105
      Height = 17
      Caption = 'Make video call'
      Checked = True
      State = cbChecked
      TabOrder = 41
    end
    object CheckBoxConference: TCheckBox
      Left = 208
      Top = 226
      Width = 89
      Height = 17
      Caption = 'Conference'
      TabOrder = 42
      OnClick = CheckBoxConferenceClick
    end
    object CheckBoxPRACK: TCheckBox
      Left = 299
      Top = 227
      Width = 70
      Height = 17
      Caption = 'PRACK'
      TabOrder = 43
      OnClick = CheckBoxPRACKClick
    end
    object CheckBoxDND: TCheckBox
      Left = 299
      Top = 207
      Width = 89
      Height = 17
      Caption = 'Do not disturb'
      TabOrder = 44
      OnClick = CheckBoxDNDClick
    end
    object CheckBoxAA: TCheckBox
      Left = 208
      Top = 207
      Width = 89
      Height = 17
      Caption = 'Auto Answer'
      TabOrder = 45
    end
    object CheckBoxSDP: TCheckBox
      Left = 208
      Top = 189
      Width = 161
      Height = 17
      Caption = 'Make call without SDP'
      TabOrder = 46
    end
  end
  object Panel7: TPanel
    Left = 860
    Top = 288
    Width = 360
    Height = 2
    BevelOuter = bvLowered
    TabOrder = 1
  end
  object GroupBox2: TGroupBox
    Left = 441
    Top = 407
    Width = 410
    Height = 125
    Caption = 'Audio and Video Recording'
    TabOrder = 2
    object Label17: TLabel
      Left = 16
      Top = 36
      Width = 103
      Height = 13
      Caption = 'Record file direcotory'
    end
    object Label18: TLabel
      Left = 16
      Top = 95
      Width = 80
      Height = 13
      Caption = 'Record file name'
    end
    object Button29: TButton
      Left = 125
      Top = 31
      Width = 75
      Height = 22
      Caption = '...'
      TabOrder = 0
      OnClick = Button29Click
    end
    object EditRecordFilePath: TEdit
      Left = 16
      Top = 64
      Width = 377
      Height = 21
      Color = cl3DLight
      ReadOnly = True
      TabOrder = 1
    end
    object EditRecordFileName: TEdit
      Left = 134
      Top = 92
      Width = 83
      Height = 21
      TabOrder = 2
    end
    object Button30: TButton
      Left = 223
      Top = 91
      Width = 82
      Height = 22
      Caption = 'Start Record'
      TabOrder = 3
      OnClick = Button30Click
    end
    object Button31: TButton
      Left = 311
      Top = 91
      Width = 82
      Height = 22
      Caption = 'Stop Record'
      TabOrder = 4
      OnClick = Button31Click
    end
    object CheckBoxAudioStreamCallback: TCheckBox
      Left = 216
      Top = 34
      Width = 161
      Height = 17
      Caption = 'Audio Stream Callback'
      TabOrder = 5
      OnClick = CheckBoxAudioStreamCallbackClick
    end
  end
  object GroupBox3: TGroupBox
    Left = 441
    Top = 546
    Width = 410
    Height = 110
    Caption = 'Play Audio File to remote'
    TabOrder = 3
    object Label20: TLabel
      Left = 24
      Top = 25
      Width = 55
      Height = 13
      Caption = 'Select a file'
    end
    object Button32: TButton
      Left = 85
      Top = 19
      Width = 75
      Height = 22
      Caption = '...'
      TabOrder = 0
      OnClick = Button32Click
    end
    object EditPlayAudioFileName: TEdit
      Left = 16
      Top = 50
      Width = 377
      Height = 21
      Color = cl3DLight
      ReadOnly = True
      TabOrder = 1
    end
    object Button33: TButton
      Left = 122
      Top = 75
      Width = 76
      Height = 25
      Caption = 'Start'
      TabOrder = 2
      OnClick = Button33Click
    end
    object Button34: TButton
      Left = 220
      Top = 75
      Width = 76
      Height = 25
      Caption = 'Stop'
      TabOrder = 3
      OnClick = Button34Click
    end
  end
  object GroupBox4: TGroupBox
    Left = 857
    Top = 327
    Width = 344
    Height = 133
    Caption = 'Call forward'
    TabOrder = 4
    object Label22: TLabel
      Left = 16
      Top = 24
      Width = 75
      Height = 13
      Caption = 'Forward call to:'
    end
    object CheckBoxForwardCallBusy: TCheckBox
      Left = 16
      Top = 64
      Width = 169
      Height = 17
      Caption = 'Forward call when on phone'
      TabOrder = 0
    end
    object Button37: TButton
      Left = 85
      Top = 90
      Width = 75
      Height = 25
      Caption = 'Enable'
      TabOrder = 1
      OnClick = Button37Click
    end
    object Button38: TButton
      Left = 181
      Top = 90
      Width = 75
      Height = 25
      Caption = 'Disable'
      TabOrder = 2
      OnClick = Button38Click
    end
    object EditForwardAddress: TEdit
      Left = 16
      Top = 40
      Width = 313
      Height = 21
      TabOrder = 3
    end
  end
  object LocalVideo: TPanel
    Left = 25
    Top = 414
    Width = 176
    Height = 144
    TabOrder = 5
  end
  object RemoteVideo: TPanel
    Left = 257
    Top = 414
    Width = 176
    Height = 144
    TabOrder = 6
  end
  object Button27: TButton
    Left = 362
    Top = 599
    Width = 72
    Height = 22
    Caption = 'Stop Video'
    TabOrder = 7
    OnClick = Button27Click
  end
  object Button26: TButton
    Left = 258
    Top = 599
    Width = 72
    Height = 22
    Caption = 'Send Video'
    TabOrder = 8
    OnClick = Button26Click
  end
  object Button25: TButton
    Left = 130
    Top = 599
    Width = 72
    Height = 22
    Caption = 'Local Video'
    TabOrder = 9
    OnClick = Button25Click
  end
  object Button24: TButton
    Left = 25
    Top = 599
    Width = 72
    Height = 22
    Caption = 'Options'
    TabOrder = 10
    OnClick = Button24Click
  end
  object ComboBoxResolution: TComboBox
    Left = 86
    Top = 567
    Width = 84
    Height = 21
    Style = csDropDownList
    TabOrder = 11
    OnChange = ComboBoxResolutionChange
    Items.Strings = (
      'QCIF'
      'CIF'
      'VGA'
      'SVGA'
      'XVGA'
      '720P'
      'QVGA')
  end
  object TrackBarQuality: TTrackBar
    Left = 298
    Top = 567
    Width = 109
    Height = 26
    Max = 2000
    Min = 50
    Frequency = 100
    Position = 150
    TabOrder = 12
    TickStyle = tsNone
    OnChange = TrackBarQualityChange
  end
  object ComboBoxCamera: TComboBox
    Left = 923
    Top = 153
    Width = 235
    Height = 21
    Style = csDropDownList
    TabOrder = 13
    OnChange = ComboBoxCameraChange
  end
  object ComboBoxMicrophone: TComboBox
    Left = 923
    Top = 131
    Width = 235
    Height = 21
    Style = csDropDownList
    TabOrder = 14
    OnChange = ComboBoxMicrophoneChange
  end
  object ComboBoxSpeaker: TComboBox
    Left = 923
    Top = 108
    Width = 235
    Height = 21
    Style = csDropDownList
    TabOrder = 15
    OnChange = ComboBoxSpeakerChange
  end
  object Panel3: TPanel
    Left = 860
    Top = 100
    Width = 310
    Height = 2
    BevelOuter = bvLowered
    TabOrder = 16
  end
  object Panel2: TPanel
    Left = 860
    Top = 30
    Width = 310
    Height = 2
    BevelOuter = bvLowered
    TabOrder = 17
  end
  object TrackBarSpeaker: TTrackBar
    Left = 923
    Top = 47
    Width = 201
    Height = 18
    Max = 255
    Frequency = 10
    TabOrder = 18
    OnChange = TrackBarSpeakerChange
  end
  object TrackBarMicrophone: TTrackBar
    Left = 923
    Top = 71
    Width = 201
    Height = 18
    Max = 255
    Frequency = 10
    TabOrder = 19
    OnChange = TrackBarMicrophoneChange
  end
  object CheckBoxMuteMicrophone: TCheckBox
    Left = 1130
    Top = 71
    Width = 77
    Height = 17
    Caption = 'Mute Mic'
    TabOrder = 20
    OnClick = CheckBoxMuteMicrophoneClick
  end
  object CheckBoxAMRWB: TCheckBox
    Left = 1125
    Top = 187
    Width = 97
    Height = 17
    Caption = 'AMR-WB'
    TabOrder = 21
    OnClick = CheckBoxAMRWBClick
  end
  object CheckBoxG7221: TCheckBox
    Left = 1042
    Top = 187
    Width = 77
    Height = 17
    Caption = 'G.722.1'
    TabOrder = 22
    OnClick = CheckBoxG7221Click
  end
  object CheckBoxG729: TCheckBox
    Left = 959
    Top = 187
    Width = 57
    Height = 17
    Caption = 'G729'
    Checked = True
    State = cbChecked
    TabOrder = 23
    OnClick = CheckBoxG729Click
  end
  object CheckBoxG711U: TCheckBox
    Left = 861
    Top = 187
    Width = 75
    Height = 17
    Caption = 'G711 uLaw'
    Checked = True
    State = cbChecked
    TabOrder = 24
    OnClick = CheckBoxG711UClick
  end
  object CheckBoxG711A: TCheckBox
    Left = 861
    Top = 210
    Width = 75
    Height = 17
    Caption = 'G711 aLaw'
    Checked = True
    State = cbChecked
    TabOrder = 25
    OnClick = CheckBoxG711AClick
  end
  object CheckBoxAMR: TCheckBox
    Left = 959
    Top = 211
    Width = 57
    Height = 17
    Caption = 'AMR'
    TabOrder = 26
    OnClick = CheckBoxAMRClick
  end
  object CheckBoxG722: TCheckBox
    Left = 1042
    Top = 210
    Width = 77
    Height = 17
    Caption = 'G.722'
    TabOrder = 27
    OnClick = CheckBoxG722Click
  end
  object CheckBoxSPEEXWB: TCheckBox
    Left = 1125
    Top = 210
    Width = 97
    Height = 17
    Caption = 'SPEEX-WB'
    TabOrder = 28
    OnClick = CheckBoxSPEEXWBClick
  end
  object CheckBoxSPEEX: TCheckBox
    Left = 1042
    Top = 233
    Width = 77
    Height = 17
    Caption = 'SPEEX'
    TabOrder = 29
    OnClick = CheckBoxSPEEXClick
  end
  object CheckBoxILBC: TCheckBox
    Left = 959
    Top = 234
    Width = 68
    Height = 17
    Caption = 'iLBC'
    TabOrder = 30
    OnClick = CheckBoxILBCClick
  end
  object CheckBoxGSM: TCheckBox
    Left = 861
    Top = 233
    Width = 75
    Height = 17
    Caption = 'GSM 6.10'
    TabOrder = 31
    OnClick = CheckBoxGSMClick
  end
  object CheckBoxH2631998: TCheckBox
    Left = 959
    Top = 265
    Width = 87
    Height = 17
    Caption = 'H263-1998'
    TabOrder = 32
    OnClick = CheckBoxH2631998Click
  end
  object CheckBoxH263: TCheckBox
    Left = 861
    Top = 264
    Width = 75
    Height = 17
    Caption = 'H263 '
    TabOrder = 33
    OnClick = CheckBoxH263Click
  end
  object CheckBoxH264: TCheckBox
    Left = 1042
    Top = 265
    Width = 112
    Height = 17
    Caption = 'H264'
    Checked = True
    State = cbChecked
    TabOrder = 34
    OnClick = CheckBoxH264Click
  end
  object CheckBoxVP8: TCheckBox
    Left = 1125
    Top = 265
    Width = 97
    Height = 17
    Caption = 'VP8'
    TabOrder = 35
    OnClick = CheckBoxVP8Click
  end
  object CheckBoxAGC: TCheckBox
    Left = 1054
    Top = 298
    Width = 57
    Height = 17
    Caption = 'AGC'
    Checked = True
    State = cbChecked
    TabOrder = 36
    OnClick = CheckBoxAGCClick
  end
  object CheckBoxVAD: TCheckBox
    Left = 989
    Top = 298
    Width = 57
    Height = 17
    Caption = 'VAD'
    TabOrder = 37
    OnClick = CheckBoxVADClick
  end
  object CheckBoxCNG: TCheckBox
    Left = 924
    Top = 299
    Width = 57
    Height = 17
    Caption = 'CNG'
    TabOrder = 38
    OnClick = CheckBoxCNGClick
  end
  object CheckBoxAEC: TCheckBox
    Left = 860
    Top = 298
    Width = 57
    Height = 17
    Caption = 'AEC'
    Checked = True
    State = cbChecked
    TabOrder = 39
    OnClick = CheckBoxAECClick
  end
  object Panel6: TPanel
    Left = 860
    Top = 256
    Width = 360
    Height = 2
    BevelOuter = bvLowered
    TabOrder = 40
  end
  object CheckBoxANS: TCheckBox
    Left = 1121
    Top = 296
    Width = 97
    Height = 17
    Caption = 'ANS'
    TabOrder = 41
    OnClick = CheckBoxANSClick
  end
  object CheckBoxOpus: TCheckBox
    Left = 1125
    Top = 233
    Width = 97
    Height = 17
    Caption = 'Opus'
    TabOrder = 42
    OnClick = CheckBoxOpusClick
  end
  object OpenDialog1: TOpenDialog
    Filter = 'Wave file|*.wav'
    InitialDir = 'c:\'
    Left = 888
    Top = 537
  end
end
