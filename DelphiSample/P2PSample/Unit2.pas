unit Unit2;


interface


type
  TSession = class
  private
    SessionState : Boolean;
    RecvCallState : Boolean;
    HoldState : Boolean;
    SessionID : NativeInt;
    ReferCall : Boolean;
    OriginSessionId : NativeInt;
    ExistsEarlyMedia : Boolean;

  public
    function GetSessionID: NativeInt;
    function GetSessionState: Boolean;
    function GetExistsEarlyMedia: Boolean;
    function GetRecvCallState: Boolean;
    function GetHoldState: Boolean;
    function GetIsReferCall: Boolean;
    function GetOriginCallSessionId: NativeInt;
    procedure SetSessionID(Value: NativeInt);
    procedure SetSessionState(Value: Boolean);
    procedure SetHoldState(Value: Boolean);
    procedure SetRecvCallState(Value: Boolean);
    procedure SetReferCall(referCallState : Boolean; OriginCallSessionId : NativeInt);
    procedure SetExistsEarlyMedia(Value: Boolean);

    procedure Reset();

  end;


implementation


{ TClassData }


function TSession.GetExistsEarlyMedia: Boolean;
begin
  result :=  ExistsEarlyMedia;
end;

function TSession.GetIsReferCall: Boolean;
begin
 Result := ReferCall;
end;

function TSession.GetOriginCallSessionId: NativeInt;
begin
 Result := OriginSessionId;
end;

procedure TSession.SetReferCall(referCallState : Boolean; OriginCallSessionId : NativeInt);
begin
  OriginSessionId :=  OriginCallSessionId;
  referCall := referCallState;
end;


function TSession.GetSessionID: NativeInt;
begin
  Result := SessionID;
end;

function TSession.GetSessionState: Boolean;
begin
  Result := SessionState;
end;

function TSession.GetRecvCallState: Boolean;
begin
  Result := RecvCallState;
end;

function TSession.GetHoldState: Boolean;
begin
  Result := HoldState;
end;

procedure TSession.SetSessionID(Value: NativeInt);
begin
    SessionID := Value;
end;

procedure TSession.SetHoldState(Value: Boolean);
begin
    HoldState := Value;
end;

procedure TSession.SetSessionState(Value: Boolean);
begin
    SessionState := Value;
end;


procedure TSession.SetRecvCallState(Value: Boolean);
begin
    RecvCallState := Value;
end;

procedure TSession.SetExistsEarlyMedia(Value: Boolean);
begin
  ExistsEarlyMedia :=  Value;
end;


procedure TSession.Reset();
begin
    SessionID := 0;
    HoldState := False;
    SessionState := False;
    RecvCallState := False;
    ReferCall := False;
    OriginSessionId := 0;
    ExistsEarlyMedia := False;
end;

end.


