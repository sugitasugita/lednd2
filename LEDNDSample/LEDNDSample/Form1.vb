Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Globalization

Public Class LEDNDSample

    Private digit As Integer = 7 ' 表示機のLED桁数、デフォルトは 7 。

    ' 「表示」ボタンをクリックする
    Private Sub BtnDisp_Click(sender As Object, e As EventArgs) Handles BtnDisp.Click

        ' この表示データは、7桁LED表示機に合わせてあるため、
        ' 4桁LED表示機では、変数 digit の初期値を 4 に変更してください。
        ' コマンド 1F 01 は、表示のオーバーライトモード指定を行っています。
        Dim a() As String = {Chr(&H1F), Chr(&H1), "1", "2", "3", "4", "5", "6", "7"} ' 表示機に送るデータ
        Dim disp As String = ""
        Dim dg As Integer

        ' USBCOM通信の場合
        If RadioUSB.Checked Then
            ' 数字を一桁ずつ送る（LED桁数に、コマンド2バイト分が追加される）
            For dg = 0 To digit + 1
                SendData(a(dg))  ' SendDataメソッドに進み、表示機に送信する
            Next

            ' 無線LAN通信の場合
        ElseIf RadioWiFi.Checked Then
            ' 数字をまとめて送る（LED桁数に、コマンド2バイト分が追加される）
            For dg = 0 To digit + 1
                disp += a(dg)
            Next
            SendData(disp)

            ' 有線LAN通信の場合
        ElseIf RadioLAN.Checked Then
            ' 数字をまとめて送る（LED桁数に、コマンド2バイト分が追加される）
            For dg = 0 To digit + 1
                disp += a(dg)
            Next
            SendData(disp)
        End If

    End Sub

    ' 「クリア」ボタンをクリックする
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        SendData("")
    End Sub

    '通信の実行
    '実用のプログラムに組み込む場合、エラー処理等を組み込んでください
    Private Sub SendData(ByVal msg As String)

        Dim ret As Integer = 0
        Dim sendData As String = ""
        Dim dispMethod As String = ""


        If RadioUSB.Checked Then

            ' USBCOMの場合

            'シリアルポート番号がCOM1の場合
            SerialPort1.PortName = "COM1"
            SerialPort1.BaudRate = 115200
            SerialPort1.Parity = IO.Ports.Parity.None
            SerialPort1.DataBits = 8
            SerialPort1.StopBits = IO.Ports.StopBits.One
            SerialPort1.Handshake = Ports.Handshake.RequestToSend

            If msg = "" Then
                '表示クリア
                sendData = Chr(&HC)
            Else
                '表示
                sendData = msg
            End If

            SerialPort1.Open()
            SerialPort1.Write(sendData)
            SerialPort1.Close()

        ElseIf RadioWiFi.Checked Then

            ' 無線LANの場合

            'LEDNDのIPアドレスが192.168.1.250の場合
            Dim url As String = "http://192.168.1.250/disp/"

            If msg = "" Then
                '表示クリア
                sendData = url + "%0C"
            Else
                '表示
                sendData = url + msg
            End If

            SendByHttp(sendData)

        ElseIf RadioLAN.Checked Then

            ' 有線LANの場合

            ' オプション外付けアダプタの有線LAN IPアドレスが 192.168.1.250 の場合
            Dim url As String = "http://192.168.1.250"

            If msg = "" Then
                ' 表示クリア
                sendData = url + "/disp/?d=%0C"
            Else
                ' 表示
                sendData = url + "/disp/?d=" + msg
            End If

            Dim resText As String

            Try
                ' 文字コードをUTF8に変換する
                Dim enc As Encoding = Encoding.UTF8
                ' WebClientによるHTTP通信を設定する
                Dim webC As New System.Net.WebClient
                webC.Encoding = enc

                ' NameValueCollectionによりデータを受信する
                Dim nameC As New System.Collections.Specialized.NameValueCollection
                Dim resData As Byte() = {}

                Try
                    ' HTTP通信でデータを送信し(sendData)、その後受信する(nameC)
                    resData = webC.UploadValues(sendData, nameC)
                Catch ex As ArgumentException       ' エラー処理
                    MsgBox(ex.Message)
                Catch ex As WebException            ' エラー処理
                    MsgBox(ex.Message)
                Finally
                    webC.Dispose()
                End Try

                Try
                    ' 受信したデータ
                    resText = System.Text.Encoding.UTF8.GetString(resData)
                Catch ex As ArgumentNullException   ' 受信時のエラー処理
                    Console.WriteLine("エラー")
                End Try

            Catch ex As Exception
                MsgBox("HTTP通信エラー", MsgBoxStyle.Critical)
            End Try

        End If

    End Sub

    ' HTTP通信処理
    Private Async Sub SendByHttp(ByVal url As String)

        Dim sendUrl As Uri = New Uri(url)
        Dim html As String = ""

        Using httpcl As New HttpClient()
            html = Await httpcl.GetStringAsync(sendUrl)
        End Using

    End Sub

End Class
