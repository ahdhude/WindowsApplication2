Imports System.Security.Cryptography
Public Class ArrayUtilities
    Private Random As RNGCryptoServiceProvider = New RNGCryptoServiceProvider
    Private Bytes(4) As Byte


    Public Function ShuffleArray(ByVal argArr As Array) As Array
        Dim FirstArray As New ArrayList(argArr)


        Dim SecoundArray As Array = Array.CreateInstance(GetType(Object), FirstArray.Count)

        Dim intIndex As Integer

        For i As Integer = 0 To FirstArray.Count - 1

            intIndex = RandomNumber(FirstArray.Count)
            SecoundArray(i) = FirstArray(intIndex)
            FirstArray.RemoveAt(intIndex)
        Next

        FirstArray = Nothing

        Return SecoundArray
    End Function


    Private Function RandomNumber(ByVal argMax As Integer) As Integer
        If argMax <= 0 Then Throw New Exception
        Random.GetBytes(Bytes)
        Dim intValue As Integer = (BitConverter.ToInt32(Bytes, 0)) Mod argMax
        If intValue < 0 Then intValue = -intValue
        Return intValue
    End Function

End Class
