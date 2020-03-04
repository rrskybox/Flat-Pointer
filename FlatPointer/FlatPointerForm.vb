Imports System.IO

'Windows Visual Basic Forms Application: Flat Pointer
'
' Tool to aid the creation and usage of a TSX Sky Database reference point for
'    pointing the telescope at an artificial light source for flats.
'
' See file "FlatPointerDescription.docx" for details.
'
'
' ------------------------------------------------------------------------
'
' Author: R.McAlister (2016)
'
' Version 1.0  - First light
'
' Version 1.1 - 
'
' ------------------------------------------------------------------------
'
'
Imports System.Reflection

Public Class FlatPointerForm

      Private Sub BuildButton_Click(sender As Object, e As EventArgs) Handles BuildButton.Click
        'Reads in the embedded text file "MyFlatFieldSDB.txt", changes the Alt and Az fields
        '  then rewrites it back out to the SoftwareBisque SDBs folder

        'Installs the dbq file
        Dim FFDestinationPath As String = "C:\Users\" + System.Environment.UserName + "\Documents\Software Bisque\TheSkyX Professional Edition\SDBs\My Flat Field SDB.txt"
        Dim fdstream As Stream
        Dim dassembly As [Assembly]

        'Collect the file contents to be written
        dassembly = [Assembly].GetExecutingAssembly()
        fdstream = dassembly.GetManifestResourceStream("FlatPointer.MyFlatFieldSDB.txt")
        Dim fdstreamreader = New StreamReader(fdstream)
        Dim dstring = fdstreamreader.ReadToEnd()

        My.Computer.FileSystem.WriteAllText(FFDestinationPath, (dstring + vbCrLf), False)
        '
        'Fill in fields and output to file
        Dim fe As New SDB_Node
        fe.Label = "My Flat Field"
        fe.raHours = AzimuthBox.Value.ToString("G")
        fe.decDegrees = AltitudeBox.Value.ToString("G")
        fe.objType = "Reference Point"
        fe.MaxFOV = "100"
        fe.MinFOV = "0"

        Dim fstring = fe.Entry()
        My.Computer.FileSystem.WriteAllText(FFDestinationPath, fstring, True)

        Return
    End Sub

    Private Sub Download_Click(sender As Object, e As EventArgs) Handles DownloadButton.Click
        'Gets the current az/alt coordinates from TSX and stroes them in the form variables

        Dim tsxt = CreateObject("TheSkyX.sky6RASCOMtele")
        tsxt.GetAzAlt()
        AzimuthBox.Value = tsxt.dAz
        AltitudeBox.Value = tsxt.dAlt
        Return
    End Sub

    Private Sub AddScriptButton_Click(sender As Object, e As EventArgs) Handles AddScriptButton.Click
        'Installs the CCDAP script file
        'Set up destination file path\filename
        Dim FFFDestinationPath As String = "C:\Users\" + System.Environment.UserName + "\Documents\CCDWare\CCDAutopilot5\Scripts\Flat Field Finder.exe"

        'Collect the file contents to be written
        Dim dassembly = [Assembly].GetExecutingAssembly()
        Dim fdstream = dassembly.GetManifestResourceStream("FlatPointer.FlatManCometh.exe")
        'Copy the file
        Dim wfile = New FileStream(FFFDestinationPath, FileMode.Create, FileAccess.Write)
        fdstream.CopyTo(wfile)
        wfile.Close()
        fdstream.Close()
        Return
    End Sub

    Private Sub ButtonUp_Click(sender As Object, e As EventArgs) Handles ButtonUp.Click
        'Done
        Close()
        Return
    End Sub

    Private Sub FlatPointerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Return
    End Sub
End Class
