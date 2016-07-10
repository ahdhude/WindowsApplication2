Imports System.Data.SqlClient

Public Class Form1
    Dim index As Integer = 1
    Dim pindex As Integer = 1
    Dim radioans As String
    Dim uname As String = "shirhaan" ''THIS SHOULD BE CHANGED 
    Dim radarray(1) As Integer
    Dim id As Integer = 1   'THIS TOOOO
    Dim marks As Integer
    Dim score As Integer
    Dim mysqlconn As SqlConnection
    Dim command As SqlCommand
   

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()

        Call random()
        Call Ansload()


    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        Dim db As New Database1DataSetTableAdapters.Question1TableAdapter()
        Dim pic As String



        pic = db.GetData(index).Rows(0).Item(2).ToString()
        If pic.Length > 1 Then
            PictureBox1.Load(pic)

        Else


        End If
        Call Ansload()

        pindex = index

        index = index + 1
        Call crrt()


    End Sub





    Function Ansload()
        Call radio_unselect()
        Dim db As New Database1DataSetTableAdapters.answer1TableAdapter()
        Dim pic1 As String
        Dim pic2 As String
        Dim pic3 As String
        Dim pic4 As String

        RadioButton1.Text = db.GetData(index).Rows(0).Item(0)
        RadioButton2.Text = db.GetData(index).Rows(1).Item(0)
        RadioButton3.Text = db.GetData(index).Rows(2).Item(0)
        RadioButton4.Text = db.GetData(index).Rows(3).Item(0)

        pic1 = db.GetData(index).Rows(0).Item(2).ToString()
        pic2 = db.GetData(index).Rows(1).Item(2).ToString()
        pic3 = db.GetData(index).Rows(2).Item(2).ToString()
        pic4 = db.GetData(index).Rows(3).Item(2).ToString()


        If pic1.Length > 1 Then
            PictureBox2.Load(pic1)
            PictureBox3.Load(pic2)
            PictureBox4.Load(pic3)
            PictureBox5.Load(pic4)
        Else


        End If



    End Function



    Function crrt()
        Dim mark As New Database1DataSetTableAdapters.Question1TableAdapter
        Dim db As New Database1DataSetTableAdapters.answer1TableAdapter
        Dim correct As String
        correct = db.GetData(pindex).Rows(0).Item(0).ToString

        If radioans = correct Then
            Call loadscore()
            Label4.Text = "correct"
            marks = mark.GetData(pindex).Rows(0).Item(3)
            score = marks + score
            Call examscore()



        Else
            Label4.Text = "wrong"

        End If






    End Function



    ' GENERATE RANDOM NUMBER


    '    Dim allNumbers As New List(Of Integer)
    '    Dim randomNumbers As New List(Of Integer)
    '    Dim rand As New Random

    '    ' Fill the list of all numbers
    'For i As Integer = 0 To 51 Step 1
    '    allNumbers.Add(i)
    'Next i

    '    ' Grab a random entry from the list of all numbers
    'For i As Integer = 0 To 51 Step 1
    '    Dim selectedIndex As Integer = rand.Next(0, (allNumbers.Count - 1))
    '    Dim selectedNumber As Integer = allNumbers(selectedIndex)
    '    randomNumbers.Add(selectedNumber)
    '    allNumbers.Remove(selectedNumber)
    '    ' Might as well just add the number to ListBox1 here, too
    '    ListBox1.Items.Add(selectedNumber)
    'Next i


    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        radioans = RadioButton4.Text


    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        radioans = RadioButton3.Text

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        radioans = RadioButton2.Text

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        radioans = RadioButton1.Text

    End Sub





    Function radio_unselect()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
    End Function



    Function examscore()
        Dim db As New Database1DataSetTableAdapters.examTableAdapter
        Dim data = db.UpdateQueryScore(score, uname, id)

       


    End Function




    Function loadscore()
        Dim db As New Database1DataSetTableAdapters.exam1TableAdapter
        score = CInt(db.GetData(uname).Rows(0).Item(2))
        uname = db.GetData(uname).Rows(0).Item(0)
        id = CInt(db.GetData(uname).Rows(0).Item(1))



    End Function



    Function random()


        Dim AU As ArrayUtilities
        AU = New ArrayUtilities

        Dim GivenArray As Integer() = {1, 2}
        Dim NewArray As Array = AU.ShuffleArray(GivenArray)

        '1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56

       
        NewArray.CopyTo(radarray, 0)


    End Function


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Label3.Text = CInt(Label3.Text) - 1

        If Label3.Text = 0 Then Timer1.Enabled = False

    End Sub
End Class
