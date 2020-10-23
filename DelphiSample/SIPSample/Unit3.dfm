object Form2: TForm2
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = 'Transfer'
  ClientHeight = 201
  ClientWidth = 297
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 16
    Top = 8
    Width = 249
    Height = 169
    TabOrder = 0
    object Label1: TLabel
      Left = 16
      Top = 16
      Width = 54
      Height = 13
      Caption = 'Transfer to'
    end
    object Label2: TLabel
      Left = 16
      Top = 62
      Width = 221
      Height = 13
      Caption = 'Must likes: sip:number@sip.portsip.com:5060)'
    end
    object Label3: TLabel
      Left = 16
      Top = 104
      Width = 199
      Height = 13
      Caption = 'For attended transfer,please enter which'
    end
    object Label4: TLabel
      Left = 16
      Top = 118
      Width = 149
      Height = 13
      Caption = ' line would you want to replace'
    end
    object Label5: TLabel
      Left = 19
      Top = 137
      Width = 39
      Height = 13
      Caption = 'Line No.'
    end
    object Edit1: TEdit
      Left = 16
      Top = 35
      Width = 217
      Height = 21
      TabOrder = 0
    end
    object Button1: TButton
      Left = 88
      Top = 80
      Width = 75
      Height = 22
      Caption = 'Ok'
      TabOrder = 1
      OnClick = Button1Click
    end
    object EditLineNum: TEdit
      Left = 64
      Top = 135
      Width = 57
      Height = 21
      TabOrder = 2
    end
  end
end
