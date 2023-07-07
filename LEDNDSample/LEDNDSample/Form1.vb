Imports System.IO
Imports System.Net.Http

Public Class LEDNDSample

    Private Sub BtnDisp_Click(sender As Object, e As EventArgs) Handles BtnDisp.Click
        SendData("1,234,567")
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        SendData("")
    End Sub

    '通信の実行
    '実用のプログラムに組み込む場合、エラー処理等を組み込んでください
    Private Sub SendData(ByVal msg As String)

        Dim ret As Integer = 0
        Dim sendData As String = ""

        If RadioUSB.Checked Then

            'USBCOMの場合

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

            '無線LANの場合

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
