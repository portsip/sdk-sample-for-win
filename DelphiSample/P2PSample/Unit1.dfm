object Form1: TForm1
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 
    'PortSIP Solutions, Inc. http://www.portsip.com   sales@portsip.c' +
    'om'
  ClientHeight = 621
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
  object Label4: TLabel
    Left = 25
    Top = 8
    Width = 167
    Height = 13
    Cursor = crHandPoint
    Caption = 'Click here to visit PortSIP'#39's website'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsUnderline]
    ParentFont = False
    OnClick = Label4Click
  end
  object Label5: TLabel
    Left = 249
    Top = 8
    Width = 164
    Height = 13
    Cursor = crHandPoint
    Caption = 'Click here to send email to PortSIP'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clBlue
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsUnderline]
    ParentFont = False
    OnClick = Label5Click
  end
  object Label7: TLabel
    Left = 22
    Top = 530
    Width = 54
    Height = 13
    Caption = 'Resolution:'
  end
  object Label8: TLabel
    Left = 177
    Top = 530
    Width = 38
    Height = 13
    Caption = 'Quality:'
  end
  object Label9: TLabel
    Left = 221
    Top = 530
    Width = 32
    Height = 13
    Caption = 'normal'
  end
  object Label23: TLabel
    Left = 399
    Top = 530
    Width = 21
    Height = 13
    Caption = 'Best'
  end
  object Label15: TLabel
    Left = 860
    Top = 123
    Width = 37
    Height = 13
    Caption = 'Camera'
  end
  object Label13: TLabel
    Left = 860
    Top = 101
    Width = 55
    Height = 13
    Caption = 'Microphone'
  end
  object Label14: TLabel
    Left = 860
    Top = 79
    Width = 39
    Height = 13
    Caption = 'Speaker'
  end
  object Label12: TLabel
    Left = 862
    Top = 51
    Width = 55
    Height = 13
    Caption = 'Microphone'
  end
  object Label11: TLabel
    Left = 862
    Top = 29
    Width = 39
    Height = 13
    Caption = 'Speaker'
  end
  object Label10: TLabel
    Left = 863
    Top = 15
    Width = 34
    Height = 13
    Caption = 'Volume'
  end
  object GroupBox1: TGroupBox
    Left = 24
    Top = 31
    Width = 824
    Height = 322
    Caption = 'SIP'
    TabOrder = 0
    object Label1: TLabel
      Left = 16
      Top = 19
      Width = 52
      Height = 13
      Caption = 'User Name'
    end
    object Label2: TLabel
      Left = 16
      Top = 43
      Width = 46
      Height = 13
      Caption = 'Password'
    end
    object Label3: TLabel
      Left = 16
      Top = 70
      Width = 47
      Height = 13
      Caption = 'Local port'
    end
    object Label6: TLabel
      Left = 18
      Top = 98
      Width = 29
      Height = 13
      Caption = 'SRTP:'
    end
    object EditUserName: TEdit
      Left = 81
      Top = 16
      Width = 184
      Height = 21
      TabOrder = 0
    end
    object EditPassword: TEdit
      Left = 81
      Top = 40
      Width = 184
      Height = 21
      PasswordChar = '*'
      TabOrder = 1
    end
    object Button1: TButton
      Left = 226
      Top = 94
      Width = 75
      Height = 22
      Caption = 'Initialize'
      TabOrder = 2
      OnClick = Button1Click
    end
    object Button2: TButton
      Left = 319
      Top = 94
      Width = 75
      Height = 22
      Caption = 'Uninitialize'
      TabOrder = 3
      OnClick = Button2Click
    end
    object Panel1: TPanel
      Left = 15
      Top = 122
      Width = 379
      Height = 2
      BevelOuter = bvLowered
      TabOrder = 5
    end
    object EditPhoneNumber: TEdit
      Left = 16
      Top = 136
      Width = 186
      Height = 21
      TabOrder = 4
    end
    object Button3: TButton
      Left = 16
      Top = 163
      Width = 62
      Height = 22
      Caption = '1'
      TabOrder = 6
      OnClick = Button3Click
    end
    object Button4: TButton
      Left = 78
      Top = 163
      Width = 62
      Height = 22
      Caption = '2'
      TabOrder = 7
      OnClick = Button4Click
    end
    object Button5: TButton
      Left = 140
      Top = 163
      Width = 62
      Height = 22
      Caption = '3'
      TabOrder = 8
      OnClick = Button5Click
    end
    object Button6: TButton
      Left = 16
      Top = 187
      Width = 62
      Height = 22
      Caption = '4'
      TabOrder = 9
      OnClick = Button6Click
    end
    object Button7: TButton
      Left = 78
      Top = 187
      Width = 62
      Height = 22
      Caption = '5'
      TabOrder = 10
      OnClick = Button7Click
    end
    object Button8: TButton
      Left = 140
      Top = 187
      Width = 62
      Height = 22
      Caption = '6'
      TabOrder = 11
      OnClick = Button8Click
    end
    object Button9: TButton
      Left = 16
      Top = 211
      Width = 62
      Height = 22
      Caption = '7'
      TabOrder = 12
      OnClick = Button9Click
    end
    object Button10: TButton
      Left = 78
      Top = 211
      Width = 62
      Height = 22
      Caption = '8'
      TabOrder = 13
      OnClick = Button10Click
    end
    object Button11: TButton
      Left = 140
      Top = 211
      Width = 62
      Height = 22
      Caption = '9'
      TabOrder = 14
      OnClick = Button11Click
    end
    object Button12: TButton
      Left = 16
      Top = 235
      Width = 62
      Height = 22
      Caption = '*'
      TabOrder = 15
      OnClick = Button12Click
    end
    object Button13: TButton
      Left = 78
      Top = 235
      Width = 62
      Height = 22
      Caption = '0'
      TabOrder = 16
      OnClick = Button13Click
    end
    object Button14: TButton
      Left = 140
      Top = 235
      Width = 62
      Height = 22
      Caption = '#'
      TabOrder = 17
      OnClick = Button14Click
    end
    object ComboBoxLines: TComboBox
      Left = 16
      Top = 264
      Width = 186
      Height = 21
      Style = csDropDownList
      TabOrder = 18
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
      Height = 300
      BevelOuter = bvLowered
      TabOrder = 19
    end
    object Button28: TButton
      Left = 424
      Top = 293
      Width = 75
      Height = 22
      Caption = 'Clear'
      TabOrder = 20
      OnClick = Button28Click
    end
    object ListBoxLog: TListBox
      Left = 424
      Top = 16
      Width = 381
      Height = 271
      ItemHeight = 13
      TabOrder = 21
    end
    object EditLocalPort: TEdit
      Left = 81
      Top = 64
      Width = 184
      Height = 21
      TabOrder = 22
      Text = '5060'
    end
    object ComboBoxSRTP: TComboBox
      Left = 57
      Top = 95
      Width = 83
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 23
      Text = 'Noe'
      Items.Strings = (
        'Noe'
        'Prefer'
        'Force')
    end
  end
  object GroupBox2: TGroupBox
    Left = 448
    Top = 359
    Width = 400
    Height = 124
    Caption = 'Audio and Video Recording'
    TabOrder = 1
    object Label17: TLabel
      Left = 16
      Top = 28
      Width = 103
      Height = 13
      Caption = 'Record file direcotory'
    end
    object Label18: TLabel
      Left = 16
      Top = 92
      Width = 80
      Height = 13
      Caption = 'Record file name'
    end
    object Button29: TButton
      Left = 125
      Top = 28
      Width = 75
      Height = 22
      Caption = '...'
      TabOrder = 0
      OnClick = Button29Click
    end
    object EditRecordFilePath: TEdit
      Left = 16
      Top = 62
      Width = 377
      Height = 21
      Color = cl3DLight
      ReadOnly = True
      TabOrder = 1
    end
    object EditRecordFileName: TEdit
      Left = 112
      Top = 92
      Width = 105
      Height = 21
      TabOrder = 2
    end
    object Button30: TButton
      Left = 223
      Top = 92
      Width = 82
      Height = 22
      Caption = 'Start Record'
      TabOrder = 3
      OnClick = Button30Click
    end
    object Button31: TButton
      Left = 311
      Top = 92
      Width = 82
      Height = 22
      Caption = 'Stop Record'
      TabOrder = 4
      OnClick = Button31Click
    end
    object CheckBoxAudioStreamCallback: TCheckBox
      Left = 216
      Top = 28
      Width = 161
      Height = 17
      Caption = 'Audio Stream Callback'
      TabOrder = 5
      OnClick = CheckBoxAudioStreamCallbackClick
    end
  end
  object GroupBox3: TGroupBox
    Left = 448
    Top = 493
    Width = 400
    Height = 105
    Caption = 'Play Audio File to remote'
    TabOrder = 2
    object Label20: TLabel
      Left = 24
      Top = 21
      Width = 55
      Height = 13
      Caption = 'Select a file'
    end
    object Button32: TButton
      Left = 85
      Top = 16
      Width = 75
      Height = 22
      Caption = '...'
      TabOrder = 0
      OnClick = Button32Click
    end
    object EditPlayAudioFileName: TEdit
      Left = 16
      Top = 42
      Width = 369
      Height = 21
      Color = cl3DLight
      ReadOnly = True
      TabOrder = 1
    end
    object Button33: TButton
      Left = 104
      Top = 69
      Width = 76
      Height = 25
      Caption = 'Start'
      TabOrder = 2
      OnClick = Button33Click
    end
    object Button34: TButton
      Left = 202
      Top = 69
      Width = 76
      Height = 25
      Caption = 'Stop'
      TabOrder = 3
      OnClick = Button34Click
    end
  end
  object GroupBox4: TGroupBox
    Left = 854
    Top = 302
    Width = 355
    Height = 140
    Caption = 'Call forward'
    TabOrder = 3
    object Label22: TLabel
      Left = 16
      Top = 32
      Width = 75
      Height = 13
      Caption = 'Forward call to:'
    end
    object CheckBoxForwardCallBusy: TCheckBox
      Left = 16
      Top = 72
      Width = 169
      Height = 17
      Caption = 'Forward call when on phone'
      TabOrder = 0
    end
    object Button37: TButton
      Left = 104
      Top = 96
      Width = 75
      Height = 25
      Caption = 'Enable'
      TabOrder = 1
      OnClick = Button37Click
    end
    object Button38: TButton
      Left = 200
      Top = 96
      Width = 75
      Height = 25
      Caption = 'Disable'
      TabOrder = 2
      OnClick = Button38Click
    end
    object EditForwardAddress: TEdit
      Left = 16
      Top = 51
      Width = 321
      Height = 21
      TabOrder = 3
    end
  end
  object LocalVideo: TPanel
    Left = 22
    Top = 369
    Width = 176
    Height = 144
    TabOrder = 4
  end
  object RemoteVideo: TPanel
    Left = 237
    Top = 369
    Width = 176
    Height = 144
    TabOrder = 5
  end
  object Button27: TButton
    Left = 341
    Top = 553
    Width = 72
    Height = 22
    Caption = 'Stop Video'
    TabOrder = 6
    OnClick = Button27Click
  end
  object Button26: TButton
    Left = 266
    Top = 553
    Width = 72
    Height = 22
    Caption = 'Send Video'
    TabOrder = 7
    OnClick = Button26Click
  end
  object Button25: TButton
    Left = 90
    Top = 554
    Width = 72
    Height = 22
    Caption = 'Local Video'
    TabOrder = 8
    OnClick = Button25Click
  end
  object Button24: TButton
    Left = 18
    Top = 554
    Width = 72
    Height = 22
    Caption = 'Options'
    TabOrder = 9
    OnClick = Button24Click
  end
  object ComboBoxResolution: TComboBox
    Left = 82
    Top = 527
    Width = 56
    Height = 21
    Style = csDropDownList
    TabOrder = 10
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
    Left = 259
    Top = 527
    Width = 134
    Height = 20
    Max = 2000
    Min = 50
    Frequency = 100
    Position = 150
    TabOrder = 11
    TickStyle = tsNone
    OnChange = TrackBarQualityChange
  end
  object CheckBoxMuteMicrophone: TCheckBox
    Left = 1107
    Top = 51
    Width = 114
    Height = 17
    Caption = 'Mute Microphone'
    TabOrder = 12
    OnClick = CheckBoxMuteMicrophoneClick
  end
  object ComboBoxCamera: TComboBox
    Left = 930
    Top = 120
    Width = 279
    Height = 21
    Style = csDropDownList
    TabOrder = 13
    OnChange = ComboBoxCameraChange
  end
  object ComboBoxMicrophone: TComboBox
    Left = 930
    Top = 98
    Width = 279
    Height = 21
    Style = csDropDownList
    TabOrder = 14
    OnChange = ComboBoxMicrophoneChange
  end
  object ComboBoxSpeaker: TComboBox
    Left = 930
    Top = 76
    Width = 279
    Height = 21
    Style = csDropDownList
    TabOrder = 15
    OnChange = ComboBoxSpeakerChange
  end
  object TrackBarMicrophone: TTrackBar
    Left = 923
    Top = 50
    Width = 187
    Height = 18
    Max = 255
    Frequency = 100
    TabOrder = 16
    OnChange = TrackBarMicrophoneChange
  end
  object TrackBarSpeaker: TTrackBar
    Left = 923
    Top = 26
    Width = 187
    Height = 18
    Max = 255
    Frequency = 10
    TabOrder = 17
    OnChange = TrackBarSpeakerChange
  end
  object CheckBoxG711U: TCheckBox
    Left = 860
    Top = 159
    Width = 75
    Height = 17
    Caption = 'G711 uLaw'
    Checked = True
    State = cbChecked
    TabOrder = 18
    OnClick = CheckBoxG711UClick
  end
  object CheckBoxG711A: TCheckBox
    Left = 860
    Top = 184
    Width = 75
    Height = 17
    Caption = 'G711 aLaw'
    Checked = True
    State = cbChecked
    TabOrder = 19
    OnClick = CheckBoxG711AClick
  end
  object CheckBoxGSM: TCheckBox
    Left = 860
    Top = 209
    Width = 75
    Height = 17
    Caption = 'GSM 6.10'
    TabOrder = 20
    OnClick = CheckBoxGSMClick
  end
  object CheckBoxAMR: TCheckBox
    Left = 959
    Top = 209
    Width = 57
    Height = 17
    Caption = 'AMR'
    TabOrder = 21
    OnClick = CheckBoxAMRClick
  end
  object CheckBoxILBC: TCheckBox
    Left = 959
    Top = 184
    Width = 68
    Height = 17
    Caption = 'iLBC'
    TabOrder = 22
    OnClick = CheckBoxILBCClick
  end
  object CheckBoxG729: TCheckBox
    Left = 959
    Top = 159
    Width = 57
    Height = 17
    Caption = 'G729'
    Checked = True
    State = cbChecked
    TabOrder = 23
    OnClick = CheckBoxG729Click
  end
  object CheckBoxG7221: TCheckBox
    Left = 1059
    Top = 159
    Width = 86
    Height = 17
    Caption = 'G.722.1'
    TabOrder = 24
    OnClick = CheckBoxG7221Click
  end
  object CheckBoxAMRWB: TCheckBox
    Left = 1059
    Top = 182
    Width = 86
    Height = 17
    Caption = 'AMR-WB'
    TabOrder = 25
    OnClick = CheckBoxAMRWBClick
  end
  object CheckBoxSPEEXWB: TCheckBox
    Left = 1059
    Top = 205
    Width = 86
    Height = 17
    Caption = 'SPEEX-WB'
    TabOrder = 26
    OnClick = CheckBoxSPEEXWBClick
  end
  object CheckBoxSPEEX: TCheckBox
    Left = 1157
    Top = 182
    Width = 85
    Height = 17
    Caption = 'SPEEX'
    TabOrder = 27
    OnClick = CheckBoxSPEEXClick
  end
  object CheckBoxG722: TCheckBox
    Left = 1157
    Top = 159
    Width = 85
    Height = 17
    Caption = 'G.722'
    TabOrder = 28
    OnClick = CheckBoxG722Click
  end
  object CheckBoxH263: TCheckBox
    Left = 860
    Top = 244
    Width = 80
    Height = 17
    Caption = 'H263 '
    TabOrder = 29
    OnClick = CheckBoxH263Click
  end
  object CheckBoxH2631998: TCheckBox
    Left = 954
    Top = 244
    Width = 87
    Height = 17
    Caption = 'H263-1998'
    TabOrder = 30
    OnClick = CheckBoxH2631998Click
  end
  object CheckBoxH264: TCheckBox
    Left = 1059
    Top = 244
    Width = 112
    Height = 17
    Caption = 'H264'
    Checked = True
    State = cbChecked
    TabOrder = 31
    OnClick = CheckBoxH264Click
  end
  object CheckBoxVP8: TCheckBox
    Left = 1156
    Top = 244
    Width = 60
    Height = 17
    Caption = 'VP8'
    TabOrder = 32
    OnClick = CheckBoxVP8Click
  end
  object CheckBoxOpus: TCheckBox
    Left = 1158
    Top = 205
    Width = 77
    Height = 17
    Caption = 'Opus'
    TabOrder = 33
    OnClick = CheckBoxOpusClick
  end
  object Button23: TButton
    Left = 313
    Top = 324
    Width = 105
    Height = 22
    Caption = 'Attended Transfer'
    TabOrder = 34
    OnClick = Button23Click
  end
  object Button20: TButton
    Left = 232
    Top = 324
    Width = 75
    Height = 22
    Caption = 'Transfer'
    TabOrder = 35
    OnClick = Button20Click
  end
  object Button18: TButton
    Left = 232
    Top = 302
    Width = 75
    Height = 22
    Caption = 'Hold'
    TabOrder = 36
    OnClick = Button18Click
  end
  object Button19: TButton
    Left = 313
    Top = 302
    Width = 105
    Height = 22
    Caption = 'UnHold'
    TabOrder = 37
    OnClick = Button19Click
  end
  object Button17: TButton
    Left = 313
    Top = 274
    Width = 105
    Height = 22
    Caption = 'Reject'
    TabOrder = 38
    OnClick = Button17Click
  end
  object Button21: TButton
    Left = 232
    Top = 280
    Width = 75
    Height = 22
    Caption = 'Answer'
    TabOrder = 39
    OnClick = Button21Click
  end
  object Button15: TButton
    Left = 232
    Top = 261
    Width = 75
    Height = 22
    Caption = 'Dial'
    TabOrder = 40
    OnClick = Button15Click
  end
  object Button16: TButton
    Left = 313
    Top = 258
    Width = 105
    Height = 22
    Caption = 'Hang Up'
    TabOrder = 41
    OnClick = Button16Click
  end
  object CheckBoxAnswerVideoCall: TCheckBox
    Left = 233
    Top = 238
    Width = 121
    Height = 17
    Caption = 'Answer video call'
    Checked = True
    State = cbChecked
    TabOrder = 42
  end
  object CheckBoxMakeVideoCall: TCheckBox
    Left = 233
    Top = 220
    Width = 105
    Height = 17
    Caption = 'Make video call'
    Checked = True
    State = cbChecked
    TabOrder = 43
  end
  object CheckBoxConference: TCheckBox
    Left = 233
    Top = 202
    Width = 89
    Height = 17
    Caption = 'Conference'
    TabOrder = 44
    OnClick = CheckBoxConferenceClick
  end
  object CheckBoxPRACK: TCheckBox
    Left = 324
    Top = 203
    Width = 70
    Height = 17
    Caption = 'PRACK'
    TabOrder = 45
    OnClick = CheckBoxPRACKClick
  end
  object CheckBoxDND: TCheckBox
    Left = 324
    Top = 183
    Width = 89
    Height = 17
    Caption = 'Do not disturb'
    TabOrder = 46
    OnClick = CheckBoxDNDClick
  end
  object CheckBoxAA: TCheckBox
    Left = 233
    Top = 183
    Width = 89
    Height = 17
    Caption = 'Auto Answer'
    TabOrder = 47
  end
  object CheckBoxSDP: TCheckBox
    Left = 233
    Top = 165
    Width = 161
    Height = 17
    Caption = 'Make call without SDP'
    TabOrder = 48
  end
  object CheckBoxAEC: TCheckBox
    Left = 860
    Top = 270
    Width = 57
    Height = 17
    Caption = 'AEC'
    Checked = True
    State = cbChecked
    TabOrder = 49
    OnClick = CheckBoxAECClick
  end
  object CheckBoxCNG: TCheckBox
    Left = 927
    Top = 270
    Width = 57
    Height = 17
    Caption = 'CNG'
    TabOrder = 50
    OnClick = CheckBoxCNGClick
  end
  object CheckBoxVAD: TCheckBox
    Left = 992
    Top = 270
    Width = 57
    Height = 17
    Caption = 'VAD'
    TabOrder = 51
    OnClick = CheckBoxVADClick
  end
  object CheckBoxAGC: TCheckBox
    Left = 1057
    Top = 270
    Width = 57
    Height = 17
    Caption = 'AGC'
    Checked = True
    State = cbChecked
    TabOrder = 52
    OnClick = CheckBoxAGCClick
  end
  object CheckBoxANS: TCheckBox
    Left = 1124
    Top = 270
    Width = 75
    Height = 17
    Caption = 'ANS'
    TabOrder = 53
    OnClick = CheckBoxANSClick
  end
  object OpenDialog1: TOpenDialog
    Filter = 'Wave file|*.wav'
    InitialDir = 'c:\'
    Left = 928
    Top = 496
  end
end
