object Form1: TForm1
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 
    'PortSIP Solutions, Inc. http://www.portsip.com   sales@portsip.c' +
    'om'
  ClientHeight = 685
  ClientWidth = 784
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
  object Label15: TLabel
    Left = 26
    Top = 9
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
  end
  object Label17: TLabel
    Left = 256
    Top = 9
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
  end
  object GroupBox1: TGroupBox
    Left = 26
    Top = 28
    Width = 729
    Height = 629
    Caption = 'SIP SIMPLE'
    TabOrder = 0
    object Label16: TLabel
      Left = 424
      Top = 16
      Width = 22
      Height = 13
      Caption = 'Logs'
    end
    object Label10: TLabel
      Left = 16
      Top = 220
      Width = 43
      Height = 13
      Caption = 'Contacts'
    end
    object Label11: TLabel
      Left = 400
      Top = 239
      Width = 196
      Height = 13
      Caption = 'Must likes sip:username@sip.portsip.com'
    end
    object Label12: TLabel
      Left = 400
      Top = 326
      Width = 48
      Height = 13
      Caption = 'My Status'
    end
    object Label13: TLabel
      Left = 400
      Top = 413
      Width = 69
      Height = 13
      Caption = 'Send Message'
    end
    object Label14: TLabel
      Left = 400
      Top = 571
      Width = 241
      Height = 13
      Caption = 'Send to(Must likes sip:username@sip.portsip.com)'
    end
    object Label9: TLabel
      Left = 11
      Top = 60
      Width = 60
      Height = 13
      Caption = 'User Domain'
    end
    object Label6: TLabel
      Left = 16
      Top = 104
      Width = 61
      Height = 13
      Caption = 'STUN Server'
    end
    object Label5: TLabel
      Left = 212
      Top = 104
      Width = 49
      Height = 13
      Caption = 'STUN Port'
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
    object Label8: TLabel
      Left = 11
      Top = 38
      Width = 64
      Height = 13
      Caption = 'Display Name'
    end
    object Label7: TLabel
      Left = 207
      Top = 38
      Width = 53
      Height = 13
      Caption = 'Auth Name'
    end
    object Label2: TLabel
      Left = 212
      Top = 16
      Width = 46
      Height = 13
      Caption = 'Password'
    end
    object Label1: TLabel
      Left = 16
      Top = 16
      Width = 52
      Height = 13
      Caption = 'User Name'
    end
    object Panel4: TPanel
      Left = 410
      Top = 16
      Width = 2
      Height = 153
      BevelOuter = bvLowered
      TabOrder = 9
    end
    object ListBoxLog: TListBox
      Left = 424
      Top = 16
      Width = 289
      Height = 148
      ItemHeight = 13
      TabOrder = 10
    end
    object ContactsList: TListView
      Left = 16
      Top = 239
      Width = 362
      Height = 326
      Columns = <
        item
          Caption = 'SIP Uri'
          Width = 215
        end
        item
          Caption = 'Status'
          Width = 115
        end>
      GridLines = True
      RowSelect = True
      TabOrder = 11
      ViewStyle = vsReport
    end
    object AddContactName: TEdit
      Left = 400
      Top = 258
      Width = 313
      Height = 21
      TabOrder = 12
    end
    object Button3: TButton
      Left = 400
      Top = 285
      Width = 75
      Height = 25
      Caption = 'Add contact'
      TabOrder = 13
      OnClick = Button3Click
    end
    object Panel2: TPanel
      Left = 400
      Top = 318
      Width = 313
      Height = 2
      BevelOuter = bvLowered
      TabOrder = 14
    end
    object StatusText: TEdit
      Left = 400
      Top = 345
      Width = 313
      Height = 21
      TabOrder = 15
    end
    object Button4: TButton
      Left = 400
      Top = 372
      Width = 105
      Height = 25
      Caption = 'Set Status'
      TabOrder = 16
      OnClick = Button4Click
    end
    object Panel3: TPanel
      Left = 400
      Top = 405
      Width = 313
      Height = 2
      BevelOuter = bvLowered
      TabOrder = 17
    end
    object SendMessage: TMemo
      Left = 400
      Top = 432
      Width = 313
      Height = 133
      TabOrder = 18
    end
    object SendTo: TEdit
      Left = 400
      Top = 596
      Width = 241
      Height = 21
      TabOrder = 19
    end
    object Button5: TButton
      Left = 647
      Top = 594
      Width = 75
      Height = 25
      Caption = 'Send'
      TabOrder = 21
      OnClick = Button5Click
    end
    object Button6: TButton
      Left = 15
      Top = 594
      Width = 106
      Height = 25
      Caption = 'Delete Contact'
      TabOrder = 20
      OnClick = Button6Click
    end
    object EditStunServer: TEdit
      Left = 81
      Top = 101
      Width = 121
      Height = 21
      TabOrder = 7
    end
    object EditStunServerPort: TEdit
      Left = 274
      Top = 101
      Width = 121
      Height = 21
      TabOrder = 8
    end
    object EditSIPServerPort: TEdit
      Left = 274
      Top = 79
      Width = 121
      Height = 21
      TabOrder = 6
    end
    object EditSIPServer: TEdit
      Left = 81
      Top = 79
      Width = 121
      Height = 21
      TabOrder = 5
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
    object EditPassword: TEdit
      Left = 273
      Top = 13
      Width = 121
      Height = 21
      PasswordChar = '*'
      TabOrder = 1
    end
    object EditUserName: TEdit
      Left = 81
      Top = 13
      Width = 121
      Height = 21
      TabOrder = 0
    end
    object Button1: TButton
      Left = 228
      Top = 191
      Width = 75
      Height = 22
      Caption = 'Online'
      TabOrder = 23
      OnClick = Button1Click
    end
    object Button2: TButton
      Left = 319
      Top = 191
      Width = 75
      Height = 22
      Caption = 'Offline'
      TabOrder = 22
      OnClick = Button2Click
    end
    object Panel5: TPanel
      Left = 15
      Top = 128
      Width = 379
      Height = 41
      TabOrder = 24
      object RadioButton1: TRadioButton
        Left = 5
        Top = 8
        Width = 156
        Height = 17
        Caption = 'Peer to Peer Presence mode'
        Checked = True
        TabOrder = 0
        TabStop = True
      end
      object RadioButton2: TRadioButton
        Left = 175
        Top = 8
        Width = 154
        Height = 17
        Caption = 'Presence Agent Mode'
        TabOrder = 1
      end
    end
  end
end
