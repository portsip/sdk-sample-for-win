program P2PSample;

uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {Form1},
  Unit2 in 'Unit2.pas',
  PortSIPConsts in '..\PortSIPLib\PortSIPConsts.pas',
  PortSIPLib in '..\PortSIPLib\PortSIPLib.pas',
  Unit3 in 'Unit3.pas' {Form2};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.Run;
end.
